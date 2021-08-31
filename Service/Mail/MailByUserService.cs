using MailKit.Security;
using MeroBolee.Model;
using MeroBolee.Repository.Mail;
using MeroBolee.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.Mail
{
    public class MailByUserService: IMailByUserService
    {
       // private readonly MailSettings _mailSettings;
        private UserMailSetting userMailSetting;
        private readonly IMailRepository mailRepository;
        public MailByUserService(IOptions<UserMailSetting> mailSettings, IMailRepository mailRepository)
        {
            userMailSetting = mailSettings.Value;
            this.mailRepository = mailRepository;
        }
        //public MailService(IOptions<UserMailSetting> mailSettings, IMailRepository mailRepository)
        //{
        //    userMailSetting = mailSettings.Value; ;
        //    this.mailRepository = mailRepository;
        //}

        public async Task SendEmailAsyncByUser(MailRequestByUser mailRequest)
        {
            //try
            //{
            //    bool isSent;
                var email = new MimeMessage();
                //userMailSetting.DisplayName = "";
                userMailSetting.Mail = mailRequest.FromEmail;
                userMailSetting.Password = mailRequest.Password;
                email.Sender = MailboxAddress.Parse(userMailSetting.Mail);
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
                smtp.Connect(userMailSetting.Host, userMailSetting.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(userMailSetting.Mail, userMailSetting.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

                PostMail(new MailEntity
                {
                    FromEmail = userMailSetting.Mail,
                    ToEmail = mailRequest.ToEmail,
                    Subject = mailRequest.Subject,
                    Body = mailRequest.Body
                }, mailRequest.Attachments);
            //}

            //catch (Exception ex)
            //{
            //    throw new Exception();
            //}
        }

        public void PostMail(MailEntity mailEntity, ICollection<IFormFile> attachment)
        {
            mailRepository.PostMail(mailEntity, attachment);
        }

    }
}
