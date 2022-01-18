using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class ProvinceMapper
    {
        public ProvinceEntity ProvinceDtoEntity(AddProvinceDto addProvinceDto)
        {
            if (addProvinceDto == null)
            {
                return null;
            }
            return new ProvinceEntity
            {
                Name = addProvinceDto.Province,
                CountryId= addProvinceDto.CountryId

            };
        
        }

        public GetProvinceDto ProvinceEntityToDto(ProvinceEntity provinceEntity)
        {
            if (provinceEntity == null)
            {
                return null;
            }
            else if (provinceEntity.CountryId==null)  
            {
                return new GetProvinceDto 
                {

                    Id = provinceEntity.Id,
                    Province = provinceEntity.Name,
                    CountryId =null,
                    Country =null
                };
            }
            return new GetProvinceDto
            {
                Id= provinceEntity.Id,
                Province= provinceEntity.Name,
                CountryId= provinceEntity.CountryId,
                Country= provinceEntity.Country.Name

            };
        
        }

        public IEnumerable<GetProvinceDto> ProvinceEntityListToDto(IEnumerable<ProvinceEntity> provinceEntities)
        {

            List<GetProvinceDto> getProvinces = new List<GetProvinceDto>();
            if (provinceEntities == null)
            {
                return getProvinces = null;
            }
            foreach (ProvinceEntity province in provinceEntities)
            {
                getProvinces.Add(new GetProvinceDto
                  {
                      Id = province.Id,
                      Province = province.Name,
                      CountryId = province.CountryId,
                      Country = province.Country.Name
                  } 
                );
            }
            return getProvinces;
        }
    }
}
