using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.Country
{
    public interface ICountryRepository : IRepositoryBase<CountryEntity>
    {
        CountryEntity AddCountry(CountryEntity country);
        CountryEntity GetCountryDetail(int id);
        IEnumerable<CountryEntity> GetCountry(string search);
        CountryEntity UpdateCountry(int id, CountryEntity country);
        void DeleteCountry(int id);
    }
}
