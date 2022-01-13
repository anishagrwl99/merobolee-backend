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
        private readonly ResponseMsg response = new ResponseMsg();

        public TechnicalSupportController(ITechnicalSupportService RequestHelpService)
        {
            this.RequestHelpService = RequestHelpService;
        }
        /// <summary>
        /// Send technical support query  
        /// </summary>
        /// <returns></returns>
        [HttpPost("RequestSupport")]
        public async Task<IActionResult> Add([FromBody] PostTechnicalSupportDto addRequestHelp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GetRequestHelpDto dto = await RequestHelpService.PostRequest(addRequestHelp);
                    return Ok(new Responses<GetRequestHelpDto>(dto, "200", "Record is successfully added"));
                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    response.Data = ModelState;
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
            }
            catch (Exception e)
            {
                response.statusCode = "500";
                response.Message = e.Message + (e.InnerException == null? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

    }
}
