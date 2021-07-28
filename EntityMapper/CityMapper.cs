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
            if (addCityDto.Municipality_Id == 0 && addCityDto.VDC_Id != 0)
            {
                return new CityEntity
                {
                    City_Name = addCityDto.City,
                    Municipality_Id = null,
                    Vdc_Id = addCityDto.VDC_Id

                };

            }
            else if (addCityDto.Municipality_Id != 0 && addCityDto.VDC_Id == 0)
            {
                return new CityEntity
                {
                    City_Name = addCityDto.City,
                    Municipality_Id = addCityDto.Municipality_Id,
                    Vdc_Id = null
                };
            }
            else
            {
                return new CityEntity
                {
                    City_Name = addCityDto.City,
                    Municipality_Id = null,
                    Vdc_Id = null

                };
            }

        }

        public GetCityDto CityEntityToDto(CityEntity cityEntity)
        {
            if (cityEntity == null)
            {
                return null;
            }
            else if (cityEntity.Municipality_Id == null && cityEntity.Vdc_Id!=null)
            {
                return new GetCityDto
                {
                    Id = cityEntity.City_Id,
                    City = cityEntity.City_Name,
                    Municipality_Id = null,
                    Municipality = null,
                    VDC_Id= cityEntity.Vdc_Id,
                    Vdc= cityEntity.VDC.Vdc_Name
                };
            }
            else if (cityEntity.Vdc_Id==null && cityEntity.Municipality_Id!=null)
            {
                return new GetCityDto
                {
                    Id = cityEntity.City_Id,
                    City = cityEntity.City_Name,
                    Municipality_Id = cityEntity.Municipality_Id,
                    Municipality = cityEntity.Municipality.Municipality_Name,
                    VDC_Id = null,
                    Vdc = null
                };
            }

            return new GetCityDto
            {
                Id = cityEntity.City_Id,
                City = cityEntity.City_Name,
                Municipality_Id = null,
                Municipality = null,
                VDC_Id = null,
                Vdc = null
                //District_id = cityEntity.District_Id,
                //District = cityEntity.District.District_Name

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
            }
            return getCity;
        }
    }
}
