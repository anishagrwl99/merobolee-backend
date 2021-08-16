using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.WatchList
{
    public interface IWatchListService
    {
        void AddWatchList(AddWatchList watchList);
        IEnumerable<GetWatchListDto> GetAllWatchList(int id);
        void RemoveWatchList(int id);
    }
}
