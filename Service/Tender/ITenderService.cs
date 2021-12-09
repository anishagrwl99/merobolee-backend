using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public interface ITenderService
    {
        GetTenderDto AddTender(AddTenderDto tenderDto);
        IEnumerable<TenderCard> GetMarketplaceTender(string search);
        IEnumerable<GetTenderDto> GetTenderByAuctioneer(int userId, string search);
        GetTenderDto GetTenderDetail(long id);
        GetTenderDto UpdateTender(int id, AddTenderDto tenderDto);
        IEnumerable<TenderCard> UpcomingTender(string search);
        IEnumerable<GetTenderDto> FavouriteTender(int userId, string search);

        IEnumerable<GetTenderDto> GetMyTenders(long companyId, string search, CompanyTypeEnum companyType);
        IEnumerable<TenderCard> GetBidIniviterTenderHistory(long companyId, string search);
        BidInviterTenderListing GetBidInviterTenderListing(long companyId, string search);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenderCode"></param>
        /// <returns><see cref="Tuple{TenderId, UserId}"/> where T1 is TenderId and T2 is UserId who created a tender</returns>
        Tuple<long, long> GetTenderIdFromCode(string tenderCode);


        /// <summary>
        /// Get a supplier who won the tender by a tender code
        /// </summary>
        /// <param name="tenderCode"></param>
        /// <returns></returns>
        Tuple<long, long> GetTenderWinnerIdFromCode(string tenderCode);



        /// <summary>
        /// End live tender auction if there is no bid is done
        /// </summary>
        /// <param name="tenderId"></param>
        void EndTenderAuction(long tenderId);

        /// <summary>
        /// Approve a tender for listing by bid inviter once listing is done by admin
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        TenderApproveDto ApproveTenderByBidInviter(TenderApproveDto dto);


        /// <summary>
        /// Get all logs associated with a tender auction for a company
        /// </summary>
        /// <param name="companyId">Supplier company Id</param>
        /// <param name="tenderId">A tender number</param>
        /// <returns></returns>
        Task<List<AuctionLog>> GetTenderAuctionLog(long companyId, long tenderId);
    }
}
