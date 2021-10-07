using MeroBolee.Dto;
using MeroBolee.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.BidderReuest
{
    public interface IBiddingRequestService
    {
        Task<GetBiddingRequestDto> SendRequest(AddBiddingRequestDto bidderRequest);

        Task<LiveBidResponse> LiveBid(TenderMaterialBiddingDto materialDto);

        GetBiddingRequestDto ShowRequest(int requestId);

        IEnumerable<GetBiddingRequestDto> ShowAllRequest();

        IEnumerable<GetBiddingRequestDto> AllRequestByBidder(int bidderId);

        GetBiddingRequestDto UpdateRequest(int id, UpdateRequestDto updateRequest);

        Task<LiveBidResponse> TenderPosition(int tenderId, int supplierId);
    }
}
