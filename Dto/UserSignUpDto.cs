using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class UserSignUpDto
    {
        //public int CompanyId { get; set; }

        [Required(ErrorMessage = "Company name is required")]
        [MaxLength(1500, ErrorMessage = "Company name can be {1} characters long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "PAN Number is required")]
        [MaxLength(50, ErrorMessage = "PAN Number can be {1} characters long")]
        public string PANNumber { get; set; }

        [Required(ErrorMessage = "Country id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid country id")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Province name is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid province id")]
        public int ProvinceId { get; set; }

        [Required(ErrorMessage = "City name is required")]
        [MaxLength(100, ErrorMessage = "City name can be {1} characters long")]
        public string City { get; set; }


        [Required(ErrorMessage = "Address1 is required")]
        [MaxLength(300, ErrorMessage = "Address1 can be {1} characters long")]
        public string Address1 { get; set; }

        [Required(ErrorMessage = "Address2 is required")]
        [MaxLength(300, ErrorMessage = "Address1 can be {1} characters long")]
        public string Address2 { get; set; }
        public string Address3 { get; set; }


        [Required(ErrorMessage = "Zip is required")]
        [MaxLength(30, ErrorMessage = "Zip can be {1} characters long")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [MaxLength(100, ErrorMessage = "First name can be {1} characters long")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(100, ErrorMessage = "Last name can be {1} characters long")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Valid email address is required")]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }

        [Compare("ConfirmPassword", ErrorMessage = "Password and confirmation password should match")]
        [Required(ErrorMessage = "Password is required")]
        [MaxLength(8, ErrorMessage = "Password can be {1} characters long")]
        [MinLength(6, ErrorMessage = "Password should be {1} characters long")]
        public string Password { get; set; }


        [Compare("Password", ErrorMessage = "Password and confirmation password should match")]
        [Required(ErrorMessage = "Confirmation password is required")]
        [MaxLength(8, ErrorMessage = "Confirmation password can be {1} characters long")]
        [MinLength(6, ErrorMessage = "Confirmation password should be {1} characters long")]
        public string ConfirmPassword { get; set; }

        [Range(typeof(bool), "true", "true")]
        public bool AgreeTermsAndCondition { get; set; }
    }
}
