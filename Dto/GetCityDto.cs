using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetCityDto
    {
        private int id;
        private string city;
        private int? municipalityId;
        private string municipality;
        private int? vdcId;
        private string vdc;


        public int Id { get => id; set => id = value; }

        
        public string City { get => city; set => city = value; }

      
        public int? Municipality_Id { get => municipalityId; set => municipalityId = value; }

        
        public string Municipality { get => municipality; set => municipality = value; }

        
        public int? VDCId { get => vdcId; set => vdcId = value; }

        
        public string Vdc { get => vdc; set => vdc = value; }

        
    }
}
