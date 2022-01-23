using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddVDCDto
    {

        [Required(ErrorMessage = "VDC is required")]
        [MinLength(100, ErrorMessage = "VDC can be {1} character long")]
        public string Vdc { get; set; }

        [Required(ErrorMessage = "District Id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid district Id")]
        public int? DistrictId { get; set; }
    }
}
