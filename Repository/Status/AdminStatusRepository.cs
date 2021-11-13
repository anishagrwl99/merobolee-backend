using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public class AdminStatusRepository: RepositoryBase<AdminStatusEntity>, IAdminStatusRepository
    {
        public AdminStatusRepository(IDbFactory dbFactory) : base(dbFactory)
        { }

        public IEnumerable<AdminStatusEntity> GetAdminStatuses()
        {
            return meroBoleeDbContexts.AdminStatusEntities.ToList();
        }
    }
}
