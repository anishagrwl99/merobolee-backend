using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service.SMTPMail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.Mail
{
    public class MailController : Controller
    {
        private readonly ISMTPMailService mailService;
        private readonly ResponseMsg response = new ResponseMsg();
        public MailController(ISMTPMailService mailService)
        {
            this.mailService = mailService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            try
            {
                if (request.ToEmail == null)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    return StatusCode(StatusCodes.Status200OK, new ErrorResponse<ResponseMsg>(response));
                }
                await mailService.SendEmailAsync(request);
                response.statusCode = "200";
                response.Message = "Mail Sent Successfully";
                return StatusCode(StatusCodes.Status200OK, new ErrorResponse<ResponseMsg>(response));
            }
            catch (Exception ex)
            {

                response.statusCode = "500";
                response.Message = ex.Message;// "Something went wrong";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }

        }

    }
}
