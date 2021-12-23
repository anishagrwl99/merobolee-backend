using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Model;
using MeroBolee.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public class BiddingRequestService : BiddingRequestMapper, IBiddingRequestService
    {
        private readonly object _locker = new object();
        private IBidderRequestRepository bidderRequestRepository;
        private IMemoryCache memoryCache;
        private ICryptoService cryptoService;
        private readonly ITenderService tenderService;

        public BiddingRequestService(IBidderRequestRepository bidderRequestRepository,
                                        IMemoryCache cache,
                                        ICryptoService cryptoService,
                                        ITenderService tenderService)
        {
            this.bidderRequestRepository = bidderRequestRepository;
            memoryCache = cache;
            this.cryptoService = cryptoService;
            this.tenderService = tenderService;
        }
        public async Task<GetBiddingRequestDto> SendRequest(AddBiddingRequestDto bidderRequest)
        {
            try
            {
                return EnterBiddingRoomToEntity(await bidderRequestRepository.SendRequest(BidderRequestDtoRequest(bidderRequest), bidderRequest.BidderRequestDocs));
            }
            catch
            {
                throw;
            }
        }

        public async Task<LiveBidResponse> TenderPosition(int tenderId, int supplierId)
        {
            List<LiveBiddingEntity> bids = await bidderRequestRepository.TenderLiveBids(tenderId);
            return GetSupplierBiddingPosition(bids, supplierId, decimal.MinValue);
            //// return bids;
            //return null;
        }
        public async Task<LiveBidResponse> LiveBid(TenderMaterialBiddingDto materialDto)
        {
            try
            {
                string errorMessage = "";
                bool isQuotationValid = await IsQuotationValid(materialDto, out errorMessage);
                if (isQuotationValid)
                {
                    string batch = $"Tender_Batch_{materialDto.SupplierId}_{materialDto.TenderId}";
                    long batchNo = 0;
                    memoryCache.TryGetValue<long>(batch, out batchNo);

                    List<LiveBiddingEntity> entities = MaterialBiddingDtoToLiveBiddingEntity(materialDto, cryptoService, batchNo);
                    //entity.Quotation = cryptoService.Encrypt(entity.Quotation);
                    entities = bidderRequestRepository.LiveBid(entities);

                    if (entities != null) //if tender is not expired 
                    {

                        AddQuotationToCache(entities, materialDto.TenderId, materialDto.SupplierId);
                        decimal currentQuotation = Math.Round(materialDto.MaterialQuotation.Sum(x => x.Quotation), 2);
                        LiveBidResponse response = GetPositionFromCache(materialDto.TenderId, materialDto.SupplierId, currentQuotation);
                        response.MaterialQuotation = materialDto.MaterialQuotation;

                        AuctionLog log = new AuctionLog
                        {
                            Amount = currentQuotation,
                            LogDate = DateTime.Now,
                            Position = response.Position,
                            TenderId = materialDto.TenderId,
                            UserId = materialDto.SupplierId,
                            CompanyId = materialDto.CompanyId,
                            BiddingId = materialDto.BiddingId
                        };

                        bidderRequestRepository.WriteAutionLogEntry(log);
                        response.Log = log;
                        response.CurrentQuotation = currentQuotation;
                        return response;
                    }
                    else
                    {
                        return new LiveBidResponse
                        {
                            IsBidSuccess = false,
                            IsLowestBidReceived = false,
                            LowestBidRecievedTime = materialDto.BiddingDate,
                            MaterialQuotation = materialDto.MaterialQuotation,
                            Position = "NA",
                            CurrentQuotation = 0,
                            Message = "Tender bidding has expired"
                        };
                    }

                }
                else
                {
                    decimal currentQuotation = materialDto.MaterialQuotation.Sum(x => x.Quotation);
                    LiveBidResponse response = GetPositionFromCache(materialDto.TenderId, materialDto.SupplierId, currentQuotation);
                    response.IsBidSuccess = false;
                    response.CurrentQuotation = currentQuotation;
                    response.MaterialQuotation = materialDto.MaterialQuotation;
                    response.Message = errorMessage;
                    return response;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public LiveBidResponse AutoBid(TenderAutoBidDto bidDto)
        {
            string key = $"Tender_Bidding_{bidDto.TenderId}";
            List<LiveBiddingEntity> biddings = new List<LiveBiddingEntity>();
            memoryCache.TryGetValue<List<LiveBiddingEntity>>(key, out biddings);

            List<LiveBiddingEntity> autoBidEntities = new List<LiveBiddingEntity>();
            if (biddings != null && biddings.Count > 0)
            {

                foreach (TenderMaterialQuotationDto q in bidDto.MaterialQuotation)
                {
                    LiveBiddingEntity ent = biddings
                        .Where(x => x.MaterialId == q.MaterialId && x.UserId == bidDto.SupplierId)
                        .FirstOrDefault();
                    if (ent != null)
                    {
                        autoBidEntities.Add(new LiveBiddingEntity
                        {
                            BidDate = bidDto.BiddingDate,
                            BiddingRequestId = bidDto.BiddingId,
                            TenderId = bidDto.TenderId,
                            MaterialId = q.MaterialId,
                            Quotation = DescreaseQuotationByPercent(bidDto.Percentage, ent.Quotation)
                        });
                    }
                }

                var entities = bidderRequestRepository.AutoBid(autoBidEntities);
                AddQuotationToCache(entities, bidDto.TenderId, bidDto.SupplierId);
                decimal currentQuotation = entities.Sum(x => cryptoService.Decrypt<decimal>(x.Quotation));
                LiveBidResponse response = GetPositionFromCache(bidDto.TenderId, bidDto.SupplierId, currentQuotation);
                response.MaterialQuotation = entities.Select(x => new TenderMaterialQuotationDto
                {
                    MaterialId = x.MaterialId,
                    Quotation = cryptoService.Decrypt<decimal>(x.Quotation)
                }).ToList();
                response.IsBidSuccess = true;
                return response;

            }
            else
            {
                return new LiveBidResponse
                {
                    IsBidSuccess = false,
                    IsLowestBidReceived = false,
                    LowestBidRecievedTime = bidDto.BiddingDate,
                    MaterialQuotation = null,
                    Position = "NA",
                    Message = "Tender bidding has expired"
                };
            }
        }

        public Task<ResetBidDto> CheckBiddingTime(long tenderId)
        {
            return Task.Run(() =>
            {
                string timeKey = $"{tenderId}_Lowest_Bid_Time";
                ResetBidDto dto = null;
                memoryCache.TryGetValue<ResetBidDto>(timeKey, out dto);

                if (dto != null && dto.IsTenderExpired)
                {
                    return dto;
                }


                if (dto != null)
                {
                    long totalElapsedSeconds = (long)(DateTime.Now - dto.MinQuotationRecivedAt).TotalSeconds;
                    long totalIntervalInSec = dto.Interval * 60;
                    long remainingSec = totalIntervalInSec - totalElapsedSeconds;

                    dto.RemainingMinute = (int)(remainingSec / 60);
                    dto.RemainingSecond = (int)(remainingSec % 60);

                    if (dto.RemainingMinute < 1 && dto.IsQuotationReceived == false && dto.RemainingSecond < 1)
                    {
                        dto.RemainingMinute = (int)dto.Interval;
                        dto.MinQuotationRecivedAt = DateTime.Now;
                        dto.FullIntervalCountWithoutReceivingBid++;

                        if (dto.RemainingSecond < 0) //if request is not receive and second moves to negative
                        {
                            int sec = Math.Abs(dto.RemainingSecond);
                            dto.RemainingMinute = (int)((dto.Interval * 60 - (int)(sec / 60)) / 60) - 1;
                            dto.RemainingSecond = 60 - (int)(sec % 60);
                        }
                        else
                        {
                            dto.RemainingSecond = 0;
                        }

                    }
                }
                else
                {
                    TenderEntity e = bidderRequestRepository.GetTenderDetail(tenderId);
                    if (e != null)
                    {
                        dto = new ResetBidDto
                        {
                            MinQuotationRecivedAt = DateTime.Now,
                            RemainingMinute = e.Tender_live_interval,
                            RemainingSecond = 0,
                            Interval = e.Tender_live_interval,
                            IsTenderExpired = false,
                            IsQuotationReceived = false,
                            FullIntervalCountWithoutReceivingBid = 0,
                            TenderLiveEndDate = e.Live_End_Date
                        };

                    }
                }

                //check if bidding expired
                if (dto != null
                        && (dto.FullIntervalCountWithoutReceivingBid >= 2
                            || dto.TenderLiveEndDate < DateTime.Now
                           )
                        )
                {
                    dto.IsTenderExpired = true;
                    dto.RemainingMinute = 0;
                    dto.RemainingSecond = 0;
                }
                memoryCache.Set<ResetBidDto>(timeKey, dto, dto.TenderLiveEndDate.AddMinutes(5));
                return dto;
            });
        }

        public GetBiddingRequestDto ShowRequest(int requestId)
        {
            return BidderRequestToEntity(bidderRequestRepository.ShowRequest(requestId));
        }

        public IEnumerable<GetBiddingRequestDto> ShowAllRequest()
        {
            return BidderRequestToDto(bidderRequestRepository.ShowAllRequest());
        }

        public IEnumerable<GetBiddingRequestDto> AllRequestByBidder(int bidderId)
        {
            return BidderRequestToDto(bidderRequestRepository.AllRequestByBidder(bidderId));
        }

        public GetBiddingRequestDto UpdateRequest(int id, UpdateRequestDto updateRequest)
        {
            return BidderRequestToEntity(bidderRequestRepository.UpdateRequest(id, updateRequest));
        }

        public Task MoveBidToHistory()
        {
            return Task.Run(async () =>
            {
                List<LiveBiddingEntity> list = await bidderRequestRepository.GetExpiredBids();
                List<BiddingHistoryEntity> historyEntities = new List<BiddingHistoryEntity>();
                foreach (LiveBiddingEntity item in list)
                {
                    //Create history object with decrypted quotation
                    BiddingHistoryEntity entity = new BiddingHistoryEntity
                    {
                        BiddingRequestId = item.BiddingRequestId,
                        UserId = item.UserId,
                        TenderId = item.TenderId,
                        MaterialId = item.MaterialId,
                        Quotation = cryptoService.Decrypt<decimal>(item.Quotation),
                        BidDate = item.BidDate,
                        BatchNo = item.BatchNo
                    };
                    historyEntities.Add(entity);

                }
                //Save History
                bool isHistoryCreated = await bidderRequestRepository.AddHistory(historyEntities);

                //delete item from live bid
                if (isHistoryCreated)
                {
                    await bidderRequestRepository.DeleteLiveBids(list);
                }
            });
        }


        public async Task<List<AuctionLog>> GetTenderAuctionLog(long companyId, long tenderId)
        {
            try
            {
                List<AuctionLog> logs = await bidderRequestRepository.GetTenderAuctionLog(companyId, tenderId);
                return logs;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<AuctionLog>> GetTenderAuctionLogForBidInviter(long tenderId)
        {
            try
            {
                List<AuctionLog> logs = await bidderRequestRepository.GetTenderAuctionLogForBidInviter(tenderId);
                return logs;
            }
            catch (Exception)
            {

                throw;
            }
        }


        private LiveBidResponse GetPositionFromCache(long tenderId, long supplierId, decimal quotation)
        {
            string key = $"Tender_Bidding_{tenderId}";
            List<LiveBiddingEntity> biddings;
            memoryCache.TryGetValue<List<LiveBiddingEntity>>(key, out biddings);
            LiveBidResponse response = GetSupplierBiddingPosition(biddings, supplierId, quotation);
            return response;
        }

        private void AddQuotationToCache(List<LiveBiddingEntity> bids, long tenderId, long supplierId)
        {
            lock (_locker)
            {
                string key = $"Tender_Bidding_{tenderId}";
                string batch = $"Tender_Batch_{supplierId}_{tenderId}";
                DateTime expiryDate = bids.FirstOrDefault().TenderEntity.Live_End_Date.AddMinutes(5);
                long batchNo = 0;
                List<LiveBiddingEntity> biddings = new List<LiveBiddingEntity>();
                memoryCache.TryGetValue<List<LiveBiddingEntity>>(key, out biddings);
                memoryCache.TryGetValue<long>(batch, out batchNo);
                batchNo++;
                memoryCache.Set<long>(batch, batchNo, expiryDate);

                if (biddings == null || biddings.Count < 1) //No cache yet
                {
                    biddings = new List<LiveBiddingEntity>();
                    biddings.AddRange(bids);
                }
                else //Cache found
                {
                    //Get minimum quotation from supplier
                    foreach (LiveBiddingEntity bid in bids)
                    {
                        LiveBiddingEntity ent = biddings
                            .Where(x => x.UserId == supplierId && x.MaterialId == bid.MaterialId)
                            .FirstOrDefault();

                        if (ent == null)
                        {
                            biddings.Add(bid);
                        }
                        else
                        {
                            ent.Quotation = bid.Quotation;
                        }
                    }
                }
                memoryCache.Set<List<LiveBiddingEntity>>(key, biddings, expiryDate);
            }
        }

        private Task<bool> IsQuotationValid(TenderMaterialBiddingDto dto, out string errorMsg)
        {
            decimal minimumQuotation = 0;
            bool isValid = false;
            errorMsg = "You have already quotated less than or same as current quotation";
            Tuple<decimal, DateTime, DateTime> tenderInfo = tenderService.GetMaxQuotationAllowed(dto.TenderId);
            decimal currentQuotation = dto.MaterialQuotation.Sum(x => x.Quotation);
            if (tenderInfo.Item1 != 0 && currentQuotation < tenderInfo.Item1)
            {
                foreach (var item in dto.MaterialQuotation)
                {
                    item.Quotation = Math.Round(item.Quotation, 2);
                    string key = $"{dto.SupplierId}_{dto.BiddingId}_{dto.TenderId}_{item.MaterialId}";
                    memoryCache.TryGetValue<decimal>(key, out minimumQuotation);
                    if (minimumQuotation <= 0) //no bid found for this material
                    {
                        memoryCache.Set<decimal>(key, item.Quotation);
                        isValid = true;
                        item.IsPrevCacheAvailable = false;
                    }
                    else if (item.Quotation < minimumQuotation)
                    {
                        memoryCache.Set<decimal>(key, item.Quotation);
                        isValid = true;
                        item.IsPrevCacheAvailable = true;
                        item.PreviousQuotation = minimumQuotation;
                    }
                    else if (minimumQuotation > 0)
                    {
                        item.IsPrevCacheAvailable = true;
                        item.PreviousQuotation = minimumQuotation;
                    }
                }

                if (!isValid)
                {
                    foreach (var item in dto.MaterialQuotation)
                    {
                        string key = $"{dto.SupplierId}_{dto.BiddingId}_{dto.TenderId}_{item.MaterialId}";
                        if (item.IsPrevCacheAvailable)
                        {
                            memoryCache.Set<decimal>(key, item.PreviousQuotation);
                        }
                        else
                        {
                            memoryCache.Remove(key);
                        }
                    }
                }
            }
            else if (tenderInfo.Item1 == 0)
            {
                #pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                Task.Run(() =>
                {
                    UpdateTenderMaxQuotation(dto.TenderId, tenderInfo.Item2, tenderInfo.Item3);
                });
                #pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            }
            else
            {
                isValid = false;
                errorMsg = "You have quotated more than allwed quotation";
            }
            return Task.FromResult<bool>(isValid);
        }

        private LiveBidResponse GetSupplierBiddingPosition(List<LiveBiddingEntity> livebids, long supplierId, decimal currentQuotation)
        {
            try
            {
                DateTime tenderEndDate = livebids.FirstOrDefault().TenderEntity.Live_End_Date;
                var a = livebids
                    .GroupBy(x => new { x.TenderId, x.UserId })
                    .Select(x => new
                    {
                        SupplierId = x.Key.UserId,
                        TenderId = x.Key.TenderId,
                        Quotation = x.Sum(o => cryptoService.Decrypt<decimal>(o.Quotation)),
                        Interval = x.Min(o => o.TenderEntity.Tender_live_interval)
                    })
                    .OrderBy(x => x.Quotation)
                    .ToList();
                int ind = a.FindIndex(x => x.SupplierId == supplierId) + 1;
                var b = a.Where(x => x.SupplierId == supplierId).FirstOrDefault();
                if (b != null)
                {
                    string timeKey = $"{a.FirstOrDefault().TenderId}_Lowest_Bid_Time";
                    ResetBidDto dto = null;
                    memoryCache.TryGetValue<ResetBidDto>(timeKey, out dto);
                    LiveBidResponse resp = new LiveBidResponse
                    {
                        IsBidSuccess = true,
                        Position = $"L{ind}", // ind <= 5 ? $"L{ind}" : "L6",
                        MaterialQuotation = new List<TenderMaterialQuotationDto>
                        {
                            new TenderMaterialQuotationDto
                            {
                                MaterialId = 0,
                                Quotation = b.Quotation
                            }
                        },
                        //Quotation = b.Quotation,
                        Message = "Bidding position is calculated",
                        IsLowestBidReceived = false,
                        LowestBidRecievedTime = dto == null ? DateTime.Now : dto.MinQuotationRecivedAt
                    };

                    if (currentQuotation > 0)
                    {
                        var c = a.OrderBy(x => x.Quotation).FirstOrDefault();
                        if (currentQuotation <= c.Quotation && c.SupplierId == supplierId)
                        {
                            resp.IsLowestBidReceived = true;
                            resp.LowestBidRecievedTime = DateTime.Now;

                            dto = new ResetBidDto
                            {
                                MinQuotationRecivedAt = DateTime.Now,
                                RemainingMinute = c.Interval,
                                RemainingSecond = 0,
                                Interval = c.Interval,
                                IsQuotationReceived = true,
                                IsTenderExpired = false,
                                FullIntervalCountWithoutReceivingBid = -1,
                                TenderLiveEndDate = tenderEndDate
                            };
                            timeKey = $"{c.TenderId}_Lowest_Bid_Time";
                            memoryCache.Set<ResetBidDto>(timeKey, dto, tenderEndDate.AddMinutes(5));
                            //Lowest Quotation Received - set Flag to reset timer
                        }
                    }

                    return resp;
                }
                else
                {
                    return new LiveBidResponse
                    {
                        IsBidSuccess = false,
                        Position = "NA",
                        MaterialQuotation = new List<TenderMaterialQuotationDto>
                        {
                            new TenderMaterialQuotationDto
                            {
                                MaterialId = 0,
                                Quotation = 0
                            }
                        },
                        Message = "Bidding not found to calculate position",
                        IsLowestBidReceived = false,
                        LowestBidRecievedTime = DateTime.MinValue
                    };
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        private string DescreaseQuotationByPercent(decimal percentage, string prevQuotation)
        {
            decimal quotation = cryptoService.Decrypt<decimal>(prevQuotation);
            quotation = quotation - (percentage * quotation) / 100; //decrease quotation by x%
            return cryptoService.Encrypt(quotation.ToString());
        }


        private async Task<decimal> GetMaxQuotation(long tenderId)
        {
            List<LiveBiddingEntity> liveBids = await bidderRequestRepository.TenderLiveBids(tenderId);
            foreach (var item in liveBids)
            {
                item.Quotation = cryptoService.Decrypt<string>(item.Quotation);
            }

            decimal maxQtn = liveBids.GroupBy(x => new { x.BatchNo, x.Quotation }).Max(x => x.Sum(y => Convert.ToDecimal(x.Key.Quotation)));
            return maxQtn;
        }

        private void UpdateTenderMaxQuotation(long tenderId, DateTime startTime, DateTime endTime)
        {
            TimeSpan timeSpan = endTime.Subtract(startTime);
            DateTime midDate = startTime.AddSeconds(timeSpan.TotalSeconds / 2);
            if (midDate <= DateTime.Now)
            {
                decimal maxQtn = GetMaxQuotation(tenderId).Result;
                memoryCache.Set($"TenderInfo_{tenderId}", Tuple.Create(maxQtn, startTime, endTime));
                //update tender max quotation
                tenderService.UpdateTenderMaxQuotation(maxQtn, tenderId);

            }
        }
    }
}
