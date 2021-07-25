using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetUserDto
    {
        private int user_Id;
        private string company_Name;
        private string company_Type;
        private string registration_No;
        private int role_Id;
        private string role;
        private int country_Id;
        private string country;
        private int province_Id;
        private string province;
        private int district_Id;
        private string city;
        private int city_Id;
        private string address;
        private string email;
        private string phone_No;
        private string contact_Person;
        private string position;
        private string contact_No;
        private string username;
        private string password;
        private int status_Id;
        private string status;
        private int membership_Id;
        private string membership;
        private DateTime? activate_Date;
        private DateTime? expried_Date;

        public string Company_Name { get => company_Name; set => company_Name = value; }
        public string Company_Type { get => company_Type; set => company_Type = value; }
        public string Registration_No { get => registration_No; set => registration_No = value; }
        public int Country_Id { get => country_Id; set => country_Id = value; }
        public string Country { get => country; set => country = value; }
        public int Province_Id { get => province_Id; set => province_Id = value; }
        public string Province { get => province; set => province = value; }
        public int District_Id { get => district_Id; set => district_Id = value; }
        public string City { get => city; set => city = value; }
        public int City_Id { get => city_Id; set => city_Id = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string Phone_No { get => phone_No; set => phone_No = value; }
        public string Contact_Person { get => contact_Person; set => contact_Person = value; }
        public string Position { get => position; set => position = value; }
        public string Contact_No { get => contact_No; set => contact_No = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Status_Id { get => status_Id; set => status_Id = value; }
        public string Status { get => status; set => status = value; }
        public int Membership_Id { get => membership_Id; set => membership_Id = value; }
        public string Membership { get => membership; set => membership = value; }
        public DateTime? Activate_Date { get => activate_Date; set => activate_Date = value; }
        public DateTime? Expried_Date { get => expried_Date; set => expried_Date = value; }
        public int User_Id { get => user_Id; set => user_Id = value; }
        public int Role_Id { get => role_Id; set => role_Id = value; }
        public string Role { get => role; set => role = value; }
    }
}
