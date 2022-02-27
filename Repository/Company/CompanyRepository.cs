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
        Task<CompanyEntity> AddCompany(CompanyEntity companyEntity, long userId);
        Task<UserEntity> AddUser(long companyId, UserEntity user);
        Task<List<CompanyEntity>> GetCompanyByType(CompanyTypeEnum companyType, string search);
        Task<List<CompanyEntity>> GetAllCompany( string search);
        Task<List<CompanyEntity>> GetVerifiedCompany(CompanyTypeEnum companyType, string search);


        Task<CompanyEntity> GetCompany(long companyId);
        Task<Tuple<CompanyEntity, List<UserEntity>, List<TenderEntity>>> GetCompanyDetail(long companyId);

        Task<CompanyEntity> UpdateCompany(CompanyEntity companyEntity);

        Task<CompanyEntity> ChangeCompanyStatus(CompanyEntity ent);

    }

    public class CompanyRepository : RepositoryBase<CompanyEntity>, ICompanyRepository
    {
        private readonly IUnitOfWork unitOfWork;


        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyRepository"/> class.
        /// </summary>
        /// <param name="dbFactory">The database factory.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public CompanyRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Adds the company.
        /// </summary>
        /// <param name="companyEntity">The company entity.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<CompanyEntity> AddCompany(CompanyEntity companyEntity, long userId)
        {
            try
            {
                companyEntity.Date_created = companyEntity.Date_modified = DateTime.Now;
                meroBoleeDbContexts.CompanyEntities.Add(companyEntity);
                await unitOfWork.SaveChangesAsync();
                UserCompany uc = new UserCompany
                {
                    CompanyId = companyEntity.CompanyId,
                    UserId = userId
                };
                meroBoleeDbContexts.UserCompanies.Add(uc);
                await unitOfWork.SaveChangesAsync();
                return companyEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public async Task<UserEntity> AddUser(long companyId, UserEntity user)
        {
            try
            {
                meroBoleeDbContexts.UserEntities.Add(user);
                await unitOfWork.SaveChangesAsync();
                UserCompany uc = new UserCompany
                {
                    CompanyId = companyId,
                    UserId = user.Id
                };
                meroBoleeDbContexts.UserCompanies.Add(uc);
                await unitOfWork.SaveChangesAsync();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Gets the company detail.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
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
                                                    join uc in meroBoleeDbContexts.UserCompanies on u.Id equals uc.UserId
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
                                         join t in meroBoleeDbContexts.TenderEntities on b.TenderId equals t.Id
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


        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <param name="companyType">The company type.</param>
        /// <param name="search">The search.</param>
        /// <returns></returns>
        public async Task<List<CompanyEntity>> GetCompanyByType(CompanyTypeEnum companyType, string search)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                {
                    return await meroBoleeDbContexts.CompanyEntities
                        .Include(x=> x.Country)
                        .Include(x=> x.CompanyStatus)
                        .Where(x => x.CompanyId != 1 && x.RegisteredAs == companyType.ToString()) //1 is merobolee company
                        .OrderByDescending(x => x.CompanyId)
                        .ToListAsync();
                }
                else
                {
                    return await meroBoleeDbContexts.CompanyEntities
                        .Include(x => x.Country)
                        .Include(x => x.CompanyStatus)
                        .Where(x => x.Name.ToLower().Contains(search.ToLower()) 
                                 && x.CompanyId != 1 && x.RegisteredAs == companyType.ToString()) //1 is merobolee company
                        .OrderByDescending(x => x.CompanyId)
                        .ToListAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<List<CompanyEntity>> GetAllCompany(string search)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                {
                    return await meroBoleeDbContexts.CompanyEntities
                        .Include(x => x.Country)
                        .Include(x => x.CompanyStatus)
                        .Where(x => x.CompanyId != 1) //1 is merobolee company
                        .OrderByDescending(x => x.CompanyId)
                        .ToListAsync();
                }
                else
                {
                    return await meroBoleeDbContexts.CompanyEntities
                        .Include(x => x.Country)
                        .Include(x => x.CompanyStatus)
                        .Where(x => x.Name.ToLower().Contains(search.ToLower())
                                 && x.CompanyId != 1) //1 is merobolee company
                        .OrderByDescending(x => x.CompanyId)
                        .ToListAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get verified bid inviter company
        /// </summary>
        /// <param name="companyType"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<List<CompanyEntity>> GetVerifiedCompany(CompanyTypeEnum companyType, string search)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                {
                    return await meroBoleeDbContexts.CompanyEntities
                        .Include(x => x.Country)
                        .Include(x => x.CompanyStatus)
                        .Where(x => x.CompanyId != 1 && x.CompanyStatusId == 4 && x.RegisteredAs == companyType.ToString()) //1 is merobolee company
                        .OrderByDescending(x => x.CompanyId)
                        .ToListAsync();
                }
                else
                {
                    return await meroBoleeDbContexts.CompanyEntities
                        .Include(x => x.Country)
                        .Include(x => x.CompanyStatus)
                        .Where(x => x.Name.ToLower().Contains(search.ToLower())
                                 && x.CompanyId != 1 && x.CompanyStatusId == 4
                                 && x.RegisteredAs == companyType.ToString()) //1 is merobolee company
                        .OrderByDescending(x => x.CompanyId)
                        .ToListAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public async Task<CompanyEntity> GetCompany(long companyId)
        {
            try
            {
                return await meroBoleeDbContexts
                    .CompanyEntities
                    .Where(x => x.CompanyId == companyId)
                    .FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }



        /// <summary>
        /// Updates the company.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public async Task<CompanyEntity> UpdateCompany(CompanyEntity obj)
        {
            try
            {
                meroBoleeDbContexts.CompanyEntities.Update(obj);
                await unitOfWork.SaveChangesAsync();

                return obj;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }


        /// <summary>
        /// Changes the company status.
        /// </summary>
        /// <param name="ent">The ent.</param>
        /// <returns></returns>
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
