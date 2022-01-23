using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetDistrictDto
    {
        public int Id { get; set; }

       
        public string District { get; set; }

        
        public int? ProvinceId { get; set; }

       
        public string Province { get; set; }
    }
}
