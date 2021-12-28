using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Attribute
{

    /// <summary>
    /// Allow only certain kind of files
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class AllowExtensionsAttribute : ValidationAttribute
    {
        #region Public / Protected Properties  

        /// <summary>  
        /// Gets or sets extensions property.  
        /// </summary>  
        public string Extensions { get; set; } = ".png,.jpg,.jpeg,.pdf,.doc,.docx";

        #endregion

        #region Is valid method  

        /// <summary>  
        /// Is valid method.  
        /// </summary>  
        /// <param name="value">Value parameter</param>  
        /// <returns>Returns - true is specify extension matches.</returns>  
        public override bool IsValid(object value)
        {
            // Initialization  
            IFormFile file = value as IFormFile;
            bool isValid = false;

            // Settings.  
            List<string> allowedExtensions = this.Extensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            // Verification.  
            if (file != null)
            { 
                //var fileName = file.FileName;
                var fileExtension = Path.GetExtension(file.FileName);
                
                // File Extension verification  
                isValid = allowedExtensions.Any(y => fileExtension.EndsWith(y));
                if(isValid) //is allowed extension check if file is actually what extension says
                {
                    isValid = file.ValidateSignature(fileExtension);
                }
            }

            return isValid;
        }

        #endregion
    }
}
