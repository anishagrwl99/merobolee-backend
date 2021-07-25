using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.District
{
    public interface IDistrictRepository : IRepositoryBase<DistrictEntity>
    {
        DistrictEntity AddDistrict(DistrictEntity districtEntity);
        IEnumerable<DistrictEntity> GetDistricts(string search);
        DistrictEntity GetDistrictDetail(int id);

        DistrictEntity UpdateDistrict(int id, DistrictEntity districtEntity);
        void DeleteDistrict(int id);

        IEnumerable<DistrictEntity> CascadeDistrict(int countryId);
    }
}
