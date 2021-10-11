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
            return EnterBiddingRoomToEntity(await bidderRequestRepository.SendRequest(BidderRequestDtoRequest(bidderRequest),bidderRequest.BidderRequestDocs));
        }
    
        public  async Task<LiveBidResponse> TenderPosition(int tenderId, int supplierId)
        {
            List<LiveBiddingEntity> bids =  await bidderRequestRepository.TenderLiveBids(tenderId);
            return GetSupplierBiddingPosition(bids, supplierId, decimal.MinValue);
           //// return bids;
           //return null;
        }
        public async Task<LiveBidResponse> LiveBid(TenderMaterialBiddingDto materialDto)
        {
            try
            {
                bool isQuotationValid = IsQuotationValid(materialDto);
                if (isQuotationValid)
                {
                    LiveBiddingEntity entity = MaterialBiddingDtoToLiveBiddingEntity(materialDto);
                    entity.Quotation = cryptoService.Encrypt(entity.Quotation);
                    entity = await bidderRequestRepository.LiveBid(entity);

                    if (entity != null) //if tender is not expired 
                    {
                        AddQuotationToCache(entity, entity.SupplierId, entity.MaterialId);
                        LiveBidResponse response = GetPositionFromCache(entity.TenderId, entity.SupplierId, materialDto.Quotation);
                        return response;
                    }
                    else
                    {
                        return new LiveBidResponse
                        {
                            IsBidSuccess = false,
                            IsLowestBidReceived = false,
                            LowestBidRecievedTime = materialDto.BiddingDate,
                            MaterialId = materialDto.MaterialId,
                            Position = "NA",
                            Quotation = materialDto.Quotation,
                            Message = "Tender bidding has expired"
                        };
                    }

                }
                else
                {
                    LiveBidResponse response = GetPositionFromCache(materialDto.TenderId, materialDto.SupplierId, materialDto.Quotation);
                    response.IsBidSuccess = false;
                    response.MaterialId = materialDto.MaterialId;
                    response.Message = "You have already quotated less than current quotation";
                    return response;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

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
                        SupplierId =item.SupplierId,
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
                if(isHistoryCreated)
                {
                    await bidderRequestRepository.DeleteLiveBids(list);
                }
            });
        }

        private LiveBidResponse GetPositionFromCache(int tenderId, int supplierId, decimal quotation)
        {
            string key = $"Tender_Bidding_{tenderId}";
            List<LiveBiddingEntity> biddings;
            memoryCache.TryGetValue<List<LiveBiddingEntity>>(key, out biddings);
            LiveBidResponse response =  GetSupplierBiddingPosition(biddings, supplierId, quotation);
            return response;
        }
      
        private void AddQuotationToCache(LiveBiddingEntity obj, int supplierId, int materialId)
        {
            lock (_locker)
            {
                string key = $"Tender_Bidding_{obj.TenderId}";
                List<LiveBiddingEntity> biddings = new List<LiveBiddingEntity>();
                memoryCache.TryGetValue<List<LiveBiddingEntity>>(key, out biddings);
                if (biddings == null || biddings.Count < 1) //No cache yet
                {
                    biddings = new List<LiveBiddingEntity>();
                    biddings.Add(obj);
                }
                else //Cache found
                {
                    //Get minimum quotation from supplier
                    LiveBiddingEntity ent = biddings.Where(x => x.SupplierId == supplierId && x.MaterialId == materialId).FirstOrDefault();
                    if (ent == null)
                    {
                        biddings.Add(obj);
                    }
                    else
                    {
                        ent.Quotation = obj.Quotation;
                    }
                }
                memoryCache.Set<List<LiveBiddingEntity>>(key, biddings, obj.TenderEntity.Live_End_Date.AddMinutes(5));
            }
        }

        private bool IsQuotationValid(TenderMaterialBiddingDto dto)
        {
            decimal minimumQuotation = 0;
            string key = $"{dto.SupplierId}_{dto.BiddingId}_{dto.TenderId}_{dto.MaterialId}";
            memoryCache.TryGetValue<decimal>(key, out minimumQuotation);
            if(minimumQuotation == 0) //no bid found for this material
            {
                memoryCache.Set<decimal>(key, dto.Quotation);
                return true;
            }
            else if(dto.Quotation<minimumQuotation)
            {
                memoryCache.Set<decimal>(key, dto.Quotation);
                return true;
            }
            return false;
        }

        private LiveBidResponse GetSupplierBiddingPosition(List<LiveBiddingEntity> livebids, int supplierId, decimal currentQuotation)
        {
            try
            {
                var a = livebids
                    .GroupBy(x => new { x.TenderId, x.SupplierId })
                    .Select(x => new
                    {
                        SupplierId = x.Key.SupplierId,
                        TenderId = x.Key.TenderId,
                        Quotation = x.Sum(o => cryptoService.Decrypt<decimal>(o.Quotation))
                    })
                    .OrderBy(x=>x.Quotation)
                    .ToList();
                int ind = a.FindIndex(x => x.SupplierId == supplierId) + 1;
                var b = a.Where(x => x.SupplierId == supplierId).FirstOrDefault();
                if (b != null)
                {
                    LiveBidResponse resp =  new LiveBidResponse
                    {
                        IsBidSuccess = true,
                        Position = ind <= 5 ? $"L{ind}" : "L6",
                        Quotation = b.Quotation,
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
                        Quotation = 0,
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
