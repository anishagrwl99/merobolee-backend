using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.CompanyType
{
    public interface ICompanyTypeRepository : IRepositoryBase<CompanyTypeEntity>
    {
        CompanyTypeEntity AddCompanyType(CompanyTypeEntity companyTypeEntity);
        IEnumerable<CompanyTypeEntity> GetCompanyType(string search);
        CompanyTypeEntity GetCompanyTypeDetail(int id);

        CompanyTypeEntity UpdateCompanyType(int id, CompanyTypeEntity companyTypeEntity);
        void DeleteCompanyType(int id);
    }
}
