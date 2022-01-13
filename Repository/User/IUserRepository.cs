using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public interface IUserRepository : IRepositoryBase<UserEntity>
    {
        Task<UserEntity> AddUser(UserEntity user);
        IEnumerable<UserEntity> GetAllUser(string search);
        Task<Tuple<UserEntity, List<CompanyEntity>>> GetUserDetail(long id);
        Task<UserEntity> GetUserInfoDetail(long id);
        Task<UserEntity> UpdateUser(UserEntity user);
        Task<UserProfileDto> GetUserProfile(long userId, long companyId);
        Task<Tuple<bool, string>> UpdateProfilePicture(long userId, string picLocation);
        Task<bool> ChangeUserPassword(ChangePasswordDto dto);
        Task<List<UserEntity>> GetMeroboleeUsers();

    }
}
