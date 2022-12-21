using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public interface IBidderRequestRepository : IRepositoryBase<BidRequestEntity>
    {
        /// <summary>
        /// Check if tender winner is already selected
        /// </summary>
        /// <param name="tenderId"></param>
        /// <returns></returns>
        Task<bool> CheckTenderWinner(long tenderId);


        /// <summary>
        /// Set a tender winner
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        Task<TenderWinnerEntity> SetTenderWinner(TenderWinnerEntity ent);

        /// <summary>
        /// Update a bid request entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<BidRequestEntity> UpdateBidRequest(BidRequestEntity entity);

        /// <summary>
        /// Get a bid request only for checking if it exists or not
        /// </summary>
        /// <param name="tenderId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<BidRequestEntity> GetBidRequestEntityOnly(long tenderId, long companyId);


        /// <summary>
        /// Get a bid request only
        /// </summary>
        /// <param name="bidId"></param>
        /// <returns></returns>
        Task<BidRequestEntity> GetBidRequestEntityOnly(long bidId);

        /// <summary>
        /// Register for bidding
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<BidRequestEntity> RegisterForBidding(BidRequestEntity entity);

        /// <summary>
        /// Registers for bidding.
        /// </summary>
        /// <param name="documents">The entity.</param>
        /// <returns></returns>
        Task<bool> SubmitDocumentRegisterForBidding(List<BidderRequestDocEntity> documents);





        /// <summary>
        /// Check necessary conditions before entering live bidding room
        /// </summary>
        /// <param name="tenderId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<BidRequestEntity> EnterLiveBiddingRoom(long tenderId, long companyId);


        /// <summary>
        /// Live bid in a tender
        /// </summary>
        /// <param name="bidEntity"></param>
        /// <returns></returns>
        List<LiveBiddingEntity> LiveBid(List<LiveBiddingEntity> bidEntity);

        // <summary>
        /// Live bid in a tender
        /// </summary>
        /// <param name="sealBidEntity"></param>
        /// <returns></returns>
        List<SealBidEntity> SealBid(List<SealBidEntity> sealBidEntity);

        List<SealBidEntity> SealBidEdit(List<SealBidEntity> sealBidEntity);


        /// <summary>
        /// Auto bid
        /// </summary>
        /// <param name="bidEntity"></param>
        /// <returns></returns>
        List<LiveBiddingEntity> AutoBid(List<LiveBiddingEntity> bidEntity);


        /// <summary>
        /// Get all bids done in a tender
        /// </summary>
        /// <param name="tenderId"></param>
        /// <returns></returns>
        Task<List<LiveBiddingEntity>> TenderLiveBids(long tenderId);

        Task<BidRequestEntity> BidDetail(long bidId, long companyId, long tenderId);

        Task<IEnumerable<BidRequestEntity>> ShowAllRegistration(long tenderId);

        Task<IEnumerable<OnlineSuppliers>> ShowAllOnlineSuppliers(long tenderId);

        Task<IEnumerable<BidRequestEntity>> SupplierBidHistory(long supplierCompanyId);
        Task<IEnumerable<TenderWinnerEntity>> GetSupplierWinningBids(long supplierCompanyId);

        Task<List<LiveBiddingEntity>> GetExpiredBids();
        Task<List<SealBidEntity>> GetExpiredBidsForSeal();

        Task<bool> DeleteLiveBids(List<LiveBiddingEntity> records);
        Task<bool> AddHistory(List<BiddingHistoryEntity> records);
        TenderEntity GetTenderDetail(long tenderId);
        Task<bool> IsBidderRegistered(long companyId, long tenderId, long biddingId);
        void WriteAutionLogEntry(AuctionLog log);
        TenderEntity UpdateLiveEndDate(long tenderId,DateTime liveEndDate);
        
        /// <summary>
        /// Get all logs associated with a tender auction for a company
        /// </summary>
        /// <param name="companyId">Supplier company Id</param>
        /// <param name="tenderId">A tender Id</param>
        /// <returns></returns>
        Task<List<AuctionLog>> GetTenderAuctionLog(long companyId, long tenderId);
        Task<List<AuctionLog>> GetAuctionLogForAdmin(long tenderId);

        
        /// <summary>
        /// Get all logs associated with a tender auction for a company
        /// </summary>
        /// <param name="tenderId">A tender Id</param>
        /// <returns></returns>
        Task<List<BidInviterAuctionLog>> GetTenderAuctionLogForBidInviter(long tenderId);
        
        Task<AuctionLog> LogActivityForAdmin(long tenderId,long logId);
        Task<AuctionLog> UpdateAuctionLog(AuctionLog auctionLogEntity, BidRequestEntity bidRequestEntity);

        Task<BidRequestEntity> UpdateSuspendStatusBidRequest( BidRequestEntity bidRequestEntity);
        Task<List<BidRequestEntity>> GetBidRequestEntity(long tenderId, long userId, long companyId);

        /// <summary>
        /// Determines whether [is supplier registered] [the specified company identifier].
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="tenderId">The tender identifier.</param>
        /// <returns></returns>
        Task<bool> IsSupplierRegistered(long companyId, long tenderId);

        /// <summary>
        /// Determines whether [is supplier registered] [the specified company identifier].
        /// </summary>
        /// <param name="tenderId">The tender identifier.</param>
        /// <returns></returns>

        Task<List<PositionAmountDto>> GetFinalBiddingPosition(long tenderId);

        /// <summary>
        /// Determines whether [is supplier registered] [the specified company identifier].
        /// </summary>
        /// <param name="userId">The company identifier.</param>
        /// <returns></returns>
        Task<string> FindCompanyName(long userId);


        /// <summary>
        /// Determines whether [is supplier registered] [the specified company identifier].
        /// </summary>
        /// <param name="quotations">The company identifier.</param>
        /// <returns></returns>

        Task<List<QuotationEntity>> SaveToQuotationEntity(List<QuotationEntity> quotations);

        /// <summary>
        /// Determines whether [is supplier registered] [the specified company identifier].
        /// </summary>
        /// <param name="quotationsSealBid">The company identifier.</param>
        /// <returns></returns>
        Task<List<QuotationSealBidEntity>> SaveToQuotationEntitySealBid(List<QuotationSealBidEntity> quotationsSealBid);

        Task<List<QuotationSealBidEntity>> EditToQuotationEntitySealBid(List<QuotationSealBidEntity> quotationsSealBid, long tenderId, long userId);


        /// <summary>
        /// Determines whether [is supplier registered] [the specified company identifier].
        /// </summary>
        /// <param name="subsectionTotal">The company identifier.</param>
        /// <returns></returns>
        Task<List<SealBidSubsectionTotalEntity>> SaveToSubsectionTotalEntity(List<SealBidSubsectionTotalEntity> subsectionTotal);

        Task<List<SealBidSubsectionTotalEntity>> SaveToSubsectionTotalEntityEdit(List<SealBidSubsectionTotalEntity> subsectionTotal, long tenderId, long supplierId);



        /// <summary>
        /// Determines whether [is supplier registered] [the specified company identifier].
        /// </summary>
        /// <param name="TenderId">The company identifier.</param>
        /// <param name="UserId">The company identifier.</param>
        /// <returns></returns>

        Task<List<QuotationResponseDto>> GenerateBill(long TenderId, long UserId);


        Task<bool> SealBidCheckIfSubmitted(long tenderId, long supplierId);


    }
}
