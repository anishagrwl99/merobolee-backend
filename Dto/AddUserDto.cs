using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddUserDto
    {

        private string first_Name;
        private string middle_Name;
        private string last_Name;
        private string designation;
        private string person_email;
        private string username;
        private string password;
        private long _companyId;


        public string First_Name { get => first_Name; set => first_Name = value; }
        public string Middle_Name { get => middle_Name; set => middle_Name = value; }
        public string Last_Name { get => last_Name; set => last_Name = value; }
        public string Designation { get => designation; set => designation = value; }
      
        public string Person_email { get => person_email; set => person_email = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public long CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }

    }

    public class AddUserReponseDto : AddUserDto
    {
        public long UserId { get; set; }
    }
}
