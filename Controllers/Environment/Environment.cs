using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.Environment
{
    [Route("[controller]")]
    [ApiController]
    public class EnvironmentController : ControllerBase
    {
        private readonly IWebHostEnvironment environment;

        public EnvironmentController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        [HttpGet]
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
    }
}
