using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using System.Diagnostics;


namespace MeroBolee.Service
{
    public class RequestDemoService : IRequestDemoService
    {
        public async Task<string> RequestDemo(RequestDemoDto requestDemoDto) {
            try {
                string demoRequestBy = "DEMO REQUEST BY : ";
                string senderName = "Request Demo";
                string toName = "REQUEST DEMO";
                string fromEmailId = "requestdemo@merobolee.com";
                SendEmailResponseDto sendEmailResponseDto = RequestDemoEmail(requestDemoDto, demoRequestBy, senderName, toName, fromEmailId);
                return sendEmailResponseDto.response;
            } catch {
                throw;
            }
        }

        public async Task<string> ContactUs(RequestDemoDto requestDemoDto) {
            try {
                string demoRequestBy = "CONTACT REQUEST RAISED BY: ";
                string senderName = "CONTACT US";
                string toName = "CONTACT US";
                string fromEmailId = "support@merobolee.com";
                SendEmailResponseDto sendEmailResponseDto = RequestDemoEmail(requestDemoDto, demoRequestBy, senderName, toName, fromEmailId);
                return sendEmailResponseDto.response;
            } catch {
                throw;
            }
        }
        
        public static SendEmailResponseDto RequestDemoEmail(RequestDemoDto requestDemoDto, string demoRequestBy, string senderName, string toName, string fromEmailId)
        {
            Configuration.Default.ApiKey.Remove("api-key");
            Configuration.Default.ApiKey.Add("api-key", "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");

            var apiInstance = new TransactionalEmailsApi();
            string SenderName = senderName;
            string SenderEmail = fromEmailId;
            SendSmtpEmailSender Email = new SendSmtpEmailSender(SenderName, SenderEmail);
            string ToEmail = fromEmailId;
            string ToName = toName;
            SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(ToEmail, ToName);
            List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
            To.Add(smtpEmailTo);
            string HtmlContent = "<b> NAME : </b>" + requestDemoDto.Name + "\t\n" + "<br>" + "<b> MESSAGE : </b>" + requestDemoDto.YourMessage + "" + "\t\n" + "<br>" + "<b> CONTACT NUMBER : </b>" + requestDemoDto.ContactNumber + "\t\n" + "<br>" + "<b> EMAIL ID : </b>" + requestDemoDto.EmailId + "\t\n";
            string TextContent = null;
            string Subject = demoRequestBy + requestDemoDto.EmailId;
            SendSmtpEmailTo1 smtpEmailTo1 = new SendSmtpEmailTo1(ToEmail, ToName);
            List<SendSmtpEmailTo1> To1 = new List<SendSmtpEmailTo1>();
            To1.Add(smtpEmailTo1);
            try
            {
                var sendSmtpEmail = new SendSmtpEmail(Email, To, null, null, HtmlContent, TextContent, Subject, null, null, null, null, null, null, null);
                CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
                Debug.WriteLine(result.ToJson());
                Console.WriteLine(result.ToJson());
                SendEmailResponseDto sendEmailResponseDto = new SendEmailResponseDto();
                sendEmailResponseDto.response = "SUCESSFULLY SENT EMAIL";
                return sendEmailResponseDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
    }
}