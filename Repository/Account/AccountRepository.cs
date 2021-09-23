using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public interface IAccountRepository
    {
        Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest request);
    }
    public class AccountRepository : RepositoryBase<UserEntity>, IAccountRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public AccountRepository(IUnitOfWork unitOfWork, IDbFactory dbFactory) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest request)
        {
            return Task.Run(() =>
            {
                string hashPassword = BCrypt.Net.BCrypt.HashPassword(request.Password, CryptoConfig.Salt);
                UserEntity userEntity = meroBoleeDbContexts.UserEntities
                .Where(x => x.Person_email == request.Email && x.Password == hashPassword)
                .Include(x => x.Role)
                .FirstOrDefault();
                
                if (userEntity != null)
                {
                    return new AuthenticateResponse
                    {
                        Id = userEntity.User_Id,
                        FirstName = userEntity.First_Name,
                        LastName = userEntity.Last_Name,
                        Created = userEntity.Date_created,
                        Email = userEntity.Person_email,
                        Role = userEntity.Role.Role_Name
                    };
                }
                return null;
            });
            

        }


    }
}
