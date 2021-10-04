using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Repository;
using MeroBolee.Service.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public interface IDocumentStatusService
    {
        public List<DocumentStatusEntity> List();
    }

    public class DocumentStatusService : DocumentMapper, IDocumentStatusService
    {

        private readonly IDocumentStatusRepository statRepo;
        public DocumentStatusService(IDocumentStatusRepository statRepo)
        {
            this.statRepo = statRepo;
        }

        public List<DocumentStatusEntity> List()
        {
            try
            {
                return statRepo.Get();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
 