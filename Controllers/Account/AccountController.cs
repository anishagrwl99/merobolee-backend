using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Service;
using MeroBolee.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MeroBolee.Utility;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
        private readonly ResponseMsg response = new ResponseMsg();

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        /// <summary>
        /// Default constructor
        /// </summary>
        public AccountController(IAccountService accountService, IOptions<AppDefaults> defaultOptions, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.accountService = accountService;
            this.defaultOptions = defaultOptions.Value;
            this.userManager = userManager;
            this.signInManager = signInManager;
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
                var context = new MeroBoleeDbContext();
                var isEmailConfirmed = context.Users.Where(x => x.Email == model.Email).Select(x => x.EmailConfirmed).SingleOrDefault();
                if (isEmailConfirmed != true) {
                     return NotFound(new Responses<ResponseMsg>(null, "404", "Record not found or email is not confirmed."));
                }

                if (ModelState.IsValid)
                {
                    string basePath = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/";
                    _defaultPic = $"{basePath}{defaultOptions.DefaultProfilePicture}";
                    AuthenticateResponse resp =  await accountService.AuthenticateAsync(model, CompanyTypeEnum.Bidder, basePath, _defaultPic);
                    if (resp != null)
                    {
                        //setTokenCookie(response.RefreshToken);
                        return Ok(resp);
                    }                   

                }
            }
            catch (Exception ex)
            {
                response.statusCode = "500";
                response.Message = $"{ex.Message} Inner Message: {(ex.InnerException != null ? ex.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
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
                var context = new MeroBoleeDbContext();
                var isEmailConfirmed = context.Users.Where(x => x.Email == model.Email).Select(x => x.EmailConfirmed).SingleOrDefault();
                if (isEmailConfirmed != true) {
                     return NotFound(new Responses<ResponseMsg>(null, "404", "Record not found or email is not confirmed."));
                }
                
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
                response.statusCode = "500";
                response.Message = $"{ex.Message} Inner Message: {(ex.InnerException != null ? ex.InnerException.Message : "")}";
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse<ResponseMsg>(response));
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

        [HttpPost("/register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
             if (ModelState.IsValid)
            {
                // Copy data from RegisterViewModel to IdentityUser
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                // Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(user, model.Password);

                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return null;
        }

    [HttpGet("/Account/ConfirmEmail")]
    public async Task<IActionResult> ConfirmEmail(string userId, string token)
    {
        if (userId == null || token == null)
        {
            return RedirectToAction("index", "home");
        }

        // var decodedTokenString = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));

        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
          {
            return NotFound(new Responses<ResponseMsg>(null, "404", "Record not found"));

            }

            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
        {
            return Ok(result);

        }

        return NotFound(new Responses<ResponseMsg>(null, "404", "Email Could Not be Confirmed"));

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
