using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Repository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.User
{
    public class UserService : UserMapper, IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public GetUserDto AddUser(AddUserDto userDto)
        {
            return UserEntityToDto(userRepository.AddUser(UserDtoEntity(userDto)));
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
