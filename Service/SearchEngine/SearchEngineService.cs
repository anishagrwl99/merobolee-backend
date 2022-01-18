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
using System.ComponentModel.DataAnnotations;

namespace MeroBolee.Service
{

    /// <summary>
    /// Signup service interface
    /// </summary>
    public interface ISearchEngineService
    {
        Task<List<CompanyDetailResponse>> Search(AdvanceSearch searchParams, string baseUrl, string defaultPic);
    }

    /// <summary>
    /// Signup service implementation
    /// </summary>
    public class SearchEngineService : CompanyMapper, ISearchEngineService
    {
        private readonly ISearchEngineRepository searchEngineRepository;
        private readonly IUploadFile fileService;
        private readonly IUserService userService;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="searchEngineRepository"></param>
        /// <param name="fileService"></param>
        /// <param name="userService"></param>
        public SearchEngineService(ISearchEngineRepository searchEngineRepository, IUploadFile fileService, IUserService userService)
        {
            this.searchEngineRepository = searchEngineRepository;
            this.fileService = fileService;
            this.userService = userService;
        }

        public async Task<List<CompanyDetailResponse>> Search(AdvanceSearch searchParams, string baseUrl, string defaultPic)
        {
            List<CompanyEntity> companies = await searchEngineRepository.GetCompanies(searchParams);
            if (companies != null && companies.Count > 0)
            {
                //CompanyDetailResponse detail = ToDetailResponse(resp.Item1, resp.Item2, resp.Item3, fileService, baseUrl, defaultPic);
                List<CompanyDetailResponse> resp = await ToDetailResponse(companies,  userService, fileService, baseUrl, defaultPic);
                return resp;
            }

            return null;
        }
    }
}
