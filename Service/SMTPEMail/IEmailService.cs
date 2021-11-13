using MeroBolee.Model;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    /// <summary>
    /// Email service interface
    /// </summary>
    public interface ISMTPEmailService
    {


        /// <summary>
        /// Compose email
        /// </summary>
        /// <param name="mailRequest"></param>
        /// <returns></returns>
        MimeMessage ComposeEmail(EmailInfo mailRequest);


        /// <summary>
        /// Send composed email
        /// </summary>
        /// <param name="emailContent"></param>
        /// <returns></returns>
        Task<bool> Send(MimeMessage emailContent);

    }
}
