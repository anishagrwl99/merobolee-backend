using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Model;
using MeroBolee.Repository.WatchLIst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.WatchList
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
             watchListRepository.AddWatchList(WatchListDtoToEntity(watchList));
            return watchList;
        }

        public IEnumerable<TenderCard> GetAllWatchList(long supplierId, long companyId)
        {
            return watchListRepository.GetAllWatchList(supplierId, companyId);
        }

        public void RemoveWatchList(int id)
        {
            watchListRepository.RemoveWatchList(id);
        }
    }
}
