using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetRoleDto
    {
        public int Role_Id { get; set; }
        public string Role { get; set;}
        
    }

    public class AddRoleDto
    { 
        public string Role { get; set; }
    }
}
