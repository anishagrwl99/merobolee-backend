using MeroBolee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.District
{
    public interface IDistrictService
    {
        GetDistrictDto AddDistrict(AddDistrictDto districtDto);
        IEnumerable<GetDistrictDto> GetDistricts(string search);
        GetDistrictDto GetDistrictDetail(int id);

        GetDistrictDto UpdateDistrict(int id, AddDistrictDto districtDto);
        void DeleteDistrict(int id);

        IEnumerable<GetDistrictDto> CascadeDistrict(int provinceId);
    }
}
