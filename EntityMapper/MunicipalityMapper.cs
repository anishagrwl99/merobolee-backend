using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class MunicipalityMapper
    {
        public MunicipalityEntity MunicipalityDtoEntity(AddMunicipalityDto addMunicipality)
        {
            if (addMunicipality == null)
            {
                return null;
            }
            return new MunicipalityEntity
            {
                MunicipalityName = addMunicipality.Municipality,
                DistrictId= addMunicipality.DistrictId
            };

        }

        public GetMunicipalityDto MunicipalityEntityToDto(MunicipalityEntity municipalityEntity)
        {
            if (municipalityEntity == null)
            {
                return null;
            }
            else if (municipalityEntity.DistrictId==  null)
            {
                return new GetMunicipalityDto
                {
                    Id= municipalityEntity.MunicipalityId,
                    Municipality= municipalityEntity.MunicipalityName,
                    DistrictId= null,
                    District=null
                };
            }

            return new GetMunicipalityDto
            {
                Id = municipalityEntity.MunicipalityId,
                Municipality = municipalityEntity.MunicipalityName,
                DistrictId= municipalityEntity.DistrictId,
                District= municipalityEntity.District.Name
            };

        }

        public IEnumerable<GetMunicipalityDto> MunicipalityEntityListToDto(IEnumerable<MunicipalityEntity> municipalityEntities)
        {

            List<GetMunicipalityDto> getMunicipalities = new List<GetMunicipalityDto>();
            if (municipalityEntities == null)
            {
                return getMunicipalities = null;
            }
            foreach (MunicipalityEntity municipalityEntity in municipalityEntities)
            {
                getMunicipalities.Add
                (
                  new GetMunicipalityDto
                  {
                      Id = municipalityEntity.MunicipalityId,
                      Municipality = municipalityEntity.MunicipalityName,
                      DistrictId = municipalityEntity.DistrictId,
                      District = municipalityEntity.District.Name
                  }
                );
            }
            return getMunicipalities;
        }
    }
}
