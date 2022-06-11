using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public interface ICompanyDocumentRepository : IRepositoryBase<CompanyDocumentEntity>
    {
        public CompanyDocumentEntity AddDocument(CompanyDocumentEntity obj);
        public CompanyDocumentEntity ChangeStatus(int userId, long documentId, int statusId, string remarks);
        public List<CompanyDocumentEntity> GetAllDocument(int companyId);
        public string GetCompanyFolder(long companyId);

        public Task<bool> DeleteDocument(long documentId);
    }


    public class CompanyDocumentRepository : RepositoryBase<CompanyDocumentEntity>, ICompanyDocumentRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public CompanyDocumentRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public CompanyDocumentEntity AddDocument(CompanyDocumentEntity obj)
        {
            try
            {
                meroBoleeDbContexts.CompanyDocumentEntities.Add(obj);
                unitOfWork.SaveChange();
                return obj;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public CompanyDocumentEntity ChangeStatus(int userId, long documentId, int statusId, string remarks)
        {
            try
            {
                CompanyDocumentEntity entity =  meroBoleeDbContexts
                    .CompanyDocumentEntities
                    .Where(x => x.Id == documentId)
                    .FirstOrDefault();
                if(entity != null)
                {
                    entity.DocumentStatusId = statusId;
                    entity.StatusChangedBy = userId;
                    entity.Remarks = remarks;
                    unitOfWork.SaveChange();
                    return entity;

                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<CompanyDocumentEntity> GetAllDocument(int companyId)
        {
            try
            {
                return meroBoleeDbContexts.CompanyDocumentEntities
                    .Include(d => d.DocumentType)
                    .Include(st => st.DocumentStatus)
                    .Include(u => u.UploadUserEntity)
                    .Include(s => s.StatusChangedUserEntity)
                    .Where(x => x.CompanyID == companyId)
                    .Where(X => X.IsDeleted == false)
                    .ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetCompanyFolder(long companyId)
        {
            try
            {
                return meroBoleeDbContexts.CompanyEntities
                    .Where(x => x.CompanyId == companyId)
                    .Select(x => x.FolderName)
                    .FirstOrDefault();
                    
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<bool> DeleteDocument(long documentId) {
            try
            {
                var deleteQuery = meroBoleeDbContexts.CompanyDocumentEntities
                    .Where(x => x.Id == documentId)
                    .FirstOrDefault();
                deleteQuery.IsDeleted = true;
                await unitOfWork.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
