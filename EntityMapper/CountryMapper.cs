using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class CountryMapper
    {
        public CountryEntity CountryDtoToEntity(AddCountryDto addCountryDto)
        {
            if (addCountryDto == null)
            {
                return null;
            }
            return new CountryEntity
            {
                Country_Name = addCountryDto.Country,
                Country_Code=addCountryDto.Code,
                Abbre=addCountryDto.Abrre
            };
        }

        public IEnumerable<GetCountryDto> CountryEntityListToDto(IEnumerable<CountryEntity> countryEntities)
        {
            List<GetCountryDto> getCountryDtos = new List<GetCountryDto>();
            if (countryEntities == null)
            {
                return getCountryDtos = null;
            }
            foreach (CountryEntity country in countryEntities)
            {
                getCountryDtos.Add(new GetCountryDto
                {
                    Id = country.Country_Id,
                    Country = country.Country_Name,
                    Code= country.Country_Code,
                    Abrre= country.Abbre
                }
                );
            }
            return getCountryDtos;
        }

        public GetCountryDto CountryEntityToDto(CountryEntity country)
        {
            if (country == null)
            {
                return null;
            }
            return new GetCountryDto
            {
                Id = country.Country_Id,
                Country = country.Country_Name,
                Code = country.Country_Code,
                Abrre = country.Abbre
            };
        }
    }
}
