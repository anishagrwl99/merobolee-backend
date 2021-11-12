using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.Tender
{
   public interface ITenderRepository: IRepositoryBase<TenderEntity>
   {
        TenderEntity AddTender(TenderEntity tenderEntity);
        IEnumerable<TenderCard> GetMarketplaceTender(string search);
        IEnumerable<TenderEntity> GetTenderByAuctioneer(long userId, string search);
      //  IEnumerable<TenderEntity> GetTenderByBidder();
        TenderEntity GetTenderDetail(long id);
        TenderEntity UpdateTender(long id, TenderEntity tenderEntity);

        /// <summary>
        /// Upcoming tenders within 7 days
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        IEnumerable<TenderCard> UpcomingTender(string search);
        IEnumerable<TenderEntity> FavouriteTender(long userId, string search);

        IEnumerable<TenderEntity> GetMyTender(long companyId ,string search, CompanyTypeEnum companyType);
        IEnumerable<TenderCard> GetBidIniviterTenderHistory(long companyId ,string search);
        IEnumerable<TenderCard> GetBidIniviterTenderListing(long companyId ,string search);
        IEnumerable<TenderEntity> GetBidInviterTenderListing(long companyId ,string search);
        Tuple<long, long> GetTenderIdFromCode(string tenderCode);

        Tuple<long, long> GetTenderWinnerIdFromCode(string tenderCode);

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
    }
}
