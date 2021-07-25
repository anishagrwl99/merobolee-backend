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
                Province = addProvinceDto.Province,
                Country_Id= addProvinceDto.Country_id

            };
        
        }

        public GetProvinceDto ProvinceEntityToDto(ProvinceEntity provinceEntity)
        {
            if (provinceEntity == null)
            {
                return null;
            }
            else if (provinceEntity.Country_Id==null)  
            {
                return new GetProvinceDto 
                {

                    Id = provinceEntity.Province_Id,
                    Province = provinceEntity.Province,
                    Country_id =null,
                    Country =null
                };
            }
            return new GetProvinceDto
            {
                Id= provinceEntity.Province_Id,
                Province= provinceEntity.Province,
                Country_id= provinceEntity.Country_Id,
                Country= provinceEntity.Country.Country_Name

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
                      Id = province.Province_Id,
                      Province = province.Province,
                      Country_id = province.Country_Id,
                      Country = province.Country.Country_Name
                  } 
                );
            }
            return getProvinces;
        }
    }
}
