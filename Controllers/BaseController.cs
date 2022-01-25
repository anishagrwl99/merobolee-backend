using MeroBolee.Dto;
using MeroBolee.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace MeroBolee.Controllers
{

    /// <summary>
    /// Authorize controller
    /// </summary>
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme/*, Roles = "Bid Inviter, Bidder"*/)]
    public class AuthorizeController : Controller
    {
        internal string _baseUrl, _defaultPic;

        /// <summary>
        /// Called before the action method is invoked.
        /// </summary>
        /// <param name="context">The action executing context.</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/";
            base.OnActionExecuting(context);
        }
    }

    /// <summary>
    /// Base controller
    /// </summary>   
    public class BaseController : AuthorizeController
    {
        internal bool isCompanyVerified = false;
        /// <summary>
        /// Condition to check before executing action in each controller
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/";
            AuthenticateResponse user = HttpContext.Items["RequestUser"] as AuthenticateResponse;
            //return StatusCode(StatusCodes.Status401Unauthorized);
            bool NotExecuteAction = false;
            if (user.UserStatusId != 1)
            {
                context.HttpContext.Response.StatusCode = 403;
                NotExecuteAction = true;
            }

            if (NotExecuteAction)
            {
                context.Result = Forbid();
            }
            isCompanyVerified = user.CompanyStatusId == 4;
            base.OnActionExecuting(context);
        }


    }
}
