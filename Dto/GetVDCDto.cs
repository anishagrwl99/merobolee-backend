using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetVDCDto
    {
        private int id;
        private string vdc;
        private int? districtId;
        private string district;

        public int Id { get => id; set => id = value; }
        public string Vdc { get => vdc; set => vdc = value; }
        public int? DistrictId { get => districtId; set => districtId = value; }
        public string District { get => district; set => district = value; }
    }
}
