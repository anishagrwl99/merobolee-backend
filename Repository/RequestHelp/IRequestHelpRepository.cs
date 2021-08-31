using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.RequestHelp
{
    public interface IRequestHelpRepository : IRepositoryBase<RequestHelpEntity>
    {
        RequestHelpEntity PostRequest(RequestHelpEntity requestHelp);
        RequestHelpEntity GetRequestHelp(int id);
        IEnumerable<RequestHelpEntity> GetAllRequestHelp();
        IEnumerable<RequestHelpEntity> GetAllRequestHelpByBidder(int id);
        RequestHelpEntity UpdateRequestHelp(int id, RequestHelpEntity requestHelp);
    }
}
