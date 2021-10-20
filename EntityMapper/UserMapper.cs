using MeroBolee.Dto;
using MeroBolee.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class UserMapper
    {
        public UserEntity SupplierSignUpDToUserEntity(UserSignUpDto obj)
        {
            if (obj == null) return null;

            return new UserEntity
            {
                First_Name = obj.FirstName,
                Last_Name = obj.LastName,
                Person_email = obj.Email,
                Password = obj.Password,
                Date_created= DateTime.Now,
                Date_modified = DateTime.Now,
                Role_Id = 3, //Bidder(Supplier) role
                Status_id = 1 //Registered status
            };
        }
        public UserEntity UserDtoEntity(AddUserDto userDto)
        {
            if (userDto == null)
            {
                return null;
            }
            return new UserEntity
            {
                First_Name= userDto.First_Name,
                Middle_Name= userDto.Middle_Name,
                Last_Name= userDto.Last_Name,
                Designation= userDto.Designation,
                //Person_email = userDto.Person_email,
                //Front_Citizenship = userDto.Front_Citizenship,
                //Back_Citizenship = userDto.Back_Citizenship,
                //Tax_Clearance = userDto.Tax_Clearance,
                //Pan_Vat_Registration = userDto.Pan_Vat_Registration,
                //Company_Registration = userDto.Company_Registration,
                //Experienced_document = userDto.Experienced_document,
                //Bank_credit_letter = userDto.Bank_credit_letter,
                Username = userDto.Username,
                Password= userDto.Password
             //   Activate_Date= userDto.Activate_date
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
                First_Name = userDto.First_Name,
                Middle_Name = userDto.Middle_Name,
                Last_Name = userDto.Last_Name,
                Designation = userDto.Designation,
                Person_email = userDto.Person_email,
             //   Front_Citizenship = userDto.Front_Citizenship,
             //   Back_Citizenship = userDto.Back_Citizenship,
             //   Tax_Clearance = userDto.Tax_Clearance,
             //   Pan_Vat_Registration = userDto.Pan_Vat_Registration,
             //   Company_Registration = userDto.Company_Registration,
             ////   Experienced_document = userDto.Experienced_document,
             //   Bank_credit_letter = userDto.Bank_credit_letter,
                Username = userDto.Username,
                Password = userDto.Password,
                Role_Id = userDto.Role_Id,
                Status_id= userDto.Status_id
            };

        }

        public GetUserDto UserEntityToDto(UserEntity userEntity)
        {
            if (userEntity == null)
            {
                return null;
            }

            GetUserDto getUser = new GetUserDto();

            if (userEntity.Role == null)
            {
                getUser.Role = null;
            }
            else
            {
                getUser.Role = userEntity.Role.Role_Name;
            }


            if (userEntity.UserStatus == null)
            {
                getUser.UserStatus = null;
            }
            else
            {
                getUser.UserStatus = userEntity.UserStatus.Status;
            }

            
            getUser.User_Id = userEntity.User_Id;
            getUser.Company_Code = userEntity.User_Code;
            getUser.First_Name = userEntity.First_Name;
            getUser.Middle_Name = userEntity.Middle_Name;
            getUser.Last_Name = userEntity.Last_Name;
            getUser.Designation = userEntity.Designation;
            getUser.Person_email = userEntity.Person_email;
            getUser.Username = userEntity.Username;
            getUser.Password = userEntity.Password;
            getUser.Role_Id = userEntity.Role_Id;
            getUser.Status_id = userEntity.Status_id;
            getUser.Activate_Date = userEntity.Activate_Date;
            getUser.Expried_Date = userEntity.Expried_Date;
            return getUser;

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
                    UserEntityToDto(userEntity)
                //new GetUserDto
                //{
                //    User_Id = userEntity.User_Id,
                //    Company_Code = userEntity.User_Code,
                //    Company_Name = userEntity.Company_Name,
                //    Registration_No = userEntity.Registration_No,
                //    Country_Id = userEntity.Country_Id,
                //    Country = userEntity.Country.Country_Name,
                //    Province_Id = userEntity.Province_Id,
                //    Province = userEntity.Province.Province,
                //    District_Id = userEntity.District_Id,
                //    District = userEntity.District.District_Name,
                //    City_Id = userEntity.City_Id,
                //    City = userEntity.City.City_Name,
                //    Municipality_Id = userEntity.Municipality_Id,
                //    Municipality = userEntity.Municipality.Municipality_Name,
                //    Vdc_id = userEntity.Vdc_id,
                //    Vdc = userEntity.VDC.Vdc_Name,
                //    Register_Country = userEntity.Register_Country,
                //    Register_Country_Name= userEntity.Country.Country_Name,
                //    Company_Type_Id = userEntity.Company_Type_Id,
                //    CompanyType = userEntity.CompanyType.Company_type,
                //    Company_acronym = userEntity.Company_acronym,
                //    Description = userEntity.Description,
                //    Employee_no = userEntity.Employee_no,
                //    Category_Id = userEntity.Category_Id,
                //    Category = userEntity.Category.Category,
                //    Vat_Pan_No = userEntity.Vat_Pan_No,
                //    Website = userEntity.Website,
                //    Address1 = userEntity.Address1,
                //    Address2 = userEntity.Address2,
                //    Address3 = userEntity.Address3,
                //    Fax_No = userEntity.Fax_No,
                //    Company_email = userEntity.Company_email,
                //    Company_Contact1 = userEntity.Company_Contact1,
                //    Company_Contact2 = userEntity.Company_Contact2,
                //    Salutation = userEntity.Salutation,
                //    First_Name = userEntity.First_Name,
                //    Middle_Name = userEntity.Middle_Name,
                //    Last_Name = userEntity.Last_Name,
                //    Designation = userEntity.Designation,
                //    Person_contact1 = userEntity.Person_contact1,
                //    Person_contact2 = userEntity.Person_contact2,
                //    Person_email = userEntity.Person_email,
                //    Front_Citizenship = userEntity.Front_Citizenship,
                //    Back_Citizenship = userEntity.Back_Citizenship,
                //    Tax_Clearance = userEntity.Tax_Clearance,
                //    Pan_Vat_Registration = userEntity.Pan_Vat_Registration,
                //    Company_Registration = userEntity.Company_Registration,
                // //   Experienced_document = userEntity.Experienced_document,
                //    Bank_credit_letter = userEntity.Bank_credit_letter,
                //    Username = userEntity.Username,
                //    Password = userEntity.Password,
                //    Role_Id = userEntity.Role_Id,
                //    Role = userEntity.Role.Role_Name,
                //    Membership_Id = userEntity.Membership_Id,
                //    MembershipType = userEntity.MembershipType.Membership_Title

                //}
                );
            }
            return getUsers;
        }

    }
}
