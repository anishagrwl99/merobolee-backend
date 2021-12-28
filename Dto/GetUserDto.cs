using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetUserDto
    {
        private long userId;
        private Guid companyCode;
        private int? countryId;
        private int? provinceId;
        private int? districtId;
        private int? cityId;
        private int? roleId;
        private int registerCountry;
        private string registerCountryName;
        private string registrationNo;
        private string companyName;
        private int? companyTypeId;
        private string companyAcronym;
        private string description;
        private int employeeNo;
        private int? categoryId;
        private string vatPanNo;
        private string website;
        private string address1;
        private string address2;
        private string address3;
        private int? municipalityId;
        private int? vdcid;
        private string faxNo;
        private string companyemail;
        private string companyContact1;
        private string companyContact2;
        private string salutation;
        private string firstName;
        private string middleName;
        private string lastName;
        private string designation;
        private string personcontact1;
        private string personcontact2;
        private string personemail;
        private string username;
        private string password;
        private string frontCitizenship;
        private string backCitizenship;
        private string taxClearance;
        private string panVatRegistration;
        private string companyRegistration;
        private  ICollection<UserExperienceDto> experienceddocument;
        private string bankCreditLetter;
        private int? membershipId;
        private string country;
        private string province;
        private string district;
        private string city;
        private string category;
        private string userStatus;
        private string membershipType;
        private string role;
        private string municipality;
        private string vdc;
        private string companyType;
        private DateTime? activateDate;
        private DateTime? expriedDate;
        private int? statusId;

        public long UserId { get => userId; set => userId = value; }
        public Guid CompanyCode { get => companyCode; set => companyCode = value; }
        public int? CategoryId { get => categoryId; set => categoryId = value; }
        public string Category { get => category; set => category = value; }

        public int? CountryId { get => countryId; set => countryId = value; }
        public string Country { get => country; set => country = value; }
        public int? ProvinceId { get => provinceId; set => provinceId = value; }
        public string Province { get => province; set => province = value; }
        public int? DistrictId { get => districtId; set => districtId = value; }
        public string District { get => district; set => district = value; }
        public int? CityId { get => cityId; set => cityId = value; }
        public string City { get => city; set => city = value; }
        public int? StatusId { get => statusId; set => statusId = value; }
        public string UserStatus { get => userStatus; set => userStatus = value; }
        public int? MembershipId { get => membershipId; set => membershipId = value; }
        public string MembershipType { get => membershipType; set => membershipType = value; }
        public int? RoleId { get => roleId; set => roleId = value; }
        public string Role { get => role; set => role = value; }
        public int? MunicipalityId { get => municipalityId; set => municipalityId = value; }
        public string Municipality { get => municipality; set => municipality = value; }
        public int? VdcId { get => vdcid; set => vdcid = value; }
        public string Vdc { get => vdc; set => vdc = value; }
        public int? CompanyTypeId { get => companyTypeId; set => companyTypeId = value; }
        public string CompanyType { get => companyType; set => companyType = value; }
        public int RegisterCountry { get => registerCountry; set => registerCountry = value; }
        public string RegisterCountryName { get => registerCountryName; set => registerCountryName = value; }
        public string RegistrationNo { get => registrationNo; set => registrationNo = value; }
        public string CompanyName { get => companyName; set => companyName = value; }
        public string CompanyAcronym { get => companyAcronym; set => companyAcronym = value; }
        public string Description { get => description; set => description = value; }
        public int EmployeeNo { get => employeeNo; set => employeeNo = value; }
        public string VatPanNo { get => vatPanNo; set => vatPanNo = value; }
        public string Website { get => website; set => website = value; }
        public string Address1 { get => address1; set => address1 = value; }
        public string Address2 { get => address2; set => address2 = value; }
        public string Address3 { get => address3; set => address3 = value; }
        public string FaxNo { get => faxNo; set => faxNo = value; }
        public string CompanyEmail { get => companyemail; set => companyemail = value; }
        public string CompanyContact1 { get => companyContact1; set => companyContact1 = value; }
        public string CompanyContact2 { get => companyContact2; set => companyContact2 = value; }
        public string Salutation { get => salutation; set => salutation = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string MiddleName { get => middleName; set => middleName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Designation { get => designation; set => designation = value; }
        public string PersonContact1 { get => personcontact1; set => personcontact1 = value; }
        public string PersonContact2 { get => personcontact2; set => personcontact2 = value; }
        public string PersonEmail { get => personemail; set => personemail = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string FrontCitizenship { get => frontCitizenship; set => frontCitizenship = value; }
        public string BackCitizenship { get => backCitizenship; set => backCitizenship = value; }
        public string TaxClearance { get => taxClearance; set => taxClearance = value; }
        public string PanVatRegistration { get => panVatRegistration; set => panVatRegistration = value; }
        public string CompanyRegistration { get => companyRegistration; set => companyRegistration = value; }
        public ICollection<UserExperienceDto> ExperiencedDocument { get => experienceddocument; set => experienceddocument = value; }
        public string BankCreditLetter { get => bankCreditLetter; set => bankCreditLetter = value; }
        public DateTime? ActivateDate { get => activateDate; set => activateDate = value; }
        public DateTime? ExpriedDate { get => expriedDate; set => expriedDate = value; }
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
