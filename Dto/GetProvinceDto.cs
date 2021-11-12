using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetProvinceDto
    {
        private int id;
        private string province;
        private int? country_id;
        private string country;

        public int Id { get => id; set => id = value; }

        
        public string Province { get => province; set => province = value; }

        
        public int? CountryId { get => country_id; set => country_id = value; }

        
        public string Country { get => country; set => country = value; }

    }
}
