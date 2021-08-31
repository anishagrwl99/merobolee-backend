using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.Mail
{
    public interface IMailRepository: IRepositoryBase<MailEntity>
    {
        void PostMail(MailEntity mailEntity,ICollection<IFormFile> attachment);
        IEnumerable<MailEntity> ShowSendMail();
        IEnumerable<MailEntity> ShowReceiveMail(string email);

        IEnumerable<MailEntity> CallForAction(string email);
        IEnumerable<MailEntity> ShowSentMail(string email);
    }
}
