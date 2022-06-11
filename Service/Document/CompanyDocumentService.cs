using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Repository;
using MeroBolee.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace MeroBolee.Service
{
    public interface ICompanyDocumentService
    {
        public Task<DocumentDto> AddDocument(DocumentDto obj);
        public DocumentUpdateStatusDto ChangeStatus(DocumentUpdateStatusDto obj);
        public List<DocumentResponseDto> GetAllDocument(int companyId , string baseUrl);

        Task<bool> DeleteDocument(long documentId);
    }

    public class CompanyDocumentService : DocumentMapper, ICompanyDocumentService
    {

        private readonly ICompanyDocumentRepository companyDocRepository;
        private IUploadFile docUpload;
        public CompanyDocumentService(ICompanyDocumentRepository companyDocRepository, IUploadFile uploadFileService)
        {
            this.companyDocRepository = companyDocRepository;
            docUpload = uploadFileService;
        }

        public async Task<DocumentDto> AddDocument(DocumentDto obj)
        {
            try
            {
                string path = "";
                if(obj.Document!= null && obj.Document.Length>0)
                {
                    string folder = companyDocRepository.GetCompanyFolder(obj.CompanyId);
                    path = await docUpload.Upload(obj.Document, folder);
                }
                CompanyDocumentEntity entity = ToEntity(obj);
                entity.IsDeleted = false;
                entity.DocumentPath = path;
                var ent =  companyDocRepository.AddDocument(entity);
                if (ent != null) return obj;
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DocumentUpdateStatusDto ChangeStatus(DocumentUpdateStatusDto obj)
        {
            try
            {
                var ent = companyDocRepository.ChangeStatus(obj.UserId, obj.DocumentId, obj.StatusId, obj.Remarks);
                if (ent != null) return obj;
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<DocumentResponseDto> GetAllDocument(int companyId, string baseUrl)
        {
            try
            {
                return ToListDto(companyDocRepository.GetAllDocument(companyId), baseUrl);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteDocument([FromBody] long documentId) {
            try
            {
                return await companyDocRepository.DeleteDocument(documentId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
 