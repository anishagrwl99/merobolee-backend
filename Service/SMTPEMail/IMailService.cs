using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.SMTPMail
{
    public interface ISMTPMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
      //  Task SendWelcomeEmailAsync(WelcomeRequest request);
    }
}
