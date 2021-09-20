using MeroBolee.Dto;
using MeroBolee.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers
{
    /// <summary>
    /// Controller to manage user account
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;


        /// <summary>
        /// Default constructor
        /// </summary>
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet("Authenticate")]
        public async Task<ActionResult<AuthenticateResponse>> Authenticate([FromQuery] AuthenticateRequest model)
        {
            if(ModelState.IsValid)
            {
                AuthenticateResponse response = await accountService.AuthenticateAsync(model);
                if(response != null)
                {
                    //setTokenCookie(response.RefreshToken);
                    return Ok(response);
                }
                
            }
            return NotFound();
        }



        private void setTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

    }
}
