using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Model;
using MeroBolee.Repository.BidderRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.BidderReuest
{
    public class BiddingRequestService : BiddingRequestMapper, IBiddingRequestService
    {
        private readonly object _locker = new object();
        private readonly IBidderRequestRepository bidderRequestRepository;
        private readonly IMemoryCache memoryCache;
        private readonly ICryptoService cryptoService;

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
                    // return LiveBiddingEntityToMaterialBiddingDto(entity);
                    AddQuotationToCache(entity, entity.SupplierId, entity.MaterialId);
                    LiveBidResponse response = GetPositionFromCache(entity.TenderId, entity.SupplierId, materialDto.Quotation);
                    return response;
                    //List<LiveBiddingEntity> bids = await bidderRequestRepository.TenderLiveBids(materialDto.TenderId);
                    //return new LiveBidResponse();

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
                memoryCache.Set<List<LiveBiddingEntity>>(key, biddings);
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
