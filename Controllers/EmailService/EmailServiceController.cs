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
using System.Net;



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
            string SenderName = "Mero Bolee";
            string SenderEmail = "support@merobolee.com";
            SendSmtpEmailSender Email = new SendSmtpEmailSender(SenderName, SenderEmail);
            string ToEmail = emailRequestdto.toEmailId;
            string ToName = "User";
            SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(ToEmail, ToName);
            List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
            To.Add(smtpEmailTo);

            var confirmationLink = string.Format("{0}/signin?userId={1}&token={2}&role={3}", "https://merobolee.com", emailRequestdto.id, HttpUtility.UrlEncode(emailRequestdto.token), emailRequestdto.role);
            string HtmlContent = "";
            using (WebClient web1 = new WebClient())
            {
                 HtmlContent = web1.DownloadString("https://office.merobolee.com/Resource/verify-email.html");
            }

            // string HtmlContent = System.IO.File.ReadAllText("https://office.merobolee.com/Resource/verify-email.html");
            if(HtmlContent.Contains("{0}")) {
                HtmlContent = HtmlContent.Replace("{0}", confirmationLink);
            }
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
            string SenderName = "Mero Bolee";
            string SenderEmail = "support@merobolee.com";
            SendSmtpEmailSender Email = new SendSmtpEmailSender(SenderName, SenderEmail);
            string ToEmail = emailRequestdto.toEmailId;
            string ToName = "User";
            SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(ToEmail, ToName);
            List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
            To.Add(smtpEmailTo);
            var confirmationLink = emailRequestdto.confirmationLink;
            string HtmlContent = "";
            using (WebClient web1 = new WebClient())
            {
                 HtmlContent = web1.DownloadString("https://office.merobolee.com/Resource/password-reset.html");
            }

            // string HtmlContent = System.IO.File.ReadAllText("https://office.merobolee.com/Resource/verify-email.html");
            if(HtmlContent.Contains("{0}")) {
                HtmlContent = HtmlContent.Replace("{0}", confirmationLink);
            }
            // string HtmlContent = string.Format(HtmlFromFile, confirmationLink);

            // string HtmlContent = "<style>html,body { padding: 0; margin:0; }</style>\n<div style=\"font-family:Arial,Helvetica,sans-serif; line-height: 1.5; font-weight: normal; font-size: 15px; color: #2F3044; min-height: 100%; margin:0; padding:0; width:100%; background-color:#edf2f7\">\n\t<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"border-collapse:collapse;margin:0 auto; padding:0; max-width:600px\">\n\t\t<tbody>\n\t\t\t<tr>\n\t\t\t\t<td align=\"center\" valign=\"center\" style=\"text-align:center; padding: 40px\">\n\t\t\t\t\t<a href=\"https://keenthemes.com\" rel=\"noopener\" target=\"_blank\">\n\t\t\t\t\t\t<img alt=\"Logo\" src=\"C:\\Users\\Anish\\OneDrive\\Desktop\\logo1.png\" />\n\t\t\t\t\t</a>\n\t\t\t\t</td>\n\t\t\t</tr>\n\t\t\t<tr>\n\t\t\t\t<td align=\"left\" valign=\"center\">\n\t\t\t\t\t<div style=\"text-align:left; margin: 0 20px; padding: 40px; background-color:#ffffff; border-radius: 6px\">\n\t\t\t\t\t\t<!--begin:Email content-->\n\t\t\t\t\t\t<div style=\"padding-bottom: 30px; font-size: 17px;\">\n\t\t\t\t\t\t\t<strong>Welcome to Mero Bolee!</strong>\n\t\t\t\t\t\t</div>\n\t\t\t\t\t\t<div style=\"padding-bottom: 30px\">To activate your account, please click on the button below to verify your email address. Be a part of the next generation of procurement in Nepal</div>\n\t\t\t\t\t\t<div style=\"padding-bottom: 40px; text-align:center;\">\n\t\t\t\t\t\t\t<a href=" + confirmationLink + "\" rel=\"noopener\" style=\"text-decoration:none;display:inline-block;text-align:center;padding:0.75575rem 1.3rem;font-size:0.925rem;line-height:1.5;border-radius:0.35rem;color:#ffffff;background-color:#009EF7;border:0px;margin-right:0.75rem!important;font-weight:600!important;outline:none!important;vertical-align:middle\" target=\"_blank\">Activate Account</a>\n\t\t\t\t\t\t</div>\n\t\t\t\t\t\t<div style=\"padding-bottom: 30px\">This password reset link will expire in 60 minutes. If you did not request a password reset, no further action is required.</div>\n\t\t\t\t\t\t<div style=\"border-bottom: 1px solid #eeeeee; margin: 15px 0\"></div>\n\t\t\t\t\t\t<div style=\"padding-bottom: 50px; word-wrap: break-all;\">\n\t\t\t\t\t\t\t<p style=\"margin-bottom: 10px;\">Button not working? Try pasting this URL into your browser:</p>\n\t\t\t\t\t\t\t<a href=\"https://keenthemes.com/account/confirm/07579ae29b6?email=max%40kt.com\" rel=\"noopener\" target=\"_blank\" style=\"text-decoration:none;color: #009EF7\">https://keenthemes.com/account/confirm/07579ae29b6?email=max%40kt.com</a>\n\t\t\t\t\t\t</div>\n\t\t\t\t\t\t<!--end:Email content-->\n\t\t\t\t\t\t<div style=\"padding-bottom: 10px\">Kind regards,\n\t\t\t\t\t\t<br>Mero Bolee Team.\n\t\t\t\t\t\t<tr>\n\t\t\t\t\t\t\t<td align=\"center\" valign=\"center\" style=\"font-size: 13px; text-align:center;padding: 20px; color: #6d6e7c;\">\n\t\t\t\t\t\t\t\t<p>Dillibazar, Kathmandu 29, Nepal</p>\n\t\t\t\t\t\t\t\t<p>Copyright ©\n\t\t\t\t\t\t\t\t<a href=\"https://merobolee.com\" rel=\"noopener\" target=\"_blank\">MeroBolee Tech Pvt. Ltd.</a>.</p>\n\t\t\t\t\t\t\t</td>\n\t\t\t\t\t\t</tr></br></div>\n\t\t\t\t\t</div>\n\t\t\t\t</td>\n\t\t\t</tr>\n\t\t</tbody>\n\t</table>\n</div>";
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