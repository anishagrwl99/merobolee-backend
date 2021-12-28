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
        Task<List<CompanyEntity>> GetCompany(string search);
        Task<CompanyEntity> GetCompany(long companyId);
        Task<Tuple<CompanyEntity, List<UserEntity>, List<TenderEntity>>> GetCompanyDetail(long companyId);

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


        public async Task<Tuple<CompanyEntity, List<UserEntity>, List<TenderEntity>>> GetCompanyDetail(long companyId)
        {
            try
            {
                CompanyEntity company = await meroBoleeDbContexts.CompanyEntities
                                    .Include(x => x.Country)
                                    .Include(x => x.Province)
                                    .Include(x => x.CompanyStatus)
                                    .Where(x => x.CompanyId == companyId)
                                    .FirstOrDefaultAsync();

                if (company != null)
                {

                    List<UserEntity> users = await (from u in meroBoleeDbContexts.UserEntities
                                                    join uc in meroBoleeDbContexts.UserCompanies on u.User_Id equals uc.UserId
                                                    where uc.CompanyId == companyId
                                                    select u
                                                 )
                                             .ToListAsync();

                    List<TenderEntity> tenders = new List<TenderEntity>();
                    if (string.Equals(company.RegisteredAs, "BidInviter", StringComparison.OrdinalIgnoreCase))
                    {
                        tenders = await meroBoleeDbContexts
                                .TenderEntities
                                .Include(x => x.CategoryEntity)
                                .Include(x => x.TenderStatusEntity)
                                .Include(x => x.TenderCards)
                                .Where(x => x.CompanyId == companyId)
                            .ToListAsync();

                    }
                    else if (string.Equals(company.RegisteredAs, "Bidder", StringComparison.OrdinalIgnoreCase))
                    {
                        tenders = await (from b in meroBoleeDbContexts.BidRequestEntities
                                         join t in meroBoleeDbContexts.TenderEntities on b.TenderId equals t.Tender_Id
                                         where b.CompanyId == companyId
                                         select t
                                     )
                                     .Include(t => t.CategoryEntity)
                                     .Include(t => t.TenderStatusEntity)
                                     .Include(t => t.TenderCards)
                                     .ToListAsync<TenderEntity>();
                    }

                    //return companyDetailResponse; 

                    return Tuple.Create(company, users, tenders);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CompanyEntity>> GetCompany(string search)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                {
                    return await meroBoleeDbContexts.CompanyEntities
                        .Include(x=> x.Country)
                        .Include(x=> x.CompanyStatus)
                        .Where(x => x.CompanyId != 1) //1 is merobolee company
                        .ToListAsync();
                }
                else
                {
                    return await meroBoleeDbContexts.CompanyEntities
                        .Include(x => x.Country)
                        .Include(x => x.CompanyStatus)
                        .Where(x => x.Name.ToLower().Contains(search.ToLower()) 
                                 && x.CompanyId != 1 //1 is merobolee company
                    ).ToListAsync();
                }
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
