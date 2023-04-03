using System.ComponentModel.DataAnnotations;

namespace MeroBolee.Dto
{
    public class AddMunicipalityDto
    {
        [Required(ErrorMessage = "Municipality name is required")]
        [MaxLength(100, ErrorMessage = "Municipality name can be {1} character long")]
        public string Municipality { get; set; }

        [Required(ErrorMessage = "District Id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid district Id")]
        public int? DistrictId { get; set; }
    }
}
