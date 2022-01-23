using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    /// <summary>
    /// Account repo interface
    /// </summary>
    public interface IAccountRepository
    {
        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="request"></param>
        /// <param name="registeredAs"></param>
        /// <returns></returns>
        AuthenticateResponse AuthenticateAsync(AuthenticateRequest request, CompanyTypeEnum registeredAs);
    }


    /// <summary>
    /// account repo implementation
    /// </summary>
    public class AccountRepository : RepositoryBase<UserEntity>, IAccountRepository
    {
        //private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="dbFactory"></param>
        public AccountRepository(IUnitOfWork unitOfWork, IDbFactory dbFactory) : base(dbFactory)
        {
            // this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="request"></param>
        /// <param name="registeredAs"></param>
        /// <returns></returns>
        public AuthenticateResponse AuthenticateAsync(AuthenticateRequest request, CompanyTypeEnum registeredAs)
        {
            try
            {

                var user = from u in meroBoleeDbContexts.UserEntities
                           join uc in meroBoleeDbContexts.UserCompanies on u.Id equals uc.UserId
                           join c in meroBoleeDbContexts.CompanyEntities on uc.CompanyId equals c.CompanyId
                           join cs in meroBoleeDbContexts.CompanyStatusEntities on c.CompanyStatusId equals cs.Id
                           join r in meroBoleeDbContexts.RoleEntities on u.RoleId equals r.Id
                           where u.Email == request.Email && u.Password == request.Password && c.RegisteredAs.Contains(registeredAs.ToString())
                           select new AuthenticateResponse
                           {
                               Id = u.Id,
                               FirstName = u.FirstName,
                               MiddleName = u.MiddleName,
                               LastName = u.LastName,
                               Created = u.Date_created,
                               Email = u.Email,
                               Role = r.Name,
                               UserStatusId = u.StatusId == null ? 0 : u.StatusId.Value,
                               ProfilePicture = u.ProfilePicture,
                               CompanyId = c.CompanyId,
                               CompanyName = c.Name,
                               CompanyEmail = c.CompanyEmail,
                               CompanyStatusId = c.CompanyStatusId == null ? 0 : c.CompanyStatusId.Value,
                               CompanyStatus = cs.Status
                           };

                return user.FirstOrDefault();
                //UserEntity userEntity = meroBoleeDbContexts.UserEntities
                //    .Where(x => x.Person_email == request.Email && x.Password == request.Password)
                //    .Include(x => x.Role)
                //    .FirstOrDefault();

                //if (userEntity != null)
                //{
                //    return new AuthenticateResponse
                //    {
                //        Id = userEntity.User_Id,
                //        FirstName = userEntity.First_Name,
                //        LastName = userEntity.Last_Name,
                //        Created = userEntity.Date_created,
                //        Email = userEntity.Person_email,
                //        Role = userEntity.Role.Role_Name,
                //    };
                //}
                //return null;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
