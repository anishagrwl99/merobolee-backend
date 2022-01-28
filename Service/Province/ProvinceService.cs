using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Model;
using MeroBolee.Repository;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public class ProvinceService:ProvinceMapper ,IProvinceService
    {
        private readonly IProvinceRepository provinceRepository;
        private readonly IMemoryCache memoryCache;

        public ProvinceService(IProvinceRepository provinceRepository, IMemoryCache memoryCache)
        {
            this.provinceRepository = provinceRepository;
            this.memoryCache = memoryCache;
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

        public IEnumerable<GetProvinceDto> GetProvinces()
        {
            string key = "AllProvince";
            IEnumerable<ProvinceEntity> provinces = null;
            memoryCache.TryGetValue<IEnumerable<ProvinceEntity>>(key, out provinces);
            if (provinces == null)
            {
                provinces = provinceRepository.GetProvinces();
                memoryCache.Set(key, provinces, DateTime.Now.AddDays(7));
            }

            return ProvinceEntityListToDto(provinces);
        }

        public GetProvinceDto UpdateProvince(int id, AddProvinceDto provinceDto)
        {
                return ProvinceEntityToDto(provinceRepository.UpdateProvince(id, ProvinceDtoEntity(provinceDto) ));
        }
    }
}
