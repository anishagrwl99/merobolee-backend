using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class VDCMapper
    {
        public VDCEntity VDCDtoEntity(AddVDCDto addVDC)
        {
            if (addVDC == null)
            {
                return null;
            }
            return new VDCEntity
            {
                Name = addVDC.Vdc,
                DistrictId = addVDC.DistrictId
            };

        }

        public GetVDCDto VDCEntityToDto(VDCEntity vdcEntity)
        {
            if (vdcEntity == null)
            {
                return null;
            }
            else if (vdcEntity.DistrictId == null)
            {
                return new GetVDCDto
                {
                    Id = vdcEntity.Id,
                    Vdc = vdcEntity.Name,
                    DistrictId = null,
                    District = null
                };
            }

            return new GetVDCDto
            {
                Id = vdcEntity.Id,
                Vdc = vdcEntity.Name,
                DistrictId = vdcEntity.DistrictId,
                District = vdcEntity.District.Name
            };

        }

        public IEnumerable<GetVDCDto> VDCEntityListToDto(IEnumerable<VDCEntity> vdcEntities)
        {

            List<GetVDCDto> getVDC = new List<GetVDCDto>();
            if (vdcEntities == null)
            {
                return getVDC = null;
            }
            foreach (VDCEntity vdcEntity in vdcEntities)
            {
                getVDC.Add
                (
                  new GetVDCDto
                  {
                      Id = vdcEntity.Id,
                      Vdc = vdcEntity.Name,
                      DistrictId = vdcEntity.DistrictId,
                      District = vdcEntity.District.Name
                  }
                );
            }
            return getVDC;
        }
    }
}
