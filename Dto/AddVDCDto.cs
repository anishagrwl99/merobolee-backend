using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddVDCDto
    {
        private string vdc;
        private int? district_Id;

        public string Vdc { get => vdc; set => vdc = value; }
        public int? District_Id { get => district_Id; set => district_Id = value; }
    }
}
