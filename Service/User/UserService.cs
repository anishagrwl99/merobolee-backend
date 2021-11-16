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

        public GetUserDto GetUserDetail(long id)
        {
            return UserEntityToDto(userRepository.GetUserDetail(id));
        }

        public async Task<GetUserDto> SignUp(SignUpDto userDto)
        {
            UserEntity user = SignUpDtoEntity(userDto);
            return UserEntityToDto(await userRepository.AddUser(user));
        }

        public async Task<GetUserDto> UpdateUserByAdmin(int id, AddUserDto userDto)
        {
            UserEntity user = UserDtoEntity(userDto);
            return UserEntityToDto(await userRepository.UpdateUser(id, user));
        }

        public async Task<GetUserDto> UpdateUserByUser(int id, SignUpDto userDto)
        {
            UserEntity user = SignUpDtoEntity(userDto);
            return UserEntityToDto(await userRepository.UpdateUser(id, user));
        }

        public async Task<UserProfileDto> GetUserProfile(long userId, long companyId, string defaultPic)
        {
            try
            {
                UserProfileDto profile = await userRepository.GetUserProfile(userId, companyId);
                if(!string.IsNullOrEmpty(profile.ProfilePicture))
                {
                    bool fileExists = await uploadImage.FileExists(profile.ProfilePicture);
                    if(fileExists != false)
                    {
                        profile.ProfilePicture = defaultPic;
                    }
                }
                else
                {
                    profile.ProfilePicture = defaultPic;
                }
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
                        if(!string.IsNullOrEmpty(res.Item2))
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

    }
}
