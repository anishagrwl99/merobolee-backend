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
        /// <param name="Tos"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        MimeMessage ComposeEmail(List<string> Tos, string subject, string message);

        /// <summary>
        /// Compose email
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        MimeMessage ComposeEmail(string to, string subject, string message);


        /// <summary>
        /// Send composed email
        /// </summary>
        /// <param name="emailContent"></param>
        /// <returns></returns>
        Task<bool> Send(MimeMessage emailContent);

    }
}
