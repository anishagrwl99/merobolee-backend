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

        public string Name { get; set; }

        [Required(ErrorMessage = "PAN Number is required")]
        public string PANNumber { get; set; }

        [Required(ErrorMessage = "Country name is required")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Province name is required")]
        public int ProvinceId { get; set; }

        [Required(ErrorMessage = "City name is required")]
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }

        public string Zip { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Valid email address is required")]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }

        [Compare("ConfirmPassword", ErrorMessage = "Password and confirmation password should match")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }


        [Compare("Password", ErrorMessage = "Password and confirmation password should match")]
        [Required(ErrorMessage = "Confirmation password is required")]
        public string ConfirmPassword { get; set; }

        [Range(typeof(bool), "true", "true")]
        public bool AgreeTermsAndCondition { get; set; }
    }
}
