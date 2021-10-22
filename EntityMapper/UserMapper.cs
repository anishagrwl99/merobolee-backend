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
        public UserEntity SupplierSignUpDToUserEntity(UserSignUpDto obj, CompanyTypeEnum companyTypeEnum)
        {
            if (obj == null) return null;

            return new UserEntity
            {
                First_Name = obj.FirstName,
                Last_Name = obj.LastName,
                Person_email = obj.Email,
                Password = obj.Password,
                Date_created = DateTime.Now,
                Date_modified = DateTime.Now,
                Role_Id = companyTypeEnum == CompanyTypeEnum.Bidder ? 3 : 2, //Bidder(Supplier) role
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
                First_Name = userDto.First_Name,
                Middle_Name = userDto.Middle_Name,
                Last_Name = userDto.Last_Name,
                Designation = userDto.Designation,
                Username = userDto.Username,
                Password = userDto.Password
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
                Username = userDto.Username,
                Password = userDto.Password,
                Role_Id = userDto.Role_Id,
                Status_id = userDto.Status_id
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
                );
            }
            return getUsers;
        }

    }
}
