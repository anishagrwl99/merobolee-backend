using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Model;
using MeroBolee.Repository.BidderRequest;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.BidderReuest
{
    public class BiddingRequestService : BiddingRequestMapper, IBiddingRequestService
    {
        private readonly IBidderRequestRepository bidderRequestRepository;
        public BiddingRequestService(IBidderRequestRepository bidderRequestRepository)
        {
            this.bidderRequestRepository = bidderRequestRepository;
        }
        public async Task<GetBiddingRequestDto> SendRequest(AddBiddingRequestDto bidderRequest)
        {
            return EnterBiddingRoomToEntity(await bidderRequestRepository.SendRequest(BidderRequestDtoRequest(bidderRequest),bidderRequest.BidderRequestDocs));
        }

        public async Task<TenderMaterialBiddingDto> LiveBid(TenderMaterialBiddingDto materialDto)
        {
            try
            {
                LiveBiddingEntity entity = await bidderRequestRepository.LiveBid(MaterialBiddingDtoToLiveBiddingEntity(materialDto));
                return LiveBiddingEntityToMaterialBiddingDto(entity);
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

      
    }
}
