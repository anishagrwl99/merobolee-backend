using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.User
{
   public interface IUserRepository : IRepositoryBase<UserEntity>
    {
        UserEntity AddUser(UserEntity user);
        IEnumerable<UserEntity> GetAllUser(string search);
        UserEntity GetUserDetail(int id);
        UserEntity UpdateUser(int id, UserEntity user);
        UserEntity UpdateUserByUser(int id, UserEntity user);
    }
}
