using MeroBolee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
   public interface ICountryService
   {
        GetCountryDto AddCountry(AddCountryDto addCountryDto);
        IEnumerable<GetCountryDto> GetCountry(string search);
        GetCountryDto GetCountryDetail(int id);
        GetCountryDto UpdateCountry(int id, AddCountryDto addCountryDto);
        void DeleteCountry(int id);
   }
}
