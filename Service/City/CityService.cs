using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Repository.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.City
{
    public class CityService: CityMapper, ICityService
    {
        private readonly ICityRepository CityRepository;
        public CityService(ICityRepository CityRepository)
        {
            this.CityRepository = CityRepository;
        }

        public GetCityDto AddCity(AddCityDto cityDto)
        {     
                return CityEntityToDto(CityRepository.AddCity(CityDtoEntity(cityDto)));
        }

        public IEnumerable<GetCityDto> CascadeCity(int id)
        {
            return CityEntityListToDto(CityRepository.CascadeCity(id));
        }

        public void DeleteCity(int id)
        {
                CityRepository.DeleteCity(id);
        }

        public GetCityDto GetCityDetail(int id)
        {
                return CityEntityToDto(CityRepository.GetCityDetail(id));
        }

        public IEnumerable<GetCityDto> GetCity(string search)
        {
               return CityEntityListToDto(CityRepository.GetCity(search));
        }

        public GetCityDto UpdateCity(int id, AddCityDto cityDto)
        {
                return CityEntityToDto(CityRepository.UpdateCity(id, CityDtoEntity(cityDto)));
        }


    }
}
