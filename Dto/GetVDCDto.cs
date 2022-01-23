using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetVDCDto
    {
        public int Id { get; set; }
        public string Vdc { get; set; }
        public int? DistrictId { get; set; }
        public string District { get; set; }
    }
}
