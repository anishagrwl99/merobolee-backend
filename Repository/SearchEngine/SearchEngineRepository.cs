using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    /// <summary>
    /// Status repo interface
    /// </summary>
    public interface ISearchEngineRepository : IRepositoryBase<CommonStatus>
    {
        Task<AdvanceSearchDto> Search(AdvanceSearch searchParams);

        Task<AdvanceSearchDto> Search(string searchText);
    }


    /// <summary>
    /// status repos implementation
    /// </summary>
    public class SearchEngineRepository : RepositoryBase<CommonStatus>, ISearchEngineRepository
    {

        private IUnitOfWork unitOfWork;


        /// <summary>
        /// Default const
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="dbFactory"></param>
        public SearchEngineRepository(IUnitOfWork unitOfWork, IDbFactory dbFactory) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<AdvanceSearchDto> Search(AdvanceSearch searchParams)
        {
            try
            {
                AdvanceSearchDto search = new AdvanceSearchDto()
                {
                    Companies = new List<CompanyDto>(),
                    Tenders = new List<TenderCard>(),
                    Users = new List<UserResponseDto>()
                };

                if (searchParams.CompanyFields != null && searchParams.CompanyFields.Count > 0)
                {
                    List<CompanyEntity> companies = await meroBoleeDbContexts
                                                        .CompanyEntities
                                                        .Include(x => x.Country)
                                                        .Include(x => x.Province)
                                                        .Include(x => x.CompanyStatus)
                                                        .Where(FilterLinq<CompanyEntity>.GetWherePredicate(searchParams.CompanyFields.ToArray()))
                                                        .ToListAsync();

                    search.Companies = (from c in companies
                                        select new CompanyDto
                                        {
                                            Id = c.CompanyId,
                                            Code = c.ReferenceCode,
                                            Name = c.Name,
                                            Country = c.Country.Name,
                                            Province = c.Province.Name,
                                            City = c.City,
                                            Address1 = c.Address1,
                                            Address2 = c.Address2,
                                            Address3 = c.Address3,
                                            Zip = c.Zip,
                                            Email = c.CompanyEmail,
                                            Website = c.CompanyWebsite,
                                            MobileNumber = c.MobileNumber,
                                            PhoneNumber = c.PhoneNumber,
                                            Status = c.CompanyStatus.Status,
                                            RegisteredDate = c.Date_created
                                        }).ToList();
                }

                if (searchParams.UserFields != null && searchParams.UserFields.Count > 0)
                {
                    List<UserEntity> users = await meroBoleeDbContexts
                                                    .UserEntities
                                                    .Include(x => x.UserStatus)
                                                    .Include(x => x.Role)
                                                    .Where(FilterLinq<UserEntity>.GetWherePredicate(searchParams.UserFields.ToArray()))
                                                    .ToListAsync();

                    search.Users = (from u in users
                                    select new UserResponseDto
                                    {
                                        Id = u.Id,
                                        Designation = u.Designation,
                                        FirstName = u.FirstName,
                                        MiddleName = u.MiddleName,
                                        LastName = u.LastName,
                                        Email = u.Email,
                                        UserName = u.Username,
                                        ProfilePic = u.ProfilePicture
                                    }
                                   ).ToList();
                }

                if (searchParams.TenderFields != null && searchParams.TenderFields.Count > 0)
                {
                    List<TenderEntity> tenders = await meroBoleeDbContexts
                                                    .TenderEntities
                                                    .Include(x => x.TenderStatusEntity)
                                                    .Include(x => x.TenderMaterialEntities)
                                                    //.Include(x => x.TenderCards)
                                                    .Include(x => x.CategoryEntity)
                                                    .Include(x => x.Company)
                                                    .Where(FilterLinq<TenderEntity>.GetWherePredicate(searchParams.TenderFields.ToArray()))
                                                    .ToListAsync();

                    search.Tenders = (from t in tenders
                                      select new TenderCard
                                      {
                                          TenderId = t.Id,
                                          CompanyId = t.Company.CompanyId,
                                          CompanyName = t.Company.Name,
                                          TenderCode = t.Code,
                                          TenderTitle = t.Title,
                                          CategoryId = t.ProcurementCategoryId,
                                          CategoryName = t.CategoryEntity.Title,
                                          LiveStartDate = t.LiveStartDate,
                                          LiveEndDate = t.LiveEndDate,
                                          RegistrationTill = t.RegistrationTill,
                                          Status = t.TenderStatusEntity.Status
                                          //CardInfo = (from tc in t.TenderCards
                                          //            where tc.TenderId == t.Id
                                          //            select new TenderCardInfo
                                          //            {
                                          //                Id = tc.Id,
                                          //                Label = tc.Label,
                                          //                Value = tc.Value
                                          //            }).ToList()
                                      }).ToList();
                }
                /*

                List<long> companyIds = new List<long>();
                if (searchParams.UserFields != null && searchParams.UserFields.Count > 0)
                {
                    companyIds = meroBoleeDbContexts.UserCompanies
                                  .Include(x => x.User)
                                  .Where(FilterLinq<UserCompany>.GetWherePredicate(searchParams.UserFields.ToArray()))
                                  .Select(x => x.CompanyId)
                                  .ToList();
                }


                if (companyIds.Count == 0 && searchParams.CompanyFields.Count > 0)
                {
                    return await meroBoleeDbContexts
                        .CompanyEntities
                        .Include(x => x.Country)
                        .Include(x => x.Province)
                        .Include(x => x.CompanyStatus)
                        .Where(FilterLinq<CompanyEntity>.GetWherePredicate(searchParams.CompanyFields.ToArray()))
                        .ToListAsync();
                }
                else if (companyIds.Count > 0 && searchParams.CompanyFields.Count > 0)
                {

                    return await meroBoleeDbContexts
                        .CompanyEntities
                        .Include(x => x.Country)
                        .Include(x => x.Province)
                        .Include(x => x.CompanyStatus)
                        .Where(FilterLinq<CompanyEntity>.GetWherePredicate(searchParams.CompanyFields.ToArray()))
                        .Where(x => companyIds.Contains(x.CompanyId))
                        .ToListAsync();

                }
                else
                {
                    return await meroBoleeDbContexts
                        .CompanyEntities
                        .Include(x => x.Country)
                        .Include(x => x.Province)
                        .Include(x => x.CompanyStatus)
                        .ToListAsync();
                }
                */

                return search;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AdvanceSearchDto> Search(string searchText)
        {
            try
            {
                AdvanceSearchDto dto = new AdvanceSearchDto();
                dto.Tenders = await (from cm in  meroBoleeDbContexts.CommunityApprovalEntities 
                                     join  t in meroBoleeDbContexts.TenderEntities on cm.TenderId equals t.Id
                                     join c in meroBoleeDbContexts.TenderProcurementCategoryEntities on t.ProcurementCategoryId equals c.Id
                                     join s in meroBoleeDbContexts.TenderStatus on t.StatusId equals s.StatusId
                                     join c1 in meroBoleeDbContexts.CompanyEntities on cm.CompanyId equals c1.CompanyId
                                     where t.Title.Contains(searchText)
                                            || t.Code.Contains(searchText)
                                            || c.Title.Contains(searchText)
                                            || s.Status.Contains(searchText)
                                            || t.PerformanceRequest.Contains(searchText)
                                            || t.QualityRequest.Contains(searchText)
                                            || t.AdditionalRequest.Contains(searchText)
                                            || t.EligibilityCriteria.Contains(searchText)
                                            || t.Location.Contains(searchText)
                                     select new TenderCard
                                     {
                                         TenderId = t.Id,
                                         CompanyId = c1.CompanyId,
                                         CompanyName = c1.Name,
                                         TenderCode = t.Code,
                                         TenderTitle = t.Title,
                                         CategoryId = c.Id,
                                         CategoryName = c.Title,
                                         LiveStartDate = t.LiveStartDate,
                                         LiveEndDate = t.LiveEndDate,
                                         RegistrationTill = t.RegistrationTill,
                                         Status = s.Status
                                         //CardInfo = (from tc in meroBoleeDbContexts.TenderCards
                                         //            where tc.TenderId == t.Id
                                         //            select new TenderCardInfo
                                         //            {
                                         //                Id = tc.Id,
                                         //                Label = tc.Label,
                                         //                Value = tc.Value
                                         //            }).ToList()
                                     }
                               ).ToListAsync();

                dto.Users = await (from u in meroBoleeDbContexts.UserEntities
                                   where u.FirstName.Contains(searchText)
                                        || u.MiddleName.Contains(searchText)
                                        || u.LastName.Contains(searchText)
                                        || u.Email.Contains(searchText)
                                        || u.Username.Contains(searchText)
                                   select new UserResponseDto
                                   {
                                       Id = u.Id,
                                       Designation = u.Designation,
                                       FirstName = u.FirstName,
                                       MiddleName = u.MiddleName,
                                       LastName = u.LastName,
                                       Email = u.Email,
                                       UserName = u.Username,
                                       ProfilePic = u.ProfilePicture
                                   }
                                   ).ToListAsync();

                dto.Companies = await (from c in meroBoleeDbContexts.CompanyEntities
                                       join ctry in meroBoleeDbContexts.CountryEntities on c.CountryId equals ctry.Id
                                       join prov in meroBoleeDbContexts.ProvinceEntities on c.ProvinceId equals prov.Id
                                       join s in meroBoleeDbContexts.CompanyStatusEntities on c.CompanyStatusId equals s.Id
                                       where c.ReferenceCode.Contains(searchText)
                                            || c.Name.Contains(searchText)
                                            || ctry.Name.Contains(searchText)
                                            || prov.Name.Contains(searchText)
                                            || c.City.Contains(searchText)
                                            || c.Address1.Contains(searchText)
                                            || c.Address2.Contains(searchText)
                                            || c.Address3.Contains(searchText)
                                            || c.Zip.Contains(searchText)
                                            || c.CompanyEmail.Contains(searchText)
                                            || c.CompanyWebsite.Contains(searchText)
                                            || c.MobileNumber.Contains(searchText)
                                            || c.PhoneNumber.Contains(searchText)
                                       select new CompanyDto
                                       {
                                           Id = c.CompanyId,
                                           Code = c.ReferenceCode,
                                           Name = c.Name,
                                           Country = ctry.Name,
                                           Province = prov.Name,
                                           City = c.City,
                                           Address1 = c.Address1,
                                           Address2 = c.Address2,
                                           Address3 = c.Address3,
                                           Zip = c.Zip,
                                           Email = c.CompanyEmail,
                                           Website = c.CompanyWebsite,
                                           MobileNumber = c.MobileNumber,
                                           PhoneNumber = c.PhoneNumber,
                                           Status = s.Status,
                                           RegisteredDate = c.Date_created
                                       }).ToListAsync();

                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    public class FilterLinq<T>
    {


        static Expression GetPropertyExpression(Expression pe, string chain)
        {
            var properties = chain.Split('.');
            foreach (var property in properties)
                pe = Expression.Property(pe, property);

            return pe;
        }

        public static Expression<Func<T, Boolean>> GetWherePredicate(params SearchField[] SearchFieldList)
        {
            //the 'IN' parameter for expression ie T=> condition
            ParameterExpression pe = Expression.Parameter(typeof(T), typeof(T).Name);



            //combine them with and 1=1 Like no expression
            Expression combined = null;

            if (SearchFieldList != null)
            {
                foreach (var fieldItem in SearchFieldList)
                {
                    //Expression for accessing Fields name property
                    Expression columnNameProperty = GetPropertyExpression(pe, fieldItem.Key);

                    //the name constant to match 
                    Expression columnValue = Expression.Constant(fieldItem.Value);

                    //the first expression: Name = ?
                    //Expression e1 = Expression.Equal(columnNameProperty, columnValue);

                    //the first expression: Name LIKE '%<columnValue>%'
                    Expression e1 = Expression.Call(columnNameProperty, "Contains", null, columnValue);

                    // return Expression.Call(e, "Contains", null, Expression.Constant(s));
                    if (combined == null)
                    {
                        combined = e1;
                    }
                    else
                    {
                        combined = Expression.And(combined, e1);
                    }
                }
            }

            //create and return the predicate
            return Expression.Lambda<Func<T, Boolean>>(combined, new ParameterExpression[] { pe });

        }

    }
}
