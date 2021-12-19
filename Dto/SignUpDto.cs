using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{

    public class ChangePasswordDto
    {
        [Required(ErrorMessage = "User id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid user id")]
        public long UserId { get; set; }

        [Required(ErrorMessage = "Company id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid company id")]
        public long CompanyId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Compare("ConfirmationPassword", ErrorMessage = "Password and confirmation password didn't matched")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmation password is required")]
        [Compare("Password", ErrorMessage = "Password and confirmation password didn't matched")]
        public string ConfirmationPassword { get; set; }
    }
    public class ProfilePictureDto
    { 
        [Required(ErrorMessage = "User id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid user id")]
        public long UserId { get; set; }

        [Required(ErrorMessage = "Company id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid company id")]
        public long CompanyId { get; set; }


        [Required(ErrorMessage = "Profile picture is required")]
        public IFormFile ProfilePicture { get; set; }
    }

    public class ProfilePictureResponseDto
    {
        public long UserId { get; set; }
        public long CompanyId { get; set; }
        public string ProfilePicture { get; set; }
    }

    public class UserProfileDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public string LastName { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string ProfilePicture { get; set; }

        public List<CompanyDto> UserCompanies { get; set; }
    }

    public class CompanyDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Status { get; set; }
        public DateTime RegisteredDate { get; set; }

    }

    public class SignUpDto
    {
        private int roleId;
        private string companyContact;
        private string firstName;
        private string middleName;
        private string lastName;
        private string designation;
        private string personcontact1;
        private string personemail;
        private string username;
        private string password;
        private int? statusid;


        public int RoleId { get => roleId; set => roleId = value; }
        public string CompanyContact { get => companyContact; set => companyContact = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string MiddleName { get => middleName; set => middleName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Designation { get => designation; set => designation = value; }
        public string PersonContact { get => personcontact1; set => personcontact1 = value; }
        public string PersonEmail { get => personemail; set => personemail = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int? StatusId { get => statusid; set => statusid = value; }
    }
}
