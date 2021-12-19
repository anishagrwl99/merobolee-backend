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
        Task<TenderSubmission> UpdateTenderSubmissionByForm(TenderSubmissionUpdateRequestDto obj);
        Task<TenderSubmission> CreateTenderSubmissionByDocument(TenderSubmissionExternalDocumentRequestDto obj);
        Task<TenderSubmission> UpdateTenderSubmissionByDocument(TenderSubmissionExternalDocumentUpdateRequestDto obj);
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
        private IUploadFile docService;
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
            this.docService = uploadFileService;
            this.docRepo = docRepo;
        }

        public async Task<TenderSubmission> CreateTenderSubmissionByForm(TenderSubmissionRequestDto obj)
        {
            try
            {
                TenderSubmission ts = ToEntity(obj);
                string companyFolder = docRepo.GetCompanyFolder(obj.CompanyId);
                string docPath = companyFolder + $"\\TenderSubmission\\{DateTime.Now.Ticks}";
                if (obj.PriceScheduleDoc != null)
                {

                    ts.PriceScheduleDocName = obj.PriceScheduleDoc.FileName;
                    ts.PriceScheduleDocPath = await docService.Upload(obj.PriceScheduleDoc, docPath);
                }

                if (obj.AdditionalDocuments != null && obj.AdditionalDocuments.Count > 0)
                {
                    ts.AdditionalDocuments = new List<TenderSubmissionAdditionalDocument>();
                    foreach (var item in obj.AdditionalDocuments)
                    {
                        TenderSubmissionAdditionalDocument doc = new TenderSubmissionAdditionalDocument
                        {
                            TenderSubmissionId = ts.SubmissionId,
                            DocTitle = item.DocTitle,
                            DocPath = await docService.Upload(item.Document, docPath)
                        };
                        ts.AdditionalDocuments.Add(doc);
                    }
                }

                ts = submissionRepository.Add(ts);
                return ts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TenderSubmission> UpdateTenderSubmissionByForm(TenderSubmissionUpdateRequestDto obj)
        {
            try
            {
                TenderSubmission submission = await submissionRepository.GetDetailById(obj.SubmissionId);
                await DeleteTenderSubmissionDocuments(submission.TenderSubmissionDocuments);
                submission.TenderSubmissionDocuments.Clear();
                ToEntity(ref submission, obj);
                string docPath = docRepo.GetCompanyFolder(obj.CompanyId) + $"\\TenderSubmission\\{DateTime.Now.Ticks}";
                if (obj.PriceScheduleDoc != null)
                {
                    await docService.DeleteFile(submission.PriceScheduleDocPath);
                    submission.PriceScheduleDocName = obj.PriceScheduleDoc.FileName;
                    submission.PriceScheduleDocPath = await docService.Upload(obj.PriceScheduleDoc, docPath);
                }

                if (obj.AdditionalDocuments != null && obj.AdditionalDocuments.Count > 0)
                {
                    submission.AdditionalDocuments = new List<TenderSubmissionAdditionalDocument>();
                    foreach (var item in obj.AdditionalDocuments)
                    {
                        if(item.Id > 0 )
                        {
                            TenderSubmissionAdditionalDocument doc = submission
                                                                    .AdditionalDocuments
                                                                    .Where(x => x.Id == item.Id)
                                                                    .FirstOrDefault();
                            doc.DocTitle = item.DocTitle;
                            await docService.DeleteFile(doc.DocPath);
                            doc.DocPath = await docService.Upload(item.Document, docPath);
                        }
                        else
                        {
                            submission.AdditionalDocuments.Add(new TenderSubmissionAdditionalDocument
                            {
                                DocTitle = item.DocTitle,
                                DocPath = await docService.Upload(item.Document, docPath)
                            });
                        }
                    }
                }

                submission = await submissionRepository.Update(submission);
                return submission;
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
                        string uploadPath = await docService.Upload(item.Document, docPath);
                        docs.Add(new TenderSubmissionDocumentResponseDto
                        {
                            DocumentName = item.DocTitle,
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

        public async Task<TenderSubmission> UpdateTenderSubmissionByDocument(TenderSubmissionExternalDocumentUpdateRequestDto obj)
        {
            try
            {
                TenderSubmission submission = await submissionRepository.GetDetailById(obj.SubmissionId);
                await DeleteTenderSubmissionDocuments(submission.TenderSubmissionDocuments);

                List<TenderSubmissionDocumentResponseDto> docs = new List<TenderSubmissionDocumentResponseDto>();

                if (obj.Documents != null && obj.Documents.Count > 0)
                {
                    string docPath = docRepo.GetCompanyFolder(obj.CompanyId) + $"\\TenderSubmission\\{DateTime.Now.Ticks}";
                    foreach (var item in obj.Documents)
                    {
                        string uploadPath = await docService.Upload(item.Document, docPath);
                        docs.Add(new TenderSubmissionDocumentResponseDto
                        {
                            DocumentName = item.DocTitle,
                            DocumentPath = uploadPath
                        });
                    }
                }
                submission.CreatedBy = obj.CreatedBy;
                submission.PaymentProvider = obj.PaymentProvider;
                submission.PaymentReferenceCode = obj.PaymentReferenceCode;
                submission.Amount = obj.Amount;
                submission.Title = obj.Title;
                submission.PriceScheduleDocName = null;
                submission.PriceScheduleDocPath = null;
                submission.Date_modified = DateTime.Now;
                submission.SubmissionId = obj.SubmissionId;
                submission.TenderSubmissionDocuments = (from d in docs
                                                        select new TenderSubmissionDocuments
                                                        {
                                                            SubmissionId = obj.SubmissionId,
                                                            DocumentName = d.DocumentName,
                                                            DocumentPath = d.DocumentPath
                                                        }).ToList();

                submission.ProductSpecifications.Clear();
                submission.PurchaseCriterias.Clear();
                submission.PriceSchedules.Clear();
                submission.EligibilityCriterias.Clear();

                submission = await submissionRepository.Update(submission);
                return submission;
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
                bool fileExists = await docService.FileExists(user.ProfilePicture);
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

        private async Task DeleteTenderSubmissionDocuments(IEnumerable<TenderSubmissionDocuments> documents)
        {
            foreach (var item in documents)
            {
                string docPath = item.DocumentPath;
                await docService.DeleteFile(docPath);
            }
        }

    }
}
