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
        Task<bool> DeleteFile(string filePath);
    }
    public class UploadImage  : IUploadFile
    {
        private readonly IWebHostEnvironment host;
        private string _baseFolder;
        private string _baseFolderFullPath;

        public UploadImage(IWebHostEnvironment host)
        {
            this.host = host;
            _baseFolder = "Resource";
            _baseFolderFullPath = host.ContentRootPath;
        }

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
                var extension = Path.GetExtension(file.FileName);// "." + file.FileName.Split('.')[file.FileName.Split('.').Length-1]; // to get extension of file
                fileName = DateTime.Now.Ticks + extension; // to change name of file for security reason
                var pathBuilt = Path.Combine(_baseFolderFullPath, _baseFolder + "\\" + folderName); // to create path for file
                if (!Directory.Exists(pathBuilt))
                {
                    Directory.CreateDirectory(pathBuilt);
                }
                var path = Path.Combine(_baseFolderFullPath, _baseFolder + "\\" + folderName,fileName);
                using (var Stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(Stream);
                }
             //   isSaveSuccess = true;
                return Path.Combine(_baseFolder, folderName, fileName);
            }
            catch (Exception)
            {
                throw;
            }
        
        }

        public Task<bool> DeleteFile(string filePath)
        {
            return Task.Run(() =>
            {
                try
                {
                    string fullPath = Path.Combine(_baseFolderFullPath, filePath);
                    File.Delete(fullPath);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            });
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
