using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.City
{
    public interface ICityRepository : IRepositoryBase<CityEntity>
    {
        CityEntity AddCity(CityEntity cityEntity);
        IEnumerable<CityEntity> GetCity(string search);
        CityEntity GetCityDetail(int id);

        CityEntity UpdateCity(int id, CityEntity cityEntity);
        void DeleteCity(int id);

        IEnumerable<CityEntity> CascadeCity(int id);
    }
}
