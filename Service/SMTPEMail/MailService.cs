using MailKit.Security;
using MailKit.Net.Smtp;
using MeroBolee.Model;
using MeroBolee.Settings;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using MeroBolee.Repository.Mail;
using Microsoft.AspNetCore.Http;

namespace MeroBolee.Service.SMTPMail
{
    public class SMTPMailService : ISMTPMailService
    {
        private readonly MailSettings _mailSettings;
        //private UserMailSetting userMailSetting;
        private readonly IMailRepository mailRepository; 
        public SMTPMailService(IOptions<MailSettings> mailSettings, IMailRepository mailRepository)
        {
            _mailSettings = mailSettings.Value;
            this.mailRepository = mailRepository; 
        }
        //public MailService(IOptions<UserMailSetting> mailSettings, IMailRepository mailRepository)
        //{
        //    userMailSetting = mailSettings.Value; ;
        //    this.mailRepository = mailRepository;
        //}

        //public async Task SendEmailAsyncByUser(MailRequest mailRequest)
        //{
        //    try
        //    {
        //        bool isSent;
        //        var email = new MimeMessage();
        //        //userMailSetting.DisplayName = "";
        //        _mailSettings.Mail = "";
        //        _mailSettings.Password = "";
        //        email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
        //        email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
        //        email.Subject = mailRequest.Subject;
        //        var builder = new BodyBuilder();
        //        if (mailRequest.Attachments != null)
        //        {
        //            byte[] fileBytes;
        //            foreach (var file in mailRequest.Attachments)
        //            {
        //                if (file.Length > 0)
        //                {
        //                    using (var ms = new MemoryStream())
        //                    {
        //                        file.CopyTo(ms);
        //                        fileBytes = ms.ToArray();
        //                    }
        //                    builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
        //                }
        //            }
        //        }
        //        builder.HtmlBody = mailRequest.Body;
        //        email.Body = builder.ToMessageBody();
        //        using var smtp = new MailKit.Net.Smtp.SmtpClient();
        //        smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        //        smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
        //        await smtp.SendAsync(email);
        //        smtp.Disconnect(true);

        //        //PostMail(new MailEntity
        //        //{
        //        //    ToEmail = mailRequest.ToEmail,
        //        //    Subject = mailRequest.Subject,
        //        //    Body = mailRequest.Body
        //        //}, mailRequest.Attachments);
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new Exception();
        //    }
        //}


        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
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
                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);       

                PostMail(new MailEntity
                {
                    FromEmail=_mailSettings.Mail                ,
                    ToEmail= mailRequest.ToEmail,
                    Subject= mailRequest.Subject,
                    Body= mailRequest.Body
                } ,mailRequest.Attachments);
            }

            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void PostMail(MailEntity mailEntity, ICollection<IFormFile> attachment)
        {
            mailRepository.PostMail(mailEntity,attachment);
        }

        //public async Task SendWelcomeEmailAsync(WelcomeRequest request)
        //{
        //    string FilePath = Directory.GetCurrentDirectory() + "\\Templates\\WelcomeTemplate.html";
        //    StreamReader str = new StreamReader(FilePath);
        //    string MailText = str.ReadToEnd();
        //    str.Close();
        //    MailText = MailText.Replace("[username]", request.UserName).Replace("[email]", request.ToEmail);
        //    var email = new MimeMessage();
        //    email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
        //    email.To.Add(MailboxAddress.Parse(request.ToEmail));
        //    email.Subject = $"Welcome {request.UserName}";
        //    var builder = new BodyBuilder();
        //    builder.HtmlBody = MailText;
        //    email.Body = builder.ToMessageBody();
        //    using var smtp = new SmtpClient();
        //    smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        //    smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
        //    await smtp.SendAsync(email);
        //    smtp.Disconnect(true);
        //}

    }
}
