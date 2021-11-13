using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public class RequestStatusRepository : RepositoryBase<RequestHelpStatus>, IRequestStatusRepository
    {
        public RequestStatusRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public IEnumerable<RequestHelpStatus> GetRequestHelpStatus()
        {
            return meroBoleeDbContexts.RequestHelpStatuses.ToList();
        }
    }
}
