using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{

    public class UserDetailDto : UpdateUserDto
    {
        public List<CompanyDto> Companies { get; set; }

        public string ProfilePicture { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? ActivationDate { get; set; }

        
    }

    public class UpdateUserDto
    {
        [Required(ErrorMessage = "User id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid user id")]
        public long Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [MaxLength(100, ErrorMessage = "First name can be {1} characters long")]
        public string FirstName { get; set; }

        
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(100, ErrorMessage = "Last name can be {1} characters long")]
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Designation { get; set; }
    }
    public class AddUserDto
    {

        [Required(ErrorMessage = "First name is required")]
        [MaxLength(100, ErrorMessage = "First name can be {1} characters long")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(100, ErrorMessage = "Last name can be {1} characters long")]
        public string LastName { get; set; }

        public string Designation { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(100, ErrorMessage = "Last name can be {1} characters long")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string PersonEmail { get; set; }

        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password should be {1} character long")]
        [MaxLength(8, ErrorMessage = "Password can be {1} character long")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Company id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid company id")]
        public long CompanyId { get; set; }

    }

    public class AddUserReponseDto : AddUserDto
    {
        public long UserId { get; set; }
        public string ProfilePic { get; set; }
    }
}
