using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public interface ITechnicalSupportRepository : IRepositoryBase<TechnicalSupportEntity >
    {
        TechnicalSupportEntity  PostRequest(TechnicalSupportEntity  requestHelp);
        TechnicalSupportEntity  GetRequestHelp(int id);
        IEnumerable<TechnicalSupportEntity > GetAllRequestHelp();
        IEnumerable<TechnicalSupportEntity > GetAllRequestHelpByBidder(int id);
        TechnicalSupportEntity  UpdateRequestHelp(int id, TechnicalSupportEntity  requestHelp);
    }
}
