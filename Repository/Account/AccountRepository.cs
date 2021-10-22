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
        AuthenticateResponse AuthenticateAsync(AuthenticateRequest request, string registeredAs);
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
        public AuthenticateResponse AuthenticateAsync(AuthenticateRequest request, string registeredAs)
        {
            try
            {

                var user = from u in meroBoleeDbContexts.UserEntities
                           join uc in meroBoleeDbContexts.UserCompanies on u.User_Id equals uc.UserId
                           join c in meroBoleeDbContexts.CompanyEntities on uc.CompanyId equals c.CompanyId
                           join r in meroBoleeDbContexts.RoleEntities on u.Role_Id equals r.Role_Id
                           where u.Person_email == request.Email && u.Password == request.Password && c.RegisteredAs.Contains(registeredAs)
                           select new AuthenticateResponse
                           {
                               Id = u.User_Id,
                               FirstName = u.First_Name,
                               LastName = u.Last_Name,
                               CompanyId = c.CompanyId,
                               CompanyName = c.Name,
                               Created = u.Date_created,
                               Email = u.Person_email,
                               Role = r.Role_Name
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
