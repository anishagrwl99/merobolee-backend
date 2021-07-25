using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
   public interface IRoleService
    {
        GetRoleDto AddRole(AddRoleDto role);
        IEnumerable<GetRoleDto> GetAllRole(string search);
        GetRoleDto UpdateRole(int id,AddRoleDto role);
        GetRoleDto GetRoleDetail(int id);
        void DeleteRole(int id);
    }
}
