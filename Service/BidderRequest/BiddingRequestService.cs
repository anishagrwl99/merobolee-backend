using Hangfire;
using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Infrastructure;
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
        private IBidderRequestRepository bidRequestRepository;
        private IMemoryCache memoryCache;
        private ICryptoService cryptoService;
        private readonly ITenderService tenderService;
        private readonly IUploadFile fileService;
        private readonly ICompanyDocumentRepository companyDocumentRepository;

        public BiddingRequestService(IBidderRequestRepository bidRequestRepository,
                                        IMemoryCache cache,
                                        ICryptoService cryptoService,
                                        ITenderService tenderService,
                                        IUploadFile fileService,
                                        ICompanyDocumentRepository companyDocumentRepository)
        {
            this.bidRequestRepository = bidRequestRepository;
            memoryCache = cache;
            this.cryptoService = cryptoService;
            this.tenderService = tenderService;
            this.fileService = fileService;
            this.companyDocumentRepository = companyDocumentRepository;
        }

        /// <summary>
        /// Register for tender bidding
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<long> RegisterInTenderBidding(RegisterForTenderDto dto)
        {
            try
            {
                BidRequestEntity entity = await bidRequestRepository.GetBidRequestEntityOnly(dto.TenderId, dto.CompanyId);
                if (entity == null)
                {
                    //tring companyFolder = companyDocumentRepository.GetCompanyFolder(dto.CompanyId);
                    BidRequestEntity bidRequest = ToEntity(dto /*, companyFolder, fileService*/);
                    bidRequest = await bidRequestRepository.RegisterForBidding(bidRequest);
                    return bidRequest.Id;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Submits the document for registered tender.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        public async Task<long> SubmitDocumentForRegisteredTender(SubmitDocumentForRegisteredTender dto)
        {
            try
            {
                BidRequestEntity entity = await bidRequestRepository.GetBidRequestEntityOnly(dto.TenderId, dto.CompanyId);
                if (entity != null)
                {
                    string companyFolder = companyDocumentRepository.GetCompanyFolder(dto.CompanyId);
                    List<BidderRequestDocEntity> documents = ToEntity(dto, entity.Id, companyFolder, fileService);
                    return await bidRequestRepository.SubmitDocumentRegisterForBidding(documents) ? entity.Id : -1;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Update tender registration
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<long> UpdateRegistration(UpdateRegistrationForTenderDto dto)
        {
            try
            {
                BidRequestEntity entity = await bidRequestRepository.GetBidRequestEntityOnly(dto.BidId);
                if (entity != null)
                {
                    string companyFolder = companyDocumentRepository.GetCompanyFolder(dto.CompanyId);
                    string folder = $"{companyFolder}\\Tender Regiatraion\\{dto.TenderId}";
                    foreach (var item in dto.Documents)
                    {
                        var itm = entity.BidderRequestDocs.Where(x => x.Id == item.Id).FirstOrDefault();
                        if (itm != null)
                        {
                            await fileService.DeleteFile(itm.DocPath);
                            itm.DocTitle = item.DocTitle;
                            itm.DocPath = await fileService.Upload(item.Document, folder);
                        }
                        else
                        {
                            entity.BidderRequestDocs.Add(new BidderRequestDocEntity
                            {
                                DocPath = await fileService.Upload(item.Document, folder),
                                DocTitle = item.DocTitle
                            });
                        }
                    }

                    entity = await bidRequestRepository.UpdateBidRequest(entity);
                    return entity.Id;
                }
                else
                {
                    return -1;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Check necessary conditions before entering a live bidding room
        /// </summary>
        /// <param name="bidRequest"></param>
        /// <returns></returns>
        public async Task<EnterLiveBiddingRoomResponseDto> EnterLiveBiddingRoom(AddBiddingRequestDto bidRequest)
        {
            try
            {
                BidRequestEntity entity = await bidRequestRepository.EnterLiveBiddingRoom(bidRequest.TenderId, bidRequest.CompanyId);

                if (entity != null)
                {
                    return new EnterLiveBiddingRoomResponseDto
                    {
                        BidId = entity.BidRequestStatusId == 2 ? entity.Id : -1,
                        CompanyId = entity.CompanyId,
                        TenderId = entity.TenderId,
                        BidRequestStatus = entity.BidRequestStatus.Status
                    };
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<LiveBidResponse> TenderPosition(long tenderId, long supplierId)
        {
            List<LiveBiddingEntity> bids = await bidRequestRepository.TenderLiveBids(tenderId);
            if (bids != null && bids.Count > 0)
            {
                return GetSupplierBiddingPosition(bids, supplierId, decimal.MinValue);
            }
            else
            {
                return null;
            }
        }
        public async Task<LiveBidResponse> LiveBid(TenderMaterialBiddingDto materialDto)
        {
            try
            {
                bool isSupplierRegistered = await IsSupplierRegistered(materialDto);// bidRequestRepository.IsBidderRegistered(materialDto.CompanyId, materialDto.TenderId, materialDto.BiddingId);
                if (!isSupplierRegistered) return null;


                Tuple<bool, string> tuple = await IsQuotationValid(materialDto);
                bool isQuotationValid = tuple.Item1;
                string errorMessage = tuple.Item2;

                if (isQuotationValid)
                {
                    string batch = $"Tender_Batch_{materialDto.SupplierId}_{materialDto.TenderId}";
                    long batchNo = 0;
                    memoryCache.TryGetValue<long>(batch, out batchNo);

                    List<LiveBiddingEntity> entities = MaterialBiddingDtoToLiveBiddingEntity(materialDto, cryptoService, batchNo);
                    //entity.Quotation = cryptoService.Encrypt(entity.Quotation);
                    entities = bidRequestRepository.LiveBid(entities);

                    if (entities != null) //if tender is not expired 
                    {

                        AddQuotationToCache(entities, materialDto.TenderId, materialDto.SupplierId);
                        decimal currentQuotation = Math.Round(materialDto.MaterialQuotation.Sum(x => x.Quotation), 2);
                        LiveBidResponse response = GetPositionFromCache(materialDto.TenderId, materialDto.SupplierId, currentQuotation);
                        if (response != null)
                        {
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

                            bidRequestRepository.WriteAutionLogEntry(log);
                            response.Log = log;
                            response.CurrentQuotation = currentQuotation;
                            return response;
                        }
                        return null;
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
                    if (response != null)
                    {
                        response.IsBidSuccess = false;
                        response.CurrentQuotation = currentQuotation;
                        response.MaterialQuotation = materialDto.MaterialQuotation;
                        response.Message = errorMessage;
                        return response;
                    }
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                MoveToHistory();
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

                var entities = bidRequestRepository.AutoBid(autoBidEntities);
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
                    memoryCache.Remove(timeKey);
                    memoryCache.Remove($"TenderInfo_{tenderId}");
                    return dto;
                }


                if (dto != null)
                {
                    long totalElapsedSeconds = (long)(DateTime.Now - dto.MinQuotationRecivedAt).TotalSeconds;
                    long totalIntervalInSec = dto.Interval * 60;
                    long remainingSec = totalIntervalInSec - totalElapsedSeconds;


                    //if tender live end date is about to end
                    if (DateTime.Now.AddMinutes(dto.Interval) >= dto.TenderLiveEndDate)
                    {
                        dto.RemainingMinute = (dto.TenderLiveEndDate - DateTime.Now).Minutes;
                        dto.RemainingSecond = (dto.TenderLiveEndDate - DateTime.Now).Seconds;
                    }
                    else //there is still time left for tender live end
                    {
                        dto.RemainingMinute = (int)(remainingSec / 60);
                        dto.RemainingSecond = (int)(remainingSec % 60);
                    }

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
                    TenderEntity e = bidRequestRepository.GetTenderDetail(tenderId);
                    if (e != null)
                    {
                        dto = new ResetBidDto
                        {
                            MinQuotationRecivedAt = DateTime.Now,
                            RemainingMinute = e.LiveInterval,
                            RemainingSecond = 0,
                            Interval = e.LiveInterval,
                            IsTenderExpired = false,
                            IsQuotationReceived = false,
                            FullIntervalCountWithoutReceivingBid = 0,
                            TenderLiveEndDate = e.LiveEndDate
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

        /// <summary>
        /// Return bid detail response
        /// </summary>
        /// <param name="bidId"></param>
        /// <param name="companyId"></param>
        /// <param name="tenderId"></param>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        public async Task<BidDetailDto> BidDetail(long bidId, long companyId, long tenderId, string baseUrl)
        {
            BidRequestEntity entity = await bidRequestRepository.BidDetail(bidId, companyId, tenderId);
            return ToDetailDto(entity, baseUrl);
        }

        public async Task<IEnumerable<BidCardDto>> ShowAllRegistration(long tenderId)
        {
            IEnumerable<BidRequestEntity> requests = await bidRequestRepository.ShowAllRegistration(tenderId);
            return BidderRequestToDto(requests);
        }

        public async Task<IEnumerable<BidHistoryCardDto>> SupplierBidHistory(long supplierCompanyId)
        {
            IEnumerable<BidRequestEntity> requests = await bidRequestRepository.SupplierBidHistory(supplierCompanyId);
            IEnumerable<TenderWinnerEntity> winingTenders = await bidRequestRepository.GetSupplierWinningBids(supplierCompanyId);
            return ToBidHistory(requests, winingTenders);
        }

        public async Task<BidCardDto> ApproveOrDisapprove(BidUpdateRequestDto updateRequest)
        {
            try
            {
                BidRequestEntity entity = await bidRequestRepository.GetBidRequestEntityOnly(updateRequest.BidId);
                if (entity != null)
                {
                    entity.BidRequestStatusId = updateRequest.StatusId;
                    entity.Remark = updateRequest.Remark;
                    entity.Date_modified = DateTime.Now;
                    entity = await bidRequestRepository.UpdateBidRequest(entity);
                    return BidEntityToCard(entity);
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<long> SetTenderWinner(BidWinnerRequestDto dto)
        {
            try
            {
                bool exists = await bidRequestRepository.CheckTenderWinner(dto.TenderId);
                if (!exists)
                {
                    TenderWinnerEntity ent = ToWinnerEntity(dto);
                    ent = await bidRequestRepository.SetTenderWinner(ent);
                    return ent.Id;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task MoveBidToHistory()
        {
            return Task.Run(async () =>
            {
                List<LiveBiddingEntity> list = await bidRequestRepository.GetExpiredBids();
                List<BiddingHistoryEntity> historyEntities = new List<BiddingHistoryEntity>();

                var tempResult = (from l in list
                                  orderby l.BidDate descending
                                  group l by new { l.UserId, l.TenderId } into g

                                  select new
                                  {
                                      UserId = g.Key.UserId,
                                      TenderId = g.Key.TenderId,
                                      BidDate = g.Max(x => x.BidDate),
                                      BatchNo = g.Max(x => x.BatchNo)

                                  }).ToList();

                List<LiveBiddingEntity> finalRecords = (from ol in list
                               join t in tempResult on new { ol.TenderId, ol.BidDate, ol.BatchNo } equals new { t.TenderId, t.BidDate, t.BatchNo }
                               select ol
                               ).ToList();

                var computedAmount = (from ol in finalRecords
                                      group ol by new { ol.UserId, ol.TenderId, ol.BatchNo } into g                                      
                                      select new
                                      {
                                          TenderId = g.Key.TenderId,
                                          UserId = g.Key.UserId,
                                          Amount = g.Sum(x=> cryptoService.Decrypt<decimal>(x.Quotation))
                                      })
                                      .OrderBy(x=>x.Amount)
                                      .ToList();

                foreach (LiveBiddingEntity item in list)
                {
                    int position = computedAmount.FindIndex(x => x.UserId == item.UserId && x.TenderId == item.TenderId);
                    //Create history object with decrypted quotation
                    BiddingHistoryEntity entity = new BiddingHistoryEntity
                    {
                        BiddingRequestId = item.BiddingRequestId,
                        UserId = item.UserId,
                        TenderId = item.TenderId,
                        MaterialId = item.MaterialId,
                        Quotation = cryptoService.Decrypt<decimal>(item.Quotation),
                        BidDate = item.BidDate,
                        BatchNo = item.BatchNo,
                        FinalPosition = position >= 0 ? $"L{position+1}" : null
                    };
                    historyEntities.Add(entity);

                }
                //Save History
                bool isHistoryCreated = await bidRequestRepository.AddHistory(historyEntities);

                //delete item from live bid
                if (isHistoryCreated)
                {
                    await bidRequestRepository.DeleteLiveBids(list);
                }
            });
        }


        public async Task<List<AuctionLog>> GetTenderAuctionLog(long companyId, long tenderId)
        {
            try
            {
                List<AuctionLog> logs = await bidRequestRepository.GetTenderAuctionLog(companyId, tenderId);
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
                List<AuctionLog> logs = await bidRequestRepository.GetTenderAuctionLogForBidInviter(tenderId);
                return logs;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Determines whether [is supplier registered] [the specified company identifier].
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="tenderId">The tender identifier.</param>
        /// <returns></returns>
        public async Task<bool> IsSupplierRegistered(long companyId, long tenderId)
        {
            try
            {
                return await bidRequestRepository.IsSupplierRegistered(companyId, tenderId);
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
                DateTime expiryDate = bids.FirstOrDefault().TenderEntity.LiveEndDate.AddMinutes(5);
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

        private async Task<Tuple<bool, string>> IsQuotationValid(TenderMaterialBiddingDto dto)
        {
            decimal minimumQuotation = 0;
            bool isValid = false;
            string errorMsg = "You have already quotated less than or same as current quotation";
            Tuple<decimal, DateTime, DateTime> tenderInfo = tenderService.GetMaxQuotationAllowed(dto.TenderId);
            decimal currentQuotation = dto.MaterialQuotation.Sum(x => x.Quotation);
            if (tenderInfo.Item1 != 0 && currentQuotation <= tenderInfo.Item1)
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
                isValid = true;
                await UpdateTenderMaxQuotation(dto.TenderId, tenderInfo.Item2, tenderInfo.Item3);
            }
            else
            {
                isValid = false;
                errorMsg = "You have quotated more than allwed quotation";
            }
            return Tuple.Create(isValid, errorMsg);
        }

        private LiveBidResponse GetSupplierBiddingPosition(List<LiveBiddingEntity> livebids, long supplierId, decimal currentQuotation)
        {
            try
            {
                if (livebids == null || livebids.Count < 1) return null;
                DateTime tenderEndDate = livebids.FirstOrDefault().TenderEntity.LiveEndDate;
                var a = livebids
                    .GroupBy(x => new { x.TenderId, x.UserId })
                    .Select(x => new
                    {
                        SupplierId = x.Key.UserId,
                        TenderId = x.Key.TenderId,
                        Quotation = x.Sum(o => cryptoService.Decrypt<decimal>(o.Quotation)),
                        Interval = x.Min(o => o.TenderEntity.LiveInterval)
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
            List<LiveBiddingEntity> liveBids = await bidRequestRepository.TenderLiveBids(tenderId);

            if (liveBids.Count > 0)
            {
                foreach (var item in liveBids)
                {
                    item.Quotation = cryptoService.Decrypt<string>(item.Quotation);
                }

                decimal maxQtn = liveBids.GroupBy(x => new { x.BatchNo, x.Quotation }).Max(x => x.Sum(y => Convert.ToDecimal(x.Key.Quotation)));
                return maxQtn;
            }
            return 0;
        }

        private async Task UpdateTenderMaxQuotation(long tenderId, DateTime startTime, DateTime endTime)
        {
            TimeSpan timeSpan = endTime.Subtract(startTime);
            DateTime midDate = startTime.AddSeconds(timeSpan.TotalSeconds / 2);
            if (midDate <= DateTime.Now)
            {
                decimal maxQtn = await GetMaxQuotation(tenderId);
                memoryCache.Set($"TenderInfo_{tenderId}", Tuple.Create(maxQtn, startTime, endTime));
                //update tender max quotation
                await tenderService.UpdateTenderMaxQuotation(maxQtn, tenderId);

            }
        }

        private void MoveToHistory()
        {
            string jobId = "Move Live Bid To History";
            RecurringJob.RemoveIfExists(jobId);
            RecurringJob.AddOrUpdate(jobId, () => MoveBidToHistory(), Cron.Hourly());
        }

        private async Task<bool> IsSupplierRegistered(TenderMaterialBiddingDto dto)
        {

            bool? isSupplierRegistered = null;
            string key = $"SuppReg_{dto.TenderId}_{dto.SupplierId}";
            memoryCache.TryGetValue<bool?>(key, out isSupplierRegistered);

            if (isSupplierRegistered == null)
            {
                isSupplierRegistered = await bidRequestRepository.IsBidderRegistered(dto.CompanyId, dto.TenderId, dto.BiddingId);
            }

            memoryCache.Set<bool>(key, isSupplierRegistered.Value, DateTime.Now.AddDays(1));
            return isSupplierRegistered.Value;
        }
    }
}
