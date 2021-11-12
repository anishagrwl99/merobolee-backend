using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddMunicipalityDto
    {
        private string municipality;
        private int? districtId;

        public string Municipality { get => municipality; set => municipality = value; }
        public int? DistrictId { get => districtId; set => districtId = value; }
    }
}
