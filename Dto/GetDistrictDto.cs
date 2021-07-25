using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetDistrictDto
    {
        private int id;
        public int Id { get => id; set => id = value; }

        private string district;
        public string District { get => district; set => district = value; }

        private int? province_Id;
        public int? Province_Id { get => province_Id; set => province_Id = value; }

        private string province;
        public string Province { get => province; set => province = value; }
    }
}
