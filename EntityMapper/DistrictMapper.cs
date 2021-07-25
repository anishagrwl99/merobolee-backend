using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class DistrictMapper
    {
        public DistrictEntity DistrictDtoEntity(AddDistrictDto addDistrictDto)
        {if (addDistrictDto == null)
            {
                return null;
            }
            return new DistrictEntity
            {
                District_Name = addDistrictDto.District,
                Province_Id = addDistrictDto.Province_Id

            };

        }

        public GetDistrictDto DistrictEntityToDto(DistrictEntity districtEntity)
        {if (districtEntity == null)
            {
                return null;
            }
            else if (districtEntity.Province_Id == null)
            {
                return new GetDistrictDto 
                {
                    Id = districtEntity.District_Id,
                    District = districtEntity.District_Name,
                    Province_Id = null,
                    Province = null
                };
            }
            return new GetDistrictDto
            {
                Id = districtEntity.District_Id,
                District =districtEntity.District_Name,
                Province_Id = districtEntity.Province_Id,
                Province = districtEntity.Province.Province

            };

        }

        public IEnumerable<GetDistrictDto> DistrictEntityListToDto(IEnumerable<DistrictEntity> districtEntities)
        {

            List<GetDistrictDto> getDistricts = new List<GetDistrictDto>();
            if (districtEntities == null)
            {
                return getDistricts = null;
            }
            foreach (DistrictEntity district in districtEntities)
            {
                getDistricts.Add
                (
                  new GetDistrictDto
                  {
                      Id = district.District_Id,
                      District = district.District_Name,
                      Province_Id = district.Province_Id,
                      Province = district.Province.Province
                  }
                );
            }
            return getDistricts;
        }
    }
}
