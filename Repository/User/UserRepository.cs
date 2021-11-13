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
        public UserRepository(IDbFactory dbFactory, IUploadFile uploadFileService, IUnitOfWork unitOfWork): base(dbFactory)
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
                    user.Activate_Date = DateTime.Now.Date;

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
            catch (ArgumentNullException)
            {
                meroBoleeDbContexts.UserEntities.Remove(user);
                unitOfWork.SaveChange();
                DeleteFile(user.Company_Name);
                throw new ArgumentNullException();
            }
            catch (DbUpdateException)
            {
                meroBoleeDbContexts.UserEntities.Remove(user);
                unitOfWork.SaveChange();
                DeleteFile(user.Company_Name);

                throw new DbUpdateException();
            }

            catch (Exception)
            {
                meroBoleeDbContexts.UserEntities.Remove(user);
                unitOfWork.SaveChange();
                DeleteFile(user.Company_Name);
                throw new Exception();
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
                || (m.User_Code.ToString().Contains(search))
                || (m.First_Name.ToLower().Contains(search.ToLower()))
                || (m.Middle_Name.ToLower().Contains(search.ToLower()))
                || (m.Last_Name.ToLower().Contains(search.ToLower()))
                || (m.Designation.ToLower().Contains(search.ToLower()))                
                || (m.Person_email.ToLower().Contains(search.ToLower()))
                || (m.Username.ToLower().Contains(search.ToLower()))                
                || (m.UserStatus.Status.ToLower().Contains(search.ToLower()))
                || (m.Activate_Date.ToString().ToLower().Contains(search.ToLower()))
                || (m.Expried_Date.ToString().ToLower().Contains(search.ToLower()))
                ).ToList();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public UserEntity GetUserDetail(long id)
        {
            try
            {
                UserEntity user = meroBoleeDbContexts.UserEntities.Find(id);
                if (user == null)
                {
                    return user = null;
                }
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
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        
        public async Task<UserEntity> UpdateUser(int id, UserEntity userdto)
        {
            try
            {
                UserEntity user = GetUserDetail(id);
                DeleteFile(user.Company_Name);
                int salt = 6;
                string hashPasswod = BCrypt.Net.BCrypt.HashPassword(userdto.Password, salt);
                userdto.Password = hashPasswod;

                UserEntity users = meroBoleeDbContexts.UserEntities.Where(m => (m.Username == userdto.Username.ToLower()/*|| m.Email == user.Email.ToLower()*/ && m.User_Id != user.User_Id)).FirstOrDefault();
                if (users != null)
                {
                    throw new UnauthorizedAccessException();
                }
               
                else
                {                    
                    user.First_Name = userdto.First_Name;
                    user.Middle_Name = userdto.Middle_Name;
                    user.Last_Name = userdto.Last_Name;
                    user.Designation = userdto.Designation;                    

                    //  user.User_experience = userdto.User_experience;
                    user.Username = userdto.Username;
                    user.Password = userdto.Password;
                    user.Role_Id = userdto.Role_Id;
                    user.Activate_Date = userdto.Activate_Date;
                    user.Date_modified = user.Date_modified;
                    //user.Modified_time_stamp= user.Modified_time_stamp;
                    await unitOfWork.SaveChangesAsync();
                    meroBoleeDbContexts.RoleEntities.ToList();
                    return user;
                }

            }

            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }


        public string GetUserCompany(int id)
        {
            try
            {
                string userCompany = meroBoleeDbContexts.UserEntities
                                .Where(x => x.User_Id == id)
                                .Select(x => x.Company_Name)
                                .DefaultIfEmpty("")
                                .FirstOrDefault();
                
                return userCompany;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
