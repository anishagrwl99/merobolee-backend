using MeroBolee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.CompanyType
{
    public interface ICompanyTypeService
    {
        GetCompanyTypeDto AddCompanyType(AddCompanyTypeDto companyTypeDto);
        IEnumerable<GetCompanyTypeDto> GetCompanyType(string search);
        GetCompanyTypeDto GetCompanyTypeDetail(int id);
        GetCompanyTypeDto UpdateCompanyType(int id, AddCompanyTypeDto companyTypeDto);
        void DeleteCompanyType(int id);
       
    }
}
