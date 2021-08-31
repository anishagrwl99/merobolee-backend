using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.Mail
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
      //  Task SendWelcomeEmailAsync(WelcomeRequest request);
    }
}
