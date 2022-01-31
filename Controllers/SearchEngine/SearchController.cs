using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service;
using MeroBolee.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.SearchEngine
{
    [Authorize(Roles = "Super Admin, Tender Support, Customer Support")]
    public class SearchController :  AuthorizeController
    {
        private readonly ISearchEngineService searchEngineService;
        private readonly AppDefaults defaultOption;
        private readonly ResponseMsg response = new ResponseMsg();

        public SearchController(ISearchEngineService searchEngineService, IOptions<AppDefaults> defaultOption)
        {
            this.searchEngineService = searchEngineService;
            this.defaultOption = defaultOption.Value;
        }


        /// <summary>
        /// Advance search engine
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost("AdvanceSearch")]
        public async Task<IActionResult> AdvanceSearch([FromQuery] string search)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(search))
                {
                    string _defaultPic = $"{_baseUrl}{defaultOption.DefaultProfilePicture}";
                    AdvanceSearchDto searchResult = await searchEngineService.Search(search, _baseUrl, _defaultPic);
                    if (searchResult == null || 
                        (searchResult.Tenders.Count == 0 && searchResult.Users.Count == 0 && searchResult.Companies.Count == 0))
                    {
                        return NotFound(new Responses<AdvanceSearchDto>(null, "404", "Search result not found"));
                    }
                    return Ok(new Responses<AdvanceSearchDto>(searchResult, "200", "Search found"));
                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Provide a search text";
                    response.Data = ModelState;
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }
    }



}
