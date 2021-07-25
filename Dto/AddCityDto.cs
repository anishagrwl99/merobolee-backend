using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddCityDto
    {
        private string city;
        public string City { get => city; set => city = value; }

        private int? municipality_Id;
        public int? Municipality_Id { get => municipality_Id; set => municipality_Id = value; }

        private int? vdc_Id;
        public int? VDC_Id { get => vdc_Id; set => vdc_Id = value; }

    }
}
