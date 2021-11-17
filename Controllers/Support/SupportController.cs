using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service;
using MeroBolee.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace MeroBolee.Controllers.Environment
{

    public class SupportController : Controller
    {
        private readonly IWebHostEnvironment environment;
        private readonly ISupportService supportService;
        private readonly ResponseMsg response = new ResponseMsg();

        public SupportController(IWebHostEnvironment environment, ISupportService supportService)
        {
            this.environment = environment;
            this.supportService = supportService;
        }


        [HttpPost("Support/Request")]
        public IActionResult RequestSupport([FromBody] CustomerSupportDto model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    supportService.SendSupportEmail(model);
                    return Ok(new Responses<CustomerSupportDto>(null, "200", "Support ticket sent"));
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
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }
        
    }
}
