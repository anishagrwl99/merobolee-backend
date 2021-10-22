using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service.Mail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.Mail
{

    /// <summary>
    /// Mail end point
    /// </summary>
    public class MailByUserController : Controller
    {
        private readonly IEmailService mailService;
        private readonly ResponseMsg response = new();

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="mailService"></param>
        public MailByUserController(IEmailService mailService)
        {
            this.mailService = mailService;
        }


        /// <summary>
        /// Send email by bidder
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("SendByBidder")]
        public async Task<IActionResult> SendMailByBidder([FromForm] EmailInfo request)
        {
            try
            {
                if (request.ToEmail == null || request.ToEmail.Length < 1)
                {
                    response.statusCode = "400";
                    response.Message = "Invalid Format";
                    return StatusCode(StatusCodes.Status200OK, new ErrorResponse<ResponseMsg>(response));
                }
                MimeMessage email =  mailService.ComposeEmail(request);
                await mailService.Send(email);
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
