using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Repository.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.User
{
    public class UserService : UserMapper, IUserService
    {
        private readonly IUserRepository userRepository;
        private UploadImage uploadImage = new UploadImage();
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<GetUserDto> AddUser(AddUserDto userDto/*, IFormFile frontCitizenship, IFormFile backCitizenship, IFormFile taxClearance, IFormFile PANRegistration, IFormFile companyRegistration, IFormFile experienceDoc, IFormFile bankCreditLetter*/)
        {
            UserEntity user = UserDtoEntity(userDto);
            user.Front_Citizenship = await uploadImage.Upload(userDto.Front_Citizenship,userDto.Company_Name,userDto.Front_Citizenship.Name);
            user.Back_Citizenship = await uploadImage.Upload(userDto.Back_Citizenship, userDto.Company_Name,userDto.Back_Citizenship.Name);
            user.Tax_Clearance = await uploadImage.Upload(userDto.Tax_Clearance, userDto.Company_Name,userDto.Tax_Clearance.Name);
            user.Pan_Vat_Registration = await uploadImage.Upload(userDto.Pan_Vat_Registration, userDto.Company_Name, userDto.Pan_Vat_Registration.Name);
            user.Company_Registration = await uploadImage.Upload(userDto.Company_Registration, userDto.Company_Name, userDto.Company_Registration.Name);
            user.Experienced_document = await uploadImage.Upload(userDto.Experienced_document, userDto.Company_Name, userDto.Experienced_document.Name);
            user.Bank_credit_letter = await uploadImage.Upload(userDto.Bank_credit_letter, userDto.Company_Name,userDto.Bank_credit_letter.Name);
            return UserEntityToDto(userRepository.AddUser(user));
        }

        public IEnumerable<GetUserDto> GetUser(string search)
        {
            return UserEntityListToDto(userRepository.GetAllUser(search));
        }

        public GetUserDto GetUserDetail(int id)
        {
            return UserEntityToDto(userRepository.GetUserDetail(id));
        }

        public GetUserDto SignUp(SignUpDto signUpDto)
        {
            return UserEntityToDto(userRepository.AddUser(SignUpDtoEntity(signUpDto)));
        }

        public GetUserDto UpdateUserByAdmin(int id, AddUserDto userDto)
        {
            return UserEntityToDto(userRepository.UpdateUser(id, UserDtoEntity(userDto)));
        }

        public GetUserDto UpdateUserByUser(int id, SignUpDto signUpDto)
        {
            return UserEntityToDto(userRepository.UpdateUserByUser(id, SignUpDtoEntity(signUpDto)));
        }
    }
}
