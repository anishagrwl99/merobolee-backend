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
    public class SearchController : AuthorizeController
    {
        private readonly ISearchEngineService searchEngineService;
        private IUriService uriService;
        private readonly AppDefaults defaultOption;
        private readonly ResponseMsg response = new ResponseMsg();
        private readonly PaginationMapper pagination = new PaginationMapper();

        public SearchController(ISearchEngineService searchEngineService, IOptions<AppDefaults> defaultOption)
        {
            this.searchEngineService = searchEngineService;
            this.defaultOption = defaultOption.Value;
        }



        [HttpPost("AdvanceSearch")]
        public async Task<IActionResult> AdvanceSearch([FromQuery] PaginationQuery pagination, [FromBody] AdvanceSearch searchParams)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string url = Url.Action("AdvanceSearch", null, null, Request.Scheme); //get url for current request
                    uriService = new UriService(url);

                    string _defaultPic = $"{_baseUrl}{defaultOption.DefaultProfilePicture}";
                    List<CompanyDetailResponse> companies = await searchEngineService.Search(searchParams, _baseUrl, _defaultPic);
                    if (companies == null || companies.Count == 0)
                    {
                        return NotFound(new Responses<List<CompanyDetailResponse>>(companies, "404", "Record not found"));
                    }
                    return Ok(ResultAfterPagination(companies, pagination, companies.Count));
                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
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

        private PagedResponse<CompanyDetailResponse> ResultAfterPagination(IEnumerable<CompanyDetailResponse> companies, PaginationQuery pagination, int totalCount)
        {
            var paginationFilteration = this.pagination.PaginationMap(pagination);
            if (pagination == null || pagination.pageNo < 1 || pagination.size < 1)
            {
                return new PagedResponse<CompanyDetailResponse>(companies, totalCount);
            }

            var get = companies.Skip((pagination.pageNo - 1) * pagination.size).Take(pagination.size).ToList();
            var paginationResponse = PaginationHelper.CreatedPaginationResponse(uriService, paginationFilteration, get, totalCount);
            return paginationResponse;

        }
    }



}
