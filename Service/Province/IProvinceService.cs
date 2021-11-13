using MeroBolee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public interface IProvinceService
    {
        GetProvinceDto AddProvince(AddProvinceDto provinceDto);
        IEnumerable<GetProvinceDto> GetProvinces(string search);
        GetProvinceDto GetProvinceDetail(int id);

        GetProvinceDto UpdateProvince(int id, AddProvinceDto provinceDto);
        void DeleteProvince(int id);

        IEnumerable<GetProvinceDto> CascadeProvince(int countryId);
    }
}
