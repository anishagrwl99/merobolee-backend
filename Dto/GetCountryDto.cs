using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetCountryDto
    {
        private int id;
        public int Id { get => id; set => id = value; }
         
        private string country;
        public string Country { get => country; set => country = value; }
        
        private string code;
        public string Code { get => code; set => code = value; }
        
        private string abbre;
        public string Abrre { get => abbre; set => abbre = value; }
    }
}
