using MeroBolee.Dto;
using MeroBolee.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeroBolee.Repository.VendorEnlistment
{
    public interface IVendorEnlistmentRepository
    {
        Task AddBidderProcurementCategory(IEnumerable<BidderProcurementCategoryEntity> bidderProcurementCategoryEntities);
        Task AddProcurementCategory(TenderProcurementCategoryEntity tenderProcurementCategoryEntity);
        Task AddVendorEnlistmentAnnualIncome(IEnumerable<VendorEnlistmentAnnualIncomeEntity> vendorEnlistmentAnnualIncomeEntities);
        Task AddVendorEnlistmentBankInfo(IEnumerable<VendorEnlistmentBankInfoEntity> vendorEnlistmentBankInfoEntities);
        Task AddVendorEnlistmentDocumentEntity(List<VendorEnlistmentDocumentEntity> list);
        Task AddVendorEnlistmentReferences(IEnumerable<VendorEnlistmentReferencesEntity> vendorEnlistmentReferencesEntities);
        Task ChangeVendorEnlistmentEnableOrDisable(VendorEnlistmentEntity vendorEnlistmentEntity);
        Task<IEnumerable<DocumentTypeEntity>> FetchDocumentType();
        Task<IEnumerable<TenderProcurementCategoryEntity>> FetchProcurementCategory(int id);
        Task<TenderProcurementCategoryEntity> FetchProcurementCategoryById(long id);
        Task<VendorEnlistmentEntity> FetchVendorEnlistment(long vendorEnlistmentId);
        Task<VendorEnlistmentEntity> FetchVendorEnlistmentByCompanyId(long companyId);
        Task<VendorEnlistmentEntity> GetVendorEnlistmentByCompanyId(long companyId);
        Task<IEnumerable<VendorEnlistmentDocumentEntity>> GetVendorEnlistmentDocument(long vendorEnlistmentId);
        Task<VendorEnlistmentDocumentEntity> GetVendorEnlistmentDocumentById(long documentId);
        Task<VendorEnlistmentLogEntity> SaveEnableOrDisable(VendorEnlistmentLogEntity obj);
        Task<VendorEnlistmentEntity> SaveVendorEnlistment(VendorEnlistmentEntity vendorEnlistmentEntity);
        Task UpdateBidderProcurementCategory(List<BidderProcurementCategoryEntity> bidderProcuremntCategoryEntities);
        Task UpdateProcurementCategory(TenderProcurementCategoryEntity procurementCategoryEntity);
        Task UpdateSingleVendorEnlistmentDocument(VendorEnlistmentDocumentEntity documententity);
        Task UpdateVendorEnlistment(VendorEnlistmentEntity vendorEnlistmentEntity);
        Task UpdateVendorEnlistmentAnnaulIncome(List<VendorEnlistmentAnnualIncomeEntity> vendorEnlistmenAnnualIncomeEntities);
        Task UpdateVendorEnlistmentBankInfo(List<VendorEnlistmentBankInfoEntity> vendorEnlistmentBankInfoEntities);
        Task UpdateVendorEnlistmentReferences(List<VendorEnlistmentReferencesEntity> vendorEnlistmentReference);
    }
}
