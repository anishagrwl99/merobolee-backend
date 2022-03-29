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
        /// <summary>
        /// Register for tender bidding
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<long> RegisterInTenderBidding(RegisterForTenderDto dto);


        /// <summary>
        /// Submits the document for registered tender.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        Task<long> SubmitDocumentForRegisteredTender(SubmitDocumentForRegisteredTender dto);


        /// <summary>
        /// Determines whether [is supplier registered] [the specified company identifier].
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="tenderId">The tender identifier.</param>
        /// <returns></returns>
        Task<bool> IsSupplierRegistered(long companyId, long tenderId);

        /// <summary>
        /// Update a tender registration
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<long> UpdateRegistration(UpdateRegistrationForTenderDto dto);

        /// <summary>
        /// Check for necessary criteria before entering live bidding room
        /// </summary>
        /// <param name="bidderRequest"></param>
        /// <returns></returns>
        Task<EnterLiveBiddingRoomResponseDto> EnterLiveBiddingRoom(AddBiddingRequestDto bidderRequest);

        /// <summary>
        /// Live bid a tender
        /// </summary>
        /// <param name="materialDto"></param>
        /// <returns></returns>
        Task<LiveBidResponse> LiveBid(TenderMaterialBiddingDto materialDto);

        Task<BidDetailDto> BidDetail(long bidId, long companyId, long tenderId, string baseUrl);

        Task<IEnumerable<BidCardDto>> ShowAllRegistration(long tenderId);
        Task<IEnumerable<OnlineSuppliers>> ShowAllOnlineSuppliers(long tenderId);

        Task<IEnumerable<BidHistoryCardDto>> SupplierBidHistory(long supplierCompanyId);

        Task<BidCardDto> ApproveOrDisapprove(BidUpdateRequestDto updateRequest);
        Task<long> SetTenderWinner(BidWinnerRequestDto dto);

        Task<LiveBidResponse> TenderPosition(long tenderId, long supplierId);


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
        
        Task<List<AuctionLog>> GetAuctionLogForAdmin(long tenderId);
        Task<AuctionLog> LogActivityForAdmin(long tenderId, long logId);
        Task<List<BidRequestEntity>> SuspendUserFromBiddingByAdmin(long tenderId, long UserId, long companyId);

        
        /// <summary>
        /// Get all logs associated with a tender auction for a company
        /// </summary>
        /// <param name="tenderId">A tender number</param>
        /// <returns></returns>
        Task<List<AuctionLog>> GetTenderAuctionLogForBidInviter( long tenderId);

    }
}
