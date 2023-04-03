using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Repository.VendorEnlistment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.VendorEnlistment
{
    public class VendorEnlistmentService: VendorEnlistmentMapper,IVendorEnlistmentService
    {
        private readonly IVendorEnlistmentRepository vendorEnlistmentRepository;
        private IUploadFile docUpload;


        public VendorEnlistmentService(IVendorEnlistmentRepository vendorEnlistmentRepository, IUploadFile uploadFileService) { 
            this.vendorEnlistmentRepository = vendorEnlistmentRepository;
            docUpload = uploadFileService;

        }

        public async Task<bool> AddProcurementCategory(ProcurementCategoryDto procurementCategoryDto)
        {
            try
            {
                var entity = new TenderProcurementCategoryEntity();
                entity.ProcurementId = procurementCategoryDto.ProcurementId;
                entity.Title = procurementCategoryDto.Title;
                await vendorEnlistmentRepository.AddProcurementCategory(entity);
                return true;
            }
            catch 
            {

                throw;
            }
        }

        public async Task<VendorEnlistmentAddDto> AddVendorEnlistment(VendorEnlistmentAddDto vendorEnlistmentDto)
        {
            try
            {
                if (vendorEnlistmentDto.CompanyId != 0)
                {
                    var check = await vendorEnlistmentRepository.FetchVendorEnlistmentByCompanyId(vendorEnlistmentDto.CompanyId);
                    if (check != null)
                    {
                        return null;
                    }
                    else
                    {
                        var vendorEnlistmentEntity = VendorEnlistmentDtoEntity(vendorEnlistmentDto);
                        vendorEnlistmentEntity = await vendorEnlistmentRepository.SaveVendorEnlistment(vendorEnlistmentEntity);

                        if (vendorEnlistmentDto.BidderProcurementCategoryIds != null)
                        {
                            var bidderProcurementCategoryEntities =
                                BidderProcurementCategoryDtoEntity(vendorEnlistmentEntity.Id,
                                    vendorEnlistmentDto.BidderProcurementCategoryIds);
                            await vendorEnlistmentRepository.AddBidderProcurementCategory(
                                bidderProcurementCategoryEntities);
                        }

                        if (vendorEnlistmentDto.VendorEnlistmentReferencesDtos != null)
                        {

                            var vendorEnlistmentReferencesEntities =
                                VendorEnlistmentReferencesDtoEntity(vendorEnlistmentEntity.Id,
                                    vendorEnlistmentDto.VendorEnlistmentReferencesDtos);
                            await vendorEnlistmentRepository.AddVendorEnlistmentReferences(
                                vendorEnlistmentReferencesEntities);
                        }

                        if (vendorEnlistmentDto.VendorEnlistmentAnnualIncomeDtos != null)
                        {

                            var vendorEnlistmentAnnualIncomeEntities =
                                VendorEnlistmentAnnualIncomeDtoEntity(vendorEnlistmentEntity.Id,
                                    vendorEnlistmentDto.VendorEnlistmentAnnualIncomeDtos);
                            await vendorEnlistmentRepository.AddVendorEnlistmentAnnualIncome(
                                vendorEnlistmentAnnualIncomeEntities);
                        }

                        if (vendorEnlistmentDto.VendorEnlistmentBankInfoDtos != null)
                        {

                            var vendorEnlistmentBankInfoEntities =
                                VendorEnlistmentBankInfoDtoEntity(vendorEnlistmentEntity.Id,
                                    vendorEnlistmentDto.VendorEnlistmentBankInfoDtos);
                            await vendorEnlistmentRepository.AddVendorEnlistmentBankInfo(
                                vendorEnlistmentBankInfoEntities);
                        }

                        var list = new List<VendorEnlistmentDocumentEntity>();

                        if (vendorEnlistmentDto.VendorEnlistmentDocumentDtos != null)
                        {

                            foreach (var item in vendorEnlistmentDto.VendorEnlistmentDocumentDtos)
                            {
                                var entity = new VendorEnlistmentDocumentEntity();
                                if (item.Document != null && item.Document.Length > 0)
                                {
                                    entity.DocumentPath = await docUpload.Upload(item.Document,
                                        vendorEnlistmentDto.CompanyId.ToString());
                                    entity.DocumentTypeId = item.DocumentTypeId;
                                    entity.VendorEnlistmentId = vendorEnlistmentEntity.Id;
                                    list.Add(entity);
                                }
                            }
                        }

                        await vendorEnlistmentRepository.AddVendorEnlistmentDocumentEntity(list);

                        return vendorEnlistmentDto;
                    }
                }
                else
                {
                    return vendorEnlistmentDto;
                }
            }
            catch 
            {
                throw;
            }
        }

        public async Task<IEnumerable<VendorEnlistmentDocumentDto>> DeleteDocument(long documentId,string baseUrl)
        {
            try
            {
                var documententity = await vendorEnlistmentRepository.GetVendorEnlistmentDocumentById(documentId);
                var exists = await docUpload.FileExists(documententity.DocumentPath);
                if (exists)
                {
                    await docUpload.DeleteFile(documententity.DocumentPath);
                    documententity.IsDeleted = true;

                    await vendorEnlistmentRepository.UpdateSingleVendorEnlistmentDocument(documententity);

                    var documentEntities = await vendorEnlistmentRepository.GetVendorEnlistmentDocument(documententity.VendorEnlistmentId);

                    if (documentEntities.Count()==0)
                    {
                        return null;
                    }
                    else
                    {
                        var list = new List<VendorEnlistmentDocumentDto>();

                        foreach (var item in documentEntities)
                        {
                            var obj = new VendorEnlistmentDocumentDto
                            {
                                Id = item.Id,
                                DocumentTypeId = item.DocumentTypeId,
                                DocumentPath = String.IsNullOrEmpty(item.DocumentPath) ? "" : $"{baseUrl}{item.DocumentPath.Replace('\\', '/')}",
                                Name = item.Document.TypeName
                            };
                            list.Add(obj);
                        }
                        return list;
                    }
                   
                }
                else
                {
                    return null;
                }
            }
            catch 
            {

                throw;
            }
        }

        public async Task<IEnumerable<DocumentTypeEntity>> GetDocumentType()
        {
            try
            {
                return await vendorEnlistmentRepository.FetchDocumentType();
            }
            catch 
            {

                throw;
            }
        }

        public async Task<IEnumerable<TenderProcurementCategoryEntity>> GetProcurementCategory(string id)
        {
            try
            {
                var tenderProcurementCategoryEntityList = new List<TenderProcurementCategoryEntity>();

                var numbers = id?.Split(',')?.Select(Int32.Parse)?.ToList();
                foreach (var item in numbers)
                {
                    var result= await vendorEnlistmentRepository.FetchProcurementCategory(item);
                    tenderProcurementCategoryEntityList.AddRange(result);
                }
                return tenderProcurementCategoryEntityList;
            }
            catch 
            {

                throw;
            }
        }

        public async Task<VendorEnlistmentDetail> GetVendorEnlistmentDetail(long companyId,string baseUrl)
        {
            try
            {
                var vendorEnlistment = await vendorEnlistmentRepository.GetVendorEnlistmentByCompanyId(companyId);
                if (vendorEnlistment == null)
                {
                    return null;
                }
                else
                {

                    var result = VendorEnlistmentEntitytoDto(vendorEnlistment);

                    result.VendorEnlistmentReferencesDtos = VendorEnlistmentReferencesEntitytoDto(vendorEnlistment.VendorEnlistmentReference);

                    result.VendorEnlistmentAnnualIncomeDtos = VendorEnlistmentAnnualIncomeEntityToDto(vendorEnlistment.VendorEnlistmentAnnualIncomes);

                    result.VendorEnlistmentBankInfoDtos = VendorEnlistmentBankInfoEntityToDto(vendorEnlistment.VendorEnlistmentBankInfos);

                    result.BidderProcurementCategoryIds = BidderProcurementCategoryEntityToDto(vendorEnlistment.BidderProcurementCategories);

                    result.VendorEnlistmentDocumentDtos = VendorEnlistmentDocumentEntityToDto(vendorEnlistment.VendorEnlistmentDocuments, baseUrl);

                    return result;
                }
            }
            catch
            {

                throw;
            }
        }

        public async Task<VendorEnlistmentLogEntity> SetEnableOrDisable(VendorListEnableOrDisableDto vendorListEnableOrDisableDto)
        {
            try
            {
                var vendorEnlistmentEntity = await vendorEnlistmentRepository.FetchVendorEnlistment(vendorListEnableOrDisableDto.VendorEnlistmentId);
                if (vendorEnlistmentEntity == null)
                {
                    return null;
                }
                else
                {
                    vendorEnlistmentEntity.IsEnable = vendorListEnableOrDisableDto.Enable;
                    await vendorEnlistmentRepository.ChangeVendorEnlistmentEnableOrDisable(vendorEnlistmentEntity);

                    var obj = new VendorEnlistmentLogEntity()
                    {
                        IsEnabled = vendorListEnableOrDisableDto.Enable,
                        CreatedDate = DateTimeNPT.Now,
                        VendorEnlistmentId = vendorListEnableOrDisableDto.VendorEnlistmentId
                    };

                    return await vendorEnlistmentRepository.SaveEnableOrDisable(obj);
                }
            }
            catch 
            {

                throw;
            }
        }

        public async Task<VendorEnlistmentAddDto> UpdateVendorEnlistment(VendorEnlistmentAddDto vendorEnlistmentDto)
        {
            try
            {
                var vendorEnlistment = await vendorEnlistmentRepository.GetVendorEnlistmentByCompanyId(vendorEnlistmentDto.CompanyId);

                var vendorEnlistmentEntity = UpdateVendorEnlistmentEntity(vendorEnlistment, vendorEnlistmentDto);

                var vendorEnlistmentReferencesEntities = UpdateVendorEnlistmentReferenceEntity(vendorEnlistment.VendorEnlistmentReference, vendorEnlistmentDto.VendorEnlistmentReferencesDtos);

                var vendorEnlistmenAnnualIncomeEntities= UpdateVendorEnlistmentAnnualIncomeEntity(vendorEnlistment.VendorEnlistmentAnnualIncomes, vendorEnlistmentDto.VendorEnlistmentAnnualIncomeDtos);

                var vendorEnlistmentBankInfoEntities= UpdateVendorEnlistmentBankInfoEntity(vendorEnlistment.VendorEnlistmentBankInfos, vendorEnlistmentDto.VendorEnlistmentBankInfoDtos);

                var bidderProcuremntCategoryEntities= UpdateBidderProcurementCategoryEntity(vendorEnlistment.BidderProcurementCategories, vendorEnlistmentDto.BidderProcurementCategoryIds,vendorEnlistment.Id);
                
                var list = new List<VendorEnlistmentDocumentEntity>();

                if (vendorEnlistmentDto.VendorEnlistmentDocumentDtos != null)
                {
                    foreach (var item in vendorEnlistmentDto.VendorEnlistmentDocumentDtos)
                    {
                        var obj = new VendorEnlistmentDocumentEntity
                        {
                            DocumentPath = await docUpload.Upload(item.Document, vendorEnlistmentDto.CompanyId.ToString()),
                            DocumentTypeId = item.DocumentTypeId,
                            VendorEnlistmentId = vendorEnlistment.Id,
                        };
                        list.Add(obj);
                    }
                }

                await vendorEnlistmentRepository.UpdateVendorEnlistment(vendorEnlistmentEntity);
                await vendorEnlistmentRepository.UpdateVendorEnlistmentReferences(vendorEnlistmentReferencesEntities);
                await vendorEnlistmentRepository.UpdateVendorEnlistmentAnnaulIncome(vendorEnlistmenAnnualIncomeEntities);
                await vendorEnlistmentRepository.UpdateVendorEnlistmentBankInfo(vendorEnlistmentBankInfoEntities);
                await vendorEnlistmentRepository.UpdateBidderProcurementCategory(bidderProcuremntCategoryEntities);
                if(list.Count != 0) 
                {
                    await vendorEnlistmentRepository.AddVendorEnlistmentDocumentEntity(list);
                }

                return vendorEnlistmentDto;
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> DeleteProcurementCategory(long id)
        {
            try
            {
                var procurementCategoryEntity= await vendorEnlistmentRepository.FetchProcurementCategoryById(id);
                if (procurementCategoryEntity!=null)
                {
                    procurementCategoryEntity.IsDeleted = true;
                    await vendorEnlistmentRepository.UpdateProcurementCategory(procurementCategoryEntity);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {

                throw;
            }
        }
    }
}
