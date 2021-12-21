using MeroBolee.Dto;
using MeroBolee.Model;
using MeroBolee.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public interface IBiddingRequestService
    {
        Task<GetBiddingRequestDto> SendRequest(AddBiddingRequestDto bidderRequest);

        LiveBidResponse LiveBid(TenderMaterialBiddingDto materialDto);

        GetBiddingRequestDto ShowRequest(int requestId);

        IEnumerable<GetBiddingRequestDto> ShowAllRequest();

        IEnumerable<GetBiddingRequestDto> AllRequestByBidder(int bidderId);

        GetBiddingRequestDto UpdateRequest(int id, UpdateRequestDto updateRequest);

        Task<LiveBidResponse> TenderPosition(int tenderId, int supplierId);


        Task MoveBidToHistory();

        Task<ResetBidDto> CheckBiddingTime(long tenderId);
        LiveBidResponse AutoBid(TenderAutoBidDto bidDto);

        /// <summary>
        /// Get all logs associated with a tender auction for a company
        /// </summary>
        /// <param name="companyId">Supplier company Id</param>
        /// <param name="tenderId">A tender number</param>
        /// <returns></returns>
        Task<List<AuctionLog>> GetTenderAuctionLog(long companyId, long tenderId);


        /// <summary>
        /// Get all logs associated with a tender auction for a company
        /// </summary>
        /// <param name="tenderId">A tender number</param>
        /// <returns></returns>
        Task<List<AuctionLog>> GetTenderAuctionLogForBidInviter( long tenderId);

    }
}
