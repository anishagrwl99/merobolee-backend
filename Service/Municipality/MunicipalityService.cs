using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Repository.Municipality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.Municipality
{
    public class MunicipalityService : MunicipalityMapper,IMunicipalityService
    {
        private readonly IMunicipalityRepository municipalityRepository;
        public MunicipalityService(IMunicipalityRepository municipalityRepository)
        {
            this.municipalityRepository = municipalityRepository;
        }

        public GetMunicipalityDto AddMunicipality(AddMunicipalityDto municipalityDto)
        {
            return MunicipalityEntityToDto(municipalityRepository.AddMunicipality(MunicipalityDtoEntity(municipalityDto)));
        }

        public IEnumerable<GetMunicipalityDto> CascadeMunicipality(int id)
        {
            return MunicipalityEntityListToDto(municipalityRepository.CascadeMunicipality(id));
        }

        public void DeleteMunicipality(int id)
        {
            municipalityRepository.DeleteMunicipality(id);
        }

        public GetMunicipalityDto GetMunicipalityDetail(int id)
        {
            return MunicipalityEntityToDto(municipalityRepository.GetMunicipalityDetail(id));
        }

        public IEnumerable<GetMunicipalityDto> GetMunicipality(string search)
        {
            return MunicipalityEntityListToDto(municipalityRepository.GetMunicipality(search));
        }

        public GetMunicipalityDto UpdateMunicipality(int id, AddMunicipalityDto municipalityDto)
        {
            return MunicipalityEntityToDto(municipalityRepository.UpdateMunicipality(id, MunicipalityDtoEntity(municipalityDto)));
        }


    }
}
