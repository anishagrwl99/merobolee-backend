using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.Tender
{
    public interface ITenderService
    {
        GetTenderDto AddTender(AddTenderDto tenderDto);
        IEnumerable<GetTenderDto> GetMarketplaceTender(string search);
        IEnumerable<GetTenderDto> GetTenderByAuctioneer(int userId, string search);
        GetTenderDto GetTenderDetail(int id);
        GetTenderDto UpdateTender(int id, AddTenderDto tenderDto);
        IEnumerable<GetTenderDto> UpcomingTender(string search);
        IEnumerable<GetTenderDto> FavouriteTender(int userId, string search);
        IEnumerable<GetTenderDto> TenderByStatus(int statusId, string search);

        IEnumerable<GetTenderDto> GetMyTenders(long companyId, string search, CompanyTypeEnum companyType);
        IEnumerable<GetTenderDto> GetBidIniviterTenderHistory(long companyId, string search);
        IEnumerable<GetTenderDto> GetBidInviterTenderListing(long companyId, string search);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenderCode"></param>
        /// <returns><see cref="Tuple{TenderId, UserId}"/> where T1 is TenderId and T2 is UserId who created a tender</returns>
        Tuple<long, long> GetTenderIdFromCode(string tenderCode);
    }
}
