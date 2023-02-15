using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OtpNet;
using System;
using MeroBolee.Migrations;
using MeroBolee.Service;
using System.Security;
using MeroBolee.Service.Otp;
using MeroBolee.Dto;
using Microsoft.AspNetCore.Http;
using MeroBolee.Infrastructure;

namespace MeroBolee.Controllers.Otp
{
    public class OtpController : BaseController
    {
        private readonly IOtpService otpService;
        private readonly ResponseMsg response = new ResponseMsg();

        public OtpController(IOtpService otpService)
        {
            this.otpService = otpService;
        }

        [HttpPost("Otp/Create")]
        [Authorize(Roles = "Bid Inviter, Bidder, Super Admin")]
        public async Task<IActionResult> Create([FromBody] OtpDto otpDto)
        {
            try
            {
                var response = await otpService.CheckOtpSent(otpDto);
                if (response)
                {
                    return Ok(new Responses<bool>(response, "200", "Otp is successfully sent."));
                }
                else
                {
                    return NotFound(new Responses<bool>(response, "404", "Otp failed to send."));

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