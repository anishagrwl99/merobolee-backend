using MeroBolee.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MeroBolee.Controllers.Environment
{

    [ApiController]
   
    public class TestController : ControllerBase
    {
        private readonly IWebHostEnvironment environment;

        public TestController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        
        [Route("GetEnvironment")]
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Get()
        {
            try
            {
                return Ok(environment.EnvironmentName);
            }
            catch (Exception ex)
            {
                return Ok("Error Message: " + ex.Message);
                //turn StatusCode(500, ex);
            }
        }


        [HttpGet("TestToken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult TestJwtTokenAuthentication()
        {
            try
            {
                UserEntity account = HttpContext.Items["Account"] as UserEntity;
                return Ok($"Token belongs to : {account.Person_email}");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
            }
        }
    }
}
