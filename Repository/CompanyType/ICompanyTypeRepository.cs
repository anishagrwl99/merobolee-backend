using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public interface ICompanyTypeRepository : IRepositoryBase<CompanyTypeLookupEntity>
    {
        CompanyTypeLookupEntity AddCompanyType(CompanyTypeLookupEntity companyTypeEntity);
        IEnumerable<CompanyTypeLookupEntity> GetCompanyType(string search);
        CompanyTypeLookupEntity GetCompanyTypeDetail(int id);

        CompanyTypeLookupEntity UpdateCompanyType(int id, CompanyTypeLookupEntity companyTypeEntity);
        void DeleteCompanyType(int id);
    }
}
