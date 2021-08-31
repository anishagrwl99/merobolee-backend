using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.Mail
{
    public interface IMailByUserService
    {
        Task SendEmailAsyncByUser(MailRequestByUser mailRequest);

    }
}
