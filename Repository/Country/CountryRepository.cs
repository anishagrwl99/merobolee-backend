using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
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
            catch(DbUpdateException)
            {
                throw new Exception("Country is in use. Can not be delete at this time.");
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public IEnumerable<CountryEntity> GetCountry()
        {
            try
            {
                return meroBoleeDbContexts.CountryEntities.ToList();
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
                CountryEntity country = meroBoleeDbContexts.CountryEntities.Where(m => m.Id == id).FirstOrDefault();
                
                return country;
            }
            catch (Exception)
            {
                throw;
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
                countryEntity.Name = country.Name;
                countryEntity.Code = country.Code;
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
