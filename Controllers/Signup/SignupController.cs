using MeroBolee.Dto;
using MeroBolee.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers.Signup
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private readonly ISignupService service;

        public SignupController(ISignupService service)
        {
            this.service = service;
        }

        [HttpPost]        
        public IActionResult Supplier([FromBody] SupplierSignUp data)
        {
            try
            {
                var response = service.SignupSupplier(data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }



    
 }
