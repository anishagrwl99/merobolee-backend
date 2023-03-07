using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public interface IWatchListRepository : IRepositoryBase<WatchListEntity>
    {
        void AddWatchList(WatchListEntity watchList);
        IEnumerable<TenderWatchListCard> GetAllWatchList(long userId, long companyId,List<int> procurementId, List<int> algoId);
        void RemoveWatchList(int id);

        bool IsTenderAddedToWatchList(long tenderId, long companyId);
    }
}
