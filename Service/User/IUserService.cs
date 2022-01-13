using MeroBolee.Dto;
using MeroBolee.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public interface IUserService
    {
        Task<GetUserDto> AddUser(AddUserDto userDto/*, IFormFile frontCitizenship, IFormFile backCitizenship, IFormFile taxClearance, IFormFile PANRegistration, IFormFile companyRegistration, IFormFile experienceDoc, IFormFile bankCreditLetter*/ );
        Task<GetUserDto> SignUp(SignUpDto signUpDto);
        IEnumerable<GetUserDto> GetUser(string search);
        Task<UserDetailDto> GetUserDetail(long id, string baseUrl, string defaultPic);

        Task<GetUserDto> UpdateUserByAdmin(UpdateUserDto userDto);
        Task<GetUserDto> UpdateUserByUser(UpdateUserDto signUpDto);

        Task<UserProfileDto> GetUserProfile(long userId, long companyId, string defaultPic, string baseUrl);
        Task<ProfilePictureResponseDto> UpdateProfilePicture(ProfilePictureDto dto, string baseUrl);
        Task<bool> ChangeUserPassword(ChangePasswordDto dto);

        Task<List<UserEntity>> GetMeroboleeUsers();

    }
}
