using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.Municipality
{
    public class MunicipalityRepository: RepositoryBase<MunicipalityEntity>, IMunicipalityRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public MunicipalityRepository(IUnitOfWork unitOfWork, IDbFactory dbFactory) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;        
        }

        public MunicipalityEntity AddMunicipality(MunicipalityEntity municipalityEntity)
        {
            try
            {
                municipalityEntity.Date_created = municipalityEntity.Date_modified = DateTime.Now;
                meroBoleeDbContexts.MunicipalityEntities.Add(municipalityEntity);
                unitOfWork.SaveChange();
                meroBoleeDbContexts.DistrictEntities.ToList();
                return municipalityEntity;
            }
            catch(Exception )
            {
                throw new Exception();
            }
        }

        public IEnumerable<MunicipalityEntity> CascadeMunicipality(int id)
        {
            try
            {
                meroBoleeDbContexts.DistrictEntities.ToList();
                return meroBoleeDbContexts.MunicipalityEntities.Where(m => m.District_id == id).ToList();
            }
            catch (Exception)
            {
                throw  new Exception();
            }
        }

        public void DeleteMunicipality(int id)
        {
            try
            {
                meroBoleeDbContexts.MunicipalityEntities.Remove(GetMunicipalityDetail(id));
                unitOfWork.SaveChange();
            }
            catch (Exception)
            {
                throw new Exception();   
            }
        }

        public IEnumerable<MunicipalityEntity> GetMunicipality(string search)
        {
            try
            {
                meroBoleeDbContexts.DistrictEntities.ToList();
                return meroBoleeDbContexts.MunicipalityEntities.Where(m => (search == null)
            || (m.Municipality_Name.ToLower().Contains(search.ToLower()))
            ).ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public MunicipalityEntity GetMunicipalityDetail(int id)
        {
            try 
            {
                meroBoleeDbContexts.DistrictEntities.ToList();
            return meroBoleeDbContexts.MunicipalityEntities.Where(m => m.Municipality_id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public MunicipalityEntity UpdateMunicipality(int id, MunicipalityEntity municipalityEntity)
        {
            try
            { 
            MunicipalityEntity municipality = GetMunicipalityDetail(id);
            if (municipality != null)
            {
                municipality.Municipality_Name = municipalityEntity.Municipality_Name;
                municipality.District_id = municipalityEntity.District_id;
                municipality.Date_modified = municipalityEntity.Date_modified;
               // municipality.Modified_time_stamp = municipality.Modified_time_stamp;
                unitOfWork.SaveChange();

            }
                meroBoleeDbContexts.DistrictEntities.ToList();
            return municipality;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
    }
}
