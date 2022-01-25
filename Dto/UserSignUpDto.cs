using MeroBolee.Attribute;
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
        [RegularExpression("^[0-9]{9}", ErrorMessage = "PAN Number should be 9 digit long")]
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

        [MaxLength(300, ErrorMessage = "Address1 can be {1} characters long")]
        public string Address2 { get; set; }

        [MaxLength(300, ErrorMessage = "Address1 can be {1} characters long")]
        public string Address3 { get; set; }


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
        [MinLength(8, ErrorMessage = "Password should be {1} characters long")]
        [Password(MinLength =8, MaxLength = 500, ErrorMessage = "Password must contain at least one upper case, lower case, number and special character")]
        public string Password { get; set; }


        [Compare("Password", ErrorMessage = "Password and confirmation password should match")]
        [Required(ErrorMessage = "Confirmation password is required")]
        [MinLength(8, ErrorMessage = "Confirmation password should be {1} characters long")]
        [Password(MinLength = 8, MaxLength = 500, ErrorMessage = "Password must contain at least one upper case, lower case, number and special character")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Mobile number is required.")]
        [RegularExpression("^[0-9]{10}", ErrorMessage = "Mobile number should be 10 digit long")]
        public string MobileNo { get; set; }

        [RegularExpression("^[0-9]", ErrorMessage = "Phone number should be numeric only")]
        public string PhoneNo { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept terms and conditions")]
        public bool AgreeTermsAndCondition { get; set; }
    }
}
