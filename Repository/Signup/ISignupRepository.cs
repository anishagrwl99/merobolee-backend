using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public interface ISignupRepository
    {
        Task<CompanyEntity> SignupSupplier(CompanyEntity company, UserEntity user);
        Task<CompanyEntity> UpdateCompany(CompanyEntity company);
    }

    public class SignupRepository : RepositoryBase<CompanyEntity>, ISignupRepository
    {
        private IUnitOfWork unitOfWork;
        public SignupRepository(IUnitOfWork unitOfWork, IDbFactory dbFactory) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

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
                    UserId = user.User_Id,
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
    }
}
