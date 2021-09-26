using MeroBolee.Model;
using MeroBolee.Service;
using MeroBolee.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace MeroBolee.Controllers.Environment
{

    [ApiController]
   
    public class TestController : ControllerBase
    {
        private readonly IWebHostEnvironment environment;
        private readonly MeroBoleeDbContext _context;
        private readonly ICryptoService cryptoService;

        public TestController(IWebHostEnvironment environment, MeroBoleeDbContext context, ICryptoService cryptoService)
        {
            this.environment = environment;
            _context = context;
            this.cryptoService = cryptoService;
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

        [HttpPost("GetConnection")]
        public ActionResult GetConnectionString()
        {
            try
            {
                return Ok(_context.Database.GetDbConnection().ConnectionString);
            }
            catch (Exception ex)
            {
                return StatusCode(-1, ex.Message);
            }
        }


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
