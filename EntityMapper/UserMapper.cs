using MeroBolee.Dto;
using MeroBolee.Infrastructure;
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
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                Email = obj.Email,
                Password = obj.Password,
                Date_created = DateTime.Now,
                Date_modified = DateTime.Now,
                RoleId = companyTypeEnum == CompanyTypeEnum.Bidder ? 5 : 4, //Bidder(Supplier) role
                StatusId = 1, //Registered status
                IsEmailReceiver = true,
                ProfilePicture = ""
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
                FirstName = userDto.FirstName,
                MiddleName = userDto.MiddleName,
                LastName = userDto.LastName,
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
                FirstName = userDto.FirstName,
                MiddleName = userDto.MiddleName,
                LastName = userDto.LastName,
                Designation = userDto.Designation,
                Email = userDto.PersonEmail,
                Username = userDto.Username,
                Password = userDto.Password,
                RoleId = userDto.RoleId,
                StatusId = userDto.StatusId
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
                getUser.Role = userEntity.Role.Name;
            }


            if (userEntity.UserStatus == null)
            {
                getUser.UserStatus = null;
            }
            else
            {
                getUser.UserStatus = userEntity.UserStatus.Status;
            }


            getUser.UserId = userEntity.Id;
            getUser.UserCode = userEntity.Code;
            getUser.FirstName = userEntity.FirstName;
            getUser.MiddleName = userEntity.MiddleName;
            getUser.LastName = userEntity.LastName;
            getUser.Designation = userEntity.Designation;
            getUser.PersonEmail = userEntity.Email;
            getUser.Username = userEntity.Username;
            getUser.Password = "";
            getUser.RoleId = userEntity.RoleId;
            getUser.StatusId = userEntity.StatusId;
            getUser.ActivateDate = userEntity.ActivateDate;
            getUser.ExpriedDate = userEntity.ExpriedDate;
            return getUser;

        }


        public UserDetailDto UserDetailDto(UserEntity user, List<CompanyEntity> companies)
        {
            UserDetailDto userDetailDto = new UserDetailDto
            {
                Designation = user.Designation,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                ProfilePicture = user.ProfilePicture,
                UserName = user.Username,
                RegistrationDate = user.Date_created,
                ActivationDate = user.ActivateDate
            };

            userDetailDto.Companies = (from c in companies
                                       select new CompanyDto
                                       {
                                           Address1 = c.Address1,
                                           Address2 = c.Address2,
                                           Address3 = c.Address3,
                                           City = c.City,
                                           Code = c.ReferenceCode,
                                           Country = c.Country.Name,
                                           Email = c.CompanyEmail,
                                           Id = c.CompanyId,
                                           Name = c.Name,
                                           Phone1 = c.MobileNumber,
                                           Phone2 = c.PhoneNumber,
                                           Province = c.Province.Name,
                                           RegisteredDate = c.Date_created,
                                           Status = c.CompanyStatus.Status,
                                           Website = c.CompanyWebsite,
                                           Zip = c.Zip
                                       }).ToList();

            return userDetailDto;
        }

        /// <summary>
        /// user entity to dto
        /// </summary>
        /// <param name="user"></param>
        /// <param name="uploadFile"></param>
        /// <param name="baseUrl"></param>
        /// <param name="defaultImage"></param>
        /// <returns></returns>
        public IEnumerable<GetUserDto> UserEntityListToDto(IEnumerable<UserEntity> user, IUploadFile uploadFile, string baseUrl, string defaultImage)
        {
            if (user == null)
            {
                return null;
            }

            List<GetUserDto> getUsers = new();
            foreach (UserEntity userEntity in user)
            {
                GetUserDto userDto = UserEntityToDto(userEntity);
                
                bool fileExists = uploadFile.FileExists(userEntity.ProfilePicture).Result;
                if (!fileExists)
                {
                    userDto.ProfilePicture = defaultImage;
                }
                else
                {
                    userDto.ProfilePicture = $"{baseUrl}{userEntity.ProfilePicture.Replace("\\", "/")}";
                }
                getUsers.Add(userDto);
            }
            return getUsers;
        }

    }
}
