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
                Name = addDistrictDto.District,
                ProvinceId = addDistrictDto.ProvinceId

            };

        }

        public GetDistrictDto DistrictEntityToDto(DistrictEntity districtEntity)
        {if (districtEntity == null)
            {
                return null;
            }
            else if (districtEntity.ProvinceId == null)
            {
                return new GetDistrictDto 
                {
                    Id = districtEntity.Id,
                    District = districtEntity.Name,
                    ProvinceId = null,
                    Province = null
                };
            }
            return new GetDistrictDto
            {
                Id = districtEntity.Id,
                District =districtEntity.Name,
                ProvinceId = districtEntity.ProvinceId,
                Province = districtEntity.Province.Name

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
                      Id = district.Id,
                      District = district.Name,
                      ProvinceId = district.ProvinceId,
                      Province = district.Province.Name
                  }
                );
            }
            return getDistricts;
        }
    }
}
