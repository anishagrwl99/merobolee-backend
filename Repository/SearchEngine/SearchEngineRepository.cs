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
        Task<IEnumerable<CompanyEntity>> GetCompanies(List<SearchField> searchParams);
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

        public async Task<IEnumerable<CompanyEntity>> GetCompanies(List<SearchField> searchParams)
        {
            try
            {
                /*
                List<long> userIds = new List<long>();
                List<int> countryIds = new List<int>();
                List<int> provinceIds = new List<int>();

                if(searchParams.UserFields.Count>0)
                {
                    userIds = await meroBoleeDbContexts
                        .UserEntities
                        .Where(FilterLinq<UserEntity>.GetWherePredicate(searchParams.UserFields.ToArray()))
                        .Select(x => x.User_Id)
                        .ToListAsync();
                }
                if (searchParams.CountryFields.Count > 0)
                {
                    countryIds = await meroBoleeDbContexts
                        .CountryEntities
                        .Where(FilterLinq<CountryEntity>.GetWherePredicate(searchParams.CountryFields.ToArray()))
                        .Select(x => x.Country_Id)
                        .ToListAsync();
                }

                if (searchParams.ProvinceFields.Count > 0)
                {
                    countryIds = await meroBoleeDbContexts
                        .ProvinceEntities
                        .Where(FilterLinq<ProvinceEntity>.GetWherePredicate(searchParams.ProvinceFields.ToArray()))
                        .Select(x => x.Province_Id)
                        .ToListAsync();
                }
                */
                List<long> companyIds = new List<long> { 1, 2, 3 };
                return await meroBoleeDbContexts
                    .CompanyEntities
                    .Include(x=> x.Country)
                    .Include(x => x.Province)
                    .Include(x=> x.CompanyUsers)
                    .ThenInclude(y=> y.User)
                    .Where(FilterLinq<CompanyEntity>.GetWherePredicate(searchParams.ToArray()))
                    .Where(x=> companyIds.Contains(x.CompanyId))
                    .ToListAsync();
            }
            catch (Exception ex)
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

                    //the first expression: PatientantLastName = ?
                    Expression e1 = Expression.Equal(columnNameProperty, columnValue);
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
