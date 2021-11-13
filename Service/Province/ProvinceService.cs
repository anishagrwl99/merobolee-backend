using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public class ProvinceService:ProvinceMapper ,IProvinceService
    {
        private readonly IProvinceRepository provinceRepository;
        public ProvinceService(IProvinceRepository provinceRepository)
        {
            this.provinceRepository = provinceRepository;
        }

        public GetProvinceDto AddProvince(AddProvinceDto provinceDto)
        {
            return ProvinceEntityToDto(provinceRepository.AddProvince(ProvinceDtoEntity(provinceDto)));
        }

        public IEnumerable<GetProvinceDto> CascadeProvince(int countryId)
        {
                return ProvinceEntityListToDto(provinceRepository.CascadeProvince(countryId));
        }

        public void DeleteProvince(int id)
        {
                provinceRepository.DeleteProvince(id);
        }

        public GetProvinceDto GetProvinceDetail(int id)
        {
                return ProvinceEntityToDto(provinceRepository.GetProvinceDetail(id));
        }

        public IEnumerable<GetProvinceDto> GetProvinces(string search)
        {
                return ProvinceEntityListToDto(provinceRepository.GetProvinces(search));
        }

        public GetProvinceDto UpdateProvince(int id, AddProvinceDto provinceDto)
        {
                return ProvinceEntityToDto(provinceRepository.UpdateProvince(id, ProvinceDtoEntity(provinceDto) ));
        }
    }
}
