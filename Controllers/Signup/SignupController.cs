using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.Signup
{

    /// <summary>
    /// Signup controller for signing up bid inviter and bidder
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private readonly ISignupService service;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="service"></param>
        public SignupController(ISignupService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Signup bidder
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Bidder([FromBody] UserSignUpDto data)
        {
            try
            {
                var response = service.SignupCompany(data, CompanyTypeEnum.Bidder);
                return Ok(response);
            }
            catch (Exception ex)
            {
                ResponseMsg msg = new()
                {
                    statusCode = "500",
                    Message = ex.Message
                };

                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(msg));
            }
        }



        /// <summary>
        /// Signup Bid Inviter
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult BidInviter([FromBody] UserSignUpDto data)
        {
            try
            {
                var response = service.SignupCompany(data, CompanyTypeEnum.BidInviter);
                return Ok(response);
            }
            catch (Exception ex)
            {
                ResponseMsg msg = new()
                {
                    statusCode = "500",
                    Message = ex.Message
                };

                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(msg));
            }
        }

    }




}
