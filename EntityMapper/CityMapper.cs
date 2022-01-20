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
                Name = addCityDto.City,
                MunicipalityId = addCityDto.MunicipalityId.HasValue ? addCityDto.MunicipalityId : null,
                VdcId = addCityDto.VDCId.HasValue ? addCityDto.VDCId.Value : null
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
                Id = cityEntity.Id,
                City = cityEntity.Name,
                Municipality_Id = cityEntity.Municipality ==null? null: cityEntity.Municipality.MunicipalityId,
                Municipality = cityEntity.Municipality == null ? null : cityEntity.Municipality.MunicipalityName,
                VDCId = cityEntity.VDC == null? null: cityEntity.VDC.Id,
                Vdc = cityEntity.VDC == null ? null : cityEntity.VDC.Name                
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
                    Id = city.Id,
                    City = city.Name,
                    Municipality_Id = city.Municipality == null? null: city.Municipality.MunicipalityId,
                    Municipality = city.Municipality==null? null: city.Municipality.MunicipalityName,
                    VDCId = city.VDC == null? null: city.VDC.Id,
                    Vdc = city.VDC == null?  null: city.VDC.Name
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
