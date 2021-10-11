using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{

    /// <summary>
    /// Response when user is authenticated
    /// </summary>
    public class AuthenticateResponse
    {
        public long Id { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime Created { get; set; }
        public string JwtToken { get; set; }

        [JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }
    }
}
