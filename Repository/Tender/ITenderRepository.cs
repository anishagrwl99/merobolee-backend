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
        IEnumerable<TenderEntity> GetMarketplaceTender(string search);
        IEnumerable<TenderEntity> GetTenderByAuctioneer(int userId, string search);
      //  IEnumerable<TenderEntity> GetTenderByBidder();
        TenderEntity GetTenderDetail(int id);
        TenderEntity UpdateTender(int id, TenderEntity tenderEntity);
        IEnumerable<TenderEntity> UpcomingTender(string search);
        IEnumerable<TenderEntity> FavouriteTender(int userId, string search);
        IEnumerable<TenderEntity> TenderByStatus(int statusId, string search);

        IEnumerable<TenderEntity> GetMyTender(long companyId ,string search, CompanyTypeEnum companyType);
        IEnumerable<TenderEntity> GetBidIniviterTenderHistory(long companyId ,string search);
        IEnumerable<TenderEntity> GetBidInviterTenderListing(long companyId ,string search);
    }
}
