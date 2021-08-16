using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.VDC
{
    public class VDCRepository : RepositoryBase<VDCEntity>, IVDCRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public VDCRepository(IUnitOfWork unitOfWork, IDbFactory dbFactory) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public VDCEntity AddVDC(VDCEntity vdcEntity)
        {
            try
            {
                meroBoleeDbContexts.VDCEntities.Add(vdcEntity);
                unitOfWork.SaveChange();
                meroBoleeDbContexts.DistrictEntities.ToList();
                return vdcEntity;
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }

        public IEnumerable<VDCEntity> CascadeVDC(int id)
        {
            try
            {
                meroBoleeDbContexts.DistrictEntities.ToList();
              return  meroBoleeDbContexts.VDCEntities.Where(m => m.District_Id == id).ToList();
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public void DeleteVDC(int id)
        {
            try
            {
                meroBoleeDbContexts.VDCEntities.Remove(GetVDCDetail(id));
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public IEnumerable<VDCEntity> GetVDC(string search)
        {
            try
            {
                meroBoleeDbContexts.DistrictEntities.ToList();
                return meroBoleeDbContexts.VDCEntities.Where(m => (search == null)
                || (m.Vdc_Name.ToLower().Contains(search.ToLower())))
                .ToList();

            }
            catch (Exception)
            {
               throw new Exception();
            }
        }

        public VDCEntity GetVDCDetail(int id)
        {
            try
            {
                meroBoleeDbContexts.DistrictEntities.ToList();
                return meroBoleeDbContexts.VDCEntities.Where(m => m.Vdc_Id == id).FirstOrDefault();
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public VDCEntity UpdateVDC(int id, VDCEntity vdcEntity)
        {
            try
            {
                VDCEntity vdc = GetVDCDetail(id);
                if(vdc!=null)
                {
                    vdc.Vdc_Name = vdcEntity.Vdc_Name;
                    vdc.District_Id = vdcEntity.District_Id;
                    vdc.Date_modified = vdcEntity.Date_modified;
                   // vdc.Modified_time_stamp = vdcEntity.Modified_time_stamp;
                    unitOfWork.SaveChange();
                }
                meroBoleeDbContexts.DistrictEntities.ToList();
                return vdc;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
