using MeroBolee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.User
{
    public interface IUserService
    {
        GetUserDto AddUser(AddUserDto userDto);
        GetUserDto SignUp(SignUpDto signUpDto);
        IEnumerable<GetUserDto> GetUser(string search);
        GetUserDto GetUserDetail(int id);

        GetUserDto UpdateUserByAdmin(int id, AddUserDto userDto);
        GetUserDto UpdateUserByUser(int id, SignUpDto signUpDto);
       
    }
}
