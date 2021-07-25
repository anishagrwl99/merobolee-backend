using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddMunicipalityDto
    {
        private string municipality;
        private int? district_Id;

        public string Municipality { get => municipality; set => municipality = value; }
        public int? District_Id { get => district_Id; set => district_Id = value; }
    }
}
