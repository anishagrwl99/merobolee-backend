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
                Vdc_Name = addVDC.Vdc,
                District_Id = addVDC.DistrictId
            };

        }

        public GetVDCDto VDCEntityToDto(VDCEntity vdcEntity)
        {
            if (vdcEntity == null)
            {
                return null;
            }
            else if (vdcEntity.District_Id == null)
            {
                return new GetVDCDto
                {
                    Id = vdcEntity.Vdc_Id,
                    Vdc = vdcEntity.Vdc_Name,
                    DistrictId = null,
                    District = null
                };
            }

            return new GetVDCDto
            {
                Id = vdcEntity.Vdc_Id,
                Vdc = vdcEntity.Vdc_Name,
                DistrictId = vdcEntity.District_Id,
                District = vdcEntity.District.District_Name
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
                      Id = vdcEntity.Vdc_Id,
                      Vdc = vdcEntity.Vdc_Name,
                      DistrictId = vdcEntity.District_Id,
                      District = vdcEntity.District.District_Name
                  }
                );
            }
            return getVDC;
        }
    }
}
