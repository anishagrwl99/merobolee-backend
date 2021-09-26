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

namespace MeroBolee.Repository.User
{
    public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private UploadImage uploadImage = new UploadImage();
        public UserRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork): base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<UserEntity> AddUser(UserEntity user,ICollection<IFormFile> experience)
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
                    if (user.Municipality_Id == 0)
                    {
                        user.Municipality_Id = null;
                    }
                    if (user.Vdc_id == 0)
                    {
                        user.Vdc_id = null;
                    }
                    user.Date_created = DateTime.Now.Date;
                    user.Date_modified = DateTime.Now.Date;
                    user.Activate_Date = DateTime.Now.Date;
                    MembershipTypeEntity packages = meroBoleeDbContexts.MembershipTypeEntities.Where(m => m.Membership_Id == user.Membership_Id).FirstOrDefault();
                    if (packages != null)
                    {
                        if (packages.Duration_Type == "Days")
                        {
                            user.Expried_Date = DateTime.Now.AddDays(packages.Duration);
                        }
                        else if (packages.Duration_Type == "Months")
                        {
                            user.Expried_Date = DateTime.Now.AddMonths(packages.Duration);
                        }
                        else
                        {
                            user.Expried_Date = DateTime.Now.AddYears(packages.Duration);
                        }
                    }

                    else
                    {
                        user.Membership_Id = null;
                        user.Expried_Date = null;
                        user.Activate_Date = null;
                    }
                    meroBoleeDbContexts.UserEntities.Add(user);
                    unitOfWork.SaveChange();
                    if (experience == null)
                    {
                        user.Experienced_document = null;

                    }
                    else
                    {
                        foreach (var doc in experience)
                        {
                            meroBoleeDbContexts.UserExperienceDocEntities.Add(new UserExperienceDocEntity
                            {
                                User_id = user.User_Id,
                                Experienced_doc = await uploadImage.Upload(doc, user.Company_Name)
                            }
                            );
                            unitOfWork.SaveChange();
                        }
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
                    meroBoleeDbContexts.CompanyTypeEntities.ToList();
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
                meroBoleeDbContexts.CompanyTypeEntities.ToList();
                meroBoleeDbContexts.CategoryEntities.ToList();
                return meroBoleeDbContexts.UserEntities.Where(m => (search == null)
                || (m.User_Code.ToString().Contains(search))
                || (m.Company_Name.ToLower().Contains(search.ToLower()))
                || (m.Category.Category.ToLower().Contains(search.ToLower()))
                || (m.Registration_No.ToLower().Contains(search.ToLower()))
                || (m.Company_Name.ToLower().Contains(search.ToLower()))
                || (m.Country.Country_Name.ToLower().Contains(search.ToLower()))
                || (m.Province.Province.ToLower().Contains(search.ToLower()))
                || (m.District.District_Name.ToLower().Contains(search.ToLower()))
                || (m.City.City_Name.ToLower().Contains(search.ToLower()))
                || (m.Address1.ToLower().Contains(search.ToLower()))
                || (m.Address2.ToLower().Contains(search.ToLower()))
                || (m.Address3.ToLower().Contains(search.ToLower()))
                || (m.Company_Contact1.ToLower().Contains(search.ToLower()))
                || (m.Company_Contact2.ToLower().Contains(search.ToLower()))
                || (m.Company_email.ToLower().Contains(search.ToLower()))
                || (m.Description.ToLower().Contains(search.ToLower()))
                || (m.Vat_Pan_No.ToLower().Contains(search.ToLower()))
                || (m.Website.ToLower().Contains(search.ToLower()))
                || (m.Fax_No.ToLower().Contains(search.ToLower()))
                || (m.Salutation.ToLower().Contains(search.ToLower()))
                || (m.First_Name.ToLower().Contains(search.ToLower()))
                || (m.Middle_Name.ToLower().Contains(search.ToLower()))
                || (m.Last_Name.ToLower().Contains(search.ToLower()))
                || (m.Designation.ToLower().Contains(search.ToLower()))
                || (m.Person_contact1.ToLower().Contains(search.ToLower()))
                || (m.Person_contact2.ToLower().Contains(search.ToLower()))
                || (m.Person_email.ToLower().Contains(search.ToLower()))
                || (m.Username.ToLower().Contains(search.ToLower()))
                || (m.CompanyType.Company_type.ToLower().Contains(search.ToLower()))
                || (m.Website.ToLower().Contains(search.ToLower()))
                || (m.Fax_No.ToLower().Contains(search.ToLower()))
                || (m.UserStatus.Status.ToLower().Contains(search.ToLower()))
                || (m.MembershipType.Membership_Title.ToLower().Contains(search.ToLower()))
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

        public UserEntity GetUserDetail(int id)
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
                meroBoleeDbContexts.CompanyTypeEntities.ToList();
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
        
        public async Task<UserEntity> UpdateUser(int id, UserEntity userdto, ICollection<IFormFile> files)
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
                    user.Company_Name = userdto.Company_Name;
                    user.Registration_No = userdto.Registration_No;
                    user.Country_Id = userdto.Country_Id;
                    user.Province_Id = userdto.Province_Id;
                    user.District_Id = userdto.District_Id;
                    user.City_Id = userdto.City_Id;
                    user.Municipality_Id = userdto.Municipality_Id;
                    user.Vdc_id = userdto.Vdc_id;
                    user.Register_Country = userdto.Register_Country;
                    user.Company_Type_Id = userdto.Company_Type_Id;
                    user.Company_acronym = userdto.Company_acronym;
                    user.Description = userdto.Description;
                    user.Employee_no = userdto.Employee_no;
                    user.Category_Id = userdto.Category_Id;
                    user.Vat_Pan_No = userdto.Vat_Pan_No;
                    user.Website = userdto.Website;
                    user.Address1 = userdto.Address1;
                    user.Address2 = userdto.Address2;
                    user.Address3 = userdto.Address3;
                    user.Fax_No = userdto.Fax_No;
                    user.Company_email = userdto.Company_email;
                    user.Company_Contact1 = userdto.Company_Contact1;
                    user.Company_Contact2 = userdto.Company_Contact2;
                    user.Salutation = userdto.Salutation;
                    user.First_Name = userdto.First_Name;
                    user.Middle_Name = userdto.Middle_Name;
                    user.Last_Name = userdto.Last_Name;
                    user.Designation = userdto.Designation;
                    user.Person_contact1 = userdto.Person_contact1;
                    user.Person_contact2 = userdto.Person_contact2;
                    user.Person_email = userdto.Person_email;
                    user.Front_Citizenship = userdto.Front_Citizenship;
                    user.Back_Citizenship = userdto.Back_Citizenship;
                    user.Tax_Clearance = userdto.Tax_Clearance;
                    user.Pan_Vat_Registration = userdto.Pan_Vat_Registration;
                    user.Company_Registration = userdto.Company_Registration;
                    if (files == null)
                    {
                        List<UserExperienceDocEntity> docEntities = meroBoleeDbContexts.UserExperienceDocEntities.Where(m => m.User_id == user.User_Id).ToList();
                        foreach (var file in docEntities)
                        {
                            meroBoleeDbContexts.UserExperienceDocEntities.Remove(file);
                            unitOfWork.SaveChange();
                        }
                    }
                    else
                    {
                        foreach (var doc in files)
                        {
                            List<UserExperienceDocEntity> docEntities = meroBoleeDbContexts.UserExperienceDocEntities.Where(m => m.User_id == user.User_Id).ToList();
                            foreach (var file in docEntities)
                            {
                                meroBoleeDbContexts.UserExperienceDocEntities.Remove(file);
                                unitOfWork.SaveChange();
                            }
                            meroBoleeDbContexts.UserExperienceDocEntities.Add(new UserExperienceDocEntity
                            {
                                User_id = user.User_Id,
                                Experienced_doc = await uploadImage.Upload(doc, user.Company_Name)
                            }
                            );
                            unitOfWork.SaveChange();
                        }
                    }

                    //  user.User_experience = userdto.User_experience;
                    user.Bank_credit_letter = userdto.Bank_credit_letter;
                    user.Username = userdto.Username;
                    user.Password = userdto.Password;
                    user.Role_Id = userdto.Role_Id;
                    user.Membership_Id = userdto.Membership_Id;
                    user.Activate_Date = userdto.Activate_Date;
                    user.Date_modified = user.Date_modified;
                    //user.Modified_time_stamp= user.Modified_time_stamp;
                    unitOfWork.SaveChange();
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
