using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public interface ICorrespondenceRepository : IRepositoryBase<CorrespondenceEmailEntity>
    {
        public CorrespondenceEmailEntity SendCorrespondenceEmail(CorrespondenceEmailEntity obj);
        public List<CorrespondenceEmailEntity> GetCorrespondenceEmails(int supplierId);
        public CorrespondenceEmailEntity GetCorrespondenceEmailDetail(int id);
        public CorrespondenceEmailEntity ReadCorrespondenceEmail(int id);
    }


    public class CorrespondenceRepository : RepositoryBase<CorrespondenceEmailEntity>, ICorrespondenceRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public CorrespondenceRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public CorrespondenceEmailEntity SendCorrespondenceEmail(CorrespondenceEmailEntity obj)
        {
            try
            {
                meroBoleeDbContexts.CorrespondenceEmailEntities.Add(obj);
                unitOfWork.SaveChange();
                return obj;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CorrespondenceEmailEntity> GetCorrespondenceEmails(int supplierId)
        {
            return meroBoleeDbContexts
                .CorrespondenceEmailEntities
                .Include(x=>x.User)
                .Include(x=>x.User.Company)
                .Where(x=>x.SenderUserId == supplierId)
                .ToList();
        }

        public CorrespondenceEmailEntity GetCorrespondenceEmailDetail(int id)
        {
            return meroBoleeDbContexts
                .CorrespondenceEmailEntities
                .Include(x=>x.User)
                .Include(x=>x.User.Company)
                .Where(x => x.Id == id).FirstOrDefault();
        }

        public CorrespondenceEmailEntity ReadCorrespondenceEmail(int id)
        {
            CorrespondenceEmailEntity entity = GetCorrespondenceEmailDetail(id);
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
