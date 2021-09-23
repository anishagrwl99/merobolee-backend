using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.City
{
    public class CityRepository : RepositoryBase<CityEntity>, ICityRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public CityRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public CityEntity AddCity(CityEntity cityEntity)
        {
            try
            {
                //if (meroBoleeDbContexts.DistrictEntities.Find(cityEntity.District_Id) == null)
                //{
                //    cityEntity.District_Id = 0;
                //    return cityEntity;
                //}
                cityEntity.Date_created = cityEntity.Date_modified = DateTime.Now;
                meroBoleeDbContexts.CityEntities.Add(cityEntity);
                unitOfWork.SaveChange();
                meroBoleeDbContexts.MunicipalityEntities.ToList();
                meroBoleeDbContexts.VDCEntities.ToList();
                return cityEntity;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<CityEntity> CascadeCity(int id)
        {
            try
            {
                meroBoleeDbContexts.MunicipalityEntities.ToList();
                meroBoleeDbContexts.VDCEntities.ToList();
                return meroBoleeDbContexts.CityEntities.Where(m => m.Municipality_Id == id || m.Vdc_Id==id).ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void DeleteCity(int id)
        {
            try
            {
                meroBoleeDbContexts.CityEntities.Remove(GetCityDetail(id));
                unitOfWork.SaveChange();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public CityEntity GetCityDetail(int id)
        {
            try
            {
                CityEntity City = meroBoleeDbContexts.CityEntities.Find(id);
                if (City == null)
                {
                    return City = null;
                }
                meroBoleeDbContexts.MunicipalityEntities.ToList();
                meroBoleeDbContexts.VDCEntities.ToList();
                return City;
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

        public IEnumerable<CityEntity> GetCity(string search)
        {
            try
            {
                meroBoleeDbContexts.MunicipalityEntities.ToList();
                meroBoleeDbContexts.VDCEntities.ToList();
                return meroBoleeDbContexts.CityEntities.Where(m => (search == null)
                || (m.City_Name.ToLower().Contains(search.ToLower()))
                ).ToList();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException();
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

        public CityEntity UpdateCity(int id, CityEntity cityEntity)
        {
            try
            {
                CityEntity city = GetCityDetail(id);
                if (city == null)
                {
                    return city = null;
                }

                //if (meroBoleeDbContexts.DistrictEntities.Find(cityEntity.District_Id) == null)
                //{
                //    cityEntity.District_Id = 0;
                //    return cityEntity;
                //}
                city.City_Name = cityEntity.City_Name;
               // city.District_Id = cityEntity.District_Id;
                city.Date_modified = cityEntity.Date_modified;
               // city.Modified_time_stamp = cityEntity.Modified_time_stamp;
                unitOfWork.SaveChange();
                meroBoleeDbContexts.MunicipalityEntities.ToList();
                meroBoleeDbContexts.VDCEntities.ToList();
                return city;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

    }
}
