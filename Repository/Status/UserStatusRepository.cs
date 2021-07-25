using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.Status
{
    public class UserStatusRepository : RepositoryBase<UserStatusEntity>, IUserStatusRepository
    {
        public UserStatusRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public IEnumerable<UserStatusEntity> GetUserStatuses()
        {
            return meroBoleeDbContexts.UserStatusEntities.ToList();
        }
    }
}
