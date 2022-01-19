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
    [Authorize(Roles = "Bid Inviter, Bidder")]
    public class GraphController : AuthorizeController
    {
        private readonly ISearchEngineService searchEngineService;
        private readonly ResponseMsg response = new ResponseMsg();



        /// <summary>
        /// Initializes a new instance of the <see cref="GraphController"/> class.
        /// </summary>
        /// <param name="searchEngineService">The search engine service.</param>
        public GraphController(ISearchEngineService searchEngineService)
        {
            this.searchEngineService = searchEngineService;
        }


        /// <summary>
        /// Bidders the graph.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost("Bidder")]
        public async Task<IActionResult> BidderGraph([FromBody] GraphRequestDto request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok();
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


        [HttpPost("BidInviter")]
        public async Task<IActionResult> BidInviterGraph([FromBody] GraphRequestDto request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok();
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
    }



}
