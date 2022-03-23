using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mail;
using System.Web;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;



namespace MeroBolee.Controllers.EmailService
{
    public class EmailServiceController : ControllerBase
    {

        [HttpPost("/sendEmailSendInBlue")]
        public IActionResult sendEmail(EmailRequestdto emailRequestdto)
        {
            Configuration.Default.ApiKey.Remove("api-key");
            Configuration.Default.ApiKey.Add("api-key", "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");

            var apiInstance = new TransactionalEmailsApi();
            string SenderName = "MeroBolee";
            string SenderEmail = "support@merobolee.com";
            SendSmtpEmailSender Email = new SendSmtpEmailSender(SenderName, SenderEmail);
            string ToEmail = emailRequestdto.toEmailId;
            string ToName = "Anish Agrawal";
            SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(ToEmail, ToName);
            List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
            To.Add(smtpEmailTo);
            var confirmationLink = string.Format("{0}/Account/ConfirmEmail?userId={1}&token={2}", "https://office.merobolee.com", emailRequestdto.id, HttpUtility.UrlEncode(emailRequestdto.token));
            string HtmlContent = string.Concat("<html><body>Please click on the link below to confirm your email</body></html>", confirmationLink);
            string TextContent = null;
            string Subject = "Email Confirmation";
            // SendSmtpEmailReplyTo ReplyTo = new SendSmtpEmailReplyTo(ReplyToEmail, ReplyToName);
            // string AttachmentUrl = null;
            // string stringInBase64 = "aGVsbG8gdGhpcyBpcyB0ZXN0";
            // byte[] Content = System.Convert.FromBase64String(stringInBase64);
            // string AttachmentName = "test.txt";
            // SendSmtpEmailAttachment AttachmentContent = new SendSmtpEmailAttachment(AttachmentUrl, Content, AttachmentName);
            // List<SendSmtpEmailAttachment> Attachment = new List<SendSmtpEmailAttachment>();
            // Attachment.Add(AttachmentContent);

            // string confirmationLink = string.Concat(string.Concat(baseUrl, string.Concat("userId=", emailRequestdto.id)), string.Concat("&",string.Concat("token=", emailRequestdto.token)));
            SendSmtpEmailTo1 smtpEmailTo1 = new SendSmtpEmailTo1(ToEmail, ToName);
            List<SendSmtpEmailTo1> To1 = new List<SendSmtpEmailTo1>();
            To1.Add(smtpEmailTo1);
            // Dictionary<string, object> _parmas = new Dictionary<string, object>();
            // _parmas.Add("params", Params);
            // SendSmtpEmailReplyTo1 ReplyTo1 = new SendSmtpEmailReplyTo1(ReplyToEmail, ReplyToName);
            // SendSmtpEmailMessageVersions messageVersion = new SendSmtpEmailMessageVersions(To1, _parmas, Bcc, Cc, ReplyTo1, Subject);
            // List<SendSmtpEmailMessageVersions> messageVersiopns = new List<SendSmtpEmailMessageVersions>();
            // messageVersiopns.Add(messageVersion);
            try
            {
                var sendSmtpEmail = new SendSmtpEmail(Email, To, null, null, HtmlContent, TextContent, Subject, null, null, null, null, null, null, null);
                CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
                Debug.WriteLine(result.ToJson());
                Console.WriteLine(result.ToJson());
                SendEmailResponseDto sendEmailResponseDto = new SendEmailResponseDto();
                sendEmailResponseDto.response = "SUCESSFULLY SENT EMAIL";
                return Ok(new Responses<SendEmailResponseDto>(sendEmailResponseDto, "200", "Sucessfully Sent Email"));
            }
            catch (Exception ex) 
            {
                throw ex;
            }

        }
        
        // [HttpPost("/sendEmail")]
        // public IActionResult sendEmailGmail(EmailRequestdto emailRequestdto)
        // {

        //     // string baseUrl = "https://localhost:5001/Account/ConfirmEmail?";
        //     var confirmationLink = string.Format("{0}/Account/ConfirmEmail?userId={1}&token={2}", "https://office.merobolee.com", emailRequestdto.id, HttpUtility.UrlEncode(emailRequestdto.token));

        //     // string confirmationLink = string.Concat(string.Concat(baseUrl, string.Concat("userId=", emailRequestdto.id)), string.Concat("&",string.Concat("token=", emailRequestdto.token)));
        //     Console.Write(confirmationLink);
        //     // Url.Action(
        //     //    "ConfirmEmail", "Account",
        //     //    new { userId = emailRequestdto.id, code = emailRequestdto.token },
        //     //    protocol: Request.Scheme);
        //     string to = emailRequestdto.toEmailId; //To address    
        //     string from = "support@merobolee.com"; //From address    
        //     MailMessage message = new MailMessage(from, to);

        //     string mailbody = confirmationLink;
        //     message.Subject = "confirmationEmail";
        //     message.Body = mailbody;
        //     // message.BodyEncoding = Encoding.UTF8;
        //     message.IsBodyHtml = false;

        //     SmtpClient client = new SmtpClient("mail.merobolee.com", 25); //Gmail smtp    
        //     System.Net.NetworkCredential basicCredential1 = new
        //     System.Net.NetworkCredential("contact.agranish@gmail.com", "Supp0rt@MeroBolee123");
        //     client.EnableSsl = true;
        //     client.UseDefaultCredentials = false;
        //     client.Credentials = basicCredential1;
        //     try
        //     {
        //         client.Send(message);
        //         SendEmailResponseDto sendEmailResponseDto = new SendEmailResponseDto();
        //         sendEmailResponseDto.response = "SUCESSFULLY SENT EMAIL";
        //         return Ok(new Responses<SendEmailResponseDto>(sendEmailResponseDto, "200", "Sucessfully Sent Email"));
        //     }

        //     catch (Exception ex)
        //     {
        //         throw ex;
        //     }
        // }
    }
}