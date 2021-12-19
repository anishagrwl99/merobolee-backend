using MailKit.Security;
using MeroBolee.Model;
using MeroBolee.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    /// <summary>
    /// Email service
    /// </summary>
    public class SMTPEmailService : ISMTPEmailService
    {
        private readonly SMTPServerInfo smtpServer;
        private readonly MailKit.Net.Smtp.SmtpClient smtp;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="smtpSettings"></param>
        public SMTPEmailService(IOptions<SMTPServerInfo> smtpSettings)
        {
            smtpServer = smtpSettings.Value;
            smtp = new MailKit.Net.Smtp.SmtpClient();

        }

        /// <summary>
        /// Compose email 
        /// </summary>
        /// <param name="Tos">Email composition details</param>
        /// <param name="subject">Email composition details</param>
        /// <param name="message">Email composition details</param>
        /// <returns></returns>
        public MimeMessage ComposeEmail(List<string> Tos, string subject, string message)
        {
            try
            {
                MimeMessage email = new();
                email.Sender = MailboxAddress.Parse(smtpServer.FromEmail);
                foreach (string toEmail in Tos)
                {
                    email.Bcc.Add(MailboxAddress.Parse(toEmail));
                }

                email.Subject = subject;
                var builder = new BodyBuilder();
                //if (mailRequest.Attachments != null)
                //{
                //    byte[] fileBytes;
                //    foreach (var file in mailRequest.Attachments)
                //    {
                //        if (file.Length > 0)
                //        {
                //            using (var ms = new MemoryStream())
                //            {
                //                file.CopyTo(ms);
                //                fileBytes = ms.ToArray();
                //            }
                //            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                //        }
                //    }
                //}
                builder.HtmlBody = message;
                email.Body = builder.ToMessageBody();

                return email;
                //PostMail(new MailEntity
                //{
                //    FromEmail = userMailSetting.From,
                //    ToEmail = mailRequest.ToEmail,
                //    Subject = mailRequest.Subject,
                //    Body = mailRequest.Body
                //}, mailRequest.Attachments);
                //}
            }

            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// Compose email 
        /// </summary>
        /// <param name="to">Email composition details</param>
        /// <param name="subject">Email composition details</param>
        /// <param name="message">Email composition details</param>
        /// <returns></returns>
        public MimeMessage ComposeEmail(string to, string subject, string message)
        {
            try
            {
                MimeMessage email = new();
                email.Sender = MailboxAddress.Parse(smtpServer.FromEmail);
                email.Bcc.Add(MailboxAddress.Parse(to));

                email.Subject = subject;
                var builder = new BodyBuilder();
                //if (mailRequest.Attachments != null)
                //{
                //    byte[] fileBytes;
                //    foreach (var file in mailRequest.Attachments)
                //    {
                //        if (file.Length > 0)
                //        {
                //            using (var ms = new MemoryStream())
                //            {
                //                file.CopyTo(ms);
                //                fileBytes = ms.ToArray();
                //            }
                //            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                //        }
                //    }
                //}
                builder.HtmlBody = message;
                email.Body = builder.ToMessageBody();

                return email;
                //PostMail(new MailEntity
                //{
                //    FromEmail = userMailSetting.From,
                //    ToEmail = mailRequest.ToEmail,
                //    Subject = mailRequest.Subject,
                //    Body = mailRequest.Body
                //}, mailRequest.Attachments);
                //}
            }

            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Add attachment
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="fileFullPath"></param>
        public void AddAttachments(BodyBuilder builder, string[] fileFullPath)
        {
            foreach (var file in fileFullPath)
            {
                FileInfo f = new FileInfo(file);
                
                using (MemoryStream ms = new MemoryStream())
                {
                    using (FileStream source = File.Open(file, FileMode.Open))
                    {
                        source.CopyTo(ms);
                        byte[] filebytes = ms.ToArray();
                        string contentType = GetFileContentType(f.FullName);
                        builder.Attachments.Add(f.Name, filebytes, ContentType.Parse(contentType));
                    }
                }

            }

        }




        /// <summary>
        /// Send composed email
        /// </summary>
        /// <param name="emailContent">A composed email</param>
        /// <returns></returns>
        public async Task<bool> Send(MimeMessage emailContent)
        {
            try
            {
                if (emailContent != null && emailContent.Bcc.Count > 0)
                {
                    SecureSocketOptions opt = smtpServer.EnableSSL ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.None;

                    smtp.Connect(smtpServer.Server, smtpServer.Port, opt);
                    if (smtp.IsConnected)
                    {
                        await smtp.AuthenticateAsync(Encoding.UTF8, smtpServer.FromEmail, smtpServer.Password);
                        if (smtp.IsAuthenticated)
                        {
                            await smtp.SendAsync(emailContent);
                            return true;
                        }
                        else
                        {
                            throw new Exception($"Could not authenticate user {smtpServer.FromEmail} at {smtpServer.Server} : {smtpServer.Port}");
                        }
                    }
                    else
                    {
                        throw new Exception($"Could not connect to {smtpServer.Server} : {smtpServer.Port}");
                    }
                }
                else
                {
                    throw new Exception($"You need to compose email properly before sending.");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //TODO: Dispose Email Attachments as they are no longer required after sending
                //foreach (var item in emailContent.Attachments)
                //{

                //}
                if (smtp.IsConnected)
                {
                    await smtp.DisconnectAsync(true);
                }
                smtp.Dispose();//no longer required
            }
        }


        public string GetFileContentType(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(fileName, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}
