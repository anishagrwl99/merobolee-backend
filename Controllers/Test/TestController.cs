using MeroBolee.Attribute;
using MeroBolee.Dto;
using MeroBolee.Model;
using MeroBolee.Service;
using MeroBolee.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace MeroBolee.Controllers.Environment
{

    public class TestFile
    {
        /// <summary>
        /// A file to test
        /// </summary>
        [AllowExtensions(Extensions = ".docx", ErrorMessage = "File signature didn't match with its signature")]
        public IFormFile File { get; set; }
    }

    [ApiController]   
    public class TestController : ControllerBase
    {
        private readonly IWebHostEnvironment environment;
        private readonly ICryptoService cryptoService;

        public TestController(IWebHostEnvironment environment,  ICryptoService cryptoService)
        {
            this.environment = environment;
            this.cryptoService = cryptoService;
        }

        [HttpPost("/FileTest")]
        public IActionResult TestFile([FromForm] TestFile test)
        {
            if(ModelState.IsValid)
            {
                return Ok("file tested");
            }
            else
            {
                return BadRequest("bad request");
            }
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
                AuthenticateResponse account = HttpContext.Items["RequestUser"] as AuthenticateResponse;
                return Ok($"Token belongs to : {account.FirstName}");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
            }
        }

        [HttpGet("RequestingAppUrl")]
        public IActionResult GetRequestingAppUrl()
        {
            try
            {
                RequestHeaders header = Request.GetTypedHeaders();
                Uri uriReferer = header.Referer;
                
                string referer = uriReferer.ToString(); //Request.Headers["Referer"].ToString();
                return Ok(referer);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //[HttpPost("GetConnection")]
        //public ActionResult GetConnectionString()
        //{
        //    try
        //    {
        //        return Ok(_context.Database.GetDbConnection().ConnectionString);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(-1, ex.Message);
        //    }
        //}


        [HttpPost("Encrypt")]
        public IActionResult Encrypt([FromBody] string text)
        {
            try
            {
                string result = cryptoService.Encrypt(text);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Decrypt")]
        public IActionResult Decrypt([FromBody] string cypher)
        {
            try
            {
                string result = cryptoService.Decrypt<string>(cypher);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
