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
        private readonly ISendEmailService sendEmailService;

        public TenderService(ITenderRepository tenderRepository,
                                IMemoryCache cache,
                                IReferenceCodeService referenceCodeService,
                                IUploadFile uploadFileService,
                                ICompanyDocumentRepository docRepo,
                                IOtpService otpService, ISendEmailService sendEmailService)
        {
            this.tenderRepository = tenderRepository;
            this.cache = cache;
            this.referenceCodeService = referenceCodeService;
            this.uploadFileService = uploadFileService;
            this.docRepo = docRepo;
            this.otpService = otpService;
            this.sendEmailService = sendEmailService;
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
                procurementIdsList = procurementId?.Split(',')?.Select(Int32.Parse)?.ToList();
            }

            if (algoId != null)
            {
                algoIdsList = algoId?.Split(',')?.Select(Int32.Parse)?.ToList();
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
                    procurementIdsList = procurementId?.Split(',')?.Select(Int32.Parse)?.ToList();

                }

                if (algoId != null)
                {
                    algoIdsList = algoId?.Split(',')?.Select(Int32.Parse)?.ToList();
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
                    procurementIdsList = procurementId?.Split(',')?.Select(Int32.Parse)?.ToList();
                }

                if (algoId != null)
                {
                    algoIdsList = algoId?.Split(',')?.Select(Int32.Parse)?.ToList();
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

                        var supplierEntity = await tenderRepository.FindVendorEmailByProcurementCategoryId(te.ProcurementCategoryId);
                        if (supplierEntity.Count!=0)
                        {
                            EmailRequestdto emailRequestdto = new EmailRequestdto();
                            emailRequestdto.toEmailId = string.Join(",", supplierEntity);

                            emailRequestdto.callFrom = "NewTender";
                            var sendEmailResponse = sendEmailService.SendEmail(emailRequestdto);
                        }
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

        public async Task<TenderEntity> PreBidSuperseed(TenderApproveDto tenderApprove)
        {
            try
            {
                TenderEntity te = await tenderRepository.FindTenderToUpdate(tenderApprove.TenderId);
                if (te != null)
                {
                    if (te.CommunityApprovalStatus == 3)
                    {
                        return te;
                    }

                    te.StatusId = 3;
                    te.ApprovedBy = tenderApprove.UserId;
                    te.Date_modified = DateTimeNPT.Now;

                    var preBidddingApprovalEntity = await tenderRepository.FindPendingCommunityApprovalEntity(tenderApprove.TenderId);

                    if (preBidddingApprovalEntity.Count() == 0)
                    {
                        return null;
                    }
                    else
                    {
                        foreach (var item in preBidddingApprovalEntity)
                        {
                            item.StatusId = 7; //Superseeded by Admin
                        }
                        await tenderRepository.UpdateTenderStatus(te);

                        await AddToPreBiddingSuperSeed(tenderApprove);
                        await tenderRepository.UpdateCommunityApprovalStatuses(preBidddingApprovalEntity);

                        var supplierEntity = await tenderRepository.FindVendorEmailByProcurementCategoryId(te.ProcurementCategoryId);
                        if (supplierEntity.Count != 0)
                        {
                            EmailRequestdto emailRequestdto = new EmailRequestdto();
                            emailRequestdto.toEmailId = string.Join(",", supplierEntity);

                            emailRequestdto.callFrom = "NewTender";
                            var sendEmailResponse = sendEmailService.SendEmail(emailRequestdto);
                        }
                    }

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

        public async Task<IEnumerable<PostBidList>> GetPostBidApprovalList(long tenderId)
        {
            try
            {
                IEnumerable<PostBidList> postBidddingApprovalEntity = await tenderRepository.FetchPostBidApprovalList(tenderId);
                var result=await tenderRepository.FetchPostBidRemarks(tenderId,"PostBid");
                var obj = new PostBidDetail();
                if (result==null)
                {
                    return postBidddingApprovalEntity;
                }
                else
                {
                    foreach (var item in postBidddingApprovalEntity)
                    {
                        item.Message = result.Remarks;
                        item.Action = result.Status;
                    }
                    return postBidddingApprovalEntity;
                }
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
                procurementIdsList = procurementId?.Split(',')?.Select(Int32.Parse)?.ToList();

            }

            if (algoId != null)
            {
                algoIdsList = algoId?.Split(',')?.Select(Int32.Parse)?.ToList();

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
                    procurementIdsList = procurementId?.Split(',')?.Select(Int32.Parse)?.ToList();
                }

                if (algoId != null)
                {
                    algoIdsList = algoId?.Split(',')?.Select(Int32.Parse)?.ToList();
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
                    procurementIdsList = procurementId?.Split(',')?.Select(Int32.Parse)?.ToList();

                }

                if (algoId != null)
                {
                    algoIdsList = algoId?.Split(',')?.Select(Int32.Parse)?.ToList();

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
                var list = new List<TenderExtraDocumentEntity>();

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
                        list.Add(obj);
                    }
                }
                if (list.Count != 0)
                {
                    await tenderRepository.AddTenderDocuments(list);
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
                var tenderEntity = await tenderRepository.FindTenderToUpdate(dto.TenderId);
                if (tenderEntity != null)
                {
                    if (tenderEntity.StatusId == 3)
                    {
                        dto.Remarks="Conflict";
                        return dto;
                    }

                    CommunityApprovalEntity t = await tenderRepository.GetTenderEntityOfCompany(dto.TenderId, dto.CompanyId);
                    if (t != null)
                    {
                        t.StatusId = 3;//Approved
                        t.Date_Modified = DateTime.Now;
                        //t.ApprovedBy = dto.UserId;
                        tenderRepository.ApproveTenderByBidInviter(t);

                        await ToUpdateCommunityApprovalStatusInTender(tenderEntity);

                        return dto;
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

        private async Task ToUpdateCommunityApprovalStatusInTender(TenderEntity tenderEntity)
        {
            var check = await tenderRepository.CheckStatusInCommunityApproval(tenderEntity.Id);
            if (check == true)
            {
                tenderEntity.CommunityApprovalStatus = 3;
                await tenderRepository.UpdateTenderStatus(tenderEntity);
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

        public async Task<TenderApproveDto> PostBidApprove(TenderApproveDto verifyOtpDto)
        {
            try
            {
                var tenderEntity = await tenderRepository.FindTenderToUpdate(verifyOtpDto.TenderId);
                if(tenderEntity!=null)
                {
                    if (tenderEntity.PostBidStatus == 3)
                    {
                        verifyOtpDto.Remarks = "Conflict";
                        return verifyOtpDto;
                    }

                    var postBidEntity = await tenderRepository.FindPostBiddingApproval(verifyOtpDto.TenderId, verifyOtpDto.CompanyId);

                    if (postBidEntity != null)
                    {
                        postBidEntity.StatusId = 3;
                        postBidEntity.Date_Modified = DateTimeNPT.Now;
                        postBidEntity.RemarksStatusId = 0;

                        await tenderRepository.UpdatePostBidApprovalStatus(postBidEntity);

                        await ToUpdatePostSealBidStatusInTender(tenderEntity);

                        return verifyOtpDto;
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


        private async Task ToUpdatePostSealBidStatusInTender(TenderEntity tenderEntity)
        {
            var check = await tenderRepository.CheckStatusInPostBidApproval(tenderEntity.Id);
            if (check == true)
            {
                tenderEntity.PostBidStatus = 2; //Aprroved by all Bid Inviter
                await tenderRepository.UpdateTenderStatus(tenderEntity);
            }
        }

        public async Task<TenderApproveDto> PostBidRequestChanges(TenderApproveDto tenderApprove)
        {
            try
            {
                var tenderEntity = await tenderRepository.FindTenderToUpdate(tenderApprove.TenderId);
                if (tenderEntity != null)
                {
                    if (tenderEntity.PostBidStatus == 3)
                    {
                        tenderApprove.Remarks = "Conflict";
                        return tenderApprove;
                    }
                    var postBidEntity = await tenderRepository.FindPostBiddingApproval(tenderApprove.TenderId, tenderApprove.CompanyId);

                    if (postBidEntity != null)
                    {
                        postBidEntity.StatusId = 2;
                        postBidEntity.Date_Modified = DateTimeNPT.Now;
                        postBidEntity.RemarksStatusId = 1; //Outgoing Remarks for Bid Inviter

                        var postBidRemarksEntity = PostBidRemarksDtoEntity(tenderApprove, postBidEntity);
                        await tenderRepository.InsertIntoPostBidRemarks(postBidRemarksEntity);

                        await tenderRepository.UpdatePostBidApprovalStatus(postBidEntity);

                        return tenderApprove;
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

        public async Task<TenderEntity> AddSuperSeed(SuperSeedDto superSeedDto)
        {
            try
            {
                var result = await tenderRepository.FindTenderToUpdate(superSeedDto.TenderId);
                if (result != null)
                {
                    if (result.PostBidStatus == 2)
                    {
                        return result;
                    }

                    result.PostBidStatus = 3; //Approve by Admin

                    var postBidddingApprovalEntity = await tenderRepository.FindPostBiddingApprovalByTenderId(superSeedDto.TenderId);

                    if (postBidddingApprovalEntity.Count() == 0)
                    {
                        return null;
                    }
                    else
                    {
                        foreach (var item in postBidddingApprovalEntity)
                        {
                            item.StatusId = 4; //Superseeded by Admin
                            item.RemarksStatusId = 0;
                        }
                        await tenderRepository.UpdateTenderStatus(result);
                        await tenderRepository.UpdatePostBidApprovalStatusByTenderId(postBidddingApprovalEntity);

                        await AddToPostBiddingSuperSeed(superSeedDto);

                        return result;
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

        private async Task<StatDto> GetBidTypeCount(IEnumerable<dynamic> tenderEntities, string Role = null)
        {
            try
            {

                var response = await tenderRepository.AlgorithmList();
                var list = new List<CountDto>();

                if (Role == "Super Admin")
                {
                    foreach (var item in response)
                    {
                        var countDto = new CountDto()
                        {
                            Count = tenderEntities.Where(x => x.AlgoId == item.id).Count(),
                            Name = item.AlgoName,
                            Id = item.id
                        };
                        list.Add(countDto);
                    }
                }

                else if(Role=="Bid Inviter")
                {
                    foreach (var item in response)
                    {
                        var countDto = new CountDto()
                        {
                            Count = tenderEntities.Where(x => x.TenderEntities.AlgoId == item.id).Count(),
                            Name = item.AlgoName,
                            Id = item.id
                        };
                        list.Add(countDto);
                    }
                }
                else
                {
                    foreach (var item in response)
                    {
                        var countDto = new CountDto()
                        {
                            Count = tenderEntities.Where(x => x.Tender.AlgoId == item.id).Count(),
                            Name = item.AlgoName,
                            Id = item.id
                        };
                        list.Add(countDto);
                    }
                }
                var statDto = new StatDto
                {
                    Count = list,
                    Total = list.Sum(x => x.Count)
                };
                return statDto;
            }
            catch
            {

                throw;
            }
        }

        private async Task<StatDto> ProcurementTypeStatus(IEnumerable<dynamic> tenderEntities, IEnumerable<TenderProcurementTypeEntity> procurement, string Role=null)
        {
            try
            {
                var procurementList = new List<ProcurementTypeDto>();
                long companyTenders;

                if (Role == "Super Admin")
                {
                    var statustype = await tenderRepository.GetTenderStatusList();

                    foreach (var item in procurement)
                    {
                        var statusDtoList = new List<StatusDto>();

                        foreach (var status in statustype)
                        {
                            if (status.StatusId == 4)
                            {
                                companyTenders = tenderEntities.Where(t => DateTime.Compare(DateTimeNPT.Now, t.LiveEndDate) < 0 && t.StatusId == 3
                                                    && t.ProcurementId == item.Id).Count();
                            }
                            else if (status.StatusId == 5)
                            {
                                companyTenders = tenderEntities.Where(t=> t.LiveEndDate < DateTimeNPT.Now && t.StatusId == 3 && t.ProcurementId == item.Id).Count();

                            }
                            else if (status.StatusId==1)
                            {
                                companyTenders = tenderEntities.Where(t => t.StatusId == 1 && t.ProcurementId == item.Id && t.RegistrationTill >= DateTimeNPT.Now).Count();
                            }
                            else
                            {
                                companyTenders = tenderEntities.Where(t=> t.StatusId == status.StatusId && t.ProcurementId == item.Id).Count();

                            }

                            var statusDto = new StatusDto
                            {
                                Id = status.StatusId,
                                Name = status.Status,
                                Count = companyTenders
                            };
                            statusDtoList.Add(statusDto);
                        }
                        var obj = new ProcurementTypeDto
                        {
                            Name = item.Procurement,
                            statusDtos = statusDtoList,
                            Total = statusDtoList.Sum(x => x.Count)
                        };
                        procurementList.Add(obj);
                    }
                }
                else if (Role == "Bid Inviter")
                {
                    var statustype = await tenderRepository.GetTenderStatusList();

                    foreach (var item in procurement)
                    {
                        var statusDtoList = new List<StatusDto>();

                        foreach (var status in statustype)
                        {
                            if (status.StatusId == 1)
                            {
                                companyTenders= tenderEntities.Where(x =>x.TenderEntities.StatusId == 1
                                && x.TenderEntities.RegistrationTill >= DateTimeNPT.Now 
                                                           && x.TenderEntities.ProcurementId == item.Id).Count();
                            }
                            else if (status.StatusId == 2)
                            {
                                companyTenders = tenderEntities.Where(x => x.TenderEntities.StatusId == 2
                                                          && x.TenderEntities.ProcurementId == item.Id).Count();
                            }
                            else if (status.StatusId == 3)
                            {

                                companyTenders = tenderEntities.Where(x => x.TenderEntities.StatusId == 3
                              && x.TenderEntities.LiveStartDate > DateTimeNPT.Now 
                                                         && x.TenderEntities.ProcurementId == item.Id).Count();
                            }
                            else if (status.StatusId == 4)
                            {
                                companyTenders = tenderEntities.Where(x => x.TenderEntities.StatusId == 3
                              && x.TenderEntities.LiveStartDate <= DateTimeNPT.Now && x.TenderEntities.LiveEndDate > DateTimeNPT.Now 
                                                         && x.TenderEntities.ProcurementId == item.Id).Count();
                            }
                            else if (status.StatusId == 5)
                            {
                                companyTenders = tenderEntities.Where(x => x.TenderEntities.StatusId == 3
                               && x.TenderEntities.LiveEndDate < DateTimeNPT.Now 
                                                         && x.TenderEntities.ProcurementId == item.Id).Count();
                            }
                            else
                            {
                                companyTenders = tenderEntities.Where(x => x.TenderEntities.StatusId == status.StatusId
                                                        && x.TenderEntities.ProcurementId == item.Id).Count();
                            }

                            var statusDto = new StatusDto
                            {
                                Id = status.StatusId,
                                Name = status.Status,
                                Count = companyTenders
                            };

                            statusDtoList.Add(statusDto);
                        }
                        var obj = new ProcurementTypeDto
                        {
                            Name = item.Procurement,
                            statusDtos = statusDtoList,
                            Total= statusDtoList.Sum(x => x.Count)
                        };
                        procurementList.Add(obj);
                    }
                }
                else
                {
                    foreach (var item in procurement)
                    {
                        var statusDtoList = new List<StatusDto>();
                        var bidderstatus = await tenderRepository.GetBidderStatus();

                        foreach (var status in bidderstatus)
                        {
                            if (status.StatusId == 1 || status.StatusId == 3)
                            {
                                companyTenders = tenderEntities.Where(x => x.BidRequestStatusId == status.StatusId && x.Tender.RegistrationTill >= DateTimeNPT.Now
                && x.Tender.ProcurementId == item.Id).Count();
                            }
                            else
                            {
                                companyTenders = tenderEntities.Where(x => x.BidRequestStatusId == status.StatusId
                && x.Tender.ProcurementId == item.Id).Count();
                            }
                            var statusDto = new StatusDto
                            {
                                Id = status.StatusId,
                                Name = status.Status,
                                Count = companyTenders
                            };

                            statusDtoList.Add(statusDto);
                        }
                        var obj = new ProcurementTypeDto
                        {
                            Name = item.Procurement,
                            statusDtos = statusDtoList,
                            Total= statusDtoList.Sum(x => x.Count)
                        };
                        procurementList.Add(obj);
                    }
                }


                var statDto = new StatDto
                {
                    procurementTypeDtos = procurementList,
                    Total = procurementList.Sum(x => x.Total)
                };
                return statDto;
            }
            catch
            {

                throw;
            }
        }

        public async Task<Dictionary<string, StatDto>> GetAdminDashboard()
        {
            try
            {
                var dashboard = new Dictionary<string, StatDto>();

                var tenderEntities = await tenderRepository.GetAllTender();
                var procurementtype = await tenderRepository.GetProcurementList();

                var biddingStageCount = await BiddingStageCount(tenderEntities, Role:"Super Admin");

                var biddingStageCountobj = new StatDto
                {
                    Count = biddingStageCount
                };


                dashboard.Add("BiddingStageCount", biddingStageCountobj);

                var bidType = await GetBidTypeCount(tenderEntities, Role: "Super Admin");
                dashboard.Add("TypeOfBid", bidType);

                var ongoingPreBiddingCount = await OngoingPreBiddingCount(procurementtype, tenderEntities, "Super Admin");
                dashboard.Add("OngoingPreBiddingCount", ongoingPreBiddingCount);

                var ongoingPostBiddingCount = await OngoingPostBiddingCount(procurementtype, tenderEntities);
                dashboard.Add("OngoingPostBiddingCount", ongoingPostBiddingCount);

                var procurementTypeStatus = await ProcurementTypeStatus(tenderEntities, procurementtype,Role: "Super Admin");
                dashboard.Add("UpcomingPendingBidofProcurementType", procurementTypeStatus);

                var graphdata = await GraphData();
                dashboard.Add("GraphData", graphdata);

                var upcomingBid = new StatDto();
                upcomingBid.Total = tenderEntities.Where(t => t.StatusId == 3 && (t.LiveStartDate.AddDays(-7) <= DateTimeNPT.Now)
                                        && (t.LiveEndDate >= DateTimeNPT.Now)).Count();
                dashboard.Add("UpcomingBids", upcomingBid);

                var liveBid = new StatDto();
                liveBid.Total = tenderEntities.Where(t => DateTime.Compare(DateTimeNPT.Now, t.LiveEndDate) < 0 && t.StatusId == 3).Count();
                dashboard.Add("OngoingTenders", liveBid);

                return dashboard;
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

                obj.graphDatas = graphDataDto;
                return obj;
            }
            catch 
            {

                throw;
            }
        }
        public async Task<Dictionary<string, StatDto>> GetBidInviterDashboard(long companyId)
        {
            try
            {
                var tenederEntities = await tenderRepository.GetAllTender();
                var communityApprovalEntities = await tenderRepository.GetAllCommunityApproval(companyId);
                var procurementtype = await tenderRepository.GetProcurementList();

                var dashboard = new Dictionary<string, StatDto>();

                var biddingStageCount = await BiddingStageCount(tenederEntities, communityApprovalEntities, "Bid Inviter");

                var biddingStageCountobj = new StatDto
                {
                    Count = biddingStageCount
                };

                dashboard.Add("BiddingStageCount",biddingStageCountobj);

                var bidType = await GetBidTypeCount(communityApprovalEntities, "Bid Inviter");
                dashboard.Add("TypeOfBid", bidType);

                var ongoingPreBiddingCount = await OngoingPreBiddingCount(procurementtype,communityApprovalEntities);
                dashboard.Add("OngoingPreBiddingCount", ongoingPreBiddingCount);

                var ongoingPostBiddingCount = await OngoingPostBiddingCount(procurementtype, tenederEntities,companyId);
                dashboard.Add("OngoingPostBiddingCount", ongoingPostBiddingCount);

                var procurementTypeStatus = await ProcurementTypeStatus(communityApprovalEntities, procurementtype,  "Bid Inviter");
                dashboard.Add("UpcomingPendingBidofProcurementType", procurementTypeStatus);

                var graphdata = await GraphData();
                dashboard.Add("GraphData", graphdata);

                var upcomingBid = new StatDto();
                upcomingBid.Total = communityApprovalEntities.Where(t => t.TenderEntities.StatusId == 3 //Tender should be approved
                                        && (t.TenderEntities.LiveStartDate.AddDays(-3) <= DateTimeNPT.Now)
                                        && (t.TenderEntities.LiveEndDate >= DateTimeNPT.Now)).Count();
                dashboard.Add("UpcomingBids", upcomingBid);

                var liveBid = new StatDto();
                liveBid.Total = communityApprovalEntities.Where(t => DateTime.Compare(DateTimeNPT.Now, t.TenderEntities.LiveEndDate) < 0 && t.TenderEntities.StatusId == 3).Count();
                dashboard.Add("OngoingTenders", liveBid);

                return dashboard;
            }
            catch
            {

                throw;
            }
        }

        public async Task<Dictionary<string, StatDto>> GetBidderDashboard(long companyId)
        {
            try
            {
                var tenederEntities = await tenderRepository.GetAllTender();
                var bidderEntities = await tenderRepository.GetBidRequestEntities(companyId);
                var procurementtype = await tenderRepository.GetProcurementList();

                var dashboard = new Dictionary<string, StatDto>();

                var biddingStageCount = await BiddingStageCount(tenederEntities, bidderEntities);

                var biddingStageCountobj = new StatDto
                {
                    Count = biddingStageCount
                };

                dashboard.Add("BiddingStageCount", biddingStageCountobj);

                var bidType = await GetBidTypeCount(bidderEntities);
                dashboard.Add("TypeOfBid", bidType);

                var procurementTypeStatus = await ProcurementTypeStatus(bidderEntities, procurementtype);
                dashboard.Add("UpcomingPendingBidofProcurementType", procurementTypeStatus);

                var upcomingBid = new StatDto();
                upcomingBid.Total = bidderEntities.Where(t => t.Tender.StatusId == 3 //Tender should be approved
                                        && t.BidRequestStatusId == 2 //Bid request should be approved
                                        && (t.Tender.LiveStartDate.AddDays(-3) <= DateTimeNPT.Now)//Tender live date should be within next 7 days
                                        && (t.Tender.LiveEndDate >= DateTimeNPT.Now)).Count();
                dashboard.Add("UpcomingBids", upcomingBid);

                var liveBid = new StatDto();
                liveBid.Total = bidderEntities.Where(t => DateTime.Compare(DateTimeNPT.Now, t.Tender.LiveEndDate) < 0 && t.Tender.StatusId == 3).Count();
                dashboard.Add("OngoingTenders", liveBid);

                return dashboard;
            }
            catch
            {

                throw;
            }
        }
        private async Task<StatDto> OngoingPreBiddingCount(IEnumerable<TenderProcurementTypeEntity> procurement, IEnumerable<dynamic> tenderEntities,string Role=null)
        {
            try
            {
                var obj = new StatDto();
                var list = new List<CountDto>();

                if (Role == "Super Admin")
                {
                    foreach (var item in procurement)
                    {
                        var countDto = new CountDto
                        {
                            Id = item.Id,
                            Name = item.Procurement,
                            Count = tenderEntities.Where(x => ((x.StatusId == 1 && x.RegistrationTill >= DateTimeNPT.Now) || x.StatusId==2) && x.ProcurementId == item.Id 
                            && x.CommunityApprovalEntities.Count != 0).Count()
                        };
                        list.Add(countDto);
                    }
                }
                else
                {
                    foreach (var item in procurement)
                    {
                        var countDto = new CountDto
                        {
                            Id = item.Id,
                            Name = item.Procurement,
                            Count = tenderEntities.Where(x => ((x.TenderEntities.StatusId == 1 && x.TenderEntities.RegistrationTill >= DateTimeNPT.Now) || x.TenderEntities.StatusId == 2) && 
                            x.TenderEntities.ProcurementId == item.Id).Count()
                        };
                        list.Add(countDto);
                    }
                }
                obj.Count = list;
                obj.Total = list.Sum(x => x.Count);
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<StatDto> OngoingPostBiddingCount(IEnumerable<TenderProcurementTypeEntity> procurement, IEnumerable<TenderEntity> tenderEntities, long companyId = 0)
        {
            try
            {
                var obj = new StatDto();
                var list = new List<CountDto>();

                if (companyId == 0)
                {
                    foreach (var item in procurement)
                    {
                        var countDto = new CountDto
                        {
                            Id = item.Id,
                            Name = item.Procurement,
                            Count = tenderEntities.Where(x => x.PostBidStatus < 3  && x.ProcurementId == item.Id && x.PostBidddingApprovalEntities.Count!=0).Count()
                        };
                        list.Add(countDto);
                    }
                }
                else
                {
                    foreach (var item in procurement)
                    {
                        var countDto = new CountDto
                        {
                            Id = item.Id,
                            Name = item.Procurement,
                            Count = await tenderRepository.GetOngoingPostBiddingCountBidInviter(companyId, item.Id)
                        };
                        list.Add(countDto);
                    }
                }
                obj.Count = list;
                obj.Total = list.Sum(x => x.Count);
                return obj;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<List<CountDto>> BiddingStageCount(IEnumerable<TenderEntity> tenderEntities=null, IEnumerable<dynamic> communityApprovalEntities=null,string Role=null)
        {
            try
            {
                var countDtos = new List<CountDto>();

                var getMarketplaceTenderobj = new CountDto
                {
                    Id = 1,
                    Name = "Market Place",
                    Count = tenderEntities.Where(t => t.StatusId == 3 && DateTime.Compare(t.RegistrationTill, DateTimeNPT.Now) > 0).Count()
                };
                countDtos.Add(getMarketplaceTenderobj);

                if (Role == "Super Admin") //FOr Addmin
                {
                    var companyTendersForAdminobj = new CountDto
                    {
                        Id = 3,
                        Name = "Pending",
                        Count = tenderEntities.Where(t =>(t.RegistrationTill >= DateTimeNPT.Now && t.StatusId == 1) || t.StatusId==2).Count()
                    };
                    countDtos.Add(companyTendersForAdminobj);

                    var historyobj = new CountDto
                    {
                        Id = 4,
                        Name = "History",
                        Count = tenderEntities.Where(t => t.LiveEndDate < DateTimeNPT.Now && t.StatusId == 3).Count()
                    };
                    countDtos.Add(historyobj);

                    var upcomingTenderForAdminobj = new CountDto
                    {
                        Id = 5,
                        Name = "Rejected",
                        Count = tenderEntities.Where(t => t.StatusId == 6).Count()
                    };
                    countDtos.Add(upcomingTenderForAdminobj);

                    return countDtos;
                }
                else if(Role=="Bid Inviter")
                {
                    var companyTendersForBidInviterobj = new CountDto
                    {
                        Id = 3,
                        Name = "Pending",
                        Count = communityApprovalEntities.Where(t => (t.TenderEntities.RegistrationTill >= DateTimeNPT.Now && t.TenderEntities.StatusId == 1) 
                        || t.TenderEntities.StatusId == 2).Count()
                    };
                    countDtos.Add(companyTendersForBidInviterobj);

                    var historyobj = new CountDto
                    {
                        Id = 4,
                        Name = "History",
                        Count = communityApprovalEntities.Where(t => t.TenderEntities.StatusId == 3 && t.TenderEntities.LiveEndDate < DateTimeNPT.Now).Count()
                    };
                    countDtos.Add(historyobj);

                    var upcomingTenderForBidInviterobj = new CountDto
                    {
                        Id = 5,
                        Name = "Rejected",
                        Count = communityApprovalEntities.Where(t => t.TenderEntities.StatusId == 6).Count()
                    };
                    countDtos.Add(upcomingTenderForBidInviterobj);
                }
                else
                {
                    var companyTendersForAdminobj = new CountDto
                    {
                        Id = 3,
                        Name = "Pending",
                        Count = communityApprovalEntities.Where(x=> (x.BidRequestStatusId == 1 || x.BidRequestStatusId == 3) 
                        && x.Tender.RegistrationTill>=DateTimeNPT.Now).Count()
                    };
                    countDtos.Add(companyTendersForAdminobj);

                    var historyobj = new CountDto
                    {
                        Id = 4,
                        Name = "History",
                        Count = communityApprovalEntities.Where(x=> x.Tender.LiveEndDate < DateTimeNPT.Now).Count()
                    };
                    countDtos.Add(historyobj);

                    var upcomingTenderForBidderobj = new CountDto
                    {
                        Id = 5,
                        Name = "Rejected",
                        Count = communityApprovalEntities.Where(t => t.Tender.StatusId == 6).Count()
                    };
                    countDtos.Add(upcomingTenderForBidderobj);
                }
                return countDtos;

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
                if (Rank == "Winner")
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
                var newBidRequestEntity = await tenderRepository.GetBidRequestEntity(qualifiedOrWinnerDto.CompanyId, qualifiedOrWinnerDto.TenderId);
                newBidRequestEntity.IsWinner = true;
                newBidRequestEntity.WonDate = DateTimeNPT.Now;
                await tenderRepository.UpdateQualifiedStatusinBidRequest(newBidRequestEntity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<TenderExtraDocumentResponseDto>> DeleteDocument(long id,string baseUrl)
        {
            try
            {
                var entity = await tenderRepository.FetchTenderExtraDocumentById(id);

                if (entity == null)
                {
                    return null;
                }
                else
                {
                    await uploadFileService.DeleteFile(entity.DocPath);
                    entity.IsDeleted = true;
                    await tenderRepository.UpdateTenderExtraDocument(entity);

                    var documentEntities = await tenderRepository.FetchTenderExtraDocumentByTenderId(entity.TenderId);
                    if (documentEntities.Count() == 0)
                    {
                        return null;
                    }
                    else
                    {
                        var list = new List<TenderExtraDocumentResponseDto>();

                        foreach (var item in documentEntities)
                        {
                            var obj = new TenderExtraDocumentResponseDto
                            {
                                Id = item.Id,
                                DocTitle = item.DocTitle,
                                DocPath = String.IsNullOrEmpty(item.DocPath) ? "" : $"{baseUrl}{item.DocPath.Replace('\\', '/')}"
                            };
                            list.Add(obj);
                        }
                        return list;
                    }
                }
            }
            catch 
            {

                throw;
            }
        }

        public Task SendWeeklyNewTenderEmailToSupplier()
        {
            return Task.Run(async () =>
            {
                var newTenders = await tenderRepository.GetWeeklyTender();
                if (newTenders.Count() != 0)
                {
                    var supplierEmail = await tenderRepository.FetchEmailFromUser();
                    EmailRequestdto emailRequestdto = new EmailRequestdto();
                    emailRequestdto.toEmailIds = supplierEmail;
                    emailRequestdto.Tenders = newTenders;
                    emailRequestdto.callFrom = "WeeklyNewTenderEmail";
                    var sendEmailResponse = sendEmailService.SendEmail(emailRequestdto);
                }
            });
        }

        public Task MoveTenderToRejected()
        {
            return Task.Run(async () =>
            {
                var tenders = await tenderRepository.GetTenderToReject();
                if (tenders.Count() != 0)
                {
                    foreach (var item in tenders)
                    {
                        item.StatusId = 6;
                    }
                    await tenderRepository.UpdateTenderEntitiesStatus(tenders);
                }
            });
        }
    }
}
