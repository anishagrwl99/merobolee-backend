using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    /// <summary>
    /// Email composition
    /// </summary>
    public class EmailInfo
    {
        /// <summary>
        /// List of email address on which email needs to be sent
        /// </summary>
        public string[] ToEmail { get; set; }

        /// <summary>
        /// Email subject line
        /// </summary>
        public string Subject { get; set; }


        /// <summary>
        /// Email body
        /// </summary>
        public string Body { get; set; }


        /// <summary>
        /// Email attachments
        /// </summary>
        public List<IFormFile> Attachments { get; set; }
    }
}
