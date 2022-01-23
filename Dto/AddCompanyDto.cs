using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{

    public class CompanyCardResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ReferenceCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }

    public class CompanyDetailResponseDto : CompanyCardResponseDto
    {
        public string Province { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Zip { get; set; }
        public string ContactPerson { get; set; }
        public string Website { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string PANNumber { get; set; }
        public DateTime RegisteredDate { get; set; }
    }


    public class AddCompanyDto
    {

        [Required(ErrorMessage = "Company Name is required")]
        [MaxLength(200, ErrorMessage = "Company name can be {1} character long")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "PAN Number is requird")]
        [MaxLength(50, ErrorMessage = "PAN Number can be {1} character long")]
        public string PANNumber { get; set; }

        [Required(ErrorMessage = "Country name is required")]
        [Range(minimum: 1, maximum: Int32.MaxValue, ErrorMessage = "Invalid country name provided")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Province name is required")]
        [Range(minimum:1, maximum: Int32.MaxValue, ErrorMessage = "Invalid province name provided")]
        public int ProvinceId { get; set; }

        [Required(ErrorMessage = "City name is required")]
        [MaxLength(100, ErrorMessage = "City name can be {1} character long")]
        public string City { get; set; }

        [Required(ErrorMessage = "Login user id is required.")]
        [Range(minimum: 1, maximum: long.MaxValue, ErrorMessage = "Invalid user name provided")]
        public long UserId { get; set; }
        
    
        [Required(ErrorMessage = "Address line 1 is required")]
        [MaxLength(50, ErrorMessage = "Address line 1 can be {1} character long")]
        public string Address1 { get; set; }


        [Required(ErrorMessage = "Address line 2 is required")]
        [MaxLength(50, ErrorMessage = "Address line 2 can be {1} character long")]
        public string Address2 { get; set; }

        public string Address3 { get; set; }

        [MaxLength(10, ErrorMessage = "Zip can be {1} character long")]
        public string Zip { get; set; }


        [Required(ErrorMessage = "Contact person name is required")]
        [MaxLength(100, ErrorMessage = "Contact person name can be {1} character long")]
        public string ContactPerson { get; set; }

        [Required(ErrorMessage = "Company email is required")]
        [MaxLength(100, ErrorMessage = "Email can be {1} character long")]
        [EmailAddress(ErrorMessage = "Email should be a valid email address")]
        public string CompanyEmail { get; set; }

        [MaxLength(100, ErrorMessage = "Website can be {1} character long")]
        [Url(ErrorMessage = "Website should be a valid web url address")]
        public string CompanyWebsite { get; set; }

        [Required(ErrorMessage = "Company contact number is required")]
        [MaxLength(10, ErrorMessage = "Contact number can be {1} digit long")]
        public string Phone1 { get; set; }


        [MaxLength(10, ErrorMessage = "Contact number can be {1} digit long")]
        public string Phone2 { get; set; }

    }


    public class AddCompanyResponseDto : AddCompanyDto
    {

        [Required(ErrorMessage = "Company id is required.")]
        [Range(minimum:1, maximum: long.MaxValue, ErrorMessage = "Company id is outside of range. Acceptable range is {1} to {2}")]
        public long CompanyId { get; set; }

        public string ReferenceCode { get; set; }
    }

    public class CompanyDetailResponse: CompanyDetailResponseDto
    {
        public List<UserResponseDto> Users { get; set; }
        public List<TenderCard> Tenders { get; set; }
    }

    public class ChangeCompanyStatusDto
    {
     
        [Required(ErrorMessage = "Company id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid company id")]
        public long CompanyId { get; set; }


        [Required(ErrorMessage = "User id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid user id")]
        public long UserId { get; set; }


        [Required(ErrorMessage = "Status id is required")]
        [Range(1, byte.MaxValue, ErrorMessage = "Invalid status id")]
        public int StatusId { get; set; }
    }

    public class ChangeCompanyStatusResponseDto
    {
        public long CompanyId { get; set; }
        public string Status { get; set; }
    }
    

}
