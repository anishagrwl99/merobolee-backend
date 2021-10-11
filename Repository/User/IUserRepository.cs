using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.User
{
   public interface IUserRepository : IRepositoryBase<UserEntity>
    {
       Task<UserEntity> AddUser(UserEntity user, ICollection<IFormFile> files);
        IEnumerable<UserEntity> GetAllUser(string search);
        UserEntity GetUserDetail(long id);
       Task<UserEntity> UpdateUser(int id, UserEntity user, ICollection<IFormFile> files);
       
    }
}
