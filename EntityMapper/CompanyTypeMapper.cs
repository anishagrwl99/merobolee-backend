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
                Name = addCompanyType.CompanyType                            
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
                Id = companyTypeEntity.Id,
                CompanyType = companyTypeEntity.Name
                
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
                      Id = companyType.Id,
                      CompanyType = companyType.Name
                  }
                );
            }
            return getCompanyTypes;
        }

    }
}
