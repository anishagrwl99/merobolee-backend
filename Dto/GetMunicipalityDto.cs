using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetMunicipalityDto
    {
        private int id;
        private string municipality;
        private int? district_Id;
        private string district;

        public int Id { get => id; set => id = value; }
        public string Municipality { get => municipality; set => municipality = value; }
        public int? District_Id { get => district_Id; set => district_Id = value; }
        public string District { get => district; set => district = value; }
    }
}
