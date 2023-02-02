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
        private readonly ISendEmailService sendEmailService;

        public RequestDemoService(ISendEmailService sendEmailService)
        {
            this.sendEmailService = sendEmailService;
        }
        public async Task<string> RequestDemo(RequestDemoDto requestDemoDto) {
            try {
                string demoRequestBy = "DEMO REQUEST BY : ";
                string senderName = "Request Demo";
                string toName = "REQUEST DEMO";
                string fromEmailId = "support@merobolee.com";
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
        
        private SendEmailResponseDto RequestDemoEmail(RequestDemoDto requestDemoDto, string demoRequestBy, string senderName, string toName, string fromEmailId)
        {
            string HtmlContent = "<b> NAME : </b>" + requestDemoDto.Name + "\t\n" + "<br>" + "<b> MESSAGE : </b>" + requestDemoDto.YourMessage + "" + "\t\n" + "<br>" + "<b> CONTACT NUMBER : </b>" + requestDemoDto.ContactNumber + "\t\n" + "<br>" + "<b> EMAIL ID : </b>" + requestDemoDto.EmailId + "\t\n";
            EmailRequestdto emailRequestdto = new EmailRequestdto();
            emailRequestdto.toEmailId = fromEmailId;
            emailRequestdto.subject =  demoRequestBy + requestDemoDto.EmailId;
            emailRequestdto.callFrom = "ContactUs";
            emailRequestdto.htmlContent = HtmlContent;
            sendEmailService.SendEmail(emailRequestdto);
            SendEmailResponseDto sendEmailResponseDto = new SendEmailResponseDto();
            sendEmailResponseDto.response = "SUCESSFULLY SENT EMAIL";
            return sendEmailResponseDto;
        }
        
    }
}