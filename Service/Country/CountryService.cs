using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public class CountryService:CountryMapper ,ICountryService
    {
        private readonly ICountryRepository countryRepository;
        public CountryService(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
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

        public IEnumerable<GetCountryDto> GetCountry(string search)
        {
            try
            {

                return CountryEntityListToDto(countryRepository.GetCountry(search));
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
