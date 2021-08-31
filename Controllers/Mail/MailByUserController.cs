using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service.Mail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.Mail
{
    public class MailByUserController : Controller
    {
        private readonly IMailByUserService mailService;
        private readonly ResponseMsg response = new ResponseMsg();
        public MailByUserController(IMailByUserService mailService)
        {
            this.mailService = mailService;
        }
        [HttpPost("SendByBidder")]
        public async Task<IActionResult> SendMailByBidder([FromForm] MailRequestByUser request)
        {
            try
            {
                if (request.ToEmail == null || request.FromEmail == null)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    return StatusCode(StatusCodes.Status200OK, new ErrorResponse<ResponseMsg>(response));
                }
                await mailService.SendEmailAsyncByUser(request);
                response.statusCode = "200";
                response.Message = "Mail Sent Successfully";
                return StatusCode(StatusCodes.Status200OK, new ErrorResponse<ResponseMsg>(response));
            }
            catch (Exception ex)
            {
                response.statusCode = "500";
                response.Message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }

    }
}
