using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.Mail
{
     public interface IDisplayMailService
    {
        IEnumerable<MailEntity> ShowSendMail();
        IEnumerable<MailEntity> ShowReceiveMail(string email);
        IEnumerable<MailEntity> CallForAction(string email);
        IEnumerable<MailEntity> ShowSentMail(string email);
    }
}
