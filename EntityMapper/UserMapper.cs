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
               // Company_Type = userDto.Company_Type,
                Registration_No= userDto.Registration_No,
                Country_Id= userDto.Country_Id,
                Province_Id= userDto.Province_Id,
                District_Id= userDto.District_Id,
                City_Id= userDto.City_Id,
                //Address= userDto.Address,
                //Email= userDto.Email,
               // Phone_No= userDto.Phone_No,
                //Contact_person= userDto.Contact_Person,
                //Position= userDto.Position,
                //Contact_No= userDto.Contact_No,
                Username = userDto.Username,
                Password= userDto.Password,
                //Status_I= userDto.Status_Id,
                Role_Id= userDto.Role_Id,
                //Membership_Id= userDto.Membership_Id,
                Activate_Date= userDto.Activate_Date,
                Expried_Date= userDto.Expried_Date
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
              //  Company_Type = userDto.Company_Type,
                Registration_No = userDto.Registration_No,
                Role_Id= userDto.Role_Id,
                Country_Id = userDto.Country_Id,
                Province_Id = userDto.Province_Id,
                District_Id = userDto.District_Id,
                City_Id = userDto.City_Id,
                //Address = userDto.Address,
                //Email = userDto.Email,
                //Phone_No = userDto.Phone_No,
                //Contact_person = userDto.Contact_Person,
                //Position = userDto.Position,
                //Contact_No = userDto.Contact_No,
                Username = userDto.Username,
                Password = userDto.Password
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
                Company_Name = userEntity.Company_Name,
                //Company_Type = userEntity.Company_Type,
                Registration_No = userEntity.Registration_No,
                Role_Id= userEntity.Role_Id,
                Role= userEntity.Role.Role_Name,
                Country_Id = userEntity.Country_Id,
                Province_Id = userEntity.Province_Id,
                District_Id = userEntity.District_Id,
                City_Id = userEntity.City_Id,
                //Address = userEntity.Address,
                //Email = userEntity.Email,
                //Phone_No = userEntity.Phone_No,
                //Contact_Person = userEntity.Contact_person,
                //Position = userEntity.Position,
                //Contact_No = userEntity.Contact_No,
                //Username = userEntity.Username,
                Password = userEntity.Password,
                //Status_Id = userEntity.Status_I,
                Status= userEntity.UserStatus.Status,
                //Membership_Id = userEntity.Membership_Id,
                Activate_Date = userEntity.Activate_Date,
                Expried_Date = userEntity.Expried_Date
            };

        }

        public IEnumerable<GetUserDto> UserEntityListToDto(IEnumerable<UserEntity> userEntity)
        {

            List<GetUserDto> getUsers = new List<GetUserDto>();
            if (userEntity == null)
            {
                return getUsers = null;
            }
            foreach (UserEntity user in userEntity)
            {
                getUsers.Add
                (
                  new GetUserDto
                  {
                      User_Id= user.User_Id,
                      Company_Name = user.Company_Name,
                      //Company_Type = user.Company_Type,
                      Registration_No = user.Registration_No,
                      Role_Id = user.Role_Id,
                      Role = user.Role.Role_Name,
                      Country_Id = user.Country_Id,
                      Province_Id = user.Province_Id,
                      District_Id = user.District_Id,
                      City_Id = user.City_Id,
                      //Address = user.Address,
                      //Email = user.Email,
                      //Phone_No = user.Phone_No,
                      //Contact_Person = user.Contact_person,
                      //Position = user.Position,
                      //Contact_No = user.Contact_No,
                      Username = user.Username,
                      Password = user.Password,
                      //Status_Id = user.Status_I,
                      Status= user.UserStatus.Status,
                      //Membership_Id = user.Membership_Id,
                      Activate_Date = user.Activate_Date,
                      Expried_Date = user.Expried_Date
                  }
                );
            }
            return getUsers;
        }

    }
}
