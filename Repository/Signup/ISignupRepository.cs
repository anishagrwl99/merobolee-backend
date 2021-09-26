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
        bool SignupSupplier(CompanyEntity company, UserEntity user);
    }

    public class SignupRepository : RepositoryBase<CompanyEntity>, ISignupRepository
    {
        private IUnitOfWork unitOfWork;
        public SignupRepository(IUnitOfWork unitOfWork, IDbFactory dbFactory) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool SignupSupplier(CompanyEntity company, UserEntity user)
        {
            try
            {
                meroBoleeDbContexts.SupplierCompany.Add(company);
                unitOfWork.SaveChange();
                user.CompanyId = company.CompanyId;
                meroBoleeDbContexts.UserEntities.Add(user);
                unitOfWork.SaveChange();
                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
