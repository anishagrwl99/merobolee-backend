using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public interface IWatchListService
    {
        AddWatchList AddWatchList(AddWatchList watchList);
        IEnumerable<TenderWatchListCard> GetAllWatchList(long userId, long companyId);
        void RemoveWatchList(int id);
    }
}
