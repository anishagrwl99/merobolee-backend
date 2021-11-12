using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetCompanyTypeDto
    {
        private int id;
        private string companytype;
        public int Id { get => id; set => id = value; }
        public string CompanyType { get => companytype; set => companytype = value; }
    }
}
