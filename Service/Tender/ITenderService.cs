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
        IEnumerable<GetTenderDto> GetTenderByAuctioneer(int id, string search);
        GetTenderDto GetTenderDetail(int id);
        GetTenderDto UpdateTender(int id, AddTenderDto tenderDto);
        IEnumerable<GetTenderDto> UpcomingTender(string search);
        IEnumerable<GetTenderDto> FavouriteTender(int id, string search);
        IEnumerable<GetTenderDto> TenderByStatus(int id, string search);
    }
}
