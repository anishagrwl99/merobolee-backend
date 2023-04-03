using MeroBolee.Dto;
using MeroBolee.Model;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeroBolee.Service.VendorEnlistment
{
    public interface IVendorEnlistmentService
    {
        Task<bool> AddProcurementCategory(ProcurementCategoryDto procurementCategoryDto);
        Task<VendorEnlistmentAddDto> AddVendorEnlistment(VendorEnlistmentAddDto vendorEnlistmentDto);
        Task<IEnumerable<VendorEnlistmentDocumentDto>> DeleteDocument(long documentId, string baseUrl);
        Task<IEnumerable<DocumentTypeEntity>> GetDocumentType();
        Task<IEnumerable<TenderProcurementCategoryEntity>> GetProcurementCategory(string id);
        Task<bool> DeleteProcurementCategory(long id);
        Task<VendorEnlistmentDetail> GetVendorEnlistmentDetail(long companyId,string baseUrl);
        Task<VendorEnlistmentLogEntity> SetEnableOrDisable(VendorListEnableOrDisableDto vendorListEnableOrDisableDto);
        Task<VendorEnlistmentAddDto> UpdateVendorEnlistment(VendorEnlistmentAddDto vendorEnlistmentDto);
    }
}
