namespace MeroBolee.Service;

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
using System.Collections.Generic;
using System.Net;

public interface ISendEmailService
{
    public SendEmailResponseDto SendEmail(EmailRequestdto emailRequestdto);

}