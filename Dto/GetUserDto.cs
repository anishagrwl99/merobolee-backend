using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetUserDto
    {
        public long UserId { get; set; }
        public Guid UserCode { get; set; }
        public int? StatusId { get; set; }
        public string UserStatus { get; set; }
        public int? RoleId { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string PersonEmail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? ActivateDate { get; set; }
        public DateTime? ExpriedDate { get; set; }
    }

    public class UserResponseDto
    {
        public long Id { get; set; }
        public string Designation { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string ProfilePic { get; set; }
    }
}
