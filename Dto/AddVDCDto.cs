using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddVDCDto
    {
        private string vdc;
        private int? districtId;

        public string Vdc { get => vdc; set => vdc = value; }
        public int? DistrictId { get => districtId; set => districtId = value; }
    }
}
