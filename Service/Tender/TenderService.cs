using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public class TenderService: TenderMapper, ITenderService
    {
        private readonly ITenderRepository tenderRepository;
        private readonly IReferenceCodeService referenceCodeService;
        private readonly IUploadFile uploadFileService;
        private readonly ICompanyDocumentRepository docRepo;

        public TenderService(ITenderRepository tenderRepository, 
                                IReferenceCodeService referenceCodeService, 
                                IUploadFile uploadFileService, 
                                ICompanyDocumentRepository docRepo)
        {
            this.tenderRepository = tenderRepository;
            this.referenceCodeService = referenceCodeService;
            this.uploadFileService = uploadFileService;
            this.docRepo = docRepo;
        }

        public async Task<TenderEntity> AddTender(AddTenderRequestDto tenderDto)
        {
            TenderEntity entity = TenderDtoEntity(tenderDto);
            
            entity.Tender_Code = referenceCodeService.GenerateCode(ReferenceEnum.Tender).Result;
            entity = tenderRepository.AddTender(entity);
            string companyFolder = docRepo.GetCompanyFolder(tenderDto.CompanyId);
            string docPath = companyFolder + $"\\Tender\\{entity.Tender_Id}";

            if (tenderDto.TenderDetailDoc != null)
            {
                entity.TenderDetailDocPath = await uploadFileService.Upload(tenderDto.TenderDetailDoc, docPath);
            }

            if (tenderDto.TenderTermsAndConditionDoc != null)
            {
                entity.TermsAndConditionDocPath = await uploadFileService.Upload(tenderDto.TenderTermsAndConditionDoc, docPath);
            }

            entity.ExtraDocuments = new List<TenderExtraDocumentEntity>();
            
            foreach (var item in tenderDto.ExtraDocuments)
            {
                if (item.Document != null)
                {
                    TenderExtraDocumentEntity obj = new TenderExtraDocumentEntity
                    {
                        CompanyId = tenderDto.CompanyId,
                        UserId = tenderDto.CreatedBy,
                        TenderId = entity.Tender_Id,
                        DocTitle = item.DocTitle,
                        DocPath = await uploadFileService.Upload(item.Document, docPath)
                    };
                    entity.ExtraDocuments.Add(obj);
                }
                }

                await tenderRepository.UpdateTender(entity);

            return entity;
        }

        public IEnumerable<TenderCard> GetMarketplaceTender(string search)
        {
            return tenderRepository.GetMarketplaceTender(search);
        }


        public IEnumerable<TenderCard> GetBidIniviterTenderHistory(long companyId, string search)
        {
            return tenderRepository.GetBidIniviterTenderHistory(companyId, search);
        }

        public BidInviterTenderListing GetBidInviterTenderListing(long companyId, string search)
        {
            IEnumerable<TenderCard> tenders =  tenderRepository.GetBidIniviterTenderListing(companyId, search);
            BidInviterTenderListing listing = new BidInviterTenderListing
            {
                PendingTenders = tenders.Where(x => x.StatusId == 1 || x.StatusId == 2).ToList(),
                ActiveTenders = tenders.Where(x=>x.StatusId == 3 && x.LiveEndDate < DateTime.Now).ToList()               
            };
            return listing;
        }


        public GetTenderDto GetTenderDetail(long tenderId, string baseUrl)
        {
            return TenderEntityToDto(tenderRepository.GetTenderDetail(tenderId), baseUrl);
        }

        public IEnumerable<TenderCard> UpcomingTender(string search)
        {
            return tenderRepository.UpcomingTender(search);
        }

        public async Task<TenderEntity> UpdateTender(UpdateTenderRequestDto tenderDto)
        {
            TenderEntity entity = tenderRepository.GetTenderDetail(tenderDto.TenderId);
            string companyFolder = docRepo.GetCompanyFolder(tenderDto.CompanyId);
            string docPath = companyFolder + $"\\Tender\\{entity.Tender_Id}";

            if(tenderDto.TenderDetailDoc != null)
            {
                await uploadFileService.DeleteFile(entity.TenderDetailDocPath);
                entity.TenderDetailDocPath = await uploadFileService.Upload(tenderDto.TenderDetailDoc, docPath);
                entity.TenderDetailDocTitle = tenderDto.TenderDocTitle;
            }

            if(tenderDto.TenderTermsAndConditionDoc != null)
            {
                await uploadFileService.DeleteFile(entity.TermsAndConditionDocPath);
                entity.TermsAndConditionDocPath = await uploadFileService.Upload(tenderDto.TenderTermsAndConditionDoc, docPath);
            }

            
            foreach (var item in tenderDto.ExtraDocuments)
            {
                var itm = entity.ExtraDocuments.Where(x => x.Id == item.Id).FirstOrDefault();
                if (itm == null && item.Document != null)
                {
                    TenderExtraDocumentEntity obj = new TenderExtraDocumentEntity
                    {
                        CompanyId = tenderDto.CompanyId,
                        UserId = tenderDto.CreatedBy,
                        TenderId = entity.Tender_Id,
                        DocTitle = item.DocTitle,
                        DocPath = await uploadFileService.Upload(item.Document, docPath)
                    };
                    entity.ExtraDocuments.Add(obj);
                }
                else 
                {
                    if(item.Document != null)
                    {
                        await uploadFileService.DeleteFile(itm.DocPath);
                        itm.DocPath = await uploadFileService.Upload(item.Document, docPath);
                    }                   
                    itm.DocTitle = item.DocTitle;                   
                }
            }
            
            UpdateTenderEntity(ref entity, tenderDto);
            await tenderRepository.UpdateTender(entity);
            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenderCode"></param>
        /// <returns><see cref="Tuple{T1, T2}"/></returns>
        public Tuple<long, long> GetTenderIdFromCode(string tenderCode)
        {
            return tenderRepository.GetTenderIdFromCode(tenderCode);
        }


        public Tuple<long, long> GetTenderWinnerIdFromCode(string tenderCode)
        {
            return tenderRepository.GetTenderWinnerIdFromCode(tenderCode);
        }

        public void EndTenderAuction(long tenderId)
        {
            try
            {
                Task.Run(() =>
                {
                    tenderRepository.EndTenderAuction(tenderId);
                });
              
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TenderApproveDto ApproveTenderByBidInviter(TenderApproveDto dto)
        {
            try
            {
                TenderEntity t = tenderRepository.GetTenderDetail(dto.TenderId);
                t.Tender_Status_Id = 2;//Approved
                t.Date_modified = DateTime.Now;
                t.ApprovedBy = dto.UserId;
                tenderRepository.ApproveTenderByBidInviter(t);
                return dto;
            }
            catch
            {

                throw;
            }
        }

    }
}
