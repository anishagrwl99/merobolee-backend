using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Infrastructure
{
    public interface IUploadFile
    {
        Task<string> Upload(IFormFile file, string folderName);
    }
    public class UploadImage  : IUploadFile
    {
        private readonly IWebHostEnvironment host;

        public UploadImage(IWebHostEnvironment host)
        {
            this.host = host;
        }

        public async Task<string> Upload(IFormFile file,string folderName)
        {
           // bool isSaveSuccess = false;
            string fileName;
            try
            {
                string folder = "Resource";
                if (file == null)
                {
                    return null;
                }
                var extension = Path.GetExtension(file.FileName);// "." + file.FileName.Split('.')[file.FileName.Split('.').Length-1]; // to get extension of file
                fileName = DateTime.Now.Ticks + extension; // to change name of file for security reason
                var pathBuilt = Path.Combine(host.ContentRootPath, folder + "\\" + folderName); // to create path for file
                if (!Directory.Exists(pathBuilt))
                {
                    Directory.CreateDirectory(pathBuilt);
                }
                var path = Path.Combine(host.ContentRootPath, folder + "\\" + folderName,fileName);
                using (var Stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(Stream);
                }
             //   isSaveSuccess = true;
                return Path.Combine(folder, folderName, fileName);
            }
            catch (Exception)
            {
                throw;
            }
        
        }

        //public async Task<IFormFile> Download(string filePath)
        //{
        //    try
        //    {
               
        //    }
        //    catch (Exception)
        //    {
        //        throw; 
        //    }
        
        //}
    }
}
