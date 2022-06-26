using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.RequestDemo
{
    public class RequestDemoController : Controller
    {
       private readonly ResponseMsg response = new ResponseMsg();

       private IUriService uriService;

        private readonly IRequestDemoService IRequestDemoService;

        public RequestDemoController(IRequestDemoService IRequestDemoService)
        {
            this.IRequestDemoService = IRequestDemoService;
        }

        [HttpPost("RequestDemo")]
        public async Task<IActionResult> RequestDemo([FromBody] RequestDemoDto requestDemoDto) {
            try {
                
                if (ModelState.IsValid)
                {
                    RequestDemoService requestDemoService = new RequestDemoService();
                    string RequestDemoResponse = await IRequestDemoService.RequestDemo(requestDemoDto);
                    return Ok(new Responses<string>(RequestDemoResponse, "200", "Request Demo Successfully"));
                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    response.Data = ModelState;
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
            } catch {
                throw;
            }
        }

         [HttpPost("ContactUs")]
        public async Task<IActionResult> ContactUs([FromBody] RequestDemoDto requestDemoDto) {
            try {
                
                if (ModelState.IsValid)
                {
                    RequestDemoService requestDemoService = new RequestDemoService();
                    string RequestDemoResponse = await IRequestDemoService.ContactUs(requestDemoDto);
                    return Ok(new Responses<string>(RequestDemoResponse, "200", "Request Demo Successfully"));
                }
                else
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    response.Data = ModelState;
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                }
            } catch {
                throw;
            }
        }

    }
}