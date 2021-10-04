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
    public interface IDocumentTypeService
    {
        public List<DocumentTypeEntity> List();
    }

    public class DocumentTypeService : DocumentMapper, IDocumentTypeService
    {

        private readonly IDocumentTypeRepository docTypeRepository;
        public DocumentTypeService(IDocumentTypeRepository docTypeRepository)
        {
            this.docTypeRepository = docTypeRepository;
        }

        public List<DocumentTypeEntity> List()
        {
            try
            {
                return docTypeRepository.Get();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
 