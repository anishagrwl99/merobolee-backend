using System;
using System.Net;
using System.Net.Mail;
using MeroBolee.Dto;
using MeroBolee.Service.Otp;
using MeroBolee.Settings;
using Microsoft.Extensions.Options;

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

        try
        {
           return SmtpSettings(emailRequestdto);

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
            msgs.To.Add(emailRequestdto.toEmailId.Trim());  
            MailAddress address = new MailAddress(emailValues.FromEmailID);  
            msgs.From = address;  
            msgs.Subject = emailRequestdto.subject;
            msgs.Body = emailRequestdto.htmlContent;  
            msgs.IsBodyHtml = true;  
            SmtpClient client = new SmtpClient();  
            client.Host = emailValues.Host;  
            client.Port = int.Parse(emailValues.Port) ;  
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.TargetName = emailValues.TargetName;
            client.Credentials = new System.Net.NetworkCredential(emailValues.FromEmailID, emailValues.FromEmailPassword);  
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
}