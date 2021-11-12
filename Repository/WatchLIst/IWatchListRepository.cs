using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.WatchLIst
{
    public interface IWatchListRepository : IRepositoryBase<WatchListEntity>
    {
        void AddWatchList(WatchListEntity watchList);
        IEnumerable<TenderCard> GetAllWatchList(long userId, long companyId);
        void RemoveWatchList(int id);
    }
}
