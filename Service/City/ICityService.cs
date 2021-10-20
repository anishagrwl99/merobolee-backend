using MeroBolee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.City
{
    public interface ICityService
    {
        GetCityDto AddCity(AddCityDto cityDto);
        IEnumerable<GetCityDto> GetCity(string search);
        GetCityDto GetCityDetail(int id);
        GetCityDto UpdateCity(int id, AddCityDto cityDto);
        void DeleteCity(int id);
        IEnumerable<GetCityDto> CascadeCity(int id);
    }
}
