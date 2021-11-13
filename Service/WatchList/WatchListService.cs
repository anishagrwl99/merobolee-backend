using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Model;
using MeroBolee.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public class WatchListService :WatchListMapper,IWatchListService
    {
        private readonly IWatchListRepository watchListRepository;

        public WatchListService(IWatchListRepository watchListRepository)
        {
            this.watchListRepository = watchListRepository;
        }

        public AddWatchList AddWatchList(AddWatchList watchList)
        {
            bool isTenderAddedToWatchList = watchListRepository.IsTenderAddedToWatchList(watchList.TenderId, watchList.CompanyId);
            if (!isTenderAddedToWatchList)
            {
                watchListRepository.AddWatchList(WatchListDtoToEntity(watchList));
                return watchList;
            }
            return null;
        }

        public IEnumerable<TenderWatchListCard> GetAllWatchList(long supplierId, long companyId)
        {
            return watchListRepository.GetAllWatchList(supplierId, companyId);
        }

        public void RemoveWatchList(int id)
        {
            watchListRepository.RemoveWatchList(id);
        }
    }
}
