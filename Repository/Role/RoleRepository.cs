using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.Role
{
    public class RoleRepository : RepositoryBase<RoleEntity>, IRoleRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public RoleRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory) 
        {
            this.unitOfWork = unitOfWork;
        }

        public RoleEntity AddRole(RoleEntity role)
        {
            try
            {
                meroBoleeDbContexts.RoleEntities.Add(role);
                unitOfWork.SaveChange();
                return role;
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
                meroBoleeDbContexts.RoleEntities.Remove(GetById(id));
                unitOfWork.SaveChange();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public IEnumerable<RoleEntity> GetAllRole(string search)
        {
            try
            {
                return meroBoleeDbContexts.RoleEntities.Where(m => (search == null)
                   || (m.Role_Name.ToLower().Contains(search.ToLower()))).ToList();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public RoleEntity GetRoleDetail(int id)
        {
            try
            {
                RoleEntity role= meroBoleeDbContexts.RoleEntities.Where(m => m.Role_Id == id).First();
                if (role==null)
                {
                    return role = null;
                }
                return role;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public RoleEntity UpdateRole(int id,RoleEntity role)
        {
            try
            {
                RoleEntity toEditRole = GetRoleDetail(id);
                if (toEditRole == null)
                {
                    return toEditRole = null;
                }
                toEditRole.Role_Name = role.Role_Name;
                toEditRole.Date_modified = role.Date_modified;
                toEditRole.Modified_time_stamp = role.Modified_time_stamp;
                unitOfWork.SaveChange();
                return toEditRole;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
