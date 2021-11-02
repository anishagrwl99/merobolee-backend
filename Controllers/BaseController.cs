using MeroBolee.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace MeroBolee.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            AuthenticateResponse user = HttpContext.Items["RequestUser"] as AuthenticateResponse;
            //return StatusCode(StatusCodes.Status401Unauthorized);
            bool NotExecuteAction = false;
            if (user.UserStatusId != 1 || user.CompanyStatusId != 4)
            {
                context.HttpContext.Response.StatusCode = 403;
                NotExecuteAction = true;
            }

            if (NotExecuteAction)
            {
                context.Result = Forbid();
            }

            base.OnActionExecuting(context);
        }


    }
}
