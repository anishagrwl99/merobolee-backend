using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Repository.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.User
{
    public class UserService : UserMapper, IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ICryptoService cryptoService;
        private UploadImage uploadImage = new UploadImage();
        public UserService(IUserRepository userRepository, ICryptoService cryptoService)
        {
            this.userRepository = userRepository;
            this.cryptoService = cryptoService;
        }
        public async Task<GetUserDto> AddUser(AddUserDto userDto/*, IFormFile frontCitizenship, IFormFile backCitizenship, IFormFile taxClearance, IFormFile PANRegistration, IFormFile companyRegistration, IFormFile experienceDoc, IFormFile bankCreditLetter*/)
        {
            UserEntity user = UserDtoEntity(userDto);
            user.Password = cryptoService.Encrypt(user.Password);
            try
            {
                return UserEntityToDto(await userRepository.AddUser(user, userDto.Experienced_document));
            }
            catch (Exception ex)
            {    

                throw ex;

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
            return UserEntityToDto(await userRepository.AddUser(user,userDto.Experienced_document));
        }

        public  async Task<GetUserDto> UpdateUserByAdmin(int id, AddUserDto userDto)
        {
            UserEntity user = UserDtoEntity(userDto);
            return UserEntityToDto(await userRepository.UpdateUser(id, user, userDto.Experienced_document));
        }

        public async Task<GetUserDto> UpdateUserByUser(int id, SignUpDto userDto)
        {
            UserEntity user = SignUpDtoEntity(userDto);
            return UserEntityToDto( await userRepository.UpdateUser(id, user, userDto.Experienced_document));
        }

       
    }
}
