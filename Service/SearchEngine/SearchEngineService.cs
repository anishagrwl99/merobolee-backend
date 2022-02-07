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
        Task<AdvanceSearchDto> Search(AdvanceSearch search, string baseUrl, string defaultPic);
        Task<AdvanceSearchDto> Search(string search, string baseUrl, string defaultPic);
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


        public async Task<AdvanceSearchDto> Search(string search, string baseUrl, string defaultPic)
        {
            try
            {
                AdvanceSearchDto dto = await searchEngineRepository.Search(search);
                if(dto.Users.Count> 0 )
                {
                    foreach (var user in dto.Users)
                    {
                        bool dpExists = await fileService.FileExists(user.ProfilePic);
                        if(dpExists)
                        {
                            user.ProfilePic = $"{baseUrl}{user.ProfilePic.Replace("\\", "/")}";
                        }
                        else
                        {
                            user.ProfilePic = defaultPic;
                        }
                    }
                }
                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AdvanceSearchDto> Search(AdvanceSearch search, string baseUrl, string defaultPic)

        {
            try
            {
                AdvanceSearchDto dto = await searchEngineRepository.Search(search);
                if (dto.Users != null &&  dto.Users.Count > 0)
                {
                    foreach (var user in dto.Users)
                    {
                        bool dpExists = await fileService.FileExists(user.ProfilePic);
                        if (dpExists)
                        {
                            user.ProfilePic = $"{baseUrl}{user.ProfilePic.Replace("\\", "/")}";
                        }
                        else
                        {
                            user.ProfilePic = defaultPic;
                        }
                    }
                }
                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
