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

        [Required]
        public string Name { get; set; }

        public int CountryId { get; set; }
        public int ProvinceId { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }

        public string Zip { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Compare("ConfirmPassword")]
        [Required]
        public string Password { get; set; }


        [Compare("Password")]
        [Required]
        public string ConfirmPassword { get; set; }
        public bool AgreeTermsAndCondition { get; set; }
    }
}
