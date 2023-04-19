using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using MeroBolee.Dto;
using MeroBolee.Service.Otp;
using MeroBolee.Settings;
using Microsoft.Extensions.Options;
using MimeKit;


namespace MeroBolee.Service;

public class SendEmailService : ISendEmailService
{

    private readonly EmailValues emailValues;

    public SendEmailService(IOptions<EmailValues> emailValues)
    {
        this.emailValues = emailValues.Value;

    }

    public SendEmailResponseDto SendEmail(EmailRequestdto emailRequestdto)
    {

        if (emailRequestdto.callFrom.Equals("SignUp"))
        {

            string HtmlContent = "";
            using (WebClient web1 = new WebClient())
            {
                HtmlContent = web1.DownloadString("https://api.merobolee.com/Resource/verify-email.html");
            }

            if (HtmlContent.Contains("{0}"))
            {
                HtmlContent = HtmlContent.Replace("{0}", emailRequestdto.confirmationLink);
            }

            emailRequestdto.subject = "Welcome to Merobolee! Nepal's First E-bidding Platform";
            emailRequestdto.htmlContent = HtmlContent;
        }
        else if (emailRequestdto.callFrom.Equals("ForgotPassword"))
        {
            string HtmlContent = "";
            using (WebClient web1 = new WebClient())
            {
                HtmlContent = web1.DownloadString("https://api.merobolee.com/Resource/forgot-password.html");
            }

            if (HtmlContent.Contains("{0}"))
            {
                HtmlContent = HtmlContent.Replace("{0}", emailRequestdto.confirmationLink);
            }

            emailRequestdto.subject = "Meroolee: Request for password change!";
            emailRequestdto.htmlContent = HtmlContent;
        }
        else if (emailRequestdto.callFrom.Equals("OtpGenerate"))
        {
            string HtmlContent = "";
            using (WebClient web1 = new WebClient())
            {
                HtmlContent = web1.DownloadString("https://api.merobolee.com/Resource/otp.html");
            }

            if (HtmlContent.Contains("{0}"))
            {
                HtmlContent = HtmlContent.Replace("{0}", emailRequestdto.Otp);
            }

            emailRequestdto.subject = "Merobolee! Nepal's First E-bidding Platform: OTP Requested";
            emailRequestdto.htmlContent = HtmlContent;
        }
        else if (emailRequestdto.callFrom.Equals("NewTender"))
        {
            emailRequestdto.subject = "Merobolee! Nepal's First E-bidding Platform: New Tender";
            string Tender;
            string word = "New Tender is available in marketplace";
            foreach (var item in emailRequestdto.Tenders)
            {
                Tender =
                    $"\r\n Title= {item.Title} \t Category= {item.CategoryEntity.Title} \t Product= {item.Product} \t Location= {item.Location} \t RegistrationTill= {item.RegistrationTill}";
                word += Tender;
            }

            emailRequestdto.htmlContent = word;
        }
        else if (emailRequestdto.callFrom.Equals("WeeklyNewTenderEmail"))
        {
            string HtmlContent = "";
            using (WebClient web1 = new WebClient())
            {
                HtmlContent = web1.DownloadString("https://api.merobolee.com/Resource/mplace.html");
            }

            string loopData = "";
            using (WebClient web1 = new WebClient())
            {
                loopData = web1.DownloadString("https://api.merobolee.com/Resource/loopdata.html");
            }

            emailRequestdto.subject = "Merobolee! Nepal's First E-bidding Platform: New Tender";
            string word = "New Tender is available in marketplace";
            StringBuilder finalLoopData = new StringBuilder();
            foreach (var item in emailRequestdto.Tenders)
            {
                string loopDataReplica = loopData;
                if (item.AlgoId == 3 || item.AlgoId == 4)
                {
                    loopDataReplica = loopDataReplica.Replace("{tenderTitle}", item.Title).Replace("{product}", item.Product)
                        .Replace("{liveStartDate}", TimeZoneInfo.ConvertTime(item.RegistrationTill, TimeZoneInfo.FindSystemTimeZoneById("Nepal Standard Time")).ToString())
                        .Replace("{liveEndDate}", TimeZoneInfo.ConvertTime(item.RegistrationTill, TimeZoneInfo.FindSystemTimeZoneById("Nepal Standard Time")).ToString())
                        .Replace("{registrationTill}", TimeZoneInfo.ConvertTime(item.RegistrationTill, TimeZoneInfo.FindSystemTimeZoneById("Nepal Standard Time")).ToString())
                        .Replace("{tenderType}", item.AlgoName).Replace("{categoryType}", item.CategoryEntity.Title);
                    finalLoopData.Append(loopDataReplica);
                } 
                else 
                {
                    loopDataReplica = loopDataReplica.Replace("{tenderTitle}", item.Title).Replace("{product}", item.Product)
                        .Replace("{liveStartDate}", TimeZoneInfo.ConvertTime(item.LiveStartDate, TimeZoneInfo.FindSystemTimeZoneById("Nepal Standard Time")).ToString())
                        .Replace("{liveEndDate}", TimeZoneInfo.ConvertTime(item.LiveEndDate, TimeZoneInfo.FindSystemTimeZoneById("Nepal Standard Time")).ToString())
                        .Replace("{registrationTill}", TimeZoneInfo.ConvertTime(item.RegistrationTill, TimeZoneInfo.FindSystemTimeZoneById("Nepal Standard Time")).ToString())
                        .Replace("{tenderType}", item.AlgoName).Replace("{categoryType}", item.CategoryEntity.Title);
                    finalLoopData.Append(loopDataReplica);
                }

            }
            
            HtmlContent = HtmlContent.Replace("{loopData}", finalLoopData.ToString());
            emailRequestdto.htmlContent = HtmlContent;

        }

        try
        {
            if (emailRequestdto.callFrom.Equals("WeeklyNewTenderEmail"))
            {
                return SmtpSettingsZeptoEmail(emailRequestdto);
            }
            else
            {
                return SmtpSettings(emailRequestdto);
            }

        }
        catch (Exception e)
        {
            throw e;
        }
    }

    private SendEmailResponseDto SmtpSettings(EmailRequestdto emailRequestdto)
    {
        try
        {
            MailMessage msgs = new MailMessage();
            if (emailRequestdto.callFrom.Equals("NewTender") || emailRequestdto.callFrom.Equals("WeeklyNewTenderEmail"))
            {
                msgs.Bcc.Add(emailRequestdto.toEmailId);
            }
            else
            {
                msgs.To.Add(emailRequestdto.toEmailId.Trim());
            }

            MailAddress address = new MailAddress(emailValues.FromEmailID);
            msgs.From = address;
            msgs.Subject = emailRequestdto.subject;
            msgs.Body = emailRequestdto.htmlContent;
            msgs.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Host = emailValues.Host;
            client.Port = int.Parse(emailValues.Port);
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.TargetName = emailValues.TargetName;
            client.Credentials =
                new System.Net.NetworkCredential(emailValues.FromEmailID, emailValues.FromEmailPassword);
            client.Send(msgs);
            SendEmailResponseDto sendEmailResponseDto = new SendEmailResponseDto();
            sendEmailResponseDto.response = emailValues.SuccessResponse;

            return sendEmailResponseDto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private SendEmailResponseDto SmtpSettingsZeptoEmail(EmailRequestdto emailRequestdto)
    {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("noreply", "noreply@merobolee.com"));
            message.Bcc.Add(new MailboxAddress("Anish Agrawal", "rcccstha@gmail.com"));

            // foreach (var email in emailRequestdto.toEmailIds)
            // {
            //     message.Bcc.Add(new MailboxAddress("", email));
            // }

            message.Subject = emailRequestdto.subject;
            message.Body = new TextPart("html")
            {
                Text = emailRequestdto.htmlContent
            };
            var client = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                client.SslProtocols = System.Security.Authentication.SslProtocols.Tls12;
                client.Connect("smtp.zeptomail.com", 587, false);
                client.Authenticate("emailapikey",
                    "wSsVR60i8xP0Wqt4yjKrcutqzw5dBl/yQ0h/2FCo4nH6GPvE9MdpkUTOUw/zTaAcQ2U/EGBBpLIvyx0I1GUL3t9+mQoGWSiF9mqRe1U4J3x17qnvhDzOXmxVlBCILowIxw9pmGBpEs1u");
                client.Send(message);
                client.Disconnect(true);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            SendEmailResponseDto sendEmailResponseDto = new SendEmailResponseDto();
            sendEmailResponseDto.response = emailValues.SuccessResponse;

            return sendEmailResponseDto;
    }
}