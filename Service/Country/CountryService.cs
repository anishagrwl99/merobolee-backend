using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Model;
using MeroBolee.Repository;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public class CountryService:CountryMapper ,ICountryService
    {
        private readonly ICountryRepository countryRepository;
        private readonly IMemoryCache memoryCache;

        public CountryService(ICountryRepository countryRepository, IMemoryCache memoryCache)
        {
            this.countryRepository = countryRepository;
            this.memoryCache = memoryCache;
        }
        public GetCountryDto AddCountry(AddCountryDto addCountryDto)
        {
            try
            {
                return CountryEntityToDto(countryRepository.AddCountry(CountryDtoToEntity(addCountryDto)));
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }

        public void DeleteCountry(int id)
        {
            try 
            { 
            countryRepository.DeleteCountry(id);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<GetCountryDto> GetCountry()
        {
            try
            {
                string key = "AllCountries";
                IEnumerable<CountryEntity> countries = null;
                memoryCache.TryGetValue <IEnumerable<CountryEntity>>(key, out countries);
                if (countries == null)
                {
                    countries = countryRepository.GetCountry();
                    memoryCache.Set(key, countries, DateTime.Now.AddDays(7));
                }
                return CountryEntityListToDto(countries);
        }
            catch(Exception)
            {
                throw new Exception();
            }
        }

        public GetCountryDto GetCountryDetail(int id)
        {
            try
            {
                return CountryEntityToDto(countryRepository.GetCountryDetail(id));
            }   
            catch (Exception)
            {
                throw;
            }    
        }

        public GetCountryDto UpdateCountry(int id, AddCountryDto addCountryDto)
        {
            try
            {

                return CountryEntityToDto(countryRepository.UpdateCountry(id, CountryDtoToEntity(addCountryDto)));
            }
            catch (Exception)
            {
                throw new Exception();
            } 
        }
    }
}
