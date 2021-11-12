using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class CityMapper
    {
        public CityEntity CityDtoEntity(AddCityDto addCityDto)
        {
            if (addCityDto == null)
            {
                return null;
            }

            return new CityEntity
            {
                City_Name = addCityDto.City,
                Municipality_Id = addCityDto.MunicipalityId.HasValue ? addCityDto.MunicipalityId : null,
                Vdc_Id = addCityDto.VDCId.HasValue ? addCityDto.VDCId.Value : null
            };
        }

        public GetCityDto CityEntityToDto(CityEntity cityEntity)
        {
            if (cityEntity == null)
            {
                return null;
            }

            return new GetCityDto
            {
                Id = cityEntity.City_Id,
                City = cityEntity.City_Name,
                Municipality_Id = cityEntity.Municipality ==null? null: cityEntity.Municipality.Municipality_id,
                Municipality = cityEntity.Municipality == null ? null : cityEntity.Municipality.Municipality_Name,
                VDCId = cityEntity.VDC == null? null: cityEntity.VDC.Vdc_Id,
                Vdc = cityEntity.VDC == null ? null : cityEntity.VDC.Vdc_Name                
            };
        }

        public IEnumerable<GetCityDto> CityEntityListToDto(IEnumerable<CityEntity> cityEntities)
        {

            List<GetCityDto> getCity = new List<GetCityDto>();
            if (cityEntities == null)
            {
                return getCity = null;
            }
            foreach (CityEntity city in cityEntities)
            {
                getCity.Add(new GetCityDto
                {
                    Id = city.City_Id,
                    City = city.City_Name,
                    Municipality_Id = city.Municipality == null? null: city.Municipality.Municipality_id,
                    Municipality = city.Municipality==null? null: city.Municipality.Municipality_Name,
                    VDCId = city.VDC == null? null: city.VDC.Vdc_Id,
                    Vdc = city.VDC == null?  null: city.VDC.Vdc_Name
                });
                /*
                if (city.Municipality_Id == null && city.Vdc_Id == null)
                {
                    getCity.Add
                   (
                     new GetCityDto
                     {
                         Id = city.City_Id,
                         City = city.City_Name,
                         Municipality_Id = null,
                         Municipality = null,
                         VDC_Id = null,
                         Vdc = null
                     }
                   );

                }
                else if (city.Municipality_Id != null && city.Vdc_Id == null)
                {
                    getCity.Add
                   (
                     new GetCityDto
                     {
                         Id = city.City_Id,
                         City = city.City_Name,
                         Municipality_Id = city.Municipality_Id,
                         Municipality = city.Municipality.Municipality_Name,
                         VDC_Id = null,
                         Vdc = null
                     }
                   );
                }
                else
                {
                    getCity.Add
                    (
                      new GetCityDto
                      {
                          Id = city.City_Id,
                          City = city.City_Name,
                          Municipality_Id = null,
                          Municipality = null,
                          VDC_Id = city.Vdc_Id,
                          Vdc = city.VDC.Vdc_Name
                      }
                    );
                }
                */
            }
            return getCity;
        }
    }
}
