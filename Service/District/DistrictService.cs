using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Repository.District;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.District
{
    public class DistrictService :DistrictMapper,IDistrictService
    {
        private readonly IDistrictRepository DistrictRepository;
        public DistrictService(IDistrictRepository DistrictRepository)
        {
            this.DistrictRepository = DistrictRepository;
        }

        public GetDistrictDto AddDistrict(AddDistrictDto districtDto)
        {
                return DistrictEntityToDto(DistrictRepository.AddDistrict(DistrictDtoEntity(districtDto)));
        }

        public IEnumerable<GetDistrictDto> CascadeDistrict(int provinceId)
        {
                return DistrictEntityListToDto(DistrictRepository.CascadeDistrict(provinceId));
        }

        public void DeleteDistrict(int id)
        {
                DistrictRepository.DeleteDistrict(id);
        }

        public GetDistrictDto GetDistrictDetail(int id)
        {
                return DistrictEntityToDto(DistrictRepository.GetDistrictDetail(id));
        }

        public IEnumerable<GetDistrictDto> GetDistricts(string search)
        {
                return DistrictEntityListToDto(DistrictRepository.GetDistricts(search));
        }

        public GetDistrictDto UpdateDistrict(int id, AddDistrictDto districtDto)
        {
                return DistrictEntityToDto(DistrictRepository.UpdateDistrict(id, DistrictDtoEntity(districtDto)));
        }

    }
}
