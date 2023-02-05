using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Repository;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public class TenderService : TenderMapper, ITenderService
    {
        private readonly ITenderRepository tenderRepository;
        private readonly IMemoryCache cache;
        private readonly IReferenceCodeService referenceCodeService;
        private readonly IUploadFile uploadFileService;
        private readonly ICompanyDocumentRepository docRepo;

        public TenderService(ITenderRepository tenderRepository,
                                IMemoryCache cache,
                                IReferenceCodeService referenceCodeService,
                                IUploadFile uploadFileService,
                                ICompanyDocumentRepository docRepo)
        {
            this.tenderRepository = tenderRepository;
            this.cache = cache;
            this.referenceCodeService = referenceCodeService;
            this.uploadFileService = uploadFileService;
            this.docRepo = docRepo;
        }

        public async Task<TenderEntity> AddTender(AddTenderRequestDto tenderDto)
        {
            TenderEntity entity = TenderDtoEntity(tenderDto);
            entity = tenderRepository.AddTender(entity);

            List<CommunityApprovalEntity> community = CommunityDtoEntity(entity.Id,tenderDto);
            tenderRepository.AddCommunityApproval(community);

            //foreach (var item in tenderDto.companyIds)
            //{
            //    var tenderSubmissionEntity = tenderRepository.FindTenderSubmissionEntity(item);

            //    if(tenderSubmissionEntity!=null)
            //    {
            //        tenderSubmissionEntity.StatusId = 4;
            //        tenderRepository.UpdateTenderSubmissionStatus(tenderSubmissionEntity);
            //    }
            //}

            string companyFolder = docRepo.GetCompanyFolder(tenderDto.superId);
            string docPath = companyFolder + $"\\Tender\\{entity.Id}";

            if (tenderDto.TenderDetailDoc != null)
            {
                entity.TenderDetailDocPath = await uploadFileService.Upload(tenderDto.TenderDetailDoc, docPath);
            }

            if (tenderDto.TenderTermsAndConditionDoc != null)
            {
                entity.TermsAndConditionDocPath = await uploadFileService.Upload(tenderDto.TenderTermsAndConditionDoc, docPath);
            }

            List<TenderExtraDocumentEntity> documentEntities = new List<TenderExtraDocumentEntity>();

            if (tenderDto.ExtraDocuments != null)
            {
                foreach (var item in tenderDto.ExtraDocuments)
                {
                    if (item.Document != null)
                    {
                        TenderExtraDocumentEntity obj = new TenderExtraDocumentEntity
                        {
                            CompanyId = tenderDto.superId,
                            UserId = tenderDto.CreatedBy,
                            DocTitle = item.DocTitle,
                            TenderId = entity.Id,
                            IsDeleted= false,
                            DocPath = await uploadFileService.Upload(item.Document, docPath)
                        };
                        documentEntities.Add(obj);
                    }
                }
                await tenderRepository.AddTenderDocuments(documentEntities);

            }
            entity.Code = await referenceCodeService.GenerateCode(ReferenceEnum.Tender) + entity.Id.ToString("D3");
            await tenderRepository.UpdateTender(entity);

            return entity;
        }

        public Task<IEnumerable<TenderCard>> GetMarketplaceTender(string search)
        {
            return tenderRepository.GetMarketplaceTender(search);
        }
        public Task<IEnumerable<TenderCard>> GetLiveBidMarketplaceTenderForAdmin(string search)
        {
            return tenderRepository.GetLiveBidMarketplaceTenderForAdmin(search);
        }

        public async Task<IEnumerable<TenderCard>> GetBidIniviterTenderHistory(long companyId, string search)
        {
            return await tenderRepository.GetBidIniviterTenderHistory(companyId, search);
        }

        public async Task<BidInviterTenderListing> GetBidInviterTenderListing(long companyId)
        {
            IEnumerable<TenderCard> tenders = await tenderRepository.GetBidIniviterTenderListing(companyId);
            BidInviterTenderListing listing = new BidInviterTenderListing
            {
                PendingTenders = tenders.Where(x => x.StatusId == 1 || x.StatusId == 2).ToList(),
                ActiveTenders = tenders.Where(x => x.StatusId == 3 && x.LiveEndDate > DateTime.Now).ToList()
            };
            return listing;
        }


        public async Task<GetTenderDto> GetTenderDetail(long tenderId, string baseUrl, bool isRegistered, string userRole)
        {
            TenderEntity te = await tenderRepository.GetTenderDetail(tenderId);
            if (te != null)
            {
                var result= TenderEntityToDto(te, baseUrl, isRegistered, userRole);
                if (userRole != "Bidder")
                {
                    result.RegisteredCompanyIds = tenderRepository.GetBidInviterCompanyList(tenderId);

                }
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<TenderEntity> CommunityApproval(TenderApproveDtoByAdmin tenderApprove)
        {
            try
            {
                TenderEntity te = await tenderRepository.FindTenderToUpdate(tenderApprove.TenderId);
                if (te != null)
                {
                    if (tenderApprove.status == true)
                    {
                        te.StatusId = 3;
                        te.ApprovedBy = tenderApprove.UserId;
                        te.Date_modified = DateTimeNPT.Now;
                    } 
                    else if (tenderApprove.status == false)
                    {
                        te.StatusId = 6;
                        te.Date_modified = DateTimeNPT.Now;
                    }

                    await tenderRepository.UpdateTenderStatus(te);
                    return te;
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<CommunityApprovalDto>> CommunityApprovalList(long tenderId)
        {
            try
            {
                IEnumerable<CommunityApprovalDto> communityApprovalDto = await tenderRepository.FindCommunityApprovalEntityByTenderId(tenderId);
                List<CommunityApprovalDto> communityApprovalDtoUpdated = new List<CommunityApprovalDto>();
                foreach (var item in communityApprovalDto)
                {
                    if(item.StatusId == 2)
                    {
                        string remark = await tenderRepository.FetchFeedback(tenderId, item.CompanyId);
                        item.Remarks = remark;
                    }
                    communityApprovalDtoUpdated.Add(item);
                }
                return communityApprovalDtoUpdated;

            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<PostBidApprovalListDto>> GetPostBidApprovalList(long tenderId)
        {
            try
            {
                    IEnumerable<PostBidApprovalListDto> postBidddingApprovalEntity = await tenderRepository.FetchPostBidApprovalList(tenderId);
                    return postBidddingApprovalEntity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TenderDocuments> GetTenderDocuments(long tenderId, string basePath)
        {
            TenderEntity te = await tenderRepository.GetTenderEntityOnly(tenderId);
            if (te != null)
            {
                return ToTenderDocuments(te, basePath);
            }
            else
            {
                return null;
            }
        }

        public async Task<TenderDocuments> GetTenderDocumentsForSupplier(long tenderId, long companyId, string basePath)
        {
            TenderEntity te = await tenderRepository.GetTenderEntityOnly(tenderId, companyId);
            if (te != null)
            {
                return ToTenderDocuments(te, basePath);
            }
            else
            {
                return null;
            }
        }
        public async Task<IEnumerable<TenderCard>> UpcomingBidderTender(long companyId, bool isAlert, bool isLiveBidUpcoming)
        {
            IEnumerable<TenderCard> tenderCards = await tenderRepository.UpcomingBidderTender(companyId, isAlert, isLiveBidUpcoming);

            if (isLiveBidUpcoming)
            {
                List<TenderCard> updatedTenderCard = new List<TenderCard>();
                foreach (TenderCard tenderCard in tenderCards)
                {
                    long tenderId = tenderCard.TenderId;
                    TenderEntity tenderEntity = await tenderRepository.GetTenderDetail(tenderId);
                    if (tenderEntity.AlgoName.Contains("Sealed"))
                    {
                        tenderCard.isSealBiddingAllowed = true;

                    }
                    else
                    {
                        tenderCard.isSealBiddingAllowed = false;
                        updatedTenderCard.Add(tenderCard);

                    }
                }
                return updatedTenderCard;
            } else
            {
                List<TenderCard> updatedTenderCard = new List<TenderCard>();
                foreach (TenderCard tenderCard in tenderCards)
                {
                    long tenderId = tenderCard.TenderId;
                    TenderEntity tenderEntity = await tenderRepository.GetTenderDetail(tenderId);
                    if (tenderEntity.AlgoName.Contains("Sealed"))
                    {
                        tenderCard.isSealBiddingAllowed = true;
                        updatedTenderCard.Add(tenderCard);

                    }
                    else
                    {
                        tenderCard.isSealBiddingAllowed = false;
                    }
                }
                return updatedTenderCard;
            }
        }

        public async Task<IEnumerable<TenderCard>> UpcomingBidInviterTender(long companyId)
        {
            return await tenderRepository.UpcomingBidInviterTender(companyId);
        }
        public async Task<IEnumerable<TenderCard>> UpcomingTenderForAdmin()
        {
            return await tenderRepository.UpcomingTenderForAdmin();
        }
        public async Task<IEnumerable<TenderCard>> CompanyTendersForAdmin(int statusId, long? companyId)
        {
            return await tenderRepository.CompanyTendersForAdmin(statusId, companyId);
        }
        public async Task<TenderEntity> UpdateTender(UpdateTenderRequestDto tenderDto)
        {
            TenderEntity entity = await tenderRepository.GetTenderEntityOnly(tenderDto.TenderId);

            var communityapprovalentity = await tenderRepository.FetchCommunityApprovalEntity(tenderDto.TenderId);

            foreach (var item in communityapprovalentity)
            {
                if (item.StatusId==2)
                {
                    item.StatusId = 1;
                    item.Date_Modified = DateTime.Now;
                    await tenderRepository.UpdateStatusByFeedbackForCommunityApproval(item);
                }
            }

            string companyFolder = docRepo.GetCompanyFolder(tenderDto.superId);
            string docPath = companyFolder + $"\\Tender\\{entity.Id}";

            if (tenderDto.TenderDetailDoc != null)
            {
                await uploadFileService.DeleteFile(entity.TenderDetailDocPath);
                entity.TenderDetailDocPath = await uploadFileService.Upload(tenderDto.TenderDetailDoc, docPath);
                entity.TenderDetailDocTitle = tenderDto.TenderDocTitle;
            }

            if (tenderDto.TenderTermsAndConditionDoc != null)
            {
                await uploadFileService.DeleteFile(entity.TermsAndConditionDocPath);
                entity.TermsAndConditionDocPath = await uploadFileService.Upload(tenderDto.TenderTermsAndConditionDoc, docPath);
            }
            //if (tenderDto.TenderCards != null)
            //{
            //    foreach (var item in tenderDto.TenderCards)
            //    {
            //        var itm = entity.TenderCards.Where(x => x.Id == item.Id).FirstOrDefault();
            //        if (itm == null)
            //        {
            //            TenderCardEntity obj = new TenderCardEntity
            //            {
            //                TenderId = entity.Id,
            //                Label = item.Label,
            //                Value = item.Value
            //            };
            //            entity.TenderCards.Add(obj);
            //        }
            //        else
            //        {
            //            itm.Label = item.Label;
            //            itm.Value = item.Value;
            //        }
            //    }
            //}
        
            if (tenderDto.ExtraDocuments != null)
            {
                foreach (var item in tenderDto.ExtraDocuments)
                {
                    var itm = entity.ExtraDocuments.Where(x => x.Id == item.Id).FirstOrDefault();
                    if (itm == null && item.Document != null)
                    {
                        TenderExtraDocumentEntity obj = new TenderExtraDocumentEntity
                        {
                            CompanyId = tenderDto.superId,
                            UserId = tenderDto.CreatedBy,
                            TenderId = entity.Id,
                            DocTitle = item.DocTitle,
                            IsDeleted = entity.IsDeleted,
                            DocPath = await uploadFileService.Upload(item.Document, docPath)
                        };
                        entity.ExtraDocuments.Add(obj);
                    }
                    else
                    {
                        itm = new TenderExtraDocumentEntity();
                        if (item.Document != null)
                        {
                            await uploadFileService.DeleteFile(itm.DocPath);
                            itm.DocPath = await uploadFileService.Upload(item.Document, docPath);
                        }
                        itm.DocTitle = item.DocTitle;
                    }
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
        public Tuple<long, List<long>> GetTenderIdFromCode(string tenderCode)
        {
            return tenderRepository.GetTenderIdFromCode(tenderCode);
        }


        public Tuple<long, List<long>> GetTenderWinnerIdFromCode(string tenderCode)
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

        public async Task<TenderApproveDto> ApproveTenderByBidInviter(TenderApproveDto dto)
        {
            try
            {
                CommunityApprovalEntity t = await tenderRepository.GetTenderEntityOfCompany(dto.TenderId,dto.CompanyId);
                t.StatusId = 3;//Approved
                t.Date_Modified = DateTime.Now;
                //t.ApprovedBy = dto.UserId;
                tenderRepository.ApproveTenderByBidInviter(t);

                await ToUpdateCommunityApprovalStatusInTender(dto.TenderId);

                return dto;
            }
            catch
            {

                throw;
            }
        }

        private async Task ToUpdateCommunityApprovalStatusInTender(long tenderId)
        {
            var check = await tenderRepository.CheckStatusInCommunityApproval(tenderId);
            if (check == true)
            {
                TenderEntity te = await tenderRepository.FindTenderToUpdate(tenderId);
                if (te != null)
                {
                    te.CommunityApprovalStatus = 3;
                    await tenderRepository.UpdateTenderStatus(te);
                }
            }
        }

        public Tuple<decimal, DateTime, DateTime> GetMaxQuotationAllowed(long tenderId)
        {
            try
            {
                string key = $"TenderInfo_{tenderId}";
                Tuple<decimal, DateTime, DateTime> tuple;
                cache.TryGetValue<Tuple<decimal, DateTime, DateTime>>(key, out tuple);

                if (tuple == null)
                {
                    tuple = tenderRepository.GetMaxQuotationAllowed(tenderId);
                    cache.Set(key, tuple);
                }
                return tuple;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateTenderMaxQuotation(decimal maxQuotation, long tenderId)
        {
            try
            {
                TenderEntity t = await tenderRepository.GetTenderEntityOnly(tenderId);
                t.MaxQuotation = maxQuotation;
                await tenderRepository.UpdateTender(t);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteTender(long tenderId)
        {
            try
            {
                TenderEntity t = await tenderRepository.GetTenderDetailNew(tenderId);          
                //if (t != null)
                //{
                //    t.Feedbacks = await tenderRepository.GetTenderCardFeedback(tenderId);
                //    return await tenderRepository.DeleteTender(t);
                //}
                //return false;

                //.Include(x => x.TenderMaterialEntities)
                //    .Include(x => x.TenderCards)
                //    .Include(x => x.ExtraDocuments)
                //    .Include(x => x.CategoryEntity)
                //    .Include(x => x.CreatedByUser)
                //    .Include(x => x.TenderStatusEntity)
                //t.Feedbacks = await tenderRepository.GetTenderCardFeedback(tenderId);
                return await tenderRepository.DeleteTender(t);

            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> isSupplierRegistered(long tenderId, long userId, long companyId) {
             try
            {
                bool isSupplier = await tenderRepository.isSupplierRegistered(tenderId, userId, companyId);

                return isSupplier;

            }
            catch
            {

                throw;
            }
        }

         public async Task<TenderStatusDto> GetTenderStatus(long tenderId, long userId) {
             try
            {
                int tenderStatus = await tenderRepository.GetTenderStatus(tenderId, userId);
                TenderEntity tenderEntity = await tenderRepository.GetTenderDetail(tenderId);
                TenderStatusDto tenderStatusDto = new TenderStatusDto();
                if(tenderStatus == 1) {
                    if(tenderEntity.LiveEndDate < DateTimeNPT.Now) {
                        tenderStatusDto.Status = "Rejected";
                        tenderStatusDto.StatusId = 4;
                    } 
                    else 
                    {
                        tenderStatusDto.Status = "Pending Approval";
                        tenderStatusDto.StatusId = tenderStatus;
                    }
                    return tenderStatusDto;
                } else if (tenderStatus == 2) {
                    if(tenderEntity.LiveStartDate <= DateTimeNPT.Now && tenderEntity.LiveEndDate > DateTimeNPT.Now) {
                        tenderStatusDto.Status = "Live";
                        tenderStatusDto.StatusId = 5;
                    }
                    else if(tenderEntity.LiveEndDate < DateTimeNPT.Now) {
                        tenderStatusDto.Status = "Completed";
                        tenderStatusDto.StatusId = 6;
                    } 
                    else
                    {
                        tenderStatusDto.Status = "Approved";
                        tenderStatusDto.StatusId = tenderStatus;
                    }
                    return tenderStatusDto;
                } else if (tenderStatus == 3) {
                    if (tenderEntity.LiveEndDate < DateTimeNPT.Now)
                    {
                        tenderStatusDto.Status = "Rejected";
                        tenderStatusDto.StatusId = 4;
                    }
                    else
                    {
                        tenderStatusDto.Status = "Require More Documents";
                        tenderStatusDto.StatusId = tenderStatus;
                    }
                    return tenderStatusDto;
                } else if (tenderStatus == 4) {
                    tenderStatusDto.Status = "Rejected";
                    tenderStatusDto.StatusId = tenderStatus;
                    return tenderStatusDto;
                } else {
                    tenderStatusDto.Status = "Invaid Status Id";
                    tenderStatusDto.StatusId = 0;
                    return tenderStatusDto;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> GetTenderDetailBidInviterStatus(long tenderId, long companyId) {
            try {
                CommunityApprovalEntity tenderEntity = await tenderRepository.GetTenderDetailBidInviterStatus(tenderId, companyId);
                int tenderStatus = tenderEntity.StatusId;
                if(tenderEntity.TenderEntities.LiveStartDate <= DateTimeNPT.Now && tenderEntity.TenderEntities.LiveEndDate > DateTimeNPT.Now) {
                    tenderStatus = 4;
                }
                if(tenderEntity.TenderEntities.LiveEndDate < DateTimeNPT.Now) {
                    tenderStatus = 5;
                }
                return tenderStatus;
            } catch {
                throw;
            }
        }

        public async Task<int> TenderStatusForAdmin(long tenderId)
        {
            try
            {
                TenderEntity tenderEntity = await tenderRepository.GetTenderDetail(tenderId);
                int tenderStatus = tenderEntity.StatusId;
                if(tenderEntity.LiveStartDate <= DateTimeNPT.Now && tenderEntity.LiveEndDate > DateTimeNPT.Now) {
                    tenderStatus = 4;
                }
                if(tenderEntity.LiveEndDate < DateTimeNPT.Now) {
                    tenderStatus = 5;
                }
                return tenderStatus;
            }
            catch
            {
                throw;
            }
        }


        public async Task<int> AddTime(long tenderId, int min) {
            try {
                int status = await tenderRepository.AddTime(tenderId, min);
                AddTimeDto addTimeDto = new AddTimeDto();
                addTimeDto.status = status;
                addTimeDto.min = min;
                addTimeDto.tenderId = tenderId;
                string addTimeKey = $"{tenderId} + _AddTimeKey";
                DateTime dateTime = DateTimeNPT.Now;
                cache.Set<AddTimeDto>(addTimeKey, addTimeDto, dateTime.AddHours(12));
                return status;
            } catch {
                throw;
            }
        }

         public async Task<int> EndTender(long tenderId) {
            try {
                int status = await tenderRepository.EndTender(tenderId);
                
                return status;
            } catch {
                throw;
            }
        }

        public async Task<int> EnterBidRoomBidInviter(long tenderId, long companyId) 
        {
            try 
            {
                int status = await tenderRepository.EnterBidRoomBidInviter(tenderId, companyId);
                
                return status;
            } catch 
            {
                throw;
            }
        }

        public async Task<List<AlgorithmEntity>> AlgorithmList() 
        {
            try 
            {
                List<AlgorithmEntity> algoList = await tenderRepository.AlgorithmList();
                return algoList;
            }
            catch 
            {
                throw;
            }
        }

        public async Task<List<MaterialCatResDto>> MaterialCategory(long tenderId) 
        {
            try 
            {
                List<MaterialCatResDto> materialCatList = await tenderRepository.MaterialCategory(tenderId);
                return materialCatList;
            }
            catch 
            {
                throw;
            }
        }

        public async Task<List<TenderMaterialSealedResponseDto>> MaterialListCategoryWise(long tenderId, int materialId) 
        {
            try 
            {
                List<TenderMaterialSealedResponseDto> materialCatList = await tenderRepository.MaterialListCategoryWise(tenderId, materialId);
                materialCatList.OrderBy(x => x.MaterialName);
                return materialCatList;
            }
            catch 
            {
                throw;
            }
        }

        public async Task<RetriveDataSealBid> MaterialListCategoryWiseRetriveData(long tenderId, long materialId, long supplierId) 
        {
            try 
            {
                RetriveDataSealBid retriveDataSealBid = new RetriveDataSealBid();
                retriveDataSealBid.supplierId = supplierId;
                retriveDataSealBid.TenderId = tenderId;
                List<TenderMaterialSealedResponseDto> materialList = await tenderRepository.MaterialListCategoryWiseRetriveData(tenderId, materialId, supplierId);
                materialList.OrderBy(x => x.MaterialName);
                decimal subsectionTotal = await tenderRepository.GetSubSectionTotalForUser(tenderId, materialId, supplierId);
                retriveDataSealBid.materialList = materialList;
                retriveDataSealBid.subsectionTotal = subsectionTotal;
                retriveDataSealBid.materialGroupId = materialId;
                retriveDataSealBid.materialGroupName = materialList.Select(x => x.MaterialGroup).FirstOrDefault();
                return retriveDataSealBid;
            }
            catch 
            {
                throw;
            }
        }

        public async Task<RetriveSubSectionDto> RetriveSubsectionTotal(long tenderId, long supplierId) 
        {
            try 
            {
                List<SealBidSubsectionTotalEntity> sealBidSubsectionTotalEntities = await tenderRepository.RetriveSubsectionTotal(tenderId, supplierId);
                Dictionary<string, decimal> subsectionTotal = new Dictionary<string, decimal>();
                foreach(SealBidSubsectionTotalEntity sealBidSubsectionTotalEntity in sealBidSubsectionTotalEntities) 
                {
                    subsectionTotal.Add(sealBidSubsectionTotalEntity.MaterialGroup, sealBidSubsectionTotalEntity.subsectionTotal);
                }
                RetriveSubSectionDto retriveSubSectionDto = new RetriveSubSectionDto();
                retriveSubSectionDto.subsectionTotal = subsectionTotal;
                retriveSubSectionDto.totalAmount = sealBidSubsectionTotalEntities.Sum(x => x.subsectionTotal);
                return retriveSubSectionDto;
            }
            catch 
            {
                throw;
            }
        }

        public async Task<PostBidddingApprovalEntity> PostBidApprove(long tenderId, long companyId)
        {
            try
            {
                var postBidEntity = await tenderRepository.FindPostBiddingApproval(tenderId, companyId);

                if (postBidEntity != null)
                {
                    postBidEntity.StatusId = 3;
                    postBidEntity.Date_Modified = DateTimeNPT.Now;

                    await tenderRepository.UpdatePostBidApprovalStatus(postBidEntity);

                    await ToUpdatePostSealBidStatusInTender(tenderId);

                    return postBidEntity;

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


        private async Task ToUpdatePostSealBidStatusInTender(long tenderId)
        {
            var check = await tenderRepository.CheckStatusInPostBidApproval(tenderId);
            if (check == true)
            {
                TenderEntity te = await tenderRepository.FindTenderToUpdate(tenderId);
                if (te != null)
                {
                    te.PostBidStatus = 2; //Aprroved by all Bid Inviter
                    await tenderRepository.UpdateTenderStatus(te);
                }
            }
        }

        public async Task<PostBidddingApprovalEntity> PostBidRequestChanges(PostBidApproveDDtoByBidInviter tenderApprove)
        {
            try
            {
                var postBidEntity = await tenderRepository.FindPostBiddingApproval(tenderApprove.TenderId, tenderApprove.CompanyId);

                if (postBidEntity != null)
                {
                    postBidEntity.StatusId = 2;
                    postBidEntity.Date_Modified = DateTimeNPT.Now;
                    postBidEntity.RemarksStatusId = 1; //Outgoing Remarks for Bid Inviter

                    var postBidRemarksEntity = PostBidRemarksDtoEntity(tenderApprove, postBidEntity);
                    await tenderRepository.InsertIntoPostBidRemarks(postBidRemarksEntity);

                    return await tenderRepository.UpdatePostBidApprovalStatus(postBidEntity);
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

        public async Task<PostBidddingApprovalEntity> GenerateNewRequest(GenerateNewRequestDtoByAdmin tenderApprove)
        {
            try
            {
                var postBidEntity =await tenderRepository.FindPostBiddingApproval(tenderApprove.TenderId, tenderApprove.BidInviterId);
                if (postBidEntity != null)
                {
                    postBidEntity.StatusId = 1;
                    postBidEntity.Date_Modified = DateTimeNPT.Now;
                    postBidEntity.RemarksStatusId = 2; //Incoming Remarks for Bid Inviter

                    var postBidRemarksEntity = PostBidRemarksDtoEntity(tenderApprove,postBidEntity);
                    await tenderRepository.InsertIntoPostBidRemarks(postBidRemarksEntity);

                    return await tenderRepository.UpdatePostBidApprovalStatus(postBidEntity);
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

        public async Task<TenderEntity> PostBidFinalApprove(TenderApproveDtoByAdmin tenderApprove)
        {
            try
            {
                var tenderEntity = await tenderRepository.FindTenderToUpdate(tenderApprove.TenderId);
                if (tenderEntity!=null)
                {
                    if (tenderApprove.status == true)
                    {
                        tenderEntity.PostBidStatus = 3; //Approved by Admin
                        tenderEntity.ApprovedBy = tenderApprove.UserId;
                        tenderEntity.Date_modified = DateTimeNPT.Now;
                    }
                    else if (tenderApprove.status == false)
                    {
                        tenderEntity.PostBidStatus = 4; //Rejected By Admin
                        tenderEntity.Date_modified = DateTimeNPT.Now;
                    }

                    await tenderRepository.UpdateTenderStatus(tenderEntity);
                    return tenderEntity;
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

        public async Task<List<PostBidddingApprovalEntity>> AddPostBid(AddPostBidDto postBidDto)
        {
            var postBidEntity = new List<PostBidddingApprovalEntity>();

            for (int i = 0; i < postBidDto.CompanyIds.Count; i++)
            {
                var obj = new PostBidddingApprovalEntity();

                obj.TenderId = postBidDto.TenderId;
                obj.Date_Created = DateTimeNPT.Now;
                obj.Date_Modified = DateTimeNPT.Now;
                obj.StatusId = 1;
                obj.IsDeleted = false;
                obj.CompanyId = postBidDto.CompanyIds[i];
                obj.UserId = postBidDto.UserIds[i];
                postBidEntity.Add(obj);
            }

            return await tenderRepository.AddPostBid(postBidEntity);
        }

        public async Task<IEnumerable<PostBidDtoList>> GetPostBidCompanyList(long companyId)
        {
            try
            {
                    IEnumerable<PostBidDtoList> postBidddingApprovalEntity = await tenderRepository.FetchTenderTitleListForBidInviter(companyId);
                    return postBidddingApprovalEntity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<PostBidApprovalListDto>> GetPostBidRemarksList(long tenderId, long companyId)
        {
            try
            {
                IEnumerable<PostBidApprovalListDto> postBidddingApprovalEntity = await tenderRepository.FetchPostBidRemarksList(tenderId, companyId);
                return postBidddingApprovalEntity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> AddSuperSeed(SuperSeedDto superSeedDto)
        {
            try
            {
                var result = await tenderRepository.FindTenderToUpdate(superSeedDto.TenderId);
                if (result != null)
                {
                    result.PostBidStatus = 3; //Approve by Admin
                    var response = await tenderRepository.UpdateTenderStatus(result);

                    await AddToPostBiddingSuperSeed(superSeedDto);

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

        private async Task<bool> AddToPostBiddingSuperSeed(SuperSeedDto superSeedDto)
        {
            try
            {
                var postBiddingSuperseedEntity = PostBiddingSuperseedDtoEntity(superSeedDto);
                await tenderRepository.AddPostBiddingSuperSeed(postBiddingSuperseedEntity);
                return true;
            }
            catch 
            {

                throw;
            }
        }

        public async Task<int> CheckPostBidStatus(long tenderId)
        {
            try
            {
                var tenderEntity = await tenderRepository.FindTenderToUpdate(tenderId);
                if (tenderEntity!=null)
                {
                    return tenderEntity.PostBidStatus;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
