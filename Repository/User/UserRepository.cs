using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.User
{
    public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public UserRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork): base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }
        public UserEntity AddUser(UserEntity user)
        {
            try
            {
                int salt = 6;
                string hashPasswod = BCrypt.Net.BCrypt.HashPassword(user.Password, salt);
                user.Password = hashPasswod;

                UserEntity users = meroBoleeDbContexts.UserEntities.Where(m => m.Username == user.Username.ToLower()).FirstOrDefault(); //|| m.Email == user.Email.ToLower()).FirstOrDefault();
                if (users != null)
                {
                    throw new UnauthorizedAccessException();
                }
                else
                {
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
                        user.Expried_Date = null;
                        user.Activate_Date = null;
                    }

                    meroBoleeDbContexts.UserEntities.Add(user);
                    unitOfWork.SaveChange();
                    meroBoleeDbContexts.UserStatusEntities.ToList();
                    meroBoleeDbContexts.CountryEntities.ToList();
                    meroBoleeDbContexts.ProvinceEntities.ToList();
                    meroBoleeDbContexts.DistrictEntities.ToList();
                    meroBoleeDbContexts.CityEntities.ToList();
                    meroBoleeDbContexts.RoleEntities.ToList();
                    meroBoleeDbContexts.MembershipTypeEntities.ToList();
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
                return meroBoleeDbContexts.UserEntities.Where(m => (search == null)
                || (m.Company_Name.ToLower().Contains(search.ToLower()))
           //     || (m.Company_Type.ToLower().Contains(search.ToLower()))
                || (m.Registration_No.ToLower().Contains(search.ToLower()))
                || (m.Company_Name.ToLower().Contains(search.ToLower()))
                || (m.Country.Country_Name.ToLower().Contains(search.ToLower()))
                || (m.Province.Province.ToLower().Contains(search.ToLower()))
                || (m.District.District_Name.ToLower().Contains(search.ToLower()))
                || (m.City.City_Name.ToLower().Contains(search.ToLower()))
                //|| (m.Address.Contains(search.ToLower()))
                //|| (m.Email.ToLower().Contains(search.ToLower()))
                //|| (m.Phone_No.ToLower().Contains(search.ToLower()))
                //|| (m.Contact_person.ToLower().Contains(search.ToLower()))
                //|| (m.Position.ToLower().Contains(search.ToLower()))
                //|| (m.Contact_No.ToLower().Contains(search.ToLower()))
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
        
        public UserEntity UpdateUser(int id, UserEntity user)
        {
            try
            {
                UserEntity toBeEdit = GetUserDetail(id);
                int salt = 6;
                string hashPasswod = BCrypt.Net.BCrypt.HashPassword(user.Password, salt);
                user.Password = hashPasswod;

                UserEntity users = meroBoleeDbContexts.UserEntities.Where(m => (m.Username == user.Username.ToLower()/*|| m.Email == user.Email.ToLower()*/ && m.User_Id != toBeEdit.User_Id)).FirstOrDefault();
                if (users != null)
                {
                    throw new UnauthorizedAccessException();
                }
               
                else
                {                   
                        toBeEdit.Company_Name = user.Company_Name;
                      //  toBeEdit.Company_Type = user.Company_Type;
                        toBeEdit.Registration_No = user.Registration_No;
                        toBeEdit.Country_Id = user.Country_Id;
                        toBeEdit.Province_Id = user.Province_Id;
                        toBeEdit.District_Id = user.District_Id;
                        toBeEdit.City_Id = user.City_Id;
                        //toBeEdit.Address = user.Address;
                        //toBeEdit.Email = user.Email;
                        //toBeEdit.Phone_No = user.Phone_No;
                        //toBeEdit.Contact_person = user.Contact_person;
                        //toBeEdit.Contact_No = user.Contact_No;
                        //toBeEdit.Position = user.Position;
                        toBeEdit.Username = user.Username;
                        toBeEdit.Password = user.Password;
                        toBeEdit.Expried_Date = user.Expried_Date;
                        toBeEdit.Membership_Id = user.Membership_Id;
                        //toBeEdit.Status_I = user.Status_I;
                    toBeEdit.Date_modified = user.Date_modified;
                    toBeEdit.Modified_time_stamp= user.Modified_time_stamp;
                        unitOfWork.SaveChange();
                    meroBoleeDbContexts.RoleEntities.ToList();
                    return toBeEdit;
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

        public UserEntity UpdateUserByUser(int id, UserEntity user)
        {
            try
            {
                UserEntity toBeEdit = GetUserDetail(id);
                int salt = 6;
                string hashPasswod = BCrypt.Net.BCrypt.HashPassword(user.Password, salt);
                user.Password = hashPasswod;

                UserEntity users = meroBoleeDbContexts.UserEntities.Where(m => (m.Username == user.Username.ToLower()/* || m.Email == user.Email.ToLower()*/ && m.User_Id != toBeEdit.User_Id)).FirstOrDefault();
                if (users != null)
                {
                    throw new UnauthorizedAccessException();
                }

                else
                {
                    toBeEdit.Company_Name = user.Company_Name;
                //    toBeEdit.Company_Type = user.Company_Type;
                    toBeEdit.Registration_No = user.Registration_No;
                    toBeEdit.Country_Id = user.Country_Id;
                    toBeEdit.Province_Id = user.Province_Id;
                    toBeEdit.District_Id = user.District_Id;
                    toBeEdit.City_Id = user.City_Id;
                    //toBeEdit.Address = user.Address;
                    //toBeEdit.Email = user.Email;
                    //toBeEdit.Phone_No = user.Phone_No;
                    //toBeEdit.Contact_person = user.Contact_person;
                    //toBeEdit.Contact_No = user.Contact_No;
                    //toBeEdit.Position = user.Position;
                    toBeEdit.Username = user.Username;
                    toBeEdit.Password = user.Password;
                    toBeEdit.Date_modified = user.Date_modified;
                    toBeEdit.Modified_time_stamp = user.Modified_time_stamp;
                    unitOfWork.SaveChange();
                    meroBoleeDbContexts.RoleEntities.ToList();
                    return toBeEdit;
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

    }
}
