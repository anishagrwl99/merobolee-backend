using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddProvinceDto
    {
        private string province;
        private int countryid;

        public string Province { get => province; set => province = value; }

        
        public int CountryId { get => countryid; set => countryid = value; }
    }
}
