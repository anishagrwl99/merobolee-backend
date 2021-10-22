using MeroBolee.Infrastructure;
using MeroBolee.Service.User;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Controllers
{
    public class FileManagementController : Controller
    {
        public IUploadFile upload;
        private readonly IWebHostEnvironment environment;


        public FileManagementController(IWebHostEnvironment environment, IUploadFile uploadFileService)
        {
            this.environment = environment;
            upload = uploadFileService;
        }


        [HttpPost]
        [Route("SaveFile")]
        public async Task<IActionResult> UploadFile(IFormFile file = null)
        {
            return Ok(await upload.Upload(file, "Merchant"));
        }



        /// <summary>
        /// Download file uploaded by user.
        /// </summary>
        /// <param name="filePath">Relative path from root folder. Should start from \Resources\...</param>
        /// <returns></returns>
        [HttpGet]
        [Route("DownloadFile")]
        public IActionResult DownloadFile(string filePath)
        {
            try
            {
                if (filePath.StartsWith('\\'))
                {
                    filePath = filePath.Substring(1);//Remove first \ character
                }

                string filepath = Path.Combine(environment.ContentRootPath, filePath);
                string mimeType = "image/png";
                new FileExtensionContentTypeProvider().TryGetContentType(filepath, out mimeType);
                var bytes = System.IO.File.ReadAllBytes(filepath);
                return File(bytes, mimeType);
            }
            catch (Exception)
            {
                ResponseMsg response = new ResponseMsg();
                response.statusCode = "404";
                response.Message = "Invalid file path or file does not exists.";
                return StatusCode(StatusCodes.Status404NotFound, new ErrorResponse<ResponseMsg>(response));
            }
        }
    }
}
