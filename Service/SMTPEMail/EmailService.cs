using MailKit.Security;
using MeroBolee.Model;
using MeroBolee.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeroBolee.Service.SMTPMail
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
        /// <param name="mailRepository"></param>
        public SMTPEmailService(IOptions<SMTPServerInfo> smtpSettings)
        {
            smtpServer = smtpSettings.Value;
            smtp = new MailKit.Net.Smtp.SmtpClient();
        }

        /// <summary>
        /// Compose email 
        /// </summary>
        /// <param name="mailRequest">Email composition details</param>
        /// <returns></returns>
        public MimeMessage ComposeEmail(EmailInfo mailRequest)
        {
            try
            {
                MimeMessage email = new();
                email.Sender = MailboxAddress.Parse(smtpServer.From);
                foreach (string toEmail in mailRequest.ToEmail)
                {
                    email.Bcc.Add(MailboxAddress.Parse(toEmail));
                }

                email.Subject = mailRequest.Subject;
                var builder = new BodyBuilder();
                if (mailRequest.Attachments != null)
                {
                    byte[] fileBytes;
                    foreach (var file in mailRequest.Attachments)
                    {
                        if (file.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                fileBytes = ms.ToArray();
                            }
                            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                        }
                    }
                }
                builder.HtmlBody = mailRequest.Body;
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
                    SecureSocketOptions opt = smtpServer.EnableSSL ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.Auto;

                    await smtp.ConnectAsync(smtpServer.Host, smtpServer.Port, opt);
                    if (smtp.IsConnected)
                    {
                        await smtp.AuthenticateAsync(Encoding.UTF8, smtpServer.From, smtpServer.Password);
                        if (smtp.IsAuthenticated)
                        {
                            await smtp.SendAsync(emailContent);
                            return true;
                        }
                        else
                        {
                            throw new Exception($"Could not authenticate user {smtpServer.From} at {smtpServer.Host} : {smtpServer.Port}");
                        }
                    }
                    else
                    {
                        throw new Exception($"Could not connect to {smtpServer.Host} : {smtpServer.Port}");
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
                await smtp.DisconnectAsync(true);
                smtp.Dispose();//no longer required
            }
        }
    }
}
