using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public class StatusRepository : RepositoryBase<PublishStatus> , IStatusRepository
    {
        public StatusRepository(IDbFactory dbFactory): base(dbFactory)
        { }

        public IEnumerable<PublishStatus> GetPublishStatuses()
        {
            return meroBoleeDbContexts.StatusEntities.ToList();
        }
    }
}
