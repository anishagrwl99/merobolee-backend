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
        /// Gets the supplier registered tenders.
        /// </summary>
        /// <param name="supplierCompanyId">The supplier company identifier.</param>
        /// <returns></returns>
        Task<List<TenderEntity>> GetSupplierRegisteredTenders(long supplierCompanyId);


        /// <summary>
        /// Gets the supplier won tenders.
        /// </summary>
        /// <param name="supplierCompanyId">The supplier company identifier.</param>
        /// <returns></returns>
        Task<List<TenderEntity>> GetSupplierWonTenders(long supplierCompanyId);


        /// <summary>
        /// Gets the inviter tender submissions.
        /// </summary>
        /// <param name="inviterCompanyId">The inviter company identifier.</param>
        /// <returns></returns>
        Task<List<TenderSubmission>> GetInviterTenderSubmissions(long inviterCompanyId);
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
        /// Gets the inviter tender submissions.
        /// </summary>
        /// <param name="inviterCompanyId">The inviter company identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<List<TenderSubmission>> GetInviterTenderSubmissions(long inviterCompanyId)
        {
            try
            {
                return await meroBoleeDbContexts.TenderSubmissions
                        .Include(x => x.TenderSubmissionStatus)
                        .Where(x => x.CompanyId == inviterCompanyId)
                        .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }



        /// <summary>
        /// Gets the supplier registered tenders.
        /// </summary>
        /// <param name="supplierCompanyId">The supplier company identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<List<TenderEntity>> GetSupplierRegisteredTenders(long supplierCompanyId)
        {
            try
            {
                return await (from br in meroBoleeDbContexts.BidRequestEntities
                              join t in meroBoleeDbContexts.TenderEntities on br.TenderId equals t.Tender_Id
                              join ts in meroBoleeDbContexts.TenderStatus on t.Tender_Status_Id equals ts.StatusId
                              where br.CompanyId == supplierCompanyId
                              select new TenderEntity
                              {
                                  CompanyId = t.CompanyId,
                                  Tender_Id = t.Tender_Id,
                                  AdditionalRequest = t.AdditionalRequest,
                                  ApprovedBy = t.ApprovedBy,
                                  ApprovedByUser = t.ApprovedByUser,
                                  Cancel_remark = t.Cancel_remark,
                                  CategoryEntity = t.CategoryEntity,
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
        /// Gets the supplier won tenders.
        /// </summary>
        /// <param name="supplierCompanyId">The supplier company identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<List<TenderEntity>> GetSupplierWonTenders(long supplierCompanyId)
        {
            try
            {
                return await (from tw in meroBoleeDbContexts.TenderWinnerEntities
                        join t in meroBoleeDbContexts.TenderEntities on tw.TenderId equals t.Tender_Id
                        join ts in meroBoleeDbContexts.TenderStatus on t.Tender_Status_Id equals ts.StatusId
                        where tw.WinnerCompanyId == supplierCompanyId
                        select new TenderEntity
                        {
                            CompanyId = t.CompanyId,
                            Tender_Id = t.Tender_Id,
                            AdditionalRequest = t.AdditionalRequest,
                            ApprovedBy = t.ApprovedBy,
                            ApprovedByUser = t.ApprovedByUser,
                            Cancel_remark = t.Cancel_remark,
                            CategoryEntity = t.CategoryEntity,
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
