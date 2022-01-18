using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class RoleMapper
    {
        public RoleEntity RoleDtoToEntity(AddRoleDto addGetRoleDto)
        {
            if (addGetRoleDto == null)
            {
                return null;
            }
            return new RoleEntity
            { 
                 Name= addGetRoleDto.Role
            };
        }

        public IEnumerable<GetRoleDto> RoleEntityListToDto(IEnumerable<RoleEntity> roleEntities)
        {
            List<GetRoleDto> addGetRoles = new List<GetRoleDto>();
            if (roleEntities == null)
            {
                return addGetRoles = null;            
            }
            foreach (RoleEntity role in roleEntities)
            {
                addGetRoles.Add(new GetRoleDto
                    {
                        RoleId= role.Id,
                        Role=role.Name                    
                    }          
                    );                    
            }
            return addGetRoles;
        }

        public GetRoleDto RoleEntityToDto(RoleEntity roleEntity)
        {if (roleEntity == null)
            {
                return null;
            }
            return new GetRoleDto 
            {
            RoleId= roleEntity.Id,
            Role= roleEntity.Name
            };
        }
    }
}
