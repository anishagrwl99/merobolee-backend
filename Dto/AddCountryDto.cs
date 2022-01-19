using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddCountryDto
    {
        [Required(ErrorMessage = "Country name is required")]
        [MaxLength(30, ErrorMessage = "Country name can be {1} characters long")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Country code is required")]
        [MaxLength(10, ErrorMessage = "Country code can be {1} character long")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Country code is required")]
        [MaxLength(3, ErrorMessage = "Country code can be {1} character long")]
        public string Abrre { get; set; }
    }
    
}
