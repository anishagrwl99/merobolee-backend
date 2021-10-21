using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.Mail
{
    public class MailRepository : RepositoryBase<MailEntity>, IMailRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private IUploadFile uploadImage;
        public MailRepository(IDbFactory dbFactory, IUploadFile uploadFileService, IUnitOfWork unitOfWork) : base(dbFactory) 
        {
            this.unitOfWork = unitOfWork;
            uploadImage = uploadFileService;
        }

        public async void PostMail(MailEntity mailEntity, ICollection<IFormFile> attachment)
        {
            meroBoleeDbContexts.MailEntities.Add(mailEntity);
            unitOfWork.SaveChange();

            if (attachment != null)
            {

                foreach (var Attachment in attachment)
                {
                    meroBoleeDbContexts.MailAttachmentEntities.Add(new MailAttachmentEntity
                    {
                        Document = await uploadImage.Upload(Attachment, mailEntity.ToEmail)
                    }
                                   );
                    unitOfWork.SaveChange();
                }
            }

        }

        public IEnumerable<MailEntity> ShowReceiveMail(string email)
        {
            meroBoleeDbContexts.MailAttachmentEntities.ToList();
            return meroBoleeDbContexts.MailEntities.Where(m=>m.ToEmail==email.ToLower()).ToList();
        }

        public IEnumerable<MailEntity> ShowSentMail(string email)
        {
            meroBoleeDbContexts.MailAttachmentEntities.ToList();
            return meroBoleeDbContexts.MailEntities.Where(m => m.FromEmail == email.ToLower()).ToList();
        }

        public IEnumerable<MailEntity> ShowSendMail()
        {
            meroBoleeDbContexts.MailAttachmentEntities.ToList();
            return meroBoleeDbContexts.MailEntities.ToList();
        }

        public IEnumerable<MailEntity> CallForAction(string email)
        {
            meroBoleeDbContexts.MailAttachmentEntities.ToList();
            return meroBoleeDbContexts.MailEntities.Where(m => m.FromEmail == email.ToLower() || m.ToEmail==email.ToLower()).ToList();
        }
    }
}
