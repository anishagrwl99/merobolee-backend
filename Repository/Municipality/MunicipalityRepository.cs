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
                meroBoleeDbContexts.MunicipalityEntities.Add(municipalityEntity);
                unitOfWork.SaveChange();
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
                municipality.Date_modified = municipalityEntity.Date_modified;
                municipality.Modified_time_stamp = municipality.Modified_time_stamp;
                unitOfWork.SaveChange();

            }
            return municipality;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
    }
}
