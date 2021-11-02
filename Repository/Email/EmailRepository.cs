using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public interface IEmailRepository : IRepositoryBase<EmailEntity>
    {
        public EmailEntity AddEmail(EmailEntity obj);
        public List<EmailEntity> GetInboxEmails(long userId);
        public List<EmailEntity> GetOutboxEmails(long userId);
        public EmailEntity GetEmailDetail(long emailId);
        UserEmailEntity ReadEmail(long emailId, long userId);


        /// <summary>
        /// Get a parent email tender id and authorid
        /// </summary>
        /// <param name="emailId">Email Id on which reply is made</param>
        /// <returns><see cref="Tuple{T1, T2}"/> where T1 is TenderId and T2 is AuthorId</returns>
        Tuple<long, long> GetEmailTenderIdAndAuthorId(long emailId);
    }


    public class EmailRepository : RepositoryBase<EmailEntity>, IEmailRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public EmailRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public EmailEntity AddEmail(EmailEntity obj)
        {
            try
            {
                meroBoleeDbContexts.EmailEntities.Add(obj);
                unitOfWork.SaveChange();
                obj.User = meroBoleeDbContexts.UserEntities.Where(x => x.User_Id == obj.AuthorId).FirstOrDefault();
                return obj;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<EmailEntity> GetInboxEmails(long userId)
        {
            List<EmailEntity> userEmails = (from e in meroBoleeDbContexts.EmailEntities
                                            join ue in meroBoleeDbContexts.UserEmailEntities on e.Id equals ue.EmailId
                                            join u in meroBoleeDbContexts.UserEntities on e.AuthorId equals u.User_Id
                                            where ue.UserId == userId
                                            select new EmailEntity
                                            {
                                                Id = e.Id,
                                                AuthorId = e.AuthorId,
                                                Body = "",
                                                Subject = e.Subject,
                                                TenderId = e.TenderId,
                                                Date_created = e.Date_created,
                                                User = u,
                                                UserEmails = new List<UserEmailEntity>(){
                                                    new UserEmailEntity()
                                                    {
                                                        IsRead = ue.IsRead
                                                    }
                                                }
                                            }

                                        ).ToList<EmailEntity>();
            return userEmails.OrderBy(x => x.Date_created).ToList();
        }

        public List<EmailEntity> GetOutboxEmails(long userId)
        {
            List<EmailEntity> userEmails = (from e in meroBoleeDbContexts.EmailEntities
                                            join u in meroBoleeDbContexts.UserEntities on e.AuthorId equals u.User_Id
                                            where e.AuthorId == userId
                                            select new EmailEntity
                                            {
                                                Id = e.Id,
                                                AuthorId = e.AuthorId,
                                                Body = "",
                                                Subject = e.Subject,
                                                TenderId = e.TenderId,
                                                Date_created = e.Date_created,
                                                User = u,
                                                UserEmails = null
                                            }

                                        ).ToList<EmailEntity>();

            return userEmails.OrderBy(x => x.Date_created).ToList();
        }
        public EmailEntity GetEmailDetail(long emailId)
        {
            try
            {
                EmailEntity emailDetail = (from e in meroBoleeDbContexts.EmailEntities
                                           join u in meroBoleeDbContexts.UserEntities on e.AuthorId equals u.User_Id
                                           where e.Id == emailId
                                           select new EmailEntity
                                           {
                                               Id  = e.Id,
                                               AuthorId = e.AuthorId,
                                               Body = e.Body,
                                               Subject = e.Subject,
                                               TenderId = e.TenderId,
                                               User = u,
                                               UserEmails = null
                                           }

                                        ).FirstOrDefault();
                return emailDetail;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public UserEmailEntity ReadEmail(long emailId, long userId)
        {
            try
            {
                UserEmailEntity userEmail = (from ue in meroBoleeDbContexts.UserEmailEntities
                         where ue.EmailId == emailId && ue.UserId == userId
                         select ue
                         ).FirstOrDefault();
                if(userEmail != null)
                {
                    if (!userEmail.IsRead)
                    {
                        userEmail.IsRead = true;
                        meroBoleeDbContexts.Update(userEmail);
                        unitOfWork.SaveChange();
                    }
                }
                return userEmail;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Tuple<long, long> GetEmailTenderIdAndAuthorId(long emailId)
        {
            return (from e in meroBoleeDbContexts.EmailEntities
             where e.Id == emailId
             select Tuple.Create(e.TenderId, e.AuthorId)
             ).FirstOrDefault();
        }
    }
}
