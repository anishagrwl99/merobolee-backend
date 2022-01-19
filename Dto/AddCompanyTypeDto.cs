using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddCompanyTypeDto
    {

        [Required(ErrorMessage = "Company type is required")]
        [MaxLength(50, ErrorMessage = "Company type can be {1} character long")]
        public string CompanyType { get; set; }
    }
}
