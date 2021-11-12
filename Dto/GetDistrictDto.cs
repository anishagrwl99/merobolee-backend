using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetDistrictDto
    {
        private int id;
        private string district;
        private int? province_Id;
        private string province;


        public int Id { get => id; set => id = value; }

       
        public string District { get => district; set => district = value; }

        
        public int? ProvinceId { get => province_Id; set => province_Id = value; }

       
        public string Province { get => province; set => province = value; }
    }
}
