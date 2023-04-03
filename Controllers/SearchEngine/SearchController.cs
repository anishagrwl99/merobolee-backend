using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Service;
using MeroBolee.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;

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
        /// Simple search engine to search available user, company and tenders
        /// </summary>
        /// <param name="search">Search query</param>
        /// <returns></returns>
        [HttpPost("SearchEngine/Simple")]
        public async Task<IActionResult> SimpleSearch([FromQuery] string search)
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



        /// <summary>
        /// Searches the specified user or company or tenders
        /// </summary>
        /// <param name="search">The advance search criteria</param>
        /// <returns></returns>
        [HttpPost("SearchEngine/Advance")]
        public async Task<IActionResult> AdvanceSearch([FromBody] AdvanceSearch search)
        {
            try
            {
                if (ModelState.IsValid)
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
