using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Utility;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.VendorEnlistment
{
    public class VendorEnlistmentRepository : RepositoryBase<VendorEnlistmentEntity>, IVendorEnlistmentRepository
    {

		private readonly IUnitOfWork unitOfWork;

        public VendorEnlistmentRepository(IUnitOfWork unitOfWork ,IDbFactory dbFactory) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddProcurementCategory(TenderProcurementCategoryEntity tenderProcurementCategoryEntity)
        {
            try
            {
                await meroBoleeDbContexts.TenderProcurementCategoryEntities.AddAsync(tenderProcurementCategoryEntity);
                await unitOfWork.SaveChangesAsync();
            }
            catch 
            {

                throw;
            }
        }

        public async Task AddVendorEnlistmentAnnualIncome(IEnumerable<VendorEnlistmentAnnualIncomeEntity> vendorEnlistmentAnnualIncomeEntities)
        {
            try
            {
                await meroBoleeDbContexts.VendorEnlistmentAnnualIncomeEntities.AddRangeAsync(vendorEnlistmentAnnualIncomeEntities);
                await unitOfWork.SaveChangesAsync();
            }
            catch
            {

                throw;
            }
        }

        public async Task AddBidderProcurementCategory(IEnumerable<BidderProcurementCategoryEntity> bidderProcurementCategoryEntities)
        {
            try
            {
                await meroBoleeDbContexts.BidderProcurementCategoryEntities.AddRangeAsync(bidderProcurementCategoryEntities);
                await unitOfWork.SaveChangesAsync();
            }
            catch 
            {

                throw;
            }
        }

        public async Task AddVendorEnlistmentBankInfo(IEnumerable<VendorEnlistmentBankInfoEntity> vendorEnlistmentBankInfoEntities)
        {
            try
            {
                await meroBoleeDbContexts.VendorEnlistmentBankInfoEntities.AddRangeAsync(vendorEnlistmentBankInfoEntities);
                await unitOfWork.SaveChangesAsync();
            }
            catch 
            {

                throw;
            }
        }

        public async Task AddVendorEnlistmentReferences(IEnumerable<VendorEnlistmentReferencesEntity> vendorEnlistmentReferencesEntities)
        {
            try
            {
                await meroBoleeDbContexts.VendorEnlistmentReferencesEntities.AddRangeAsync(vendorEnlistmentReferencesEntities);
                await unitOfWork.SaveChangesAsync();
            }
            catch 
            {

                throw;
            }
        }

        public async Task<IEnumerable<TenderProcurementCategoryEntity>> FetchProcurementCategory(int id)
        {
            try
            {
                return await meroBoleeDbContexts.TenderProcurementCategoryEntities.Where(x=>x.ProcurementId==id && x.IsDeleted==false).ToListAsync();
            }
            catch 
            {

                throw;
            }
        }

        public async Task<VendorEnlistmentEntity> SaveVendorEnlistment(VendorEnlistmentEntity vendorEnlistmentEntity)
        {
            try
            {
                await meroBoleeDbContexts.VendorEnlistmentEntities.AddAsync(vendorEnlistmentEntity);
                await unitOfWork.SaveChangesAsync();
                return vendorEnlistmentEntity;

            }
            catch
            {

                throw;
            }
        }

        public async Task<IEnumerable<DocumentTypeEntity>> FetchDocumentType()
        {
            try
            {
                return await meroBoleeDbContexts.DocumentTypeEntities.Where(x => x.Type == "Both" || x.Type == "Bidder").ToListAsync();
            }
            catch 
            {

                throw;
            }
        }

        public async Task AddVendorEnlistmentDocumentEntity(List<VendorEnlistmentDocumentEntity> list)
        {
            try
            {
                await meroBoleeDbContexts.VendorEnlistmentDocumentEntities.AddRangeAsync(list);
                await unitOfWork.SaveChangesAsync();
            }
            catch 
            {

                throw;
            }
        }

        public async Task<VendorEnlistmentLogEntity> SaveEnableOrDisable(VendorEnlistmentLogEntity obj)
        {
            try
            {
                await meroBoleeDbContexts.VendorEnlistmentLogEntities.AddAsync(obj);
                await unitOfWork.SaveChangesAsync();
                return obj;
            }
            catch 
            {

                throw;
            }
        }

        public async Task<VendorEnlistmentEntity> FetchVendorEnlistment(long vendorEnlistmentId)
        {
            try
            {
                return await meroBoleeDbContexts.VendorEnlistmentEntities.Include(x=>x.BidderProcurementCategories).Include(x=>x.VendorEnlistmentReference)
                    .Include(x=>x.VendorEnlistmentBankInfos).Include(x=>x.VendorEnlistmentAnnualIncomes).Include(x=>x.VendorEnlistmentDocuments)
                    .Where(x => x.Id == vendorEnlistmentId).FirstOrDefaultAsync();
            }
            catch 
            {

                throw;
            }
        }

        public async Task ChangeVendorEnlistmentEnableOrDisable(VendorEnlistmentEntity vendorEnlistmentEntity)
        {
            try
            {
                meroBoleeDbContexts.VendorEnlistmentEntities.Update(vendorEnlistmentEntity);
                await unitOfWork.SaveChangesAsync();
            }
            catch 
            {

                throw;
            }
        }

        public async Task<VendorEnlistmentEntity> FetchVendorEnlistmentByCompanyId(long companyId)
        {
            try
            {
                return await meroBoleeDbContexts.VendorEnlistmentEntities.Where(x => x.CompanyId == companyId).FirstOrDefaultAsync();
            }
            catch
            {

                throw;
            }
        }

        public async Task<VendorEnlistmentEntity> GetVendorEnlistmentByCompanyId(long companyId)
        {
            try
            {
                return await meroBoleeDbContexts.VendorEnlistmentEntities.Include(x => x.BidderProcurementCategories).Include(x => x.VendorEnlistmentReference)
                     .Include(x => x.VendorEnlistmentBankInfos).Include(x => x.VendorEnlistmentAnnualIncomes).Include(x => x.VendorEnlistmentDocuments).ThenInclude(x=>x.Document)
                     .Include(x=>x.Company).ThenInclude(x => x.Country).Where(x => x.CompanyId == companyId).FirstOrDefaultAsync();
            }
            catch 
            {

                throw;
            }
        }

        public async Task UpdateVendorEnlistment(VendorEnlistmentEntity vendorEnlistmentEntity)
        {
            try
            {
                meroBoleeDbContexts.Update(vendorEnlistmentEntity);
                await unitOfWork.SaveChangesAsync();
            }
            catch
            {

                throw;
            }
        }

        public async Task UpdateVendorEnlistmentReferences(List<VendorEnlistmentReferencesEntity> vendorEnlistmentReference)
        {
            try
            {
                meroBoleeDbContexts.UpdateRange(vendorEnlistmentReference);
                await unitOfWork.SaveChangesAsync();
            }
            catch 
            {

                throw;
            }
        }

        public async Task UpdateVendorEnlistmentAnnaulIncome(List<VendorEnlistmentAnnualIncomeEntity> vendorEnlistmenAnnualIncomeEntities)
        {
            try
            {
                meroBoleeDbContexts.VendorEnlistmentAnnualIncomeEntities.UpdateRange(vendorEnlistmenAnnualIncomeEntities);
                await unitOfWork.SaveChangesAsync();
            }
            catch 
            {

                throw;
            }
        }

        public async Task UpdateVendorEnlistmentBankInfo(List<VendorEnlistmentBankInfoEntity> vendorEnlistmentBankInfoEntities)
        {
            try
            {
                meroBoleeDbContexts.VendorEnlistmentBankInfoEntities.UpdateRange(vendorEnlistmentBankInfoEntities);
                await unitOfWork.SaveChangesAsync();
            }
            catch 
            {

                throw;
            }
        }

        public async Task UpdateBidderProcurementCategory(List<BidderProcurementCategoryEntity> bidderProcuremntCategoryEntities)
        {
            try
            {
                meroBoleeDbContexts.BidderProcurementCategoryEntities.UpdateRange(bidderProcuremntCategoryEntities);
                await unitOfWork.SaveChangesAsync();
            }
            catch 
            {

                throw;
            }
        }

        public async Task<VendorEnlistmentDocumentEntity> GetVendorEnlistmentDocumentById(long documentId)
        {
            try
            {
                return await meroBoleeDbContexts.VendorEnlistmentDocumentEntities.Where(x => x.Id == documentId).FirstOrDefaultAsync();
            }
            catch 
            {

                throw;
            }
        }

        public async Task UpdateSingleVendorEnlistmentDocument(VendorEnlistmentDocumentEntity documententity)
        {
            try
            {
                meroBoleeDbContexts.VendorEnlistmentDocumentEntities.Update(documententity);
                await unitOfWork.SaveChangesAsync();
            }
            catch 
            {

                throw;
            }
        }

        public async Task<IEnumerable<VendorEnlistmentDocumentEntity>> GetVendorEnlistmentDocument(long vendorEnlistmentId)
        {
            try
            {
                return await meroBoleeDbContexts.VendorEnlistmentDocumentEntities.Include(x => x.Document).Where(x => x.VendorEnlistmentId == vendorEnlistmentId && x.IsDeleted == false).ToListAsync();
                
            }
            catch 
            {

                throw;
            }
        }

        public async Task<TenderProcurementCategoryEntity> FetchProcurementCategoryById(long id)
        {
            try
            {
                return await meroBoleeDbContexts.TenderProcurementCategoryEntities.Where(x=>x.Id==id).FirstOrDefaultAsync();
            }
            catch 
            {

                throw;
            }
        }

        public async Task UpdateProcurementCategory(TenderProcurementCategoryEntity procurementCategoryEntity)
        {
            try
            {
                meroBoleeDbContexts.TenderProcurementCategoryEntities.Update(procurementCategoryEntity);
                await unitOfWork.SaveChangesAsync();
            }
            catch 
            {

                throw;
            }
        }
    }
}
