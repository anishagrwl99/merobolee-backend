using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddDistrictDto
    {
        [Required(ErrorMessage = "District name is required")]
        [MaxLength(100, ErrorMessage = "District name can be {1} character long")]
        public string District { get; set; }

        [Required(ErrorMessage = "Province Id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid province Id")]
        public int ProvinceId { get; set; }

    }
}
