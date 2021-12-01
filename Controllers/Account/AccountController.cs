using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Service;
using MeroBolee.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers
{
    /// <summary>
    /// Controller to manage user account
    /// </summary>
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly AppDefaults defaultOptions;
        private string _defaultPic;

        /// <summary>
        /// Default constructor
        /// </summary>
        public AccountController(IAccountService accountService, IOptions<AppDefaults> defaultOptions)
        {
            this.accountService = accountService;
            this.defaultOptions = defaultOptions.Value;
        }

        /// <summary>
        /// Authenticate bidder (supplier) user
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost("Authenticate/Bidder")]
        public async Task<IActionResult> AuthenticateSupplier([FromBody] AuthenticateRequest model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string basePath = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/";
                    _defaultPic = $"{basePath}{defaultOptions.DefaultProfilePicture}";
                    AuthenticateResponse response =  await accountService.AuthenticateAsync(model, CompanyTypeEnum.Bidder, basePath, _defaultPic);
                    if (response != null)
                    {
                        //setTokenCookie(response.RefreshToken);
                        return Ok(response);
                    }                   

                }
            }
            catch (Exception ex)
            {
                ResponseMsg response = new ResponseMsg
                {
                    statusCode = StatusCodes.Status400BadRequest.ToString(),
                    Message= ex.Message
                };

                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }
            return NotFound(new Responses<ResponseMsg>(null, "404", "Record not found"));
        }



        /// <summary>
        /// Authenticate bid inviter user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Authenticate/BidInviter")]
        public async Task<IActionResult> AuthenticateBidInviter([FromBody] AuthenticateRequest model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string basePath = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/";
                    _defaultPic = $"{basePath}{defaultOptions.DefaultProfilePicture}";
                    AuthenticateResponse response = await accountService.AuthenticateAsync(model, CompanyTypeEnum.BidInviter, basePath, _defaultPic);
                    if (response != null)
                    {
                        //setTokenCookie(response.RefreshToken);
                        return Ok(response);
                    }

                }
            }
            catch (Exception ex)
            {
                ResponseMsg response = new ResponseMsg
                {
                    statusCode = StatusCodes.Status400BadRequest.ToString(),
                    Message = ex.Message
                };

                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }
            return NotFound(new Responses<ResponseMsg>(null, "404", "Record not found"));
        }


        /// <summary>
        /// Authenticate super admin user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Authenticate/Admin")]
        public async Task<IActionResult> AuthenticateAdmin([FromBody] AuthenticateRequest model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string basePath = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/";
                    _defaultPic = $"{basePath}{defaultOptions.DefaultProfilePicture}";
                    AuthenticateResponse response = await accountService.AuthenticateAsync(model, CompanyTypeEnum.SuperAdmin, basePath, _defaultPic);
                    if (response != null)
                    {
                        setTokenCookie(response);
                        return Ok(response);
                    }

                }
            }
            catch (Exception ex)
            {
                ResponseMsg response = new ResponseMsg
                {
                    statusCode = StatusCodes.Status400BadRequest.ToString(),
                    Message = ex.Message
                };

                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse<ResponseMsg>(response));
            }
            return NotFound(new Responses<ResponseMsg>(null, "404", "Record not found"));
        }


        private void setTokenCookie(AuthenticateResponse token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = false,
                Expires = token.TokenExpiryTime,
                Path = "/",
                Secure = true,
                IsEssential = true
                
            };
            Response.Cookies.Append("RequestToken", token.JwtToken, cookieOptions);
        }

    }
}
