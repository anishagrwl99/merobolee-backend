using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class CompanyTypeMapper
    {
        public CompanyTypeLookupEntity CompanyTypeDtoEntity(AddCompanyTypeDto addCompanyType)
        {
            if (addCompanyType == null)
            {
                return null;
            }
            return new CompanyTypeLookupEntity
            {
                Company_type = addCompanyType.CompanyType                            
            };

        }

        public GetCompanyTypeDto CompanyTypeEntityToDto(CompanyTypeLookupEntity companyTypeEntity)
        {
            if (companyTypeEntity == null)
            {
                return null;
            }
            return new GetCompanyTypeDto
            {
                Id = companyTypeEntity.Company_Type_Id,
                CompanyType = companyTypeEntity.Company_type
                
            };

        }

        public IEnumerable<GetCompanyTypeDto> CompanyTypeEntityListToDto(IEnumerable<CompanyTypeLookupEntity> companyTypeEntities)
        {

            List<GetCompanyTypeDto> getCompanyTypes = new List<GetCompanyTypeDto>();
            if (companyTypeEntities == null)
            {
                return getCompanyTypes = null;
            }
            foreach (CompanyTypeLookupEntity companyType in companyTypeEntities)
            {
                getCompanyTypes.Add
                (
                  new GetCompanyTypeDto
                  {
                      Id = companyType.Company_Type_Id,
                      CompanyType = companyType.Company_type
                  }
                );
            }
            return getCompanyTypes;
        }

    }
}
