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

        public OtpController(IOtpService otpService)
        {
            this.otpService = otpService;
        }

        [HttpPost("Otp/Create")]
        [Authorize(Roles = "Bid Inviter, Bidder")]
        public string Create([FromBody] OtpDto otpDto)
        {
            try
            {
                return otpService.GenerateOtp(otpDto);
               

            }
            catch (Exception )
            {
                throw;
            }
        }

      
        [HttpPost("Otp/Verify")]
        [Authorize(Roles = "Bid Inviter, Bidder")]
        public bool Verify([FromBody] OtpVerifyDto otpVerifyDto)
        {
            try
            {
                 return otpService.VerifyOtp(otpVerifyDto);
                

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
