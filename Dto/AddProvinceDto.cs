using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddProvinceDto
    {
        [Required(ErrorMessage = "Province name is required")]
        [MaxLength(100, ErrorMessage = "Province name can be {1} character long")]
        public string Province { get; set; }


        [Required(ErrorMessage = "Country Id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid country Id")]
        public int CountryId { get; set; }
    }
}
