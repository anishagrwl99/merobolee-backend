using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.Municipality
{
     public interface IMunicipalityRepository : IRepositoryBase<MunicipalityEntity>
    {
        MunicipalityEntity AddMunicipality(MunicipalityEntity municipalityEntity);
        IEnumerable<MunicipalityEntity> GetMunicipality(string search);
        MunicipalityEntity GetMunicipalityDetail(int id);

        MunicipalityEntity UpdateMunicipality(int id, MunicipalityEntity municipalityEntity);
        void DeleteMunicipality(int id);

        IEnumerable<MunicipalityEntity> CascadeMunicipality(int id);
    }
}
