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
        Task<List<CommunityApprovalEntity>> GetInviterTenderSubmissions(long inviterCompanyId);
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
        public async Task<List<CommunityApprovalEntity>> GetInviterTenderSubmissions(long inviterCompanyId)
        {
            try
            {
                DateTime fromDate = DateTime.Now.AddYears(-1);
                return await meroBoleeDbContexts.CommunityApprovalEntities.Include(x => x.TenderEntities)
                       .ThenInclude(y => y.CategoryEntity)
                       .Where(x => x.CompanyId == inviterCompanyId && x.Date_Created >= fromDate && x.Date_Created <= DateTime.Now)
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
                              join t in meroBoleeDbContexts.TenderEntities on br.TenderId equals t.Id
                              join ts in meroBoleeDbContexts.TenderStatus on t.StatusId equals ts.StatusId
                              join c in meroBoleeDbContexts.TenderProcurementCategoryEntities on t.ProcurementCategoryId equals c.Id
                              where br.CompanyId == supplierCompanyId && t.Date_created >= fromDate && t.Date_created <= DateTime.Now
                              select new TenderEntity
                              {
                                  CompanyId = br.CompanyId,
                                  Id = t.Id,
                                  AdditionalRequest = t.AdditionalRequest,
                                  ApprovedBy = t.ApprovedBy,
                                  ApprovedByUser = t.ApprovedByUser,
                                  CancelRemarks = t.CancelRemarks,
                                  CategoryEntity = c,
                                  ProcurementCategoryId=t.ProcurementCategoryId,
                                  Company = t.Company,
                                  CreatedBy = t.CreatedBy,
                                  CreatedByUser = t.CreatedByUser,
                                  Date_created = t.Date_created,
                                  Date_modified = t.Date_modified,
                                  EligibilityCriteria = t.EligibilityCriteria,
                                  ExtraDocuments = t.ExtraDocuments,
                                  Feedbacks = t.Feedbacks,
                                  LiveEndDate = t.LiveEndDate,
                                  LiveStartDate = t.LiveStartDate,
                                  Location = t.Location,
                                  MaxQuotation = t.MaxQuotation,
                                  PerformanceRequest = t.PerformanceRequest,
                                  Price = t.Price,
                                  QualityRequest = t.QualityRequest,
                                  RegistrationTill = t.RegistrationTill,
                                  //TenderCards = t.TenderCards,
                                  TenderDetailDocPath = t.TenderDetailDocPath,
                                  TenderDetailDocTitle = t.TenderDetailDocTitle,
                                  TenderMaterialEntities = t.TenderMaterialEntities,
                                  TenderStatusEntity = ts,
                                  TenderTermsConditionEntities = t.TenderTermsConditionEntities,
                                  Code = t.Code,
                                  LiveInterval = t.LiveInterval,
                                  StatusId = t.StatusId,
                                  Title = t.Title,
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
                              join t in meroBoleeDbContexts.TenderEntities on tw.TenderId equals t.Id
                              join ts in meroBoleeDbContexts.TenderStatus on t.StatusId equals ts.StatusId
                              join c in meroBoleeDbContexts.TenderProcurementCategoryEntities on t.ProcurementCategoryId equals c.Id
                              where tw.CompanyId == supplierCompanyId && t.Date_created >= fromDate && t.Date_created <= DateTime.Now
                              select new TenderEntity
                              {
                                  CompanyId = tw.CompanyId,
                                  Id = t.Id,
                                  AdditionalRequest = t.AdditionalRequest,
                                  ApprovedBy = t.ApprovedBy,
                                  ApprovedByUser = t.ApprovedByUser,
                                  CancelRemarks = t.CancelRemarks,
                                  CategoryEntity = c,
                                  ProcurementCategoryId = t.ProcurementCategoryId,
                                  Company = t.Company,
                                  CreatedBy = t.CreatedBy,
                                  CreatedByUser = t.CreatedByUser,
                                  Date_created = t.Date_created,
                                  Date_modified = t.Date_modified,
                                  EligibilityCriteria = t.EligibilityCriteria,
                                  ExtraDocuments = t.ExtraDocuments,
                                  Feedbacks = t.Feedbacks,
                                  LiveEndDate = t.LiveEndDate,
                                  LiveStartDate = t.LiveStartDate,
                                  Location = t.Location,
                                  MaxQuotation = t.MaxQuotation,
                                  PerformanceRequest = t.PerformanceRequest,
                                  Price = t.Price,
                                  QualityRequest = t.QualityRequest,
                                  RegistrationTill = t.RegistrationTill,
                                  //TenderCards = t.TenderCards,
                                  TenderDetailDocPath = t.TenderDetailDocPath,
                                  TenderDetailDocTitle = t.TenderDetailDocTitle,
                                  TenderMaterialEntities = t.TenderMaterialEntities,
                                  TenderStatusEntity = ts,
                                  TenderTermsConditionEntities = t.TenderTermsConditionEntities,
                                  Code = t.Code,
                                  LiveInterval = t.LiveInterval,
                                  StatusId = t.StatusId,
                                  Title = t.Title,
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
