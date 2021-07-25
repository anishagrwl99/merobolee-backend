using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetCompanyTypeDto
    {
        private int id;
        private string company_type;
        public int Id { get => id; set => id = value; }
        public string Company_type { get => company_type; set => company_type = value; }
    }
}
