using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.RequestDemo
{
    public class RequestDemoController : Controller
    {
       private readonly ResponseMsg response = new ResponseMsg();
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
                    string RequestDemoResponse = await IRequestDemoService.RequestDemo(requestDemoDto);
                    return Ok(new Responses<string>(RequestDemoResponse, "200", "Thank you for contacting us. We will schedule your demo shortly!"));
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
                    string RequestDemoResponse = await IRequestDemoService.ContactUs(requestDemoDto);
                    return Ok(new Responses<string>(RequestDemoResponse, "200", "Thank you for contacting us. We will connect with you shortly!"));
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