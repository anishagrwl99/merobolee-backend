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
        IEnumerable<WatchListEntity> GetAllWatchList(int id);
        void RemoveWatchList(int id);
    }
}
