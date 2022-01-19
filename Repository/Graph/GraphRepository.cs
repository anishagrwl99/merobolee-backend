using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    /// <summary>
    /// Status repo interface
    /// </summary>
    public interface IGraphRepository : IRepositoryBase<CommonStatus>
    {
        /// <summary>
        /// Gets the supplier registered tenders within a year.
        /// </summary>
        /// <param name="supplierCompanyId">The supplier company identifier.</param>
        /// <returns></returns>
        Task<List<TenderEntity>> GetSupplierRegisteredTenders(long supplierCompanyId);


        /// <summary>
        /// Gets the supplier won tenders within a year.
        /// </summary>
        /// <param name="supplierCompanyId">The supplier company identifier.</param>
        /// <returns></returns>
        Task<List<TenderEntity>> GetSupplierWonTenders(long supplierCompanyId);


        /// <summary>
        /// Gets the inviter tenders within a year.
        /// </summary>
        /// <param name="inviterCompanyId">The inviter company identifier.</param>
        /// <returns></returns>
        Task<List<TenderEntity>> GetInviterTenderSubmissions(long inviterCompanyId);
    }


    /// <summary>
    /// status repos implementation
    /// </summary>
    public class GraphRepository : RepositoryBase<CommonStatus>, IGraphRepository
    {

        private IUnitOfWork unitOfWork;


        /// <summary>
        /// Default const
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="dbFactory"></param>
        public GraphRepository(IUnitOfWork unitOfWork, IDbFactory dbFactory) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }



        /// <summary>
        /// Gets the inviter tenders within a year.
        /// </summary>
        /// <param name="inviterCompanyId">The inviter company identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<List<TenderEntity>> GetInviterTenderSubmissions(long inviterCompanyId)
        {
            try
            {
                DateTime fromDate = DateTime.Now.AddYears(-1);
                return await meroBoleeDbContexts.TenderEntities
                        .Include(x => x.CategoryEntity)
                        .Include(x => x.TenderStatusEntity)
                        .Where(x => x.CompanyId == inviterCompanyId && x.Date_created >= fromDate && x.Date_created <= DateTime.Now)
                        .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }



        /// <summary>
        /// Gets the supplier registered tenders within a year.
        /// </summary>
        /// <param name="supplierCompanyId">The supplier company identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<List<TenderEntity>> GetSupplierRegisteredTenders(long supplierCompanyId)
        {
            try
            {
                DateTime fromDate = DateTime.Now.AddYears(-1);
                return await (from br in meroBoleeDbContexts.BidRequestEntities
                              join t in meroBoleeDbContexts.TenderEntities on br.TenderId equals t.Tender_Id
                              join ts in meroBoleeDbContexts.TenderStatus on t.Tender_Status_Id equals ts.StatusId
                              join c in meroBoleeDbContexts.CategoryEntities on t.Category_Id equals c.Category_Id
                              where br.CompanyId == supplierCompanyId && t.Date_created >= fromDate && t.Date_created <= DateTime.Now
                              select new TenderEntity
                              {
                                  CompanyId = t.CompanyId,
                                  Tender_Id = t.Tender_Id,
                                  AdditionalRequest = t.AdditionalRequest,
                                  ApprovedBy = t.ApprovedBy,
                                  ApprovedByUser = t.ApprovedByUser,
                                  Cancel_remark = t.Cancel_remark,
                                  CategoryEntity = c,
                                  Category_Id = t.Category_Id,
                                  Company = t.Company,
                                  CreatedBy = t.CreatedBy,
                                  CreatedByUser = t.CreatedByUser,
                                  Date_created = t.Date_created,
                                  Date_modified = t.Date_modified,
                                  EligibilityCriteria = t.EligibilityCriteria,
                                  ExtraDocuments = t.ExtraDocuments,
                                  Feedbacks = t.Feedbacks,
                                  Live_End_Date = t.Live_End_Date,
                                  Live_Start_Date = t.Live_Start_Date,
                                  Location = t.Location,
                                  MaxQuotation = t.MaxQuotation,
                                  PerformanceRequest = t.PerformanceRequest,
                                  Price = t.Price,
                                  QualityRequest = t.QualityRequest,
                                  RegistrationTill = t.RegistrationTill,
                                  TenderCards = t.TenderCards,
                                  TenderDetailDocPath = t.TenderDetailDocPath,
                                  TenderDetailDocTitle = t.TenderDetailDocTitle,
                                  TenderMaterialEntities = t.TenderMaterialEntities,
                                  TenderStatusEntity = ts,
                                  TenderTermsConditionEntities = t.TenderTermsConditionEntities,
                                  Tender_Code = t.Tender_Code,
                                  Tender_live_interval = t.Tender_live_interval,
                                  Tender_Status_Id = t.Tender_Status_Id,
                                  Tender_Title = t.Tender_Title,
                                  TermsAndConditionDocPath = t.TermsAndConditionDocPath

                              }
                              ).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }



        /// <summary>
        /// Gets the supplier won tenders within a year.
        /// </summary>
        /// <param name="supplierCompanyId">The supplier company identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<List<TenderEntity>> GetSupplierWonTenders(long supplierCompanyId)
        {
            try
            {
                DateTime fromDate = DateTime.Now.AddYears(-1);
                return await (from tw in meroBoleeDbContexts.TenderWinnerEntities
                              join t in meroBoleeDbContexts.TenderEntities on tw.TenderId equals t.Tender_Id
                              join ts in meroBoleeDbContexts.TenderStatus on t.Tender_Status_Id equals ts.StatusId
                              join c in meroBoleeDbContexts.CategoryEntities on t.Category_Id equals c.Category_Id
                              where tw.WinnerCompanyId == supplierCompanyId && t.Date_created >= fromDate && t.Date_created <= DateTime.Now
                              select new TenderEntity
                              {
                                  CompanyId = t.CompanyId,
                                  Tender_Id = t.Tender_Id,
                                  AdditionalRequest = t.AdditionalRequest,
                                  ApprovedBy = t.ApprovedBy,
                                  ApprovedByUser = t.ApprovedByUser,
                                  Cancel_remark = t.Cancel_remark,
                                  CategoryEntity = c,
                                  Category_Id = t.Category_Id,
                                  Company = t.Company,
                                  CreatedBy = t.CreatedBy,
                                  CreatedByUser = t.CreatedByUser,
                                  Date_created = t.Date_created,
                                  Date_modified = t.Date_modified,
                                  EligibilityCriteria = t.EligibilityCriteria,
                                  ExtraDocuments = t.ExtraDocuments,
                                  Feedbacks = t.Feedbacks,
                                  Live_End_Date = t.Live_End_Date,
                                  Live_Start_Date = t.Live_Start_Date,
                                  Location = t.Location,
                                  MaxQuotation = t.MaxQuotation,
                                  PerformanceRequest = t.PerformanceRequest,
                                  Price = t.Price,
                                  QualityRequest = t.QualityRequest,
                                  RegistrationTill = t.RegistrationTill,
                                  TenderCards = t.TenderCards,
                                  TenderDetailDocPath = t.TenderDetailDocPath,
                                  TenderDetailDocTitle = t.TenderDetailDocTitle,
                                  TenderMaterialEntities = t.TenderMaterialEntities,
                                  TenderStatusEntity = ts,
                                  TenderTermsConditionEntities = t.TenderTermsConditionEntities,
                                  Tender_Code = t.Tender_Code,
                                  Tender_live_interval = t.Tender_live_interval,
                                  Tender_Status_Id = t.Tender_Status_Id,
                                  Tender_Title = t.Tender_Title,
                                  TermsAndConditionDocPath = t.TermsAndConditionDocPath

                              }
                              ).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }


}
