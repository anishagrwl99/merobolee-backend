using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public class RoleService :RoleMapper,IRoleService
    {
        private readonly IRoleRepository roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;        
        }

        public GetRoleDto AddRole(AddRoleDto role)
        {
            try 
            { 
            return RoleEntityToDto(roleRepository.AddRole(RoleDtoToEntity(role)));
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void DeleteRole(int id)
        {
            try 
            { 
            roleRepository.DeleteRole(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public IEnumerable<GetRoleDto> GetAllRole(string search)
        {
            try 
            { 
            return RoleEntityListToDto(roleRepository.GetAllRole(search));
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public GetRoleDto GetRoleDetail(int id)
        {
            try 
            { 
            return RoleEntityToDto(roleRepository.GetRoleDetail(id));
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public GetRoleDto UpdateRole(int id,AddRoleDto role)
        {
            try 
            { 
            return RoleEntityToDto(roleRepository.UpdateRole(id, RoleDtoToEntity(role)));
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
