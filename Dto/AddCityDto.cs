using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddCityDto
    {
        private string city;
        private int? municipalityId;
        private int? vdcId;


        public string City { get => city; set => city = value; }
        
        public int? MunicipalityId { get => municipalityId; set => municipalityId = value; }
        
        public int? VDCId { get => vdcId; set => vdcId = value; }

    }
}
