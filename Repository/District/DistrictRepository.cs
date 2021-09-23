using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.District
{
    public class DistrictRepository : RepositoryBase<DistrictEntity>, IDistrictRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public DistrictRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public DistrictEntity AddDistrict(DistrictEntity districtEntity)
        {
            try
            {
                districtEntity.Date_created = districtEntity.Date_modified = DateTime.Now;
                if (meroBoleeDbContexts.ProvinceEntities.Find(districtEntity.Province_Id) == null)
                {
                    districtEntity.Province_Id = 0;
                    return districtEntity;
                }
                meroBoleeDbContexts.DistrictEntities.Add(districtEntity);
                unitOfWork.SaveChange();
                meroBoleeDbContexts.ProvinceEntities.ToList();
                return districtEntity;
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

        public IEnumerable<DistrictEntity> CascadeDistrict(int provinceId)
        {
            try
            {
                meroBoleeDbContexts.ProvinceEntities.ToList();
                return meroBoleeDbContexts.DistrictEntities.Where(m => m.Province_Id == provinceId).ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void DeleteDistrict(int id)
        {
            try
            {
                meroBoleeDbContexts.DistrictEntities.Remove(GetDistrictDetail(id));
                unitOfWork.SaveChange();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public DistrictEntity GetDistrictDetail(int id)
        {
            try
            {
                DistrictEntity District = meroBoleeDbContexts.DistrictEntities.Find(id);
                if (District == null)
                {
                    return District = null;
                }
                meroBoleeDbContexts.ProvinceEntities.ToList();
                return District;
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

        public IEnumerable<DistrictEntity> GetDistricts(string search)
        {
            try
            {
                meroBoleeDbContexts.ProvinceEntities.ToList();
                return meroBoleeDbContexts.DistrictEntities.Where(m => (search == null)
                || (m.District_Name.ToLower().Contains(search.ToLower()))
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

        public DistrictEntity UpdateDistrict(int id, DistrictEntity districtEntity)
        {
            try
            {
                DistrictEntity district = GetDistrictDetail(id);
                if (district == null)
                {
                    return district = null;
                }
                if (meroBoleeDbContexts.ProvinceEntities.Find(districtEntity.Province_Id) == null)
                {
                    districtEntity.Province_Id = 0;
                    return districtEntity;
                }
                
                district.District_Name = districtEntity.District_Name;
                district.Province_Id = districtEntity.Province_Id;
               // district.Modified_time_stamp = districtEntity.Modified_time_stamp;
                district.Date_modified = districtEntity.Date_modified;
                unitOfWork.SaveChange();
                meroBoleeDbContexts.ProvinceEntities.ToList();
                return district;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

    }
}
