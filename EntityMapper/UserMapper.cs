using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class UserMapper
    {
        public UserEntity UserDtoEntity(AddUserDto userDto)
        {
            if (userDto == null)
            {
                return null;
            }
            return new UserEntity
            {
                
                Company_Name = userDto.Company_Name,
                Registration_No= userDto.Registration_No,
                Country_Id= userDto.Country_Id,
                Province_Id= userDto.Province_Id,
                District_Id= userDto.District_Id,
                City_Id= userDto.City_Id,
                Municipality_Id= userDto.Municipality_Id,
                Vdc_id=userDto.Vdc_id,
                Register_Country= userDto.Register_Country,
                Company_Type_Id= userDto.Company_Type_Id,
                Company_acronym= userDto.Company_acronym,
                Description= userDto.Description,
                Employee_no= userDto.Employee_no,
                Category_Id= userDto.Category_Id,
                Vat_Pan_No= userDto.Vat_Pan_No,
                Website= userDto.Website,
                Address1= userDto.Address1,
                Address2= userDto.Address2,
                Address3= userDto.Address3,
                Fax_No= userDto.Fax_No,
                Company_email= userDto.Company_email,
                Company_Contact1= userDto.Company_Contact1,
                Company_Contact2= userDto.Company_Contact2,
                Salutation= userDto.Salutation,
                First_Name= userDto.First_Name,
                Middle_Name= userDto.Middle_Name,
                Last_Name= userDto.Last_Name,
                Designation= userDto.Designation,
                Person_contact1= userDto.Person_contact1,
                Person_contact2= userDto.Person_contact2,
                //Person_email= userDto.Person_email,
                //Front_Citizenship= userDto.Front_Citizenship,
                //Back_Citizenship= userDto.Back_Citizenship,
                //Tax_Clearance= userDto.Tax_Clearance,
                //Pan_Vat_Registration= userDto.Pan_Vat_Registration,
                //Company_Registration= userDto.Company_Registration,
                //Experienced_document= userDto.Experienced_document,
                //Bank_credit_letter= userDto.Bank_credit_letter,
                Username = userDto.Username,
                Password= userDto.Password,
                Role_Id = userDto.Role_Id,
                Membership_Id= userDto.Membership_Id,
    };

        }

        public UserEntity SignUpDtoEntity(SignUpDto userDto)
        {
            if (userDto == null)
            {
                return null;
            }
            return new UserEntity
            {
                Company_Name = userDto.Company_Name,
                Registration_No = userDto.Registration_No,
                Country_Id = userDto.Country_Id,
                Province_Id = userDto.Province_Id,
                District_Id = userDto.District_Id,
                City_Id = userDto.City_Id,
                Municipality_Id = userDto.Municipality_Id,
                Vdc_id = userDto.Vdc_id,
                Register_Country = userDto.Register_Country,
                Company_Type_Id = userDto.Company_Type_Id,
                Company_acronym = userDto.Company_acronym,
                Description = userDto.Description,
                Employee_no = userDto.Employee_no,
                Category_Id = userDto.Category_Id,
                Vat_Pan_No = userDto.Vat_Pan_No,
                Website = userDto.Website,
                Address1 = userDto.Address1,
                Address2 = userDto.Address2,
                Address3 = userDto.Address3,
                Fax_No = userDto.Fax_No,
                Company_email = userDto.Company_email,
                Company_Contact1 = userDto.Company_Contact1,
                Company_Contact2 = userDto.Company_Contact2,
                Salutation = userDto.Salutation,
                First_Name = userDto.First_Name,
                Middle_Name = userDto.Middle_Name,
                Last_Name = userDto.Last_Name,
                Designation = userDto.Designation,
                Person_contact1 = userDto.Person_contact1,
                Person_contact2 = userDto.Person_contact2,
                Person_email = userDto.Person_email,
                Front_Citizenship = userDto.Front_Citizenship,
                Back_Citizenship = userDto.Back_Citizenship,
                Tax_Clearance = userDto.Tax_Clearance,
                Pan_Vat_Registration = userDto.Pan_Vat_Registration,
                Company_Registration = userDto.Company_Registration,
                Experienced_document = userDto.Experienced_document,
                Bank_credit_letter = userDto.Bank_credit_letter,
                Username = userDto.Username,
                Password = userDto.Password,
                Role_Id = userDto.Role_Id,
                Membership_Id = userDto.Membership_Id,
            };

        }

        public GetUserDto UserEntityToDto(UserEntity userEntity)
        {
            if (userEntity == null)
            {
                return null;
            }
            return new GetUserDto
            {
                User_Id= userEntity.User_Id,
                Company_Code= userEntity.User_Code,
                Company_Name = userEntity.Company_Name,
                Registration_No = userEntity.Registration_No,
                Country_Id = userEntity.Country_Id,
                Country= userEntity.Country.Country_Name,
                Province_Id = userEntity.Province_Id,
                Province= userEntity.Province.Province,
                District_Id = userEntity.District_Id,
                District= userEntity.District.District_Name,
                City_Id = userEntity.City_Id,
                City= userEntity.City.City_Name,
                Municipality_Id = userEntity.Municipality_Id,
                Municipality= userEntity.Municipality.Municipality_Name,
                Vdc_id = userEntity.Vdc_id,
                Vdc= userEntity.VDC.Vdc_Name,
                Register_Country = userEntity.Register_Country,
                Company_Type_Id = userEntity.Company_Type_Id,
                CompanyType= userEntity.CompanyType.Company_type,
                Company_acronym = userEntity.Company_acronym,
                Description = userEntity.Description,
                Employee_no = userEntity.Employee_no,
                Category_Id = userEntity.Category_Id,
                Category= userEntity.Category.Category,
                Vat_Pan_No = userEntity.Vat_Pan_No,
                Website = userEntity.Website,
                Address1 = userEntity.Address1,
                Address2 = userEntity.Address2,
                Address3 = userEntity.Address3,
                Fax_No = userEntity.Fax_No,
                Company_email = userEntity.Company_email,
                Company_Contact1 = userEntity.Company_Contact1,
                Company_Contact2 = userEntity.Company_Contact2,
                Salutation = userEntity.Salutation,
                First_Name = userEntity.First_Name,
                Middle_Name = userEntity.Middle_Name,
                Last_Name = userEntity.Last_Name,
                Designation = userEntity.Designation,
                Person_contact1 = userEntity.Person_contact1,
                Person_contact2 = userEntity.Person_contact2,
                Person_email = userEntity.Person_email,
                Front_Citizenship = userEntity.Front_Citizenship,
                Back_Citizenship = userEntity.Back_Citizenship,
                Tax_Clearance = userEntity.Tax_Clearance,
                Pan_Vat_Registration = userEntity.Pan_Vat_Registration,
                Company_Registration = userEntity.Company_Registration,
                Experienced_document = userEntity.Experienced_document,
                Bank_credit_letter = userEntity.Bank_credit_letter,
                Username = userEntity.Username,
                Password = userEntity.Password,
                Role_Id = userEntity.Role_Id,
                Role= userEntity.Role.Role_Name,
                Membership_Id = userEntity.Membership_Id,
                MembershipType= userEntity.MembershipType.Membership_Title
            };

        }

        public IEnumerable<GetUserDto> UserEntityListToDto(IEnumerable<UserEntity> user)
        {

            List<GetUserDto> getUsers = new List<GetUserDto>();
            if (user == null)
            {
                return getUsers = null;
            }
            foreach (UserEntity userEntity in user)
            {
                getUsers.Add
                (
                  new GetUserDto
                  {
                      User_Id = userEntity.User_Id,
                      Company_Code = userEntity.User_Code,
                      Company_Name = userEntity.Company_Name,
                      Registration_No = userEntity.Registration_No,
                      Country_Id = userEntity.Country_Id,
                      Country = userEntity.Country.Country_Name,
                      Province_Id = userEntity.Province_Id,
                      Province = userEntity.Province.Province,
                      District_Id = userEntity.District_Id,
                      District = userEntity.District.District_Name,
                      City_Id = userEntity.City_Id,
                      City = userEntity.City.City_Name,
                      Municipality_Id = userEntity.Municipality_Id,
                      Municipality = userEntity.Municipality.Municipality_Name,
                      Vdc_id = userEntity.Vdc_id,
                      Vdc = userEntity.VDC.Vdc_Name,
                      Register_Country = userEntity.Register_Country,
                      Register_Country_Name= userEntity.Country.Country_Name,
                      Company_Type_Id = userEntity.Company_Type_Id,
                      CompanyType = userEntity.CompanyType.Company_type,
                      Company_acronym = userEntity.Company_acronym,
                      Description = userEntity.Description,
                      Employee_no = userEntity.Employee_no,
                      Category_Id = userEntity.Category_Id,
                      Category = userEntity.Category.Category,
                      Vat_Pan_No = userEntity.Vat_Pan_No,
                      Website = userEntity.Website,
                      Address1 = userEntity.Address1,
                      Address2 = userEntity.Address2,
                      Address3 = userEntity.Address3,
                      Fax_No = userEntity.Fax_No,
                      Company_email = userEntity.Company_email,
                      Company_Contact1 = userEntity.Company_Contact1,
                      Company_Contact2 = userEntity.Company_Contact2,
                      Salutation = userEntity.Salutation,
                      First_Name = userEntity.First_Name,
                      Middle_Name = userEntity.Middle_Name,
                      Last_Name = userEntity.Last_Name,
                      Designation = userEntity.Designation,
                      Person_contact1 = userEntity.Person_contact1,
                      Person_contact2 = userEntity.Person_contact2,
                      Person_email = userEntity.Person_email,
                      Front_Citizenship = userEntity.Front_Citizenship,
                      Back_Citizenship = userEntity.Back_Citizenship,
                      Tax_Clearance = userEntity.Tax_Clearance,
                      Pan_Vat_Registration = userEntity.Pan_Vat_Registration,
                      Company_Registration = userEntity.Company_Registration,
                      Experienced_document = userEntity.Experienced_document,
                      Bank_credit_letter = userEntity.Bank_credit_letter,
                      Username = userEntity.Username,
                      Password = userEntity.Password,
                      Role_Id = userEntity.Role_Id,
                      Role = userEntity.Role.Role_Name,
                      Membership_Id = userEntity.Membership_Id,
                      MembershipType = userEntity.MembershipType.Membership_Title

                  }
                );
            }
            return getUsers;
        }

    }
}
