using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddUserDto
    {

        private string firstName;
        private string middleName;
        private string lastName;
        private string designation;
        private string personemail;
        private string username;
        private string password;
        private long companyId;


        public string FirstName { get => firstName; set => firstName = value; }
        public string MiddleName { get => middleName; set => middleName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Designation { get => designation; set => designation = value; }
      
        public string PersonEmail { get => personemail; set => personemail = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public long CompanyId
        {
            get { return companyId; }
            set { companyId = value; }
        }

    }

    public class AddUserReponseDto : AddUserDto
    {
        public long UserId { get; set; }
    }
}
