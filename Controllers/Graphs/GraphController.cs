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
    public class GraphController : AuthorizeController
    {
        private readonly IGraphService graphService;
        private readonly ResponseMsg response = new ResponseMsg();



        /// <summary>
        /// Initializes a new instance of the <see cref="GraphController"/> class.
        /// </summary>
        /// <param name="graphService">The search engine service.</param>
        public GraphController(IGraphService graphService)
        {
            this.graphService = graphService;
        }


        /// <summary>
        /// Get a graph data for Bidder (Supplier)
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost("Bidder")]
        [Authorize(Roles = "Bidder")]
        public async Task<IActionResult> BidderGraph([FromBody] GraphRequestDto request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SupplierGraphDto dto = await graphService.GetSupplierTendersGraph(request);
                    if(dto != null)
                    {
                        return Ok(new Responses<SupplierGraphDto>(dto, "200", "Graph data fetched"));
                    }
                    else
                    {
                        response.statusCode = "404";
                        response.Message = "Invalid Format";
                        response.Data = ModelState;
                        return StatusCode(StatusCodes.Status404NotFound, response);
                    }
                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    response.Data = ModelState;
                    return StatusCode(StatusCodes.Status400BadRequest, response);
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
        /// Get a graph data for Bid Inviter
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("BidInviter")]
        [Authorize(Roles = "Bid Inviter")]
        public async Task<IActionResult> BidInviterGraph([FromBody] GraphRequestDto request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BidInviterGraphDto dto = await graphService.GetInviterTenderGraph(request);
                    if (dto != null)
                    {
                        return Ok(new Responses<BidInviterGraphDto>(dto, "200", "Graph data fetched"));
                    }
                    else
                    {
                        response.statusCode = "404";
                        response.Message = "Invalid Format";
                        response.Data = ModelState;
                        return StatusCode(StatusCodes.Status404NotFound, response);
                    }
                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    response.Data = ModelState;
                    return StatusCode(StatusCodes.Status400BadRequest, response);
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
