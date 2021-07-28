using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddUserDto
    {

        private int country_Id;
        private int province_Id;
        private int district_Id;
        private int city_Id;
        private int role_Id;
        private int register_Country;
        private string registration_No;
        private string company_Name;
        private int company_Type_Id;
        private string company_acronym;
        private string description;
        private int employee_no;
        private int category_Id;
        private string vat_Pan_No;
        private string website;
        private string address1;
        private string address2;
        private string address3;
        private int municipality_Id;
        private int vdc_id;
        private string fax_No;
        private string company_email;
        private string company_Contact1;
        private string company_Contact2;
        private string salutation;
        private string first_Name;
        private string middle_Name;
        private string last_Name;
        private string designation;
        private string person_contact1;
        private string person_contact2;
        private string person_email;
        private string username;
        private string password;
        private IFormFile front_Citizenship;
        private IFormFile back_Citizenship;
        private IFormFile tax_Clearance;
        private IFormFile pan_Vat_Registration;
        private IFormFile company_Registration;
        private IFormFile experienced_document;
        private IFormFile bank_credit_letter;
        private int membership_Id;
        
      
        public int Country_Id { get => country_Id; set => country_Id = value; }
        public int Province_Id { get => province_Id; set => province_Id = value; }
        public int District_Id { get => district_Id; set => district_Id = value; }
        public int City_Id { get => city_Id; set => city_Id = value; }
        public int Role_Id { get => role_Id; set => role_Id = value; }
        public int Register_Country { get => register_Country; set => register_Country = value; }
        public string Registration_No { get => registration_No; set => registration_No = value; }
        public string Company_Name { get => company_Name; set => company_Name = value; }
        public int Company_Type_Id { get => company_Type_Id; set => company_Type_Id = value; }
        public string Company_acronym { get => company_acronym; set => company_acronym = value; }
        public string Description { get => description; set => description = value; }
        public int Employee_no { get => employee_no; set => employee_no = value; }
        public int Category_Id { get => category_Id; set => category_Id = value; }
        public string Vat_Pan_No { get => vat_Pan_No; set => vat_Pan_No = value; }
        public string Website { get => website; set => website = value; }
        public string Address1 { get => address1; set => address1 = value; }
        public string Address2 { get => address2; set => address2 = value; }
        public string Address3 { get => address3; set => address3 = value; }
        public int Municipality_Id { get => municipality_Id; set => municipality_Id = value; }
        public int Vdc_id { get => vdc_id; set => vdc_id = value; }
        public string Fax_No { get => fax_No; set => fax_No = value; }
        public string Company_email { get => company_email; set => company_email = value; }
        public string Company_Contact1 { get => company_Contact1; set => company_Contact1 = value; }
        public string Company_Contact2 { get => company_Contact2; set => company_Contact2 = value; }
        public string Salutation { get => salutation; set => salutation = value; }
        public string First_Name { get => first_Name; set => first_Name = value; }
        public string Middle_Name { get => middle_Name; set => middle_Name = value; }
        public string Last_Name { get => last_Name; set => last_Name = value; }
        public string Designation { get => designation; set => designation = value; }
        public string Person_contact1 { get => person_contact1; set => person_contact1 = value; }
        public string Person_contact2 { get => person_contact2; set => person_contact2 = value; }
        public string Person_email { get => person_email; set => person_email = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        //public string Front_Citizenship { get => front_Citizenship; set => front_Citizenship = value; }
        public IFormFile Back_Citizenship { get => back_Citizenship; set => back_Citizenship = value; }
        public IFormFile Tax_Clearance { get => tax_Clearance; set => tax_Clearance = value; }
        public IFormFile Pan_Vat_Registration { get => pan_Vat_Registration; set => pan_Vat_Registration = value; }
        public IFormFile Company_Registration { get => company_Registration; set => company_Registration = value; }
        public IFormFile Experienced_document { get => experienced_document; set => experienced_document = value; }
        public IFormFile Bank_credit_letter { get => bank_credit_letter; set => bank_credit_letter = value; }
        public int Membership_Id { get => membership_Id; set => membership_Id = value; }
        public IFormFile Front_Citizenship { get => front_Citizenship; set => front_Citizenship = value; }
    }
}
