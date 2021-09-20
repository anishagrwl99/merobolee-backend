using System.ComponentModel.DataAnnotations;

namespace MeroBolee.Dto
{
    /// <summary>
    /// Request payload to authenticate user
    /// </summary>
    public class AuthenticateRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
