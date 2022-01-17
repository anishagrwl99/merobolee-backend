using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.SearchEngine
{
    public class SearchController : Controller
    {
        private readonly ISearchEngineService searchEngineService;
        private readonly ResponseMsg response = new ResponseMsg();

        public SearchController(ISearchEngineService searchEngineService)
        {
            this.searchEngineService = searchEngineService;
        }
        [HttpPost("AdvanceSearch")]
        public async Task<IActionResult> AdvanceSearch([FromBody] List<SearchField> searchParams)
        {
            try
            {
                IEnumerable<CompanyEntity> companies = await searchEngineService.Search(searchParams);
                int totalCount = companies.Count();
                if (totalCount == 0)
                {
                    return NotFound(new Responses<IEnumerable<CompanyEntity>>(companies, "404", "Record not found"));
                }
                return Ok(companies);
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
