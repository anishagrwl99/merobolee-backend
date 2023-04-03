using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.Signup
{

    /// <summary>
    /// Signup controller for signing up bid inviter and bidder
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class SignupController : Controller
    {
        private readonly ISignupService service;
        private ResponseMsg response = new ResponseMsg();
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
        public async Task<IActionResult> Bidder([FromBody] UserSignUpDto data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tuple<long, string> res = await service.SignupCompany(data, CompanyTypeEnum.Bidder);
                    if (res.Item1 > 0)
                    {
                        return Ok(new Responses<long>(res.Item1, "200", "Signup successfully"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Invalid Format";
                        response.Data = res.Item2;
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    }
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
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }



        /// <summary>
        /// Signup Bid Inviter
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> BidInviter([FromBody] UserSignUpDto data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tuple<long, string> res = await service.SignupCompany(data, CompanyTypeEnum.BidInviter);
                    if (res.Item1 > 0)
                    {
                        return Ok(new Responses<long>(res.Item1, "200", "Signup successfully"));
                    }
                    else
                    {
                        response.statusCode = "400";
                        response.Message = "Invalid Format";
                        response.Data = res.Item2;
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
                    }
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
                response.Message = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
            }
        }

    }




}
