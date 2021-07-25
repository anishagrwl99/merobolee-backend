using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Repository.CompanyType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.CompanyType
{
    public class CompanyTypeService :CompanyTypeMapper ,ICompanyTypeService
    {
        private readonly ICompanyTypeRepository companyTypeRepository;
        public CompanyTypeService(ICompanyTypeRepository companyTypeRepository)
        {
            this.companyTypeRepository = companyTypeRepository;
        }

        public GetCompanyTypeDto AddCompanyType(AddCompanyTypeDto companyTypeDto)
        {
            return CompanyTypeEntityToDto(companyTypeRepository.AddCompanyType(CompanyTypeDtoEntity(companyTypeDto)));
        }

        public void DeleteCompanyType(int id)
        {
            companyTypeRepository.DeleteCompanyType(id);
        }

        public IEnumerable<GetCompanyTypeDto> GetCompanyType(string search)
        {
            return CompanyTypeEntityListToDto(companyTypeRepository.GetCompanyType(search));
        }

        public GetCompanyTypeDto GetCompanyTypeDetail(int id)
        {
            return CompanyTypeEntityToDto(companyTypeRepository.GetCompanyTypeDetail(id));
        }

        public GetCompanyTypeDto UpdateCompanyType(int id, AddCompanyTypeDto companyTypeDto)
        {
            return CompanyTypeEntityToDto(companyTypeRepository.UpdateCompanyType(id, CompanyTypeDtoEntity(companyTypeDto)));
        }
    }
}
