using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetCityDto
    {
        private int id;
        public int Id { get => id; set => id = value; }

        private string city;
        public string City { get => city; set => city = value; }

        private int? municipality_Id;
        public int? Municipality_Id { get => municipality_Id; set => municipality_Id = value; }

        private string municipality;
        public string Municipality { get => municipality; set => municipality = value; }

        private int? vdc_Id;
        public int? VDC_Id { get => vdc_Id; set => vdc_Id = value; }

        private string vdc;
        public string Vdc { get => vdc; set => vdc = value; }

        
    }
}
