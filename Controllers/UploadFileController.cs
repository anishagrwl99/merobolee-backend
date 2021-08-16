using MeroBolee.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers
{
    public class UploadFileController : Controller
    {
        public UploadImage upload = new UploadImage(); 
        [HttpPost]
        [Route("SaveFile")]
        public async Task<IActionResult> UploadFile(IFormFile file=null)
        {
           return Ok(await upload.Upload(file, "Merchant"));
        }
    }
}
