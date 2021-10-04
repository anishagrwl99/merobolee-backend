using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public interface IDocumentTypeRepository : IRepositoryBase<DocumentTypeEntity>
    {
        public List<DocumentTypeEntity> Get();
    }


    public class DocumentTypeRepository : RepositoryBase<DocumentTypeEntity>, IDocumentTypeRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public DocumentTypeRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        List<DocumentTypeEntity> IDocumentTypeRepository.Get()
        {
            try
            {
                return meroBoleeDbContexts.DocumentTypeEntities.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
