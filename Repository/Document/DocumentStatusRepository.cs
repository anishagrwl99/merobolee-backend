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
    /// document interace
    /// </summary>
    public interface IDocumentStatusRepository : IRepositoryBase<DocumentStatusEntity>
    {
        /// <summary>
        /// get document status
        /// </summary>
        /// <returns></returns>
        public new List<DocumentStatusEntity> Get();
    }

    /// <summary>
    /// Document status repo
    /// </summary>
    public class DocumentStatusRepository : RepositoryBase<DocumentStatusEntity>, IDocumentStatusRepository
    {
        private readonly IUnitOfWork unitOfWork;


        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="dbFactory"></param>
        /// <param name="unitOfWork"></param>
        public DocumentStatusRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get document status
        /// </summary>
        /// <returns></returns>
        public override List<DocumentStatusEntity> Get()
        {
            try
            {
                return meroBoleeDbContexts.DocumentStatusEntities.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
