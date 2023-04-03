using System.ComponentModel.DataAnnotations;

namespace MeroBolee.Dto
{
    public class AddCompanyTypeDto
    {

        [Required(ErrorMessage = "Company type is required")]
        [MaxLength(50, ErrorMessage = "Company type can be {1} character long")]
        public string CompanyType { get; set; }
    }
}
