using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddDistrictDto
    {
        private string district;
        public string District { get => district; set => district = value; }

        private int province_Id;
        public int Province_Id { get => province_Id; set => province_Id = value; }

    }
}
