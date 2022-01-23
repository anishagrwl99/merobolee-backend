using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetProvinceDto
    {
        public int Id { get; set; }

        
        public string Province { get; set; }

        
        public int? CountryId { get; set; }

        
        public string Country { get; set; }

    }
}
