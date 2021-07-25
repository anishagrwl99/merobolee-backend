using MeroBolee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.Municipality
{
     public interface IMunicipalityService
    {
        GetMunicipalityDto AddMunicipality(AddMunicipalityDto municipalityDto);
        IEnumerable<GetMunicipalityDto> GetMunicipality(string search);
        GetMunicipalityDto GetMunicipalityDetail(int id);
        GetMunicipalityDto UpdateMunicipality(int id, AddMunicipalityDto municipalityDto);
        void DeleteMunicipality(int id);
        IEnumerable<GetMunicipalityDto> CascadeMunicipality(int id);
    }
}
