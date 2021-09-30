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
        public List<CallActionEmailEntity> GetCallActionEmails();
        public List<CallActionEmailEntity> GetCallActionParentEmailsResponses(long emailId, long parentId);
        public List<CallActionEmailEntity> GetCallActionEmailsNested();
        public CallActionEmailEntity GetCallActionEmailDetail(long id);
        public CallActionEmailEntity ReadCallActionEmail(long id);
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
            catch (Exception)
            {

                throw;
            }
        }

        public List<CallActionEmailEntity> GetCallActionEmails()
        {
            //emails.SelectMany(c => c.Responses).Concat(emails);
            return meroBoleeDbContexts
                .CallActionEmailEntities
                .Include(x=>x.UserEntity)
                .ToList();
        }

        public List<CallActionEmailEntity> GetCallActionEmailsNested()
        {
            //emails.SelectMany(c => c.Responses).Concat(emails);
            return meroBoleeDbContexts
                .CallActionEmailEntities
                .Include(x => x.UserEntity)
                .Include(x=>x.Responses)
                .Where(x => x.ParentId == null)
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
