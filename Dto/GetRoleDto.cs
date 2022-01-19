using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetRoleDto
    {
        public int RoleId { get; set; }
        public string Role { get; set;}
        
    }

    public class AddRoleDto
    { 
        [Required(ErrorMessage = "Role name is required")]
        [MaxLength(15, ErrorMessage = "Role name can be {1} characters long")]
        public string Role { get; set; }
    }
}
