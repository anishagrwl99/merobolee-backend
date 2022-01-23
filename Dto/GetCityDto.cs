using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetCityDto
    {
        public int Id { get; set; }

        
        public string City { get; set; }

      
        public int? Municipality_Id { get; set; }

        
        public string Municipality { get; set; }

        
        public int? VDCId { get; set; }

        
        public string Vdc { get; set; }

        
    }
}
