using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private IUploadFile uploadImage;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="dbFactory">The database factory.</param>
        /// <param name="uploadFileService">The upload file service.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public UserRepository(IDbFactory dbFactory, IUploadFile uploadFileService, IUnitOfWork unitOfWork) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
            uploadImage = uploadFileService;
        }


        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        public async Task<UserEntity> AddUser(UserEntity user)
        {

            try
            {

                UserEntity users = meroBoleeDbContexts.UserEntities
                    .Include(x => x.UserStatus)
                    .Include(x => x.Role)
                    .Where(m => m.Username.ToLower() == user.Username.ToLower())
                    .FirstOrDefault(); //|| m.Email == user.Email.ToLower()).FirstOrDefault();
                if (users != null)
                {
                    throw new UnauthorizedAccessException();
                }
                else
                {
                    user.Date_created = DateTime.Now.Date;
                    user.Date_modified = DateTime.Now.Date;
                    user.ActivateDate = DateTime.Now.Date;

                    meroBoleeDbContexts.UserEntities.Add(user);
                    await unitOfWork.SaveChangesAsync();
                    
                    return user;
                }
            }
            catch (Exception)
            {
                meroBoleeDbContexts.UserEntities.Remove(user);
                unitOfWork.SaveChange();
                DeleteFile(user.CompanyName);
                throw;
            }
        }

        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="companyName">Name of the company.</param>
        private void DeleteFile(string companyName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Resource\\" + companyName);
            if (Directory.Exists(path) == true)
            {
                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    File.Delete(file);
                }
                Directory.Delete(path);
            }

        }

        /// <summary>
        /// Gets all user.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<UserEntity>> GetAllUser(long companyId)
        {
            try
            {
                return await (from uc in meroBoleeDbContexts.UserCompanies
                              join u in meroBoleeDbContexts.UserEntities on uc.UserId equals u.Id
                              join us in meroBoleeDbContexts.UserStatusEntities on u.StatusId equals us.Id
                              join r in meroBoleeDbContexts.RoleEntities on u.RoleId equals r.Id
                              where uc.CompanyId == companyId
                              select new UserEntity
                              {
                                  Id = u.Id,
                                  ActivateDate = u.ActivateDate,
                                  Code = u.Code,
                                  RoleId = u.RoleId,
                                  Date_created = u.Date_created,
                                  CompanyName  = "",
                                  Date_modified = u.Date_modified,
                                  Designation = u.Designation,
                                  Email = u.Email,
                                  ExpriedDate = u.ExpriedDate,
                                  FirstName = u.FirstName,
                                  IsEmailReceiver = u.IsEmailReceiver,
                                  LastName = u.LastName,
                                  MiddleName = u.MiddleName,
                                  Password = null,
                                  ProfilePicture = u.ProfilePicture,
                                  Username = u.Username,
                                  StatusId = u.StatusId,
                                  Role = r,
                                  UserStatus = us
                              }
                 ).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Tuple<UserEntity, List<CompanyEntity>>> GetUserDetail(long id)
        {
            try
            {
                UserEntity user = await meroBoleeDbContexts.UserEntities
                                    .Include(x => x.UserStatus)
                                    .Include(x => x.Role)
                                    .Where(x => x.Id == id)
                                    .FirstOrDefaultAsync();

                List<CompanyEntity> companies = await (from uc in meroBoleeDbContexts.UserCompanies
                                                       join c in meroBoleeDbContexts.CompanyEntities on uc.CompanyId equals c.CompanyId
                                                       join p in meroBoleeDbContexts.ProvinceEntities on c.ProvinceId equals p.Id
                                                       join ct in meroBoleeDbContexts.CountryEntities on c.CountryId equals ct.Id
                                                       join s in meroBoleeDbContexts.CompanyStatusEntities on c.CompanyStatusId equals s.Id
                                                       where uc.UserId == id
                                                       select new CompanyEntity
                                                       {
                                                           Address1 = c.Address1,
                                                           Address2 = c.Address2,
                                                           Address3 = c.Address3,
                                                           City = c.City,
                                                           ReferenceCode = c.ReferenceCode,
                                                           Country = ct,
                                                           CompanyEmail = c.CompanyEmail,
                                                           CompanyId = c.CompanyId,
                                                           Name = c.Name,
                                                           MobileNumber = c.MobileNumber,
                                                           PhoneNumber = c.PhoneNumber,
                                                           Province = p,
                                                           Date_created = c.Date_created,
                                                           CompanyStatus = s,
                                                           CompanyWebsite = c.CompanyWebsite,
                                                           Zip = c.Zip

                                                       }

                                                 ).ToListAsync();
                return Tuple.Create(user, companies);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<UserEntity> GetUserInfoDetail(long id)
        {
            try
            {
                UserEntity user = await meroBoleeDbContexts.UserEntities
                                    .Include(x => x.UserStatus)
                                    .Include(x => x.Role)
                                    .Where(x => x.Id == id)
                                    .FirstOrDefaultAsync();
                if (user == null)
                {
                    return null;
                }
                //meroBoleeDbContexts.UserStatusEntities.ToList();
                //meroBoleeDbContexts.CountryEntities.ToList();
                //meroBoleeDbContexts.ProvinceEntities.ToList();
                //meroBoleeDbContexts.DistrictEntities.ToList();
                //meroBoleeDbContexts.CityEntities.ToList();
                //meroBoleeDbContexts.RoleEntities.ToList();
                //meroBoleeDbContexts.MembershipTypeEntities.ToList();
                //meroBoleeDbContexts.MunicipalityEntities.ToList();
                //meroBoleeDbContexts.VDCEntities.ToList();
                //meroBoleeDbContexts.CompanyTypeLookupEntities.ToList();
                //meroBoleeDbContexts.CategoryEntities.ToList();
                //meroBoleeDbContexts.UserExperienceDocEntities.ToList();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserEntity> UpdateUser(UserEntity user)
        {
            try
            {
                meroBoleeDbContexts.UserEntities.Update(user);
                await unitOfWork.SaveChangesAsync();
                return user;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public string GetUserCompany(long id)
        {
            try
            {
                string userCompany = meroBoleeDbContexts.UserEntities
                                .Where(x => x.Id == id)
                                .Select(x => x.CompanyName)
                                .DefaultIfEmpty("")
                                .FirstOrDefault();

                return userCompany;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserProfileDto> GetUserProfile(long userId, long companyId)
        {
            try
            {
                return await (from u in meroBoleeDbContexts.UserEntities
                              join s in meroBoleeDbContexts.UserStatusEntities on u.StatusId equals s.Id
                              where u.Id == userId
                              select new UserProfileDto
                              {
                                  Id = u.Id,
                                  Designation = u.Designation,
                                  Email = u.Email,
                                  FirstName = u.FirstName,
                                  LastName = u.LastName,
                                  MiddleName = u.MiddleName,
                                  ProfilePicture = u.ProfilePicture,
                                  Status = s.Status,
                                  UserCompanies = (from uc in meroBoleeDbContexts.UserCompanies
                                                   join c in meroBoleeDbContexts.CompanyEntities on uc.CompanyId equals c.CompanyId
                                                   join c1 in meroBoleeDbContexts.CountryEntities on c.CountryId equals c1.Id
                                                   join p in meroBoleeDbContexts.ProvinceEntities on c.ProvinceId equals p.Id
                                                   join s in meroBoleeDbContexts.CompanyStatusEntities on c.CompanyStatusId equals s.Id
                                                   where uc.UserId == userId
                                                   select new CompanyDto()
                                                   {
                                                       Id = c.CompanyId,
                                                       Address1 = c.Address1,
                                                       Address2 = c.Address2,
                                                       Address3 = c.Address3,
                                                       City = c.City,
                                                       Code = c.ReferenceCode,
                                                       Name = c.Name,
                                                       Country = c1.Name,
                                                       Email = c.CompanyEmail,
                                                       MobileNumber = c.MobileNumber,
                                                       PhoneNumber = c.PhoneNumber,
                                                       Province = p.Name,
                                                       RegisteredDate = c.Date_created,
                                                       Status = s.Status,
                                                       Website = c.CompanyWebsite,
                                                       Zip = c.Zip
                                                   }
                                                   ).ToList()
                              }

                    ).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Tuple<bool, string>> UpdateProfilePicture(long userId, string picLocation)
        {
            try
            {
                UserEntity u = await meroBoleeDbContexts.UserEntities.Where(x => x.Id == userId).FirstOrDefaultAsync();
                if (u != null)
                {
                    string oldPic = u.ProfilePicture;
                    u.ProfilePicture = picLocation;
                    meroBoleeDbContexts.UserEntities.Update(u);
                    await unitOfWork.SaveChangesAsync();
                    return Tuple.Create(true, oldPic);
                }
                else
                {
                    return Tuple.Create(false, "");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> ChangeUserPassword(ChangePasswordDto dto)
        {
            try
            {
                UserEntity u = await meroBoleeDbContexts.UserEntities.Where(x => x.Id == dto.UserId).FirstOrDefaultAsync();
                if (u != null)
                {
                    u.Password = dto.Password;
                    meroBoleeDbContexts.UserEntities.Update(u);
                    await unitOfWork.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<UserEntity>> GetMeroboleeUsers()
        {
            try
            {
                return await (from u in meroBoleeDbContexts.UserEntities
                              join uc in meroBoleeDbContexts.UserCompanies on u.Id equals uc.UserId
                              where uc.CompanyId == 1
                              select u
                    ).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<UserEntity>> GetCompanyUsers(long companyId)
        {
            try
            {
                return await (from u in meroBoleeDbContexts.UserEntities
                              join uc in meroBoleeDbContexts.UserCompanies on u.Id equals uc.UserId
                              where uc.CompanyId == companyId
                              select u
                    ).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
