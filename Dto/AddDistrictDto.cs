using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddDistrictDto
    {
        private string district;
        private int provinceId;


        public string District { get => district; set => district = value; }

        
        public int ProvinceId { get => provinceId; set => provinceId = value; }

    }
}
