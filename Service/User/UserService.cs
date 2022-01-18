using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public class UserService : UserMapper, IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ICryptoService cryptoService;
        private IUploadFile uploadImage;
        public UserService(IUserRepository userRepository, ICryptoService cryptoService, IUploadFile uploadFileService)
        {
            this.userRepository = userRepository;
            this.cryptoService = cryptoService;
            this.uploadImage = uploadFileService;
        }
        public async Task<GetUserDto> AddUser(AddUserDto userDto/*, IFormFile frontCitizenship, IFormFile backCitizenship, IFormFile taxClearance, IFormFile PANRegistration, IFormFile companyRegistration, IFormFile experienceDoc, IFormFile bankCreditLetter*/)
        {
            UserEntity user = UserDtoEntity(userDto);
            user.Password = cryptoService.Encrypt(user.Password);
            try
            {
                return UserEntityToDto(await userRepository.AddUser(user));
            }
            catch (Exception)
            {
                throw;

            }
        }

        public IEnumerable<GetUserDto> GetUser(string search)
        {
            return UserEntityListToDto(userRepository.GetAllUser(search));
        }

        public async Task<UserDetailDto> GetUserDetail(long id, string baseUrl, string defaultPic)
        {
            Tuple<UserEntity, List<CompanyEntity>> info = await userRepository.GetUserDetail(id);
            info.Item1.ProfilePicture = await GetUserProfilePicture(info.Item1.ProfilePicture, baseUrl, defaultPic);
            return UserDetailDto(info.Item1, info.Item2);
        }

        public async Task<GetUserDto> SignUp(SignUpDto userDto)
        {
            UserEntity user = SignUpDtoEntity(userDto);
            return UserEntityToDto(await userRepository.AddUser(user));
        }

        public async Task<GetUserDto> UpdateUserByAdmin(UpdateUserDto dto)
        {
            UserEntity user = await userRepository.GetUserInfoDetail(dto.Id);
            if(user != null)
            {
                user.FirstName = dto.FirstName;
                user.MiddleName = dto.MiddleName;
                user.LastName = dto.LastName;
                user.Designation = dto.Designation;
                user.Username = dto.UserName;
                user.Date_modified = DateTime.Now;
            }
            return UserEntityToDto(await userRepository.UpdateUser(user));
        }

        public async Task<GetUserDto> UpdateUserByUser( UpdateUserDto dto)
        {
            UserEntity user = await userRepository.GetUserInfoDetail(dto.Id);
            if (user != null)
            {
                user.FirstName = dto.FirstName;
                user.MiddleName = dto.MiddleName;
                user.LastName = dto.LastName;
                user.Designation = dto.Designation;
                user.Username = dto.UserName;
                user.Date_modified = DateTime.Now;
            }
            return UserEntityToDto(await userRepository.UpdateUser(user));

        }

        public async Task<UserProfileDto> GetUserProfile(long userId, long companyId, string defaultPic, string baseUrl)
        {
            try
            {
                UserProfileDto profile = await userRepository.GetUserProfile(userId, companyId);
                profile.ProfilePicture =  await GetUserProfilePicture(profile.ProfilePicture, baseUrl, defaultPic);
                //if(!string.IsNullOrEmpty(profile.ProfilePicture))
                //{
                //    bool fileExists = await uploadImage.FileExists(profile.ProfilePicture);
                //    if(!fileExists)
                //    {
                //        profile.ProfilePicture = defaultPic;
                //    }
                //    else
                //    {
                //        profile.ProfilePicture = $"{baseUrl}{profile.ProfilePicture.Replace("\\", "/")}";
                //    }
                //}
                //else
                //{
                //    profile.ProfilePicture = defaultPic;
                //}
                return profile;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProfilePictureResponseDto> UpdateProfilePicture(ProfilePictureDto dto, string baseUrl)
        {
            try
            {
                string picPath = await uploadImage.Upload(dto.ProfilePicture, "ProfilePicture");
                if (!string.IsNullOrEmpty(picPath))
                {
                    Tuple<bool, string> res = await userRepository.UpdateProfilePicture(dto.UserId, picPath);
                    
                    if (res.Item1)
                    {
                        //delete previous profile;
                        if (!string.IsNullOrEmpty(res.Item2))
                        {
                            await uploadImage.DeleteFile(res.Item2);
                        }
                        return new ProfilePictureResponseDto
                        {
                            UserId = dto.UserId,
                            CompanyId = dto.CompanyId,
                            ProfilePicture = baseUrl + picPath.Replace("\\", "/")
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> ChangeUserPassword(ChangePasswordDto dto)
        {
            try
            {
                if (string.Equals(dto.Password, dto.ConfirmationPassword, StringComparison.Ordinal))
                {
                    dto.Password = cryptoService.Encrypt(dto.Password);
                    dto.ConfirmationPassword = dto.Password;
                    bool isChanged = await userRepository.ChangeUserPassword(dto);
                    return isChanged;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<List<UserEntity>> GetMeroboleeUsers()
        {
            try
            {
                return await userRepository.GetMeroboleeUsers();
            }
            catch ( Exception)
            {

                throw;
            }
        }

        public async Task<List<UserEntity>> GetCompanyUsers(long companyId)
        {
            try
            {
                return await userRepository.GetCompanyUsers(companyId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private async Task<string> GetUserProfilePicture(string profilePic, string basePath, string defaultPic)
        {
            if (!string.IsNullOrEmpty(profilePic))
            {
                bool fileExists = await uploadImage.FileExists(profilePic);
                if (!fileExists)
                {
                    return defaultPic;
                }
                else
                {
                    return $"{basePath}{profilePic.Replace("\\", "/")}";
                }
            }
            else
            {
                return defaultPic;
            }
        }



    }
}
