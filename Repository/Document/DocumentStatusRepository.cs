using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public interface IDocumentStatusRepository : IRepositoryBase<DocumentStatusEntity>
    {
        public List<DocumentStatusEntity> Get();
    }


    public class DocumentStatusRepository : RepositoryBase<DocumentStatusEntity>, IDocumentStatusRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public DocumentStatusRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<DocumentStatusEntity> Get()
        {
            try
            {
                return meroBoleeDbContexts.DocumentStatusEntities.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
