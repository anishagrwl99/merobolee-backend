using MeroBolee.Dto;
using MeroBolee.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    /// <summary>
    /// User Mapper 
    /// </summary>
    public class UserMapper
    {
        /// <summary>
        /// Map dto to entity
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="companyTypeEnum"></param>
        /// <returns></returns>
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
                Status_id = 1, //Registered status
                IsEmailReceiver = true
            };
        }


        /// <summary>
        /// User dto to entity
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public UserEntity UserDtoEntity(AddUserDto userDto)
        {
            if (userDto == null)
            {
                return null;
            }
            return new UserEntity
            {
                First_Name = userDto.FirstName,
                Middle_Name = userDto.MiddleName,
                Last_Name = userDto.LastName,
                Designation = userDto.Designation,
                Username = userDto.Username,
                Password = userDto.Password
            };

        }
        /// <summary>
        /// map singup dto dto user entity
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public UserEntity SignUpDtoEntity(SignUpDto userDto)
        {
            if (userDto == null)
            {
                return null;
            }

            return new UserEntity
            {
                First_Name = userDto.FirstName,
                Middle_Name = userDto.MiddleName,
                Last_Name = userDto.LastName,
                Designation = userDto.Designation,
                Person_email = userDto.PersonEmail,
                Username = userDto.Username,
                Password = userDto.Password,
                Role_Id = userDto.RoleId,
                Status_id = userDto.StatusId
            };

        }

        /// <summary>
        /// user entity to dto
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        public GetUserDto UserEntityToDto(UserEntity userEntity)
        {
            if (userEntity == null)
            {
                return null;
            }

            GetUserDto getUser = new();

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


            getUser.UserId = userEntity.User_Id;
            getUser.CompanyCode = userEntity.User_Code;
            getUser.FirstName = userEntity.First_Name;
            getUser.MiddleName = userEntity.Middle_Name;
            getUser.LastName = userEntity.Last_Name;
            getUser.Designation = userEntity.Designation;
            getUser.PersonEmail = userEntity.Person_email;
            getUser.Username = userEntity.Username;
            getUser.Password = userEntity.Password;
            getUser.RoleId = userEntity.Role_Id;
            getUser.StatusId = userEntity.Status_id;
            getUser.ActivateDate = userEntity.Activate_Date;
            getUser.ExpriedDate = userEntity.Expried_Date;
            return getUser;

        }

        /// <summary>
        /// user entity to dto
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IEnumerable<GetUserDto> UserEntityListToDto(IEnumerable<UserEntity> user)
        {

            List<GetUserDto> getUsers = new();
            if (user == null)
            {
                return null;
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
