using MeroBolee.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.User
{
    public interface IUserService
    {
        Task<GetUserDto> AddUser(AddUserDto userDto/*, IFormFile frontCitizenship, IFormFile backCitizenship, IFormFile taxClearance, IFormFile PANRegistration, IFormFile companyRegistration, IFormFile experienceDoc, IFormFile bankCreditLetter*/ );
        Task<GetUserDto> SignUp(SignUpDto signUpDto);
        IEnumerable<GetUserDto> GetUser(string search);
        GetUserDto GetUserDetail(long id);

        Task<GetUserDto> UpdateUserByAdmin(int id, AddUserDto userDto);
       Task<GetUserDto> UpdateUserByUser(int id, SignUpDto signUpDto);
       
    }
}
