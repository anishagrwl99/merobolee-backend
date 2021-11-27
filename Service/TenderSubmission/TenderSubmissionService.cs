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
    public interface ITenderSubmissionService
    {
        Task<TenderSubmission> CreateTenderSubmissionByForm(TenderSubmissionRequestDto obj);
        Task<TenderSubmission> CreateTenderSubmissionByDocument(TenderSubmissionExternalDocumentRequestDto obj);
        Task<TenderSubmission> MakePayment(TenderSubmissionPaymentRequestDto obj);
        Task<List<TenderSubmissionCard>> BidInviterTenderSubmission(long companyId, long userId);
        Task<List<TenderSubmissionCard>> AdminTenderSubmission();
        Task<TenderResponseSubmissionDto> TenderSubmissionDetail(long tenderSubmissionId, string baseUrl, string defaultPic);
        Task<TenderResponseSubmissionDto> TenderSubmissionDetail(long tenderSubmissionId, long companyId, long userId, string baseUrl, string defaultPic);
        Task<TenderSubmission> AdminChangeStatus(ChangeSubmissionStatusDto dto);
    }
    public class TenderSubmissionService : TenderSubmissionMapper, ITenderSubmissionService
    {
        private readonly ITenderSubmissionRepository submissionRepository;
        private IUploadFile uploadImage;
        private readonly ICompanyDocumentRepository docRepo;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="submissionRepository"></param>
        /// <param name="uploadFileService"></param>
        /// <param name="docRepo"></param>
        public TenderSubmissionService(ITenderSubmissionRepository submissionRepository, IUploadFile uploadFileService, ICompanyDocumentRepository docRepo)
        {
            this.submissionRepository = submissionRepository;
            this.uploadImage = uploadFileService;
            this.docRepo = docRepo;
        }

        public async Task<TenderSubmission> CreateTenderSubmissionByForm(TenderSubmissionRequestDto obj)
        {
            try
            {
                TenderSubmission ts = ToEntity(obj);
                if (obj.PriceScheduleDoc != null)
                {
                    string docPath = docRepo.GetCompanyFolder(obj.CompanyId) + $"\\TenderSubmission\\{DateTime.Now.Ticks}";
                    ts.PriceScheduleDocName = obj.PriceScheduleDoc.FileName;
                    ts.PriceScheduleDocPath = await uploadImage.Upload(obj.PriceScheduleDoc, docPath);
                }
               
                ts = submissionRepository.Add(ts);
                return ts;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TenderSubmission> CreateTenderSubmissionByDocument(TenderSubmissionExternalDocumentRequestDto obj)
        {
            try
            {
                List<TenderSubmissionDocumentResponseDto> docs = new List<TenderSubmissionDocumentResponseDto>();

                if (obj.Documents != null && obj.Documents.Count > 0)
                {
                    string docPath = docRepo.GetCompanyFolder(obj.CompanyId) + $"\\TenderSubmission\\{DateTime.Now.Ticks}";
                    foreach (var item in obj.Documents)
                    {
                        string uploadPath = await uploadImage.Upload(item, docPath);
                        docs.Add(new TenderSubmissionDocumentResponseDto
                        {
                            DocumentName = item.Name,
                            DocumentPath = uploadPath
                        });
                    }
                }
                TenderSubmission ts = ToEntity(obj, docs);
                ts = submissionRepository.Add(ts);
                return ts;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<TenderSubmission> MakePayment(TenderSubmissionPaymentRequestDto obj)
        {
            try
            {
                TenderSubmission ent = await submissionRepository.GetById(obj.SubmissionId);
                if (ent != null)
                {
                    ent.PaymentProvider = obj.PaymentProvider;
                    ent.PaymentReferenceCode = obj.PaymentReferenceCode;
                    ent.Amount = obj.PaymentAmount;
                    ent.Date_modified = DateTime.Now;
                    ent.StatusId = 2;//Move to pending
                    await submissionRepository.Update(ent);
                }
                return ent;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<TenderSubmissionCard>> BidInviterTenderSubmission(long companyId, long userId)
        {
            try
            {
                List<TenderSubmission> list = await submissionRepository.BidInviterTenderSubmissions(companyId, userId);
                List<TenderSubmissionCard> cards = ToCards(list);
                return cards;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<TenderSubmissionCard>> AdminTenderSubmission()
        {
            try
            {
                List<TenderSubmission> list = await submissionRepository.AdminTenderSubmissions();
                List<TenderSubmissionCard> cards = ToCards(list);
                return cards;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<TenderResponseSubmissionDto> TenderSubmissionDetail(long tenderSubmissionId, string baseUrl, string defaultPic)
        {
            try
            {
                TenderSubmission submission = await submissionRepository.GetDetailById(tenderSubmissionId);
                if (submission != null)
                {
                    submission.CreatedByUser.ProfilePicture = await GetProfilePic(submission.CreatedByUser, defaultPic, baseUrl);
                    if (submission.UpdatedByUser != null)
                    {
                        submission.UpdatedByUser.ProfilePicture = await GetProfilePic(submission.UpdatedByUser, defaultPic, baseUrl);
                    }
                    TenderResponseSubmissionDto res = ToDto(submission, baseUrl);
                    return res;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TenderResponseSubmissionDto> TenderSubmissionDetail(long tenderSubmissionId, long companyId, long userId, string baseUrl, string defaultPic)
        {
            try
            {
                TenderSubmission submission = await submissionRepository.GetDetailById(tenderSubmissionId, companyId, userId);
                if (submission != null)
                {
                    submission.CreatedByUser.ProfilePicture = await GetProfilePic(submission.CreatedByUser, defaultPic, baseUrl);
                    if (submission.UpdatedByUser != null)
                    {
                        submission.UpdatedByUser.ProfilePicture = await GetProfilePic(submission.UpdatedByUser, defaultPic, baseUrl);
                    }
                    TenderResponseSubmissionDto res = ToDto(submission, baseUrl);
                    return res;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TenderSubmission> AdminChangeStatus(ChangeSubmissionStatusDto dto)
        {
            try
            {
                TenderSubmission ent = await submissionRepository.GetById(dto.SubmissionId);
                if (ent != null)
                {

                    ent.Date_modified = DateTime.Now;
                    ent.StatusId = dto.StatusId;
                    ent.UpdatedBy = dto.UserId;
                    await submissionRepository.Update(ent);
                }
                return ent;
            }
            catch (Exception)
            {

                throw;
            }
        }


        private async Task<string> GetProfilePic(UserEntity user, string defaultPic, string basePath)
        {
            if (!string.IsNullOrEmpty(user.ProfilePicture))
            {
                bool fileExists = await uploadImage.FileExists(user.ProfilePicture);
                if (!fileExists)
                {
                    return defaultPic;
                }
                else
                {
                    return $"{basePath}{user.ProfilePicture.Replace("\\", "/")}";
                }
            }
            else
            {
                return defaultPic;
            }
        }

    }
}
