using MeroBolee.Model;
using MeroBolee.Repository.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.SMTPMail
{
    public class DisplayMailService : IDisplayMailService
    {
        private readonly IMailRepository mailRepository;
        public DisplayMailService(IMailRepository mailRepository)
        {
            this.mailRepository = mailRepository;
        }

        public IEnumerable<MailEntity> CallForAction(string email)
        {
            return mailRepository.CallForAction(email);
        }

        public IEnumerable<MailEntity> ShowReceiveMail(string email)
        {
            return mailRepository.ShowReceiveMail(email);
        }

        public IEnumerable<MailEntity> ShowSendMail()
        {
            return mailRepository.ShowSendMail();
        }

        public IEnumerable<MailEntity> ShowSentMail(string email)
        {
            return mailRepository.ShowSentMail(email);
        }
    }
}
