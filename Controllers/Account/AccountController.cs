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
using System.Linq;
using System.Web;


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
        private readonly ICryptoService cryptoService;
        private readonly ISendEmailService sendEmailService;

        /// <summary>
        /// Default constructor
        /// </summary>
        public AccountController(IAccountService accountService, IOptions<AppDefaults> defaultOptions, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, ICryptoService cryptoService, ISendEmailService sendEmailService)
        {
            this.accountService = accountService;
            this.defaultOptions = defaultOptions.Value;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.cryptoService = cryptoService;
            this.sendEmailService = sendEmailService;
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
                if (isEmailConfirmed != true)
                {
                    return NotFound(new Responses<ResponseMsg>(null, "404", "Record not found or email is not confirmed."));
                }

                if (ModelState.IsValid)
                {
                    string basePath = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/";
                    _defaultPic = $"{basePath}{defaultOptions.DefaultProfilePicture}";
                    AuthenticateResponse resp = await accountService.AuthenticateAsync(model, CompanyTypeEnum.Bidder, basePath, _defaultPic);
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
                if (isEmailConfirmed != true)
                {
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

        [HttpPost("Authenticate/TenderSupport")]
        public async Task<IActionResult> AuthenticateTenderSupport([FromBody] AuthenticateRequest model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string basePath = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/";
                    _defaultPic = $"{basePath}{defaultOptions.DefaultProfilePicture}";
                    AuthenticateResponse response = await accountService.AuthenticateAsync(model, CompanyTypeEnum.TenderSupport, basePath, _defaultPic);
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


        [HttpPost("Authenticate/CustomerSupport")]
        public async Task<IActionResult> AuthenticateCustomerSupport([FromBody] AuthenticateRequest model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string basePath = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/";
                    _defaultPic = $"{basePath}{defaultOptions.DefaultProfilePicture}";
                    AuthenticateResponse response = await accountService.AuthenticateAsync(model, CompanyTypeEnum.CustomerSupport, basePath, _defaultPic);
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

        [HttpPost("/Account/ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailRequestDto confirmEmailRequestDto)
        {
            if (confirmEmailRequestDto.userId == null || confirmEmailRequestDto.token == null)
            {
                return NotFound(new Responses<ResponseMsg>(null, "404", "Could Not Confirm Your Email ID! We apologise for any inconvenience caused."));
            }
            
            var user = await userManager.FindByIdAsync(confirmEmailRequestDto.userId);
            if (user == null)
            {
                return NotFound(new Responses<ResponseMsg>(null, "404", "Record not found"));

            }

            var result = await userManager.ConfirmEmailAsync(user, confirmEmailRequestDto.token);
            if (result.Succeeded)
            {
                EmailResDto emailResDto = new EmailResDto();
                emailResDto.responseMessage = "Email has been confirmed Successfully";
                return Ok(new Responses<EmailResDto>(emailResDto, "200", "Email has been confirmed Successfully"));

            }

            return NotFound(new Responses<ResponseMsg>(null, "404", "Email Could Not be Confirmed"));
        }


        [HttpPost("/forgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto model)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email
                var user = await userManager.FindByEmailAsync(model.Email);
                // If the user is found AND Email is confirmed
                if (user != null && await userManager.IsEmailConfirmedAsync(user))
                {
                    // Generate the reset password token
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);

                    // Build the password reset link
                    // var passwordResetLink = Url.Action("ResetPassword", "Account",
                    //         new { email = model.Email, token = token }, Request.Scheme);
                    MeroBoleeDbContext context = new MeroBoleeDbContext();

                    var roleId = context.UserEntities.Where(x => x.Email == model.Email).Select(x => x.RoleId).SingleOrDefault();
                    String role = null;
                    if(roleId == 5) {
                        role = "Supplier";
                    } else if (roleId == 4) {
                        role = "BidInviter";
                    }

                    var passwordResetLink = string.Format("{0}/resetpassword?emailId={1}&token={2}&role={3}", "https://merobolee.com", model.Email, HttpUtility.UrlEncode(token), role);

                    // Log the password reset link
                    EmailRequestdto emailRequestdto = new EmailRequestdto();
                    emailRequestdto.toEmailId = model.Email;
                    emailRequestdto.confirmationLink = passwordResetLink;
                    emailRequestdto.callFrom = "ForgotPassword";
                    sendEmailService.SendEmail(emailRequestdto);
                    EmailResDto emailResDto = new EmailResDto();
                    emailResDto.responseMessage = "1";
                    return Ok(new Responses<EmailResDto>(emailResDto, "200", "Forgot Password Email has been sent"));
                    // Send the user to Forgot Password Confirmation view
                }

                // To avoid account enumeration and brute force attacks, don't
                // reveal that the user does not exist or is not confirmed
                return NotFound(new Responses<ResponseMsg>(null, "404", "Email Not Confirmed / Email Not Registered"));

            }
            return NotFound(new Responses<ResponseMsg>(null, "404", "Email Not Confirmed / Email Not Registered"));

        }

        [HttpGet("/ResetPassword")]
        public IActionResult ResetPassword(string token, string email)
        {
            // If password reset token or email is null, most likely the
            // user tried to tamper the password reset link
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token");
            }
            return Ok();
        }

        [HttpPost("/ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewDto model)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    // reset the user password
                    var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        MeroBoleeDbContext meroBoleeDbContext = new MeroBoleeDbContext();
                        meroBoleeDbContext.UserEntities.Where(x => x.Email == model.Email).ToList().ForEach(x => x.Password = cryptoService.Encrypt(model.Password));
                        meroBoleeDbContext.SaveChanges();
                        EmailResDto emailResDto = new EmailResDto();
                        emailResDto.responseMessage = "Password has been reset successfully";
                        return Ok(new Responses<EmailResDto>(emailResDto, "200", "Password has been reset successfully"));
                    }
                    // Display validation errors. For example, password reset token already
                    // used to change the password or password complexity rules not met

                    return NotFound(new Responses<ResponseMsg>(null, "404", "Unable to Reset Password, Please try again"));
                }

                // To avoid account enumeration and brute force attacks, don't
                // reveal that the user does not exist
                return NotFound(new Responses<ResponseMsg>(null, "404", "Unable to Reset Password, Please try again"));
            }
            // Display validation errors if model state is not valid
            return NotFound(new Responses<ResponseMsg>(null, "404", "Unable to Reset Password, Please try again"));
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
