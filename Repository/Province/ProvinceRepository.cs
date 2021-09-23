using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.Province
{
    public class ProvinceRepository: RepositoryBase<ProvinceEntity>, IProvinceRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public ProvinceRepository(IDbFactory dbFactory,IUnitOfWork unitOfWork ): base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public ProvinceEntity AddProvince(ProvinceEntity provinceEntity)
        {
            try
            {
                provinceEntity.Date_created = provinceEntity.Date_modified = DateTime.Now;
                if (meroBoleeDbContexts.CountryEntities.Find(provinceEntity.Country_Id) == null)
                {
                    provinceEntity.Country_Id = 0;
                    return provinceEntity;
                }
                meroBoleeDbContexts.ProvinceEntities.Add(provinceEntity);
                unitOfWork.SaveChange();
                meroBoleeDbContexts.CountryEntities.ToList();
                return provinceEntity;
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

        public IEnumerable<ProvinceEntity> CascadeProvince(int countryId)
        {
            try
            {
                meroBoleeDbContexts.CountryEntities.ToList();
                return meroBoleeDbContexts.ProvinceEntities.Where(m => m.Country_Id == countryId).ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void DeleteProvince(int id)
        {
            try
            {
                meroBoleeDbContexts.ProvinceEntities.Remove(GetProvinceDetail(id));
                unitOfWork.SaveChange();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public ProvinceEntity GetProvinceDetail(int id)
        {
            try
            {
                ProvinceEntity province = meroBoleeDbContexts.ProvinceEntities.Find(id);
                if (province == null)
                {
                    return province=null;
                }
                meroBoleeDbContexts.CountryEntities.ToList();
                return province;
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

        public IEnumerable<ProvinceEntity> GetProvinces(string search)
        {
            try
            {
                meroBoleeDbContexts.CountryEntities.ToList();
                List<ProvinceEntity> provinces=  meroBoleeDbContexts.ProvinceEntities.Where(m => (search == null)
                || (m.Province.ToLower().Contains(search.ToLower()))
                ).ToList();
                return provinces;
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

        public ProvinceEntity UpdateProvince(int id, ProvinceEntity provinceEntity)
        {
            try
            {
                ProvinceEntity province = GetProvinceDetail(id);
                if (province == null)
                {
                    return province = null;
                }
                if (meroBoleeDbContexts.CountryEntities.Find(provinceEntity.Country_Id) == null)
                {
                    provinceEntity.Country_Id = 0;
                    return provinceEntity;
                }
                
                province.Province = provinceEntity.Province;
                province.Country_Id = provinceEntity.Country_Id;
                province.Date_modified = provinceEntity.Date_modified;
              //  province.Modified_time_stamp = provinceEntity.Modified_time_stamp;
                unitOfWork.SaveChange();

                meroBoleeDbContexts.CountryEntities.ToList();
                return province;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
    }
}
