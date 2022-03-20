using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mail;
using System.Web;


namespace MeroBolee.Controllers.EmailService
{
    public class EmailServiceController : ControllerBase
    {
        
        [HttpPost("/sendEmail")]
        public IActionResult sendEmail(EmailRequestdto emailRequestdto)
        {

            // string baseUrl = "https://localhost:5001/Account/ConfirmEmail?";
            var confirmationLink = string.Format("{0}/Account/ConfirmEmail?userId={1}&token={2}", "https://office.merobolee.com", emailRequestdto.id, HttpUtility.UrlEncode(emailRequestdto.token));

            // string confirmationLink = string.Concat(string.Concat(baseUrl, string.Concat("userId=", emailRequestdto.id)), string.Concat("&",string.Concat("token=", emailRequestdto.token)));
            Console.Write(confirmationLink);
            // Url.Action(
            //    "ConfirmEmail", "Account",
            //    new { userId = emailRequestdto.id, code = emailRequestdto.token },
            //    protocol: Request.Scheme);
            string to = emailRequestdto.toEmailId; //To address    
            string from = "contact.agranish@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = confirmationLink;
            message.Subject = "confirmationEmail";
            message.Body = mailbody;
            // message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = false;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("contact.agranish@gmail.com", "vesk iuby cszw mwqb");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
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