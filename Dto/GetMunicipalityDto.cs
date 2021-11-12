using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetMunicipalityDto
    {
        private int id;
        private string municipality;
        private int? districtId;
        private string district;

        public int Id { get => id; set => id = value; }
        public string Municipality { get => municipality; set => municipality = value; }
        public int? DistrictId { get => districtId; set => districtId = value; }
        public string District { get => district; set => district = value; }
    }
}
