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
        private readonly IBidderRequestRepository bidderRequestRepository;
        private readonly IMemoryCache memoryCache;
        public BiddingRequestService(IBidderRequestRepository bidderRequestRepository, IMemoryCache cache)
        {
            this.bidderRequestRepository = bidderRequestRepository;
            memoryCache = cache;
        }
        public async Task<GetBiddingRequestDto> SendRequest(AddBiddingRequestDto bidderRequest)
        {
            return EnterBiddingRoomToEntity(await bidderRequestRepository.SendRequest(BidderRequestDtoRequest(bidderRequest),bidderRequest.BidderRequestDocs));
        }
    
        public  async Task<LiveBidResponse> TenderPosition(int tenderId, int supplierId)
        {
            List<LiveBiddingEntity> bids =  await bidderRequestRepository.TenderLiveBids(tenderId);
            return GetSupplierBiddingPosition(bids, supplierId);
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
                    LiveBiddingEntity entity = await bidderRequestRepository.LiveBid(MaterialBiddingDtoToLiveBiddingEntity(materialDto));
                    // return LiveBiddingEntityToMaterialBiddingDto(entity);
                    List<LiveBiddingEntity> bids = await bidderRequestRepository.TenderLiveBids(materialDto.TenderId);
                    return new LiveBidResponse();

                }
                else
                {
                    return new LiveBidResponse
                    {
                        MaterialId = materialDto.MaterialId,
                        IsBidSuccess = false,
                        Message = "You have already quotated less than current quotation",
                        Position = ""
                    };
                }
                return null;
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

        private LiveBidResponse GetSupplierBiddingPosition(List<LiveBiddingEntity> livebids, int supplierId)
        {
            try
            {
                var a = livebids
                    .GroupBy(x => new { x.TenderId, x.SupplierId })
                    .Select(x => new
                    {
                        SupplierId = x.Key.SupplierId,
                        TenderId = x.Key.TenderId,
                        Quotation = x.Sum(o => o.Quotation)
                    })
                    .OrderBy(x=>x.Quotation)
                    .ToList();
                int ind = a.FindIndex(x => x.SupplierId == supplierId) + 1;
                var b = a.Where(x => x.SupplierId == supplierId).FirstOrDefault();
                return new LiveBidResponse
                {
                    IsBidSuccess = true,
                    Position = ind <= 5 ? $"L{ind}" : "L6",
                    Quotation = b.Quotation,
                    Message = ""
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}
