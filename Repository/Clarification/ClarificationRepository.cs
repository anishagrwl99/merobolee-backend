using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    
    public interface IClarificationRepository : IRepositoryBase<ClarificationEmailEntity>
    {
        public ClarificationEmailEntity SendClarificationEmail(ClarificationEmailEntity obj);
        public List<ClarificationEmailEntity> GetClarificationEmails(int supplierId);
        public ClarificationEmailEntity GetClarificationEmailDetail(int id);
        public ClarificationEmailEntity ReadClarificationEmail(int id);
    }


    public class ClarificationRepository : RepositoryBase<ClarificationEmailEntity>, IClarificationRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public ClarificationRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public ClarificationEmailEntity SendClarificationEmail(ClarificationEmailEntity obj)
        {
            try
            {
                meroBoleeDbContexts.ClarificationEmailEntities.Add(obj);
                unitOfWork.SaveChange();
                return obj;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ClarificationEmailEntity> GetClarificationEmails(int supplierId)
        {
            return meroBoleeDbContexts
                .ClarificationEmailEntities
                .Include(x=>x.UserEntity)
                .Include(x=>x.UserEntity.Company)
                .Include(x=>x.CorrespondenceEmailEntity)
                .Where(x=>x.CorrespondenceEmailEntity.SenderUserId == supplierId)
                .ToList();
        }

        public ClarificationEmailEntity GetClarificationEmailDetail(int id)
        {
            return meroBoleeDbContexts
                .ClarificationEmailEntities
                .Include(x=>x.UserEntity)
                .Include(x=>x.UserEntity.Company)
                .Where(x => x.Id == id).FirstOrDefault();
        }

        public ClarificationEmailEntity ReadClarificationEmail(int id)
        {
            ClarificationEmailEntity entity = GetClarificationEmailDetail(id);
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
