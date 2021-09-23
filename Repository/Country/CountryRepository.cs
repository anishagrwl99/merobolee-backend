using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.Country
{
    public class CountryRepository : RepositoryBase<CountryEntity>, ICountryRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public CountryRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork): base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public CountryEntity AddCountry(CountryEntity country)
        {
            try
            {
                country.Date_created = country.Date_modified = DateTime.Now;
                meroBoleeDbContexts.CountryEntities.Add(country);
                unitOfWork.SaveChange();
                return country;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void DeleteCountry(int id)
        {
            try
            {
                meroBoleeDbContexts.CountryEntities.Remove(GetCountryDetail(id));
                unitOfWork.SaveChange();
            }
            catch (Exception)
            {
                throw new Exception();
            }
            
        }

        public IEnumerable<CountryEntity> GetCountry(string search)
        {
            try
            {
                return meroBoleeDbContexts.CountryEntities.Where(m => (search == null)
                || ((m.Country_Name.ToLower().Contains(search.ToLower()))
                || (m.Country_Code.ToLower().Contains(search.ToLower()))
                || (m.Abbre.ToLower().Contains(search.ToLower()))
                )).ToList();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public CountryEntity GetCountryDetail(int id)
        {
            try
            {
                CountryEntity country = meroBoleeDbContexts.CountryEntities.Where(m => m.Country_Id == id).First();
                if (country == null)
                {
                    return country = null;
                }
                return country;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public CountryEntity UpdateCountry(int id, CountryEntity country)
        {
            try
            {
                CountryEntity countryEntity = GetCountryDetail(id);
                if (countryEntity == null)
                {
                    return country = null;
                }
                countryEntity.Abbre = country.Abbre;
                countryEntity.Country_Name = country.Country_Name;
                countryEntity.Country_Code = country.Country_Code;
                countryEntity.Date_modified = country.Date_modified;
             //   countryEntity.Modified_time_stamp = country.Modified_time_stamp;
                unitOfWork.SaveChange();
                return countryEntity;
            }

            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
