using System.ComponentModel.DataAnnotations;

namespace MeroBolee.Dto
{
    public class AddCityDto
    {
        [Required(ErrorMessage = "City name is required")]
        [MaxLength(100, ErrorMessage = "City name can be {1} characters long")]
        public string City { get; set; }


        [Required(ErrorMessage = "Municipality Id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid municipality id")]
        public int? MunicipalityId { get; set; }


        [Required(ErrorMessage = "VDC Id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid VDC Id")]
        public int? VDCId { get; set; }

    }
}
