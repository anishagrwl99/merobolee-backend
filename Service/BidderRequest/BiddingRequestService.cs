using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Model;
using MeroBolee.Repository.BidderRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.BidderReuest
{
    public class BiddingRequestService : BiddingRequestMapper, IBiddingRequestService
    {
        private readonly object _locker = new object();
        private IBidderRequestRepository bidderRequestRepository;
        private IMemoryCache memoryCache;
        private ICryptoService cryptoService;

        public BiddingRequestService(IBidderRequestRepository bidderRequestRepository, IMemoryCache cache, ICryptoService cryptoService)
        {
            this.bidderRequestRepository = bidderRequestRepository;
            memoryCache = cache;
            this.cryptoService = cryptoService;
        }
        public async Task<GetBiddingRequestDto> SendRequest(AddBiddingRequestDto bidderRequest)
        {
            return EnterBiddingRoomToEntity(await bidderRequestRepository.SendRequest(BidderRequestDtoRequest(bidderRequest), bidderRequest.BidderRequestDocs));
        }

        public async Task<LiveBidResponse> TenderPosition(int tenderId, int supplierId)
        {
            List<LiveBiddingEntity> bids = await bidderRequestRepository.TenderLiveBids(tenderId);
            return GetSupplierBiddingPosition(bids, supplierId, decimal.MinValue);
            //// return bids;
            //return null;
        }
        public LiveBidResponse LiveBid(TenderMaterialBiddingDto materialDto)
        {
            try
            {
                bool isQuotationValid = IsQuotationValid(materialDto);
                if (isQuotationValid)
                {
                    List<LiveBiddingEntity> entities = MaterialBiddingDtoToLiveBiddingEntity(materialDto, cryptoService);
                    //entity.Quotation = cryptoService.Encrypt(entity.Quotation);
                    entities = bidderRequestRepository.LiveBid(entities);

                    if (entities != null) //if tender is not expired 
                    {

                        AddQuotationToCache(entities, materialDto.TenderId,  materialDto.SupplierId);
                        decimal currentQuotation = materialDto.MaterialQuotation.Sum(x => x.Quotation);
                        LiveBidResponse response = GetPositionFromCache(materialDto.TenderId, materialDto.SupplierId, currentQuotation);
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
                            
                            Message = "Tender bidding has expired"
                        };
                    }

                }
                else
                {
                    decimal currentQuotation = materialDto.MaterialQuotation.Sum(x => x.Quotation);
                    LiveBidResponse response = GetPositionFromCache(materialDto.TenderId, materialDto.SupplierId, currentQuotation);
                    response.IsBidSuccess = false;
                    response.MaterialQuotation = materialDto.MaterialQuotation;
                    response.Message = "You have already quotated less than current quotation";
                    return response;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Task<ResetBidDto> CheckBiddingTime(long tenderId)
        {
            return Task.Run(() =>
            {
                string timeKey = $"{tenderId}_Lowest_Bid_Time";
                ResetBidDto dto = null;
                memoryCache.TryGetValue<ResetBidDto>(timeKey, out dto);
                if(dto != null)
                {
                    long totalElapsedSeconds = (long)( DateTime.Now - dto.MinQuotationRecivedAt).TotalSeconds;
                    long totalIntervalInSec = dto.Interval * 60;
                    long remainingSec = totalIntervalInSec - totalElapsedSeconds;

                    dto.RemainingMinute = (int)(remainingSec / 60);
                    dto.RemainingSecond = (int)(remainingSec % 60);

                    if (dto.RemainingMinute < 1 && dto.IsQuotationReceived == false)
                    {
                        dto.RemainingMinute = (int)dto.Interval;
                        dto.RemainingSecond = 0;
                        dto.MinQuotationRecivedAt = DateTime.Now;
                    }
                }
                else
                {
                    TenderEntity e = bidderRequestRepository.GetTenderDetail(tenderId);
                    if(e != null)
                    {
                        dto = new ResetBidDto
                        {
                            MinQuotationRecivedAt = DateTime.Now,
                            RemainingMinute = e.Tender_live_interval,
                            RemainingSecond = 0,
                            Interval = e.Tender_live_interval,
                            IsBiddingExpired = false,
                            IsQuotationReceived = false
                        };
                        memoryCache.Set<ResetBidDto>(timeKey, dto);
                    }
                }
                if(dto.RemainingMinute == 0 && dto.RemainingSecond == 0 && dto.IsQuotationReceived)
                {
                    dto.IsBiddingExpired = true;
                }


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
                        BidDate = item.BidDate
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
                List<LiveBiddingEntity> biddings = new List<LiveBiddingEntity>();
                memoryCache.TryGetValue<List<LiveBiddingEntity>>(key, out biddings);
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
                memoryCache.Set<List<LiveBiddingEntity>>(key, biddings, bids.FirstOrDefault().TenderEntity.Live_End_Date.AddMinutes(5));
            }
        }

        private bool IsQuotationValid(TenderMaterialBiddingDto dto)
        {
            decimal minimumQuotation = 0;
            bool isValid = false;
            foreach (var item in dto.MaterialQuotation)
            {
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
                isValid = false;
            }

            if(!isValid)
            {
                foreach (var item in dto.MaterialQuotation)
                {
                    string key = $"{dto.SupplierId}_{dto.BiddingId}_{dto.TenderId}_{item.MaterialId}";
                    if (item.IsPrevCacheAvailable)
                    {
                        memoryCache.Set<decimal>(key, item.PreviousQuotation);
                    }
                    if (!item.IsPrevCacheAvailable)
                    {
                        memoryCache.Remove(key);
                    }                    
                }
            }
            return isValid;
        }

        private LiveBidResponse GetSupplierBiddingPosition(List<LiveBiddingEntity> livebids, long supplierId, decimal currentQuotation)
        {
            try
            {
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
                    LiveBidResponse resp = new LiveBidResponse
                    {
                        IsBidSuccess = true,
                        Position = ind <= 5 ? $"L{ind}" : "L6",
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
                        LowestBidRecievedTime = DateTime.MinValue
                    };

                    if (currentQuotation > 0)
                    {
                        var c = a.OrderBy(x => x.Quotation).FirstOrDefault();
                        if (currentQuotation <= c.Quotation && c.SupplierId == supplierId)
                        {
                            resp.IsLowestBidReceived = true;
                            resp.LowestBidRecievedTime = DateTime.Now;
                           
                            ResetBidDto dto = new ResetBidDto
                            {
                                MinQuotationRecivedAt = DateTime.Now,
                                RemainingMinute = c.Interval,
                                RemainingSecond = 0,
                                Interval = c.Interval,
                                IsQuotationReceived = true,
                                IsBiddingExpired = false
                            };
                            string timeKey = $"{c.TenderId}_Lowest_Bid_Time";
                            memoryCache.Set<ResetBidDto>(timeKey, dto);
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


    }
}
