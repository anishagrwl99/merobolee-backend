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
        public UserRepository(IDbFactory dbFactory, IUploadFile uploadFileService, IUnitOfWork unitOfWork) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
            uploadImage = uploadFileService;
        }
        public async Task<UserEntity> AddUser(UserEntity user)
        {

            try
            {

                UserEntity users = meroBoleeDbContexts.UserEntities.Where(m => m.Username.ToLower() == user.Username.ToLower()).FirstOrDefault(); //|| m.Email == user.Email.ToLower()).FirstOrDefault();
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
                    meroBoleeDbContexts.UserStatusEntities.ToList();
                    meroBoleeDbContexts.CountryEntities.ToList();
                    meroBoleeDbContexts.ProvinceEntities.ToList();
                    meroBoleeDbContexts.DistrictEntities.ToList();
                    meroBoleeDbContexts.CityEntities.ToList();
                    meroBoleeDbContexts.RoleEntities.ToList();
                    meroBoleeDbContexts.MembershipTypeEntities.ToList();
                    meroBoleeDbContexts.MunicipalityEntities.ToList();
                    meroBoleeDbContexts.VDCEntities.ToList();
                    meroBoleeDbContexts.CompanyTypeLookupEntities.ToList();
                    meroBoleeDbContexts.CategoryEntities.ToList();
                    meroBoleeDbContexts.UserExperienceDocEntities.ToList();
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

        public IEnumerable<UserEntity> GetAllUser(string search)
        {
            try
            {
                meroBoleeDbContexts.UserStatusEntities.ToList();
                meroBoleeDbContexts.CountryEntities.ToList();
                meroBoleeDbContexts.ProvinceEntities.ToList();
                meroBoleeDbContexts.DistrictEntities.ToList();
                meroBoleeDbContexts.CityEntities.ToList();
                meroBoleeDbContexts.RoleEntities.ToList();
                meroBoleeDbContexts.MembershipTypeEntities.ToList();
                meroBoleeDbContexts.MunicipalityEntities.ToList();
                meroBoleeDbContexts.VDCEntities.ToList();
                meroBoleeDbContexts.CompanyTypeLookupEntities.ToList();
                meroBoleeDbContexts.CategoryEntities.ToList();
                return meroBoleeDbContexts.UserEntities.Where(m => (search == null)
                || (m.Code.ToString().Contains(search))
                || (m.FirstName.ToLower().Contains(search.ToLower()))
                || (m.MiddleName.ToLower().Contains(search.ToLower()))
                || (m.LastName.ToLower().Contains(search.ToLower()))
                || (m.Designation.ToLower().Contains(search.ToLower()))
                || (m.Email.ToLower().Contains(search.ToLower()))
                || (m.Username.ToLower().Contains(search.ToLower()))
                || (m.UserStatus.Status.ToLower().Contains(search.ToLower()))
                || (m.ActivateDate.ToString().ToLower().Contains(search.ToLower()))
                || (m.ExpriedDate.ToString().ToLower().Contains(search.ToLower()))
                ).ToList();
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
                                                           Phone1 = c.Phone1,
                                                           Phone2 = c.Phone2,
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
                                                       Phone1 = c.Phone1,
                                                       Phone2 = c.Phone2,
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
