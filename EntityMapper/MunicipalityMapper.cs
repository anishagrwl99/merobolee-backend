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
                Municipality_Name = addMunicipality.Municipality,
                District_id= addMunicipality.District_Id
            };

        }

        public GetMunicipalityDto MunicipalityEntityToDto(MunicipalityEntity municipalityEntity)
        {
            if (municipalityEntity == null)
            {
                return null;
            }
            else if (municipalityEntity.District_id==  null)
            {
                return new GetMunicipalityDto
                {
                    Id= municipalityEntity.Municipality_id,
                    Municipality= municipalityEntity.Municipality_Name,
                    District_Id= null,
                    District=null
                };
            }

            return new GetMunicipalityDto
            {
                Id = municipalityEntity.Municipality_id,
                Municipality = municipalityEntity.Municipality_Name,
                District_Id= municipalityEntity.District_id,
                District= municipalityEntity.District.District_Name
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
                      Id = municipalityEntity.Municipality_id,
                      Municipality = municipalityEntity.Municipality_Name,
                      District_Id = municipalityEntity.District_id,
                      District = municipalityEntity.District.District_Name
                  }
                );
            }
            return getMunicipalities;
        }
    }
}
