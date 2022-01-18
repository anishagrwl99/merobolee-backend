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
        Task<List<CompanyEntity>> GetCompanies(AdvanceSearch searchParams);
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

        public async Task<List<CompanyEntity>> GetCompanies(AdvanceSearch searchParams)
        {
            try
            {
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
