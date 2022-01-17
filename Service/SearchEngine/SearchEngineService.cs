using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.EntityMapper;
using MeroBolee.Model;
using MeroBolee.Repository;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MeroBolee.Settings;
using System.Text;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace MeroBolee.Service
{
    public class SearchParam
    {
        public List<SearchField> CompanyFields { get; set; }
        public List<SearchField> UserFields { get; set; }
        public List<SearchField> CountryFields { get; set; }
        public List<SearchField> ProvinceFields { get; set; }
    }


    public class SearchField
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    
    /// <summary>
    /// Signup service interface
    /// </summary>
    public interface ISearchEngineService
    {
        Task<IEnumerable<CompanyEntity>> Search(List<SearchField> searchParams);
    }

    /// <summary>
    /// Signup service implementation
    /// </summary>
    public class SearchEngineService : ISearchEngineService
    {
        private readonly ISearchEngineRepository searchEngineRepository;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="searchEngineRepository"></param>
        public SearchEngineService(ISearchEngineRepository searchEngineRepository)
        {
            this.searchEngineRepository = searchEngineRepository;
        }

        public Task<IEnumerable<CompanyEntity>> Search(List<SearchField> searchParams)
        {
            return searchEngineRepository.GetCompanies(searchParams);
        }
    }
}
