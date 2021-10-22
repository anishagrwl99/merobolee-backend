using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    /// <summary>
    /// Document type repo interface
    /// </summary>
    public interface IDocumentTypeRepository : IRepositoryBase<DocumentTypeEntity>
    {
        /// <summary>
        /// Get document type
        /// </summary>
        /// <returns></returns>
        public new List<DocumentTypeEntity> Get();
    }


    /// <summary>
    /// Document type repo implementation
    /// </summary>
    public class DocumentTypeRepository : RepositoryBase<DocumentTypeEntity>, IDocumentTypeRepository
    {
       // private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="dbFactory"></param>
        /// <param name="unitOfWork"></param>
        public DocumentTypeRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory)
        {
           // this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get document type list
        /// </summary>
        /// <returns></returns>
        public override List<DocumentTypeEntity> Get()
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
