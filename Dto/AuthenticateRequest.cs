using MeroBolee.Attribute;
using System.ComponentModel.DataAnnotations;

namespace MeroBolee.Dto
{
    /// <summary>
    /// Request payload to authenticate user
    /// </summary>
    public class AuthenticateRequest
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email adddress")]
        [MaxLength(100, ErrorMessage = "Email address can be {1} characters long")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Password(MinLength = 8, MaxLength = 500, ErrorMessage = "Password must contain at least one upper case, lower case, number and special character")]
        public string Password { get; set; }
    }
}
