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
      //  IEnumerable<TenderEntity> GetTenderByBidder();
        Task<TenderEntity> GetTenderDetail(long id);
        Task<TenderEntity> UpdateTender(TenderEntity tenderEntity);

        /// <summary>
        /// Upcoming tenders within 7 days
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<IEnumerable<TenderCard>> UpcomingTender(string search);

        Task<IEnumerable<TenderCard>> GetBidIniviterTenderHistory(long companyId ,string search);
        Task<IEnumerable<TenderCard>> GetBidIniviterTenderListing(long companyId ,string search);
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

    }
}
