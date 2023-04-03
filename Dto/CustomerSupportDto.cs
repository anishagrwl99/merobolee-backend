using System.ComponentModel.DataAnnotations;

namespace MeroBolee.Dto
{
    public class CustomerSupportDto
    {

        [Required (ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Name can be {1} character long")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Contact number is required")]
        [MaxLength(10, ErrorMessage = "Contact number can be {1} digit long")]
        public string MobileNumber { get; set; }

        [Required (ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Query is required")]
        [MaxLength(5000, ErrorMessage = "Query can be {1} character long")]
        public string Query { get; set; }
    }
}
