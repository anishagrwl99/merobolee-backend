using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
   public interface ITenderRepository: IRepositoryBase<TenderEntity>
   {
        TenderEntity AddTender(TenderEntity tenderEntity);
        Task<IEnumerable<TenderCard>> GetMarketplaceTender(string search);
        
        Task<IEnumerable<TenderCard>> GetLiveBidMarketplaceTenderForAdmin(string search);
        
         //  IEnumerable<TenderEntity> GetTenderByBidder();
         Task<TenderEntity> GetTenderDetail(long id);
        Task<TenderEntity> GetTenderDetailNew(long id);
        Task<TenderEntity> UpdateTender(TenderEntity tenderEntity);
        Task<List<TenderCardFeedbackEntity>> GetTenderCardFeedback(long tenderId);
        /// <summary>
        /// Adds the tender documents.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        Task<List<TenderExtraDocumentEntity>> AddTenderDocuments(List<TenderExtraDocumentEntity> entities);

        /// <summary>
        /// Upcoming tenders within 7 days
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="isAlert"></param>
        /// <returns></returns>
        Task<IEnumerable<TenderCard>> UpcomingBidderTender(long companyId, bool isAlert);

        /// <summary>
        /// Get bid inviter upcoming tender
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<IEnumerable<TenderCard>> UpcomingBidInviterTender(long companyId);
        Task<IEnumerable<TenderCard>> CompanyTendersForAdmin(int statusId, long? companyId);
        Task<IEnumerable<TenderCard>> UpcomingTenderForAdmin();

        Task<IEnumerable<TenderCard>> GetBidIniviterTenderHistory(long companyId ,string search);
        Task<IEnumerable<TenderCard>> GetBidIniviterTenderListing(long companyId );
        Tuple<long, List<long>> GetTenderIdFromCode(string tenderCode);

        Tuple<long, List<long>> GetTenderWinnerIdFromCode(string tenderCode);

        /// <summary>
        /// End tender auction if bidding is not received
        /// </summary>
        /// <param name="tenderId"></param>
        bool EndTenderAuction(long tenderId);

        /// <summary>
        /// Approve a tender by a bid inviter for listing
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        TenderEntity ApproveTenderByBidInviter(TenderEntity ent);

        
        Task SetTenderStatusToFeedback(TenderEntity tenderEntity);

        Tuple<decimal, DateTime, DateTime>  GetMaxQuotationAllowed(long tenderId);
        Task<TenderEntity> GetTenderEntityOnly(long tenderId);

        Task<TenderEntity> GetTenderEntityOnly(long tenderId, long companyId);

        Task<bool> DeleteTender(TenderEntity entity);

        Task<bool> isSupplierRegistered(long tenderId, long userId, long companyId);

        Task<int> GetTenderStatus(long tenderId, long userId);

        Task<int> AddTime(long tenderId, int min);

        Task<int> EndTender(long tenderId);
        Task<int> EnterBidRoomBidInviter(long tenderId, long companyId);

        Task<List<AlgorithmEntity>> AlgorithmList();
    }
}