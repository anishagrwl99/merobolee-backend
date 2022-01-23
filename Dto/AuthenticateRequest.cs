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
        [MinLength(6, ErrorMessage = "Password should be {1} character long")]
        [MaxLength (8, ErrorMessage = "Password can be {1} character long")]
        public string Password { get; set; }
    }
}
