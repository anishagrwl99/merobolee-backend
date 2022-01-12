using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.RequestHelp
{
    public class TechnicalSupportController : Controller
    {
        private readonly ITechnicalSupportService RequestHelpService;
        private readonly PaginationMapper pagination = new PaginationMapper();
        private readonly ResponseMsg response = new ResponseMsg();
        private IUriService uriService;

        public TechnicalSupportController(ITechnicalSupportService RequestHelpService)
        {
            this.RequestHelpService = RequestHelpService;
        }
        /// <summary>
        /// To add RequestHelp and status is request help status    /// </summary>
        /// <returns></returns>
        [HttpPost("RequestSupport")]
        public IActionResult Add([FromBody] PostTechnicalSupportDto addRequestHelp)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    return Ok(new Responses<GetRequestHelpDto>(RequestHelpService.PostRequest(addRequestHelp), "200", "Record is successfully added"));
                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
            }

            catch (SqlException)
            {
                response.statusCode = "500";
                response.Message = "Something went wrong";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
            catch (Exception e)
            {
                response.statusCode = "400";
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }
        }

    }
}
