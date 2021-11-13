using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public interface IRoleRepository: IRepositoryBase<RoleEntity>
    {
        RoleEntity AddRole(RoleEntity role);
        IEnumerable<RoleEntity> GetAllRole(string search);
        RoleEntity UpdateRole(int id,RoleEntity role);
        RoleEntity GetRoleDetail(int id);
        void DeleteRole(int id);
    }
}
