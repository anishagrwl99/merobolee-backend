using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class SignUpDto
    {
        private int roleId;
        private string companyContact;
        private string firstName;
        private string middleName;
        private string lastName;
        private string designation;
        private string personcontact1;
        private string personcontact2;
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
