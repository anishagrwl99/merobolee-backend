using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddProvinceDto
    {
        private string province;
        public string Province { get => province; set => province = value; }

        private int country_id;
        public int Country_id { get => country_id; set => country_id = value; }
    }
}
