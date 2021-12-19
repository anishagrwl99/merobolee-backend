using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public interface ICompanyRepository : IRepositoryBase<CompanyEntity>
    {
        CompanyEntity AddCompany(CompanyEntity companyEntity, long userId);
        UserEntity AddUser(long companyId, UserEntity user);
        IEnumerable<CompanyEntity> GetCompany(string search);
        Task<CompanyEntity> GetCompany(long companyId);
        CompanyDetailResponse GetCompanyDetail(long id, CompanyTypeEnum companyType);

        CompanyEntity UpdateCompany(long id, CompanyEntity cityEntity);

        Task<CompanyEntity> ChangeCompanyStatus(CompanyEntity ent);

    }

    public class CompanyRepository : RepositoryBase<CompanyEntity>, ICompanyRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public CompanyRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public CompanyEntity AddCompany(CompanyEntity companyEntity, long userId)
        {
            try
            {
                companyEntity.Date_created = companyEntity.Date_modified = DateTime.Now;
                meroBoleeDbContexts.CompanyEntities.Add(companyEntity);
                unitOfWork.SaveChange();
                UserCompany uc = new UserCompany
                {
                    CompanyId = companyEntity.CompanyId,
                    UserId = userId
                };
                meroBoleeDbContexts.UserCompanies.Add(uc);
                unitOfWork.SaveChange();
                return companyEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserEntity AddUser(long companyId, UserEntity user)
        {
            try
            {
                meroBoleeDbContexts.UserEntities.Add(user);
                unitOfWork.SaveChange();
                UserCompany uc = new UserCompany
                {
                    CompanyId = companyId,
                    UserId = user.User_Id
                };
                meroBoleeDbContexts.UserCompanies.Add(uc);
                unitOfWork.SaveChange();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public CompanyDetailResponse GetCompanyDetail(long id, CompanyTypeEnum companyType)
        {
            try
            {
                CompanyEntity company = meroBoleeDbContexts.CompanyEntities.Where(x => x.CompanyId == id).FirstOrDefault();
                IQueryable<UserEntity> users = from u in meroBoleeDbContexts.UserEntities
                                         join uc in meroBoleeDbContexts.UserCompanies on u.User_Id equals uc.UserId
                                         where uc.CompanyId == id
                                         select u;

                CompanyDetailResponse companyDetailResponse = new CompanyDetailResponse
                {
                    CompanyId = company.CompanyId,
                    CompanyName = company.Name,
                    CountryId = company.CountryId,
                    ProvinceId = company.ProvinceId,
                    City = company.City,
                    Address1 = company.Address1,
                    Address2 = company.Address2,
                    Address3 = company.Address3,
                    Zip = company.Zip,
                    ReferenceCode = company.ReferenceCode,
                    ContactPerson = company.ContactPerson,
                    CompanyEmail = company.CompanyEmail,
                    CompanyWebsite = company.CompanyWebsite,
                    Phone1 = company.Phone1,
                    Phone2 = company.Phone2

                };
                companyDetailResponse.Users = new List<AddUserReponseDto>();

                foreach (UserEntity u in users)
                {
                    AddUserReponseDto dto = new AddUserReponseDto
                    {
                        UserId = u.User_Id,
                        Designation = u.Designation,
                        FirstName = u.First_Name,
                        MiddleName = u.Middle_Name,
                        LastName = u.Last_Name,
                        PersonEmail = u.Person_email,
                        Username = u.Username
                    };
                    companyDetailResponse.Users.Add(dto);
                }

                companyDetailResponse.Tenders = new List<GetTenderDto>();
                List<TenderEntity> tenders = new List<TenderEntity>();
                if (companyType == CompanyTypeEnum.BidInviter)
                {
                    tenders = meroBoleeDbContexts
                        .TenderEntities
                        .Include(x => x.CategoryEntity)
                        .Where(x => x.CompanyId == id).ToList();
                   
                }
                else if(companyType == CompanyTypeEnum.Bidder)
                {
                    tenders = (from b in meroBoleeDbContexts.BidderRequestEntities
                                 join t in meroBoleeDbContexts.TenderEntities on b.Tender_Id equals t.Tender_Id
                                 where b.CompanyId == id
                                 select t).ToList<TenderEntity>();
                }
                foreach (TenderEntity t in tenders)
                {
                    GetTenderDto dto = new GetTenderDto
                    {
                        TenderId = t.Tender_Id,
                        TenderCode = t.Tender_Code,
                        TenderTitle = t.Tender_Title,
                        Category = t.CategoryEntity.Category,
                        CategoryId = t.Category_Id,
                        LiveStartDate = t.Live_Start_Date,
                        LiveEndDate = t.Live_End_Date,
                        TenderLiveInterval = t.Tender_live_interval,
                        Publish_Date = t.Date_created
                    };
                    companyDetailResponse.Tenders.Add(dto);
                }
                return companyDetailResponse; ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<CompanyEntity> GetCompany(string search)
        {
            try
            {
                return meroBoleeDbContexts.CompanyEntities
                    .Where(m => (search == null)
                             || (m.Name.ToLower().Contains(search.ToLower()))
                ).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<CompanyEntity> GetCompany(long companyId)
        {
            try
            {
                return await meroBoleeDbContexts.CompanyEntities.Where(x => x.CompanyId == companyId).FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CompanyEntity UpdateCompany(long id, CompanyEntity obj)
        {
            try
            {
                CompanyEntity company = meroBoleeDbContexts.CompanyEntities.Where(x => x.CompanyId == id).FirstOrDefault();
                if (company == null)
                {
                    return null;
                }
                company.Address1 = obj.Address1;
                company.Address2 = obj.Address2;
                company.Address3 = obj.Address3;
                company.Zip = obj.Zip;
                company.ContactPerson = obj.ContactPerson;
                company.CompanyEmail = obj.CompanyEmail;
                company.CompanyWebsite = obj.CompanyWebsite;
                company.Phone1 = obj.Phone1;
                company.Phone2 = obj.Phone2;
                company.Date_modified = DateTime.Now;
                unitOfWork.SaveChange();
                return company;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }


        public async Task<CompanyEntity> ChangeCompanyStatus(CompanyEntity ent)
        {
            try
            {
                meroBoleeDbContexts.CompanyEntities.Update(ent);
                await unitOfWork.SaveChangesAsync();
                ent.CompanyStatus = await meroBoleeDbContexts.CompanyStatusEntities.Where(x => x.Id == ent.CompanyStatusId).FirstOrDefaultAsync();
                return ent;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
