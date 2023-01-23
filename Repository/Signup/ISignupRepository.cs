using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public interface ISignupRepository
    {
        /// <summary>
        /// Signups the supplier.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        Task<CompanyEntity> SignupSupplier(CompanyEntity company, UserEntity user);

        /// <summary>
        /// Updates the company.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        Task<CompanyEntity> UpdateCompany(CompanyEntity company);


        /// <summary>
        /// Validates the company.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="panNumber">The pan number.</param>
        /// <returns></returns>
        Task<Tuple<bool, string>> ValidateCompany(string email, string panNumber);
    }

    public class SignupRepository : RepositoryBase<CompanyEntity>, ISignupRepository
    {
        private IUnitOfWork unitOfWork;


        /// <summary>
        /// Initializes a new instance of the <see cref="SignupRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="dbFactory">The database factory.</param>
        public SignupRepository(IUnitOfWork unitOfWork, IDbFactory dbFactory) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Signups the supplier.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public async Task<CompanyEntity> SignupSupplier(CompanyEntity company, UserEntity user)
        {
            try
            {
                meroBoleeDbContexts.CompanyEntities.Add(company);
                await unitOfWork.SaveChangesAsync();
                meroBoleeDbContexts.UserEntities.Add(user);
                await unitOfWork .SaveChangesAsync();
                UserCompany userCompany = new UserCompany
                {
                    UserId = user.Id,
                    CompanyId = company.CompanyId
                };
                meroBoleeDbContexts.UserCompanies.Add(userCompany);
                await unitOfWork .SaveChangesAsync();
                return company;
            }
            catch (Exception)
            {
                throw;
            }

        }


        /// <summary>
        /// Updates the company.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        public async Task<CompanyEntity> UpdateCompany(CompanyEntity company)
        {
            try
            {
                meroBoleeDbContexts.CompanyEntities.Update(company);
                await meroBoleeDbContexts.SaveChangesAsync();
                return company;
            }
            catch (Exception)
            {

                throw;
            }
        }



        /// <summary>
        /// Validates the company.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="panNumber">The pan number.</param>
        /// <returns></returns>
        public async Task<Tuple<bool, string>> ValidateCompany(string email, string panNumber)
        {
            try
            {
                string msg = "";
                bool isValid = true;
                var info = await meroBoleeDbContexts.CompanyEntities
                            .Where(x => x.CompanyEmail == email || x.PANNumber == panNumber)
                            .Select(x => new { x.CompanyEmail, x.PANNumber})
                            .FirstOrDefaultAsync();

                string userEmail = await meroBoleeDbContexts.UserEntities
                    .Where(x => x.Email == email)
                    .Select(x => x.Email)
                    .FirstOrDefaultAsync();


                if ((info != null && string.Equals(email, info.CompanyEmail, StringComparison.OrdinalIgnoreCase)) ||
                     (userEmail != null && string.Equals(email, userEmail, StringComparison.OrdinalIgnoreCase)))
                {
                    isValid = false;
                    msg = "Email is already registered";
                }
                else if (info != null && string.Equals(panNumber, info.PANNumber, StringComparison.OrdinalIgnoreCase))
                {
                    isValid = false;
                    msg = "PAN Number is already registered.";
                }

                return Tuple.Create(isValid, msg);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
