using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Repository;
using MeroBolee.Service.Otp;
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
        private readonly IOtpService otpService;


        public TenderService(ITenderRepository tenderRepository,
                                IMemoryCache cache,
                                IReferenceCodeService referenceCodeService,
                                IUploadFile uploadFileService,
                                ICompanyDocumentRepository docRepo,
                                IOtpService otpService)
        {
            this.tenderRepository = tenderRepository;
            this.cache = cache;
            this.referenceCodeService = referenceCodeService;
            this.uploadFileService = uploadFileService;
            this.docRepo = docRepo;
            this.otpService = otpService;
        }

        public async Task<TenderEntity> AddTender(AddTenderRequestDto tenderDto)
        {
            TenderEntity entity = TenderDtoEntity(tenderDto);
            if (tenderDto.Algorithm == 1 || tenderDto.Algorithm == 2)
            {
                entity.PostBidStatus = 3;
            }

            entity = tenderRepository.AddTender(entity);

            List<CommunityApprovalEntity> community = CommunityDtoEntity(entity.Id, tenderDto);
            tenderRepository.AddCommunityApproval(community);

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
                            IsDeleted = false,
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

        public Task<IEnumerable<TenderCard>> GetMarketplaceTender(string search = null, string procurementId = null, string algoId = null)
        {
            var procurementIdsList = new List<int>();
            var algoIdsList = new List<int>();

            if (procurementId != null)
            {
                var procurementList = procurementId.Split(',');
                foreach (var item in procurementList)
                {
                    var a = Int32.Parse(item);
                    procurementIdsList.Add(a);
                }
            }

            if (algoId != null)
            {
                var algoList = algoId.Split(',');
                foreach (var item in algoList)
                {
                    var a = Int32.Parse(item);
                    algoIdsList.Add(a);
                }
            }


            return tenderRepository.GetMarketplaceTender(search, procurementIdsList, algoIdsList);
        }
        public Task<IEnumerable<TenderCard>> GetLiveBidMarketplaceTenderForAdmin(string search)
        {
            return tenderRepository.GetLiveBidMarketplaceTenderForAdmin(search);
        }

        public async Task<IEnumerable<TenderCard>> GetBidIniviterTenderHistory(long companyId, string search = null, string procurementId = null, string algoId = null)
        {
            try
            {
                var procurementIdsList = new List<int>();
                var algoIdsList = new List<int>();

                if (procurementId != null)
                {
                    var procurementList = procurementId.Split(',');
                    foreach (var item in procurementList)
                    {
                        var a = Int32.Parse(item);
                        procurementIdsList.Add(a);
                    }
                }

                if (algoId != null)
                {
                    var algoList = algoId.Split(',');
                    foreach (var item in algoList)
                    {
                        var a = Int32.Parse(item);
                        algoIdsList.Add(a);
                    }
                }

                return await tenderRepository.GetBidIniviterTenderHistory(companyId, search, procurementIdsList, algoIdsList);

            }
            catch
            {

                throw;
            }
        }

        public async Task<BidInviterTenderListing> GetBidInviterTenderListing(long companyId, string procurementId = null, string algoId = null)
        {
            try
            {
                var procurementIdsList = new List<int>();
                var algoIdsList = new List<int>();

                if (procurementId != null)
                {
                    var procurementList = procurementId.Split(',');
                    foreach (var item in procurementList)
                    {
                        var a = Int32.Parse(item);
                        procurementIdsList.Add(a);
                    }
                }

                if (algoId != null)
                {
                    var algoList = algoId.Split(',');
                    foreach (var item in algoList)
                    {
                        var a = Int32.Parse(item);
                        algoIdsList.Add(a);
                    }
                }
                IEnumerable<TenderCard> tenders = await tenderRepository.GetBidIniviterTenderListing(companyId, procurementIdsList, algoIdsList);
                BidInviterTenderListing listing = new BidInviterTenderListing
                {
                    PendingTenders = tenders.Where(x => x.StatusId == 1 || x.StatusId == 2).ToList(),
                    ActiveTenders = tenders.Where(x => x.StatusId == 3 && x.LiveEndDate > DateTime.Now).ToList()
                };
                return listing;
            }
            catch
            {

                throw;
            }

        }


        public async Task<GetTenderDto> GetTenderDetail(long tenderId, string baseUrl, bool isRegistered, string userRole)
        {
            TenderEntity te = await tenderRepository.GetTenderDetail(tenderId);
            if (te != null)
            {
                var result = TenderEntityToDto(te, baseUrl, isRegistered, userRole);
                if (userRole != "Bidder")
                {
                    result.RegisteredCompanyIds = tenderRepository.GetBidInviterCompanyList(tenderId);

                }
                var res = await tenderRepository.FetchPostBidRemarks(tenderId, "PreBid");

                if (userRole == "Super Admin" && res!=null)
                {
                    var obj = new PostBidDetail
                    {
                        Status = res.Status,
                        Remarks = res.Remarks
                    };
                    result.preBidDetail = obj;
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

                        var preBiddingRejectDtoEntity= BidRejectDtoEntity(tenderApprove, "PreBid");
                        await tenderRepository.AddPostBiddingSuperSeed(preBiddingRejectDtoEntity);
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

        public async Task<bool> PreBidSuperseed(PreBidSuperSeed tenderApprove)
        {
            try
            {
                TenderEntity te = await tenderRepository.FindTenderToUpdate(tenderApprove.TenderId);
                if (te != null)
                {
                    var check = await otpService.VerifyOtp(tenderApprove.OtpCode, tenderApprove.UserId, tenderApprove.CompanyId, "");
                    if (check)
                    {
                        te.StatusId = 3;
                        te.ApprovedBy = tenderApprove.UserId;
                        te.Date_modified = DateTimeNPT.Now;

                        await tenderRepository.UpdateTenderStatus(te);

                        await AddToPreBiddingSuperSeed(tenderApprove);

                        var preBidddingApprovalEntity = await tenderRepository.FindPendingCommunityApprovalEntity(tenderApprove.TenderId);

                        if (preBidddingApprovalEntity.Count() == 0)
                        {
                            return false;
                        }
                        else
                        {
                            foreach (var item in preBidddingApprovalEntity)
                            {
                                item.StatusId = 7; //Superseeded by Admin
                            }

                            await tenderRepository.UpdateCommunityApprovalStatuses(preBidddingApprovalEntity);
                        }
                    }
                    else
                    {
                        return false;
                    }

                    return true;
                }
                return false;
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
                    if (item.StatusId == 2)
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

        public async Task<PostBidDetail> GetPostBidApprovalList(long tenderId)
        {
            try
            {
                IEnumerable<PostBidApprovalListDto> postBidddingApprovalEntity = await tenderRepository.FetchPostBidApprovalList(tenderId);
                var result=await tenderRepository.FetchPostBidRemarks(tenderId,"PostBid");
                var obj = new PostBidDetail();
                if (result==null)
                {
                    obj.postBidApprovalListDtos = postBidddingApprovalEntity;
                }
                else
                {
                    obj.Remarks = result.Remarks;
                    obj.Status = result.Status;
                    obj.postBidApprovalListDtos = postBidddingApprovalEntity;
                }
                return obj;
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
        public async Task<IEnumerable<TenderCard>> UpcomingBidderTender(long companyId, bool isAlert, bool isLiveBidUpcoming, string procurementId=null, string algoId=null)
        {
            var procurementIdsList = new List<int>();
            var algoIdsList = new List<int>();

            if (procurementId != null)
            {
                var procurementList = procurementId.Split(',');
                foreach (var item in procurementList)
                {
                    var a = Int32.Parse(item);
                    procurementIdsList.Add(a);
                }
            }

            if (algoId != null)
            {
                var algoList = algoId.Split(',');
                foreach (var item in algoList)
                {
                    var a = Int32.Parse(item);
                    algoIdsList.Add(a);
                }
            }
            IEnumerable<TenderCard> tenderCards = await tenderRepository.UpcomingBidderTender(companyId, isAlert, isLiveBidUpcoming, procurementIdsList, algoIdsList);

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
            }
            else
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

        public async Task<IEnumerable<TenderCard>> UpcomingBidInviterTender(long companyId, string procurementId = null, string algoId = null)
        {
            try
            {
                var procurementIdsList = new List<int>();
                var algoIdsList = new List<int>();

                if (procurementId != null)
                {
                    var procurementList = procurementId.Split(',');
                    foreach (var item in procurementList)
                    {
                        var a = Int32.Parse(item);
                        procurementIdsList.Add(a);
                    }
                }

                if (algoId != null)
                {
                    var algoList = algoId.Split(',');
                    foreach (var item in algoList)
                    {
                        var a = Int32.Parse(item);
                        algoIdsList.Add(a);
                    }
                }

                return await tenderRepository.UpcomingBidInviterTender(companyId, procurementIdsList, algoIdsList);

            }
            catch
            {

                throw;
            }
        }
        public async Task<IEnumerable<TenderCard>> UpcomingTenderForAdmin()
        {
            return await tenderRepository.UpcomingTenderForAdmin();
        }
        public async Task<IEnumerable<TenderCard>> CompanyTendersForAdmin(int statusId, long? companyId = null, string procurementId = null, string algoId = null)
        {
            try
            {
                var procurementIdsList = new List<int>();
                var algoIdsList = new List<int>();

                if (procurementId != null)
                {
                    var procurementList = procurementId.Split(',');
                    foreach (var item in procurementList)
                    {
                        var a = Int32.Parse(item);
                        procurementIdsList.Add(a);
                    }
                }

                if (algoId != null)
                {
                    var algoList = algoId.Split(',');
                    foreach (var item in algoList)
                    {
                        var a = Int32.Parse(item);
                        algoIdsList.Add(a);
                    }
                }

                return await tenderRepository.CompanyTendersForAdmin(statusId, companyId, procurementIdsList, algoIdsList);

            }
            catch
            {

                throw;
            }
        }
        public async Task<TenderEntity> UpdateTender(UpdateTenderRequestDto tenderDto)
        {
            TenderEntity entity = await tenderRepository.GetTenderEntityOnly(tenderDto.TenderId);

            var communityapprovalentity = await tenderRepository.FetchCommunityApprovalEntity(tenderDto.TenderId);

            foreach (var item in communityapprovalentity)
            {
                if (item.StatusId == 2)
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
                CommunityApprovalEntity t = await tenderRepository.GetTenderEntityOfCompany(dto.TenderId, dto.CompanyId);
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

        public async Task<bool> isSupplierRegistered(long tenderId, long userId, long companyId)
        {
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

        public async Task<TenderStatusDto> GetTenderStatus(long tenderId, long userId)
        {
            try
            {
                int tenderStatus = await tenderRepository.GetTenderStatus(tenderId, userId);
                TenderEntity tenderEntity = await tenderRepository.GetTenderDetail(tenderId);
                TenderStatusDto tenderStatusDto = new TenderStatusDto();
                if (tenderStatus == 1)
                {
                    if (tenderEntity.LiveEndDate < DateTimeNPT.Now)
                    {
                        tenderStatusDto.Status = "Rejected";
                        tenderStatusDto.StatusId = 4;
                    }
                    else
                    {
                        tenderStatusDto.Status = "Pending Approval";
                        tenderStatusDto.StatusId = tenderStatus;
                    }
                    return tenderStatusDto;
                }
                else if (tenderStatus == 2)
                {
                    if (tenderEntity.LiveStartDate <= DateTimeNPT.Now && tenderEntity.LiveEndDate > DateTimeNPT.Now)
                    {
                        tenderStatusDto.Status = "Live";
                        tenderStatusDto.StatusId = 5;
                    }
                    else if (tenderEntity.LiveEndDate < DateTimeNPT.Now)
                    {
                        tenderStatusDto.Status = "Completed";
                        tenderStatusDto.StatusId = 6;
                    }
                    else
                    {
                        tenderStatusDto.Status = "Approved";
                        tenderStatusDto.StatusId = tenderStatus;
                    }
                    return tenderStatusDto;
                }
                else if (tenderStatus == 3)
                {
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
                }
                else if (tenderStatus == 4)
                {
                    tenderStatusDto.Status = "Rejected";
                    tenderStatusDto.StatusId = tenderStatus;
                    return tenderStatusDto;
                }
                else
                {
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

        public async Task<int> GetTenderDetailBidInviterStatus(long tenderId, long companyId)
        {
            try
            {
                CommunityApprovalEntity tenderEntity = await tenderRepository.GetTenderDetailBidInviterStatus(tenderId, companyId);
                int tenderStatus = tenderEntity.StatusId;
                if (tenderEntity.TenderEntities.LiveStartDate <= DateTimeNPT.Now && tenderEntity.TenderEntities.LiveEndDate > DateTimeNPT.Now)
                {
                    tenderStatus = 4;
                }
                if (tenderEntity.TenderEntities.LiveEndDate < DateTimeNPT.Now)
                {
                    tenderStatus = 5;
                }
                return tenderStatus;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> TenderStatusForAdmin(long tenderId)
        {
            try
            {
                TenderEntity tenderEntity = await tenderRepository.GetTenderDetail(tenderId);
                int tenderStatus = tenderEntity.StatusId;
                if (tenderEntity.LiveStartDate <= DateTimeNPT.Now && tenderEntity.LiveEndDate > DateTimeNPT.Now)
                {
                    tenderStatus = 4;
                }
                if (tenderEntity.LiveEndDate < DateTimeNPT.Now)
                {
                    tenderStatus = 5;
                }
                return tenderStatus;
            }
            catch
            {
                throw;
            }
        }


        public async Task<int> AddTime(long tenderId, int min)
        {
            try
            {
                int status = await tenderRepository.AddTime(tenderId, min);
                AddTimeDto addTimeDto = new AddTimeDto();
                addTimeDto.status = status;
                addTimeDto.min = min;
                addTimeDto.tenderId = tenderId;
                string addTimeKey = $"{tenderId} + _AddTimeKey";
                DateTime dateTime = DateTimeNPT.Now;
                cache.Set<AddTimeDto>(addTimeKey, addTimeDto, dateTime.AddHours(12));
                return status;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> EndTender(long tenderId)
        {
            try
            {
                int status = await tenderRepository.EndTender(tenderId);

                return status;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> EnterBidRoomBidInviter(long tenderId, long companyId)
        {
            try
            {
                int status = await tenderRepository.EnterBidRoomBidInviter(tenderId, companyId);

                return status;
            }
            catch
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
                foreach (SealBidSubsectionTotalEntity sealBidSubsectionTotalEntity in sealBidSubsectionTotalEntities)
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

        public async Task<PostBidddingApprovalEntity> PostBidApprove(VerifyOtpDto verifyOtpDto)
        {
            try
            {
                var postBidEntity = await tenderRepository.FindPostBiddingApproval(verifyOtpDto.TenderId, verifyOtpDto.CompanyId);

                if (postBidEntity != null)
                {
                    var check = await otpService.VerifyOtp(verifyOtpDto.OtpCode, verifyOtpDto.UserId, verifyOtpDto.CompanyId, "");
                    if (check)
                    {
                        postBidEntity.StatusId = 3;
                        postBidEntity.Date_Modified = DateTimeNPT.Now;
                        postBidEntity.RemarksStatusId = 0;

                        await tenderRepository.UpdatePostBidApprovalStatus(postBidEntity);

                        await ToUpdatePostSealBidStatusInTender(verifyOtpDto.TenderId);

                        return postBidEntity;
                    }
                    else
                    {
                        return null;
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

        public async Task<PostBidddingApprovalEntity> PostBidRequestChanges(TenderApproveDto tenderApprove)
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
                var postBidEntity = await tenderRepository.FindPostBiddingApproval(tenderApprove.TenderId, tenderApprove.BidInviterId);
                if (postBidEntity != null)
                {
                    postBidEntity.StatusId = 1;
                    postBidEntity.Date_Modified = DateTimeNPT.Now;
                    postBidEntity.RemarksStatusId = 2; //Incoming Remarks for Bid Inviter

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

        public async Task<bool> PostBidFinalApprove(TenderApproveDtoByAdmin tenderApprove)
        {
            try
            {
                var tenderEntity = await tenderRepository.FindTenderToUpdate(tenderApprove.TenderId);
                if (tenderEntity != null)
                {
                    if (tenderApprove.status == true)
                    {
                        tenderEntity.PostBidStatus = 3; //Approved by Admin
                        tenderEntity.ApprovedBy = tenderApprove.UserId;
                        tenderEntity.Date_modified = DateTimeNPT.Now;
                        await tenderRepository.UpdateTenderStatus(tenderEntity);

                        return true;

                    }
                    else if (tenderApprove.status == false)
                    {
                        tenderEntity.PostBidStatus = 4; //Rejected By Admin
                        tenderEntity.Date_modified = DateTimeNPT.Now;

                        var preBiddingRejectDtoEntity = BidRejectDtoEntity(tenderApprove, "PostBid");
                        await tenderRepository.AddPostBiddingSuperSeed(preBiddingRejectDtoEntity);

                        await tenderRepository.UpdateTenderStatus(tenderEntity);
                        return false;

                        //var postBidddingApprovalEntity = await tenderRepository.FindPostBiddingApprovalByTenderId(tenderApprove.TenderId);

                        //foreach (var item in postBidddingApprovalEntity)
                        //{
                        //    item.StatusId = 5; //Rejected by Admin
                        //}

                        //await tenderRepository.UpdatePostBidApprovalStatusByTenderId(postBidddingApprovalEntity);
                    }
                    return false;
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

        //public async Task<List<PostBidddingApprovalEntity>> AddPostBid(AddPostBidDto postBidDto)
        //{
        //    var postBidEntity = new List<PostBidddingApprovalEntity>();

        //    for (int i = 0; i < postBidDto.CompanyIds.Count; i++)
        //    {
        //        var obj = new PostBidddingApprovalEntity();

        //        obj.TenderId = postBidDto.TenderId;
        //        obj.Date_Created = DateTimeNPT.Now;
        //        obj.Date_Modified = DateTimeNPT.Now;
        //        obj.StatusId = 1;
        //        obj.IsDeleted = false;
        //        obj.CompanyId = postBidDto.CompanyIds[i];
        //        obj.UserId = postBidDto.UserIds[i];
        //        postBidEntity.Add(obj);
        //    }

        //    return await tenderRepository.AddPostBid(postBidEntity);
        //}


        public async Task<List<PostBidddingApprovalEntity>> AddPostBid(AddPostBidDto postBidDto)
        {
            try
            {
                var postBidEntity = new List<PostBidddingApprovalEntity>();

                List<long> postBidCompanyList = await tenderRepository.GetPostBidCompanyList(postBidDto.TenderId);

                if(postBidCompanyList.Count==0)
                {
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
                }
                else
                {
                    var list = new List<long>();
                    foreach (var item in postBidDto.CompanyIds)
                    {
                        if (!postBidCompanyList.Contains(item))
                        {
                            list.Add(item);
                        }
                    }

                    for (int i = 0; i < list.Count; i++)
                    {
                        var obj = new PostBidddingApprovalEntity();

                        obj.TenderId = postBidDto.TenderId;
                        obj.Date_Created = DateTimeNPT.Now;
                        obj.Date_Modified = DateTimeNPT.Now;
                        obj.StatusId = 1;
                        obj.IsDeleted = false;
                        obj.CompanyId = list[i];
                        obj.UserId = await tenderRepository.FetchUserIdFromCompanyId(list[i]);
                        postBidEntity.Add(obj);
                    }
                }
                return await tenderRepository.AddPostBid(postBidEntity);

            }
            catch 
            {

                throw;
            }
         
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
                    var check = await otpService.VerifyOtp(superSeedDto.otpCode, superSeedDto.UserId, superSeedDto.CompanyId, "");
                    if (check)
                    {
                        result.PostBidStatus = 3; //Approve by Admin
                        var response = await tenderRepository.UpdateTenderStatus(result);

                        var postBidddingApprovalEntity = await tenderRepository.FindPostBiddingApprovalByTenderId(superSeedDto.TenderId);

                        if(postBidddingApprovalEntity.Count()==0)
                        {
                            return false;
                        }
                        else
                        {
                            foreach (var item in postBidddingApprovalEntity)
                            {
                                item.StatusId = 4; //Superseeded by Admin
                                item.RemarksStatusId = 0;
                            }

                            await tenderRepository.UpdatePostBidApprovalStatusByTenderId(postBidddingApprovalEntity);

                            await AddToPostBiddingSuperSeed(superSeedDto);

                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }

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

        private async Task<bool> AddToPreBiddingSuperSeed(TenderApproveDto tenderApprove)
        {
            try
            {
                var postBiddingSuperseedEntity = PreBiddingSuperseedDtoEntity(tenderApprove);
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
                if (tenderEntity != null)
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

        public async Task<IEnumerable<TenderProcurementTypeEntity>> GetProcurement()
        {
            try
            {
                return await tenderRepository.GetProcurementList();
            }
            catch
            {

                throw;
            }
        }

        private async Task<StatDto> GetProcurementCount(long companyId = 0,string Role=null)
        {
            try
            {
                var response = await tenderRepository.GetProcurementList();
                var list = new List<CountDto>();
                long total = 0;

                if (companyId == 0)
                {
                    foreach (var item in response)
                    {
                        var countDto = new CountDto()
                        {
                            Count = await tenderRepository.Couunt(item.Id),
                            Name = item.Procurement,
                            Id = item.Id
                        };
                        total += countDto.Count;
                        list.Add(countDto);
                    }
                }
                else if(Role=="Bid Inviter")
                {
                    foreach (var item in response)
                    {
                        var countDto = new CountDto()
                        {
                            Count = await tenderRepository.BidInviterCount(item.Id, companyId),
                            Name = item.Procurement,
                            Id = item.Id
                        };
                        total += countDto.Count;
                        list.Add(countDto);
                    }
                }
                else
                {
                    foreach (var item in response)
                    {
                        var countDto = new CountDto()
                        {
                            Count = await tenderRepository.BidderCount(item.Id, companyId),
                            Name = item.Procurement,
                            Id = item.Id
                        };
                        total += countDto.Count;
                        list.Add(countDto);
                    }
                }
                var statDto = new StatDto
                {
                    Count = list,
                    Total = total,
                    Name = "ProcurementType"
                };
               
                return statDto;
            }
            catch
            {

                throw;
            }
        }

        private async Task<StatDto> GetBidTypeCount(long companyId = 0, string Role = null)
        {
            try
            {

                var response = await tenderRepository.AlgorithmList();
                var list = new List<CountDto>();
                long total = 0;

                if (companyId == 0)
                {
                    foreach (var item in response)
                    {
                        var countDto = new CountDto()
                        {
                            Count = await tenderRepository.CountBidType(item.id),
                            Name = item.AlgoName,
                            Id = item.id
                        };
                        total += countDto.Count;
                        list.Add(countDto);
                    }
                }

                else if(Role=="Bid Inviter")
                {
                    foreach (var item in response)
                    {
                        var countDto = new CountDto()
                        {
                            Count = await tenderRepository.BidInviterCountBidType(item.id, companyId),
                            Name = item.AlgoName,
                            Id = item.id
                        };
                        total += countDto.Count;
                        list.Add(countDto);
                    }
                }
                else
                {
                    foreach (var item in response)
                    {
                        var countDto = new CountDto()
                        {
                            Count = await tenderRepository.BiderCountBidType(item.id, companyId),
                            Name = item.AlgoName,
                            Id = item.id
                        };
                        total += countDto.Count;
                        list.Add(countDto);
                    }
                }
                var statDto = new StatDto
                {
                    Count = list,
                    Name = "Type Of Bid",
                    Total = total
                };
                return statDto;
            }
            catch
            {

                throw;
            }
        }

        private async Task<StatDto> ProcurementTypeStatus(long companyId=0,string Role=null)
        {
            try
            {
                var procurementtype = await tenderRepository.GetProcurementList();
                var statustype = await tenderRepository.GetTenderStatusList();
                var procurementList = new List<ProcurementTypeDto>();
                long sum = 0;

                if (companyId == 0)
                {
                    foreach (var item in procurementtype)
                    {
                        var statusDtoList = new List<StatusDto>();
                        long total = 0;

                        foreach (var status in statustype)
                        {
                            var companyTenders = await CompanyTendersForAdmin(status.StatusId, procurementId: item.Id.ToString());

                            var statusDto = new StatusDto
                            {
                                Id = status.StatusId,
                                Name = status.Status,
                                Count = companyTenders.Count()
                            };
                            total += statusDto.Count;
                            statusDtoList.Add(statusDto);
                        }
                        var obj = new ProcurementTypeDto
                        {
                            Name = item.Procurement,
                            statusDtos = statusDtoList,
                            Total = total
                        };
                        sum += total;
                        procurementList.Add(obj);
                    }
                }
                else if (Role == "Bid Inviter")
                {
                    foreach (var item in procurementtype)
                    {
                        var statusDtoList = new List<StatusDto>();
                        long total = 0;

                        foreach (var status in statustype)
                        {
                            var companyTenders = await tenderRepository.GetBidInviterTenderStatusList(companyId, item.Id, status.StatusId);

                            var statusDto = new StatusDto
                            {
                                Id = status.StatusId,
                                Name = status.Status,
                                Count = companyTenders.Count()
                            };
                            total += statusDto.Count;

                            statusDtoList.Add(statusDto);
                        }
                        var obj = new ProcurementTypeDto
                        {
                            Name = item.Procurement,
                            statusDtos = statusDtoList,
                            Total=total
                        };
                        sum += total;
                        procurementList.Add(obj);
                    }
                }
                else
                {
                    foreach (var item in procurementtype)
                    {
                        var statusDtoList = new List<StatusDto>();
                        var bidderstatus = await tenderRepository.GetBidderStatus();
                        long total = 0;

                        foreach (var status in bidderstatus)
                        {
                            var companyTenders = await tenderRepository.GetBidderTenderStatusList(companyId, item.Id, status.StatusId);

                            var statusDto = new StatusDto
                            {
                                Id = status.StatusId,
                                Name = status.Status,
                                Count = companyTenders.Count()
                            };
                            total += statusDto.Count;

                            statusDtoList.Add(statusDto);
                        }
                        var obj = new ProcurementTypeDto
                        {
                            Name = item.Procurement,
                            statusDtos = statusDtoList,
                            Total=total
                        };
                        sum += total;
                        procurementList.Add(obj);
                    }
                }


                var statDto = new StatDto
                {
                    procurementTypeDtos = procurementList,
                    Name = "Upcoming/Pending Bid of Procurement Type",
                    Total = sum
                };
                return statDto;
            }
            catch
            {

                throw;
            }
        }

        public async Task<List<ProcurementTypeDto>> GetBidderProcurementTypeStatus(long companyId)
        {
            try
            {
                var procurementtype = await tenderRepository.GetProcurementList();

                var procurementList = new List<ProcurementTypeDto>();

                foreach (var item in procurementtype)
                {
                    var statusDtoList = new List<StatusDto>();


                    var statusDto = new StatusDto
                    {
                        Id = 1,
                        Count = await tenderRepository.GetBidderBidBasedOnProcurementType(item.Id, 1, companyId),

                    };

                    statusDtoList.Add(statusDto);
                    var obj = new ProcurementTypeDto
                    {
                        Name = item.Procurement,
                        statusDtos = statusDtoList
                    };
                    procurementList.Add(obj);
                }
                return procurementList;
            }
            catch
            {

                throw;
            }
        }

        public async Task<List<StatDto>> GetAdminDashboard()
        {
            try
            {
                long total = 0;
                var statDtoList = new List<StatDto>();

                var biddingStageCount = await BiddingStageCount();
                foreach (var item in biddingStageCount)
                {
                    total += item.Count;
                }

                var biddingStageCountobj = new StatDto
                {
                    Name = "BiddingStageCount",
                    Count = biddingStageCount,
                    Total = total
                };

                statDtoList.Add(biddingStageCountobj);


                var procurement = await GetProcurementCount();
                statDtoList.Add(procurement);

                var bidType = await GetBidTypeCount();
                statDtoList.Add(bidType);

                var ongoingPreBiddingCount = await OngoingPreBiddingCount();
                statDtoList.Add(ongoingPreBiddingCount);

                var ongoingPostBiddingCount = await OngoingPostBiddingCount();
                statDtoList.Add(ongoingPostBiddingCount);

                var procurementTypeStatus = await ProcurementTypeStatus();
                statDtoList.Add(procurementTypeStatus);

                var graphdata = await GraphData();
                statDtoList.Add(graphdata);

                return statDtoList;
            }
            catch
            {

                throw;
            }
        }

        private async Task<StatDto> GraphData()
        {
            try
            {
                var obj = new StatDto();

                var graphDataDto = new GraphDataDto();
                graphDataDto.TotalBudget = await tenderRepository.GetGraphDataTotalBudget();
                graphDataDto.graphDatas = await tenderRepository.GetGraphData();

                obj.Name = "Graph Data";
                obj.graphDatas = graphDataDto;
                return obj;
            }
            catch 
            {

                throw;
            }
        }
        public async Task<List<StatDto>> GetBidInviterDashboard(long companyId)
        {
            try
            {
                long total = 0;
                var statDtoList = new List<StatDto>();

                var biddingStageCount = await BiddingStageCount(companyId,"Bid Inviter");
                foreach (var item in biddingStageCount)
                {
                    total += item.Count;
                }

                var biddingStageCountobj = new StatDto
                {
                    Name = "BiddingStageCount",
                    Count = biddingStageCount,
                    Total = total
                };

                statDtoList.Add(biddingStageCountobj);



                var procurement = await GetProcurementCount(companyId,"Bid Inviter");
                statDtoList.Add(procurement);

                var bidType = await GetBidTypeCount(companyId, "Bid Inviter");
                statDtoList.Add(bidType);

                var ongoingPreBiddingCount = await OngoingPreBiddingCount(companyId);
                statDtoList.Add(ongoingPreBiddingCount);

                var ongoingPostBiddingCount = await OngoingPostBiddingCount(companyId);
                statDtoList.Add(ongoingPostBiddingCount);

                var procurementTypeStatus = await ProcurementTypeStatus(companyId,"Bid Inviter");
                statDtoList.Add(procurementTypeStatus);

                var graphdata = await GraphData();
                statDtoList.Add(graphdata);

                return statDtoList;
            }
            catch
            {

                throw;
            }
        }

        public async Task<List<StatDto>> GetBidderDashboard(long companyId)
        {
            try
            {
                long total = 0;
                var statDtoList = new List<StatDto>();

                var biddingStageCount = await BiddingStageCount(companyId);
                foreach (var item in biddingStageCount)
                {
                    total += item.Count;
                }

                var biddingStageCountobj = new StatDto
                {
                    Name = "BiddingStageCount",
                    Count = biddingStageCount,
                    Total = total
                };

                statDtoList.Add(biddingStageCountobj);

                var procurement = await GetProcurementCount(companyId);
                statDtoList.Add(procurement);

                var bidType = await GetBidTypeCount(companyId);
                statDtoList.Add(bidType);

                var procurementTypeStatus = await ProcurementTypeStatus(companyId);
                statDtoList.Add(procurementTypeStatus);

                return statDtoList;
            }
            catch
            {

                throw;
            }
        }
        private async Task<StatDto> OngoingPreBiddingCount(long companyId = 0,string Role=null)
        {
            try
            {
                var procurementtype = await tenderRepository.GetProcurementList();
                long total = 0;
                var obj = new StatDto();
                var list = new List<CountDto>();

                if (companyId == 0)
                {
                    foreach (var item in procurementtype)
                    {
                        var countDto = new CountDto
                        {
                            Id = item.Id,
                            Name = item.Procurement,
                            Count = await tenderRepository.GetOngoingPreBiddingCount(item.Id)
                        };
                        total += countDto.Count;
                        list.Add(countDto);
                    }

                    obj.Count = list;
                    obj.Total = total;
                    obj.Name = "OngoingPreBiddingCount";
                }
                else
                {
                    foreach (var item in procurementtype)
                    {
                        var countDto = new CountDto
                        {
                            Id = item.Id,
                            Name = item.Procurement,
                            Count = await tenderRepository.GetOngoingPreBiddingCountBidInviter(companyId,item.Id)
                        };
                        total += countDto.Count;
                        list.Add(countDto);
                    }

                    obj.Count = list;
                    obj.Total = total;
                    obj.Name = "OngoingPreBiddingCount";
                }
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<StatDto> OngoingPostBiddingCount(long companyId = 0)
        {
            try
            {
                var procurementtype = await tenderRepository.GetProcurementList();
                long total = 0;
                var obj = new StatDto();
                var list = new List<CountDto>();

                if (companyId == 0)
                {
                    foreach (var item in procurementtype)
                    {
                        var countDto = new CountDto
                        {
                            Id = item.Id,
                            Name = item.Procurement,
                            Count = await tenderRepository.GetOngoingPostBiddingCount(item.Id)
                        };
                        total += countDto.Count;
                        list.Add(countDto);
                    }

                    obj.Count = list;
                    obj.Total = total;
                    obj.Name = "OngoingPostBiddingCount";
                }
                else
                {
                    foreach (var item in procurementtype)
                    {
                        var countDto = new CountDto
                        {
                            Id = item.Id,
                            Name = item.Procurement,
                            Count = await tenderRepository.GetOngoingPostBiddingCountBidInviter(companyId,item.Id)
                        };
                        total += countDto.Count;
                        list.Add(countDto);
                    }

                    obj.Count = list;
                    obj.Total = total;
                    obj.Name = "OngoingPostBiddingCount";
                }
                return obj;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<List<CountDto>> BiddingStageCount(long companyId = 0,string Role=null)
        {
            try
            {
                var countDtos = new List<CountDto>();

                var getMarketplaceTender = await GetMarketplaceTender();
                var getMarketplaceTenderobj = new CountDto
                {
                    Id=1,
                    Name = "Market Place",
                    Count = getMarketplaceTender.Count()
                };
                countDtos.Add(getMarketplaceTenderobj);

                if (companyId == 0) //FOr Addmin
                {
                    var upcomingTenderForAdmin = await UpcomingTenderForAdmin();
                    var upcomingTenderForAdminobj = new CountDto
                    {
                        Id=2,
                        Name = "Upcoming",
                        Count = upcomingTenderForAdmin.Count()
                    };
                    countDtos.Add(upcomingTenderForAdminobj);

                    var pendingcompanyTendersForAdmin = await CompanyTendersForAdmin(1); //1 means status is pending;
                    var companyTendersForAdminobj = new CountDto
                    {
                        Id=3,
                        Name = "Pending",
                        Count = pendingcompanyTendersForAdmin.Count()
                    };
                    countDtos.Add(companyTendersForAdminobj);

                    var history = await CompanyTendersForAdmin(5); //5 means status is complete;
                    var historyobj = new CountDto
                    {
                        Id=4,
                        Name = "History",
                        Count = history.Count()
                    };
                    countDtos.Add(historyobj);

                    return countDtos;
                }
                else if(Role=="Bid Inviter")
                {
                    var upcomingTenderForBidInviter = await UpcomingBidInviterTender(companyId);
                    var upcomingTenderForBidInviterobj = new CountDto
                    {
                        Id = 2,
                        Name = "Upcoming",
                        Count = upcomingTenderForBidInviter.Count()
                    };
                    countDtos.Add(upcomingTenderForBidInviterobj);

                    var pendingcompanyTendersForBidInviter = await GetBidInviterTenderListing(companyId);
                    var companyTendersForBidInviterobj = new CountDto
                    {
                        Id=3,
                        Name = "Pending",
                        Count = pendingcompanyTendersForBidInviter.PendingTenders.Count()
                    };
                    countDtos.Add(companyTendersForBidInviterobj);

                    var history = await GetBidIniviterTenderHistory(companyId); ;
                    var historyobj = new CountDto
                    {
                        Id=4,
                        Name = "History",
                        Count = history.Count()
                    };
                    countDtos.Add(historyobj);
                }
                else
                {
                    var upcomingLiveTenderForBidder = await UpcomingBidderTender(companyId, false, true);
                    var upcomingSealedTenderForBider = await UpcomingBidderTender(companyId, true, false);
                    var upcomingTenderForBidderobj = new CountDto
                    {
                        Id = 2,
                        Name = "Upcoming",
                        Count = upcomingLiveTenderForBidder.Count()+ upcomingSealedTenderForBider.Count()
                    };
                    countDtos.Add(upcomingTenderForBidderobj);

                    var companyTendersForAdminobj = new CountDto
                    {
                        Id = 3,
                        Name = "Pending",
                        Count = await BidderPendingCount(companyId)
                    };
                    countDtos.Add(companyTendersForAdminobj);

                    var historyobj = new CountDto
                    {
                        Id = 4,
                        Name = "History",
                        Count = await tenderRepository.GetBidderHistoryCount(companyId)
                    };
                    countDtos.Add(historyobj);
                }
                return countDtos;

            }
            catch
            {

                throw;
            }
        }

        private async Task<long> BidderPendingCount(long companyId)
        {
            try
            {
                return await tenderRepository.GetBidderPendingCount(companyId);
            }
            catch 
            {

                throw;
            }
        }

        public async Task<IEnumerable<GraphDataEntity>> SaveGraphData(GraphDataDto graphDatadto)
        {
            try
            {

                var exists = await tenderRepository.CheckGraphData();
                if(exists.Count==0)
                {
                    var graphDataEntity = GraphDataDtoEntity(graphDatadto);
                    return await tenderRepository.AddGraphData(graphDataEntity);
                }
                else
                {
                    var graph = GraphDataUpdateDtoEntity(graphDatadto, exists);

                    return tenderRepository.UpdateGraphData(graph);
                }
            }
            catch 
            {

                throw;
            }
        }

        public async Task<List<BidderInfo>> GetParticipantBidderList(long tenderId,string Rank)
        {
            try
            {
                if (Rank=="Qualified")
                {
                    return await tenderRepository.GetQualifiedBidderList(tenderId);
                }
                else if (Rank == "Winner")
                {
                    return await tenderRepository.GetWinnerBidderList(tenderId);
                }
                else
                {
                    return await tenderRepository.FetchParticipantBidderList(tenderId);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> SaveQulifiedOrWinner(QualifiedOrWinnerDto qualifiedOrWinnerDto)
        {
            try
            {
                var companyList = new List<long>();
                var companyId = qualifiedOrWinnerDto.CompanyId.Split(',');
                foreach (var item in companyId)
                {
                    var obj = Int64.Parse(item);
                    companyList.Add(obj);
                }


                var bidRequestEntity = await tenderRepository.GetBidRequestEntityByTenderId(qualifiedOrWinnerDto.TenderId);
                var updateBidRequestEntitiesDto = UpdateBidRequestEntitiesDto(bidRequestEntity, qualifiedOrWinnerDto.Rank);
                await tenderRepository.UpdateWholeQualifiedStatusinBidRequest(updateBidRequestEntitiesDto);


                if (qualifiedOrWinnerDto.Rank == "Qualified")
                {
                    foreach (var item in companyList)
                    {
                        var newBidRequestEntity = await tenderRepository.GetBidRequestEntity(item, qualifiedOrWinnerDto.TenderId);
                        newBidRequestEntity.IsQualified = true;
                        newBidRequestEntity.QualifiedDate = DateTimeNPT.Now;
                        await tenderRepository.UpdateQualifiedStatusinBidRequest(newBidRequestEntity);

                    }
                    return true;
                }

                else
                {

                    foreach (var item in companyList)
                    {
                        var newBidRequestEntity = await tenderRepository.GetBidRequestEntity(item, qualifiedOrWinnerDto.TenderId);
                        newBidRequestEntity.IsWinner = true;
                        newBidRequestEntity.WonDate = DateTimeNPT.Now;
                        await tenderRepository.UpdateQualifiedStatusinBidRequest(newBidRequestEntity);
                    }
                    return true;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
