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
using MeroBolee.Utility;
using System.Linq;


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
            string ToName = "User";
            SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(ToEmail, ToName);
            List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
            To.Add(smtpEmailTo);

            MeroBoleeDbContext context = new MeroBoleeDbContext();

            var roleId = context.UserEntities.Where(x => x.Email == emailRequestdto.toEmailId).Select(x => x.RoleId).SingleOrDefault();

            String role = null;
            if (roleId == 5)
            {
                role = "Supplier";
            }
            else if (roleId == 4)
            {
                role = "BidInviter";
            }

            var confirmationLink = string.Format("{0}/signin?userId={1}&token={2}&role={3}", "https://www.merobolee.com", emailRequestdto.id, HttpUtility.UrlEncode(emailRequestdto.token), role);
            string HtmlContent = string.Concat("<html><body>Please click on the link below to confirm your email</body></html>", confirmationLink);
            string TextContent = null;
            string Subject = "Email Confirmation";
            Console.Write(confirmationLink);
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

        public IActionResult sendEmailForgotPassword(EmailRequestdto emailRequestdto)
        {
            Configuration.Default.ApiKey.Remove("api-key");
            Configuration.Default.ApiKey.Add("api-key", "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");

            var apiInstance = new TransactionalEmailsApi();
            string SenderName = "MeroBolee";
            string SenderEmail = "support@merobolee.com";
            SendSmtpEmailSender Email = new SendSmtpEmailSender(SenderName, SenderEmail);
            string ToEmail = emailRequestdto.toEmailId;
            string ToName = "User";
            SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(ToEmail, ToName);
            List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
            To.Add(smtpEmailTo);
            var confirmationLink = emailRequestdto.confirmationLink;
            string HtmlContent = string.Concat("<html><body>Please click on the link below to change your password</body></html>", confirmationLink);
            string TextContent = null;
            string Subject = "Forgot Password";
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
    }
}