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
    public interface ICallActionRepository : IRepositoryBase<CallActionEmailEntity>
    {
        public CallActionEmailEntity SendCallActionEmail(CallActionEmailEntity obj);
        public List<CallActionEmailEntity> GetCallActionEmails(long supplierId);
        public List<CallActionEmailEntity> GetCallActionParentEmailsResponses(long emailId, long parentId);
        public List<CallActionEmailEntity> GetCallActionEmailsNested(long supplierId);
        public CallActionEmailEntity GetCallActionEmailDetail(long id);
        public CallActionEmailEntity ReadCallActionEmail(long id);
        CallActionResponseDto GetParentEmail(long? parentEmailId, long currentEmailId);
        List<CallActionResponseDto> GetParentEmailResponses(long? parentEmailId, long responseEmailId);
        List<CallActionResponseDto> GetEmailResponses(long currentEmailId);
    }


    public class CallActionRepository : RepositoryBase<CallActionEmailEntity>, ICallActionRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public CallActionRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public CallActionEmailEntity SendCallActionEmail(CallActionEmailEntity obj)
        {
            try
            {
                meroBoleeDbContexts.CallActionEmailEntities.Add(obj);
                unitOfWork.SaveChange();
                return obj;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        public List<CallActionEmailEntity> GetCallActionEmails(long supplierId)
        {
            //emails.SelectMany(c => c.Responses).Concat(emails);
            List<CallActionEmailEntity> userEmails =  meroBoleeDbContexts
                .CallActionEmailEntities
                .Include(x=>x.UserEntity)
                .Where(x=>x.SenderUserId == supplierId)
                .ToList();
            List<CallActionEmailEntity> emails = new List<CallActionEmailEntity>(userEmails);
            foreach (CallActionEmailEntity email in userEmails)
            {
                List<CallActionEmailEntity> related = meroBoleeDbContexts
                                                        .CallActionEmailEntities
                                                        .Include(x => x.UserEntity)
                                                        .Where(x => x.Id == email.ParentId || x.ParentId == email.Id)
                                                        .ToList();
                emails.AddRange(related);
            }
            return emails.OrderBy(x => x.EmailSentOn).ToList();
        }

        public CallActionResponseDto GetParentEmail(long? parentEmailId, long currentEmailId)
        {
            try
            {
                if (!parentEmailId.HasValue) return null;

                var email = from eml in meroBoleeDbContexts.CallActionEmailEntities
                            join u in meroBoleeDbContexts.UserEntities on eml.SenderUserId equals u.User_Id
                            where eml.Id == parentEmailId
                            select new CallActionResponseDto
                            {
                                Id = eml.Id,
                                IsRead = eml.IsRead,
                                Subject = eml.Subject,
                                Body = null,
                                SentOn = eml.EmailSentOn,
                                SenderName = $"{u.First_Name} {u.Middle_Name} {u.Last_Name}",
                                Parent = null,
                                ParentId = null,
                                Responses = GetParentEmailResponses(parentEmailId, currentEmailId)
                            };
                return email.FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<CallActionResponseDto> GetEmailResponses(long currentEmailId)
        {
            try
            {

                var email = from eml in meroBoleeDbContexts.CallActionEmailEntities
                            join u in meroBoleeDbContexts.UserEntities on eml.SenderUserId equals u.User_Id
                            where eml.ParentId == currentEmailId
                            select new CallActionResponseDto
                            {
                                Id = eml.Id,
                                IsRead = eml.IsRead,
                                Subject = eml.Subject,
                                Body = null,
                                SentOn = eml.EmailSentOn,
                                SenderName = $"{u.First_Name} {u.Middle_Name} {u.Last_Name}",
                                Parent = null,
                                ParentId = null,
                                Responses = GetEmailResponses(eml.Id)
                            };
                return email.ToList<CallActionResponseDto>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CallActionResponseDto> GetParentEmailResponses(long? parentEmailId, long responseEmailId)
        {
            try
            {
                if (!parentEmailId.HasValue) return null;

                var email = from eml in meroBoleeDbContexts.CallActionEmailEntities
                            join u in meroBoleeDbContexts.UserEntities on eml.SenderUserId equals u.User_Id
                            where eml.ParentId == parentEmailId && eml.Id != responseEmailId
                            select new CallActionResponseDto
                            {
                                Id = eml.Id,
                                IsRead = eml.IsRead,
                                Subject = eml.Subject,
                                Body = null,
                                SentOn = eml.EmailSentOn,
                                SenderName = $"{u.First_Name} {u.Middle_Name} {u.Last_Name}",
                                Parent = null,
                                ParentId = parentEmailId,
                                Responses = null
                            };
                return email.ToList<CallActionResponseDto>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CallActionEmailEntity> GetCallActionEmailsNested(long supplierId)
        {
            //emails.SelectMany(c => c.Responses).Concat(emails);
            return meroBoleeDbContexts
                .CallActionEmailEntities
                .Include(x => x.UserEntity)
                .Include(x=>x.Responses)
                .Where(x => x.ParentId == null && x.SenderUserId == supplierId)
                .ToList();
        }

        public CallActionEmailEntity GetCallActionEmailDetail(long id)
        {
            return meroBoleeDbContexts
                .CallActionEmailEntities
                .Include(x => x.UserEntity)
                .Include(x => x.Responses)
                .Include(x=>x.ParentEmail)
                .Where(x => x.Id == id).FirstOrDefault();
        }
        public List<CallActionEmailEntity> GetCallActionParentEmailsResponses(long emailId, long parentId)
        {
            return meroBoleeDbContexts
                .CallActionEmailEntities
                .Include(x => x.UserEntity)
                .Include(x => x.Responses)
                .Where(x => x.ParentId == parentId && x.Id != emailId)
                .ToList();
        }

        public CallActionEmailEntity ReadCallActionEmail(long id)
        {
            CallActionEmailEntity entity = GetCallActionEmailDetail(id);
            if (entity != null)
            {
                entity.IsRead = true;
                unitOfWork.SaveChange();
                return entity;
            }
            return null;

        }

    }
}
