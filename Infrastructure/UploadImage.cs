using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Infrastructure
{
    public class UploadImage 
    {
        public async Task<string> Upload(IFormFile file,string folderName)
        {
           // bool isSaveSuccess = false;
            string fileName;
            try
            {
                if (file == null)
                {
                    return null;
                }
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length-1]; // to get extension of file
                fileName = DateTime.Now.Ticks + extension; // to change name of file for security reason
                var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(),"Resource\\"+ folderName); // to create path for file
                if (!Directory.Exists(pathBuilt))
                {
                    Directory.CreateDirectory(pathBuilt);
                }
                var path = Path.Combine(Directory.GetCurrentDirectory(),"Resource\\"+folderName,fileName);
                using (var Stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(Stream);
                }
             //   isSaveSuccess = true;
                return Path.Combine("Resource", folderName, fileName);
            }
            catch (Exception)
            {
                throw new Exception();
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
