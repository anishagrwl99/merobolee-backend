using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class TenderSubmissionMapper
    {

        public TenderSubmission ToEntity(TenderSubmissionRequestDto dto)
        {
            if (dto == null) return null;
            TenderSubmission tenderSubmission = new TenderSubmission
            {
                CreatedBy = dto.CreatedBy,
                CompanyId = dto.CompanyId,
                PaymentProvider = dto.PaymentProvider,
                PaymentReferenceCode = dto.PaymentReferenceCode,
                Amount = dto.Amount,
                Title = dto.Title,
                IsFormSubmission = true,
                Date_created = DateTime.Now,
                Date_modified = DateTime.Now,
                StatusId = string.IsNullOrEmpty(dto.PaymentReferenceCode) ? 1 : 2
            };
            tenderSubmission.ProductSpecifications = (from ps in dto.ProductSpecifications
                                                      select new TenderSubmissionProductSpec
                                                      {
                                                          SpecificationName = ps.SpecificationName,
                                                          SpecificationValue = ps.SpecificationValue,
                                                          TenderSubmissionId = tenderSubmission.SubmissionId
                                                      }).ToList();

            tenderSubmission.PurchaseCriterias = (from pc in dto.PurchaseCriterias
                                                  select new TenderSubmissionPurchaseCriteria
                                                  {
                                                      SN = pc.SN,
                                                      CriteriaName = pc.CriteriaName,
                                                      Remarks = pc.Remarks,
                                                      TenderSubmissionId = tenderSubmission.SubmissionId
                                                  }).ToList();

            tenderSubmission.PriceSchedules = (from ps in dto.PriceSchedules
                                               select new TenderSubmissionPriceSchedule
                                               {
                                                   ScheduleName = ps.ScheduleName,
                                                   ScheduleValue = ps.ScheduleValue,
                                                   TenderSubmissionId = tenderSubmission.SubmissionId
                                               }).ToList();

            tenderSubmission.EligibilityCriterias = (from ec in dto.EligibilityCriterias
                                                     select new TenderSubmissionEligibilityCriteria
                                                     {
                                                         SN = ec.SN,
                                                         CriteriaName = ec.CriteriaName,
                                                         Remarks = ec.Remarks,
                                                         TenderSubmissionId = tenderSubmission.SubmissionId
                                                     }).ToList();

            return tenderSubmission;
        }

        public TenderSubmission ToEntity(TenderSubmissionExternalDocumentRequestDto dto, List<TenderSubmissionDocumentResponseDto> doc)
        {
            if (dto == null) return null;
            TenderSubmission tenderSubmission = new TenderSubmission
            {
                CreatedBy = dto.CreatedBy,
                CompanyId = dto.CompanyId,
                PaymentProvider = dto.PaymentProvider,
                PaymentReferenceCode = dto.PaymentReferenceCode,
                Amount = dto.Amount,
                Title = dto.Title,
                IsFormSubmission = false,
                PriceScheduleDocName = null,
                PriceScheduleDocPath = null,
                Date_created = DateTime.Now,
                Date_modified = DateTime.Now,
                StatusId = string.IsNullOrEmpty(dto.PaymentReferenceCode) ? 1 : 2
            };
            tenderSubmission.TenderSubmissionDocuments = (from d in doc
                                                          select new TenderSubmissionDocuments
                                                          {
                                                              SubmissionId = tenderSubmission.SubmissionId,
                                                              DocumentName = d.DocumentName,
                                                              DocumentPath = d.DocumentPath
                                                          }).ToList();
            return tenderSubmission;
        }

        public TenderResponseSubmissionDto ToDto(TenderSubmission ent, string basePath)
        {
            if (ent == null) return null;
            TenderResponseSubmissionDto resp = new TenderResponseSubmissionDto
            {
                Id = ent.SubmissionId,
                UserId = ent.CreatedBy,
                CompanyId = ent.CompanyId,
                Title = ent.Title,
                PaymentProvider = ent.PaymentProvider,
                PaymentReferenceCode = ent.PaymentReferenceCode,
                Amount = ent.Amount,
                Status = ent.TenderSubmissionStatus.Status,
                IsFormSubmission = ent.IsFormSubmission,
                PriceScheduleDocName = ent.PriceScheduleDocName,
                PriceScheduleDocPath = string.IsNullOrEmpty(ent.PriceScheduleDocPath) ? null : $"{basePath}{ent.PriceScheduleDocPath.Replace("\\", "/")}"
            };

            if (ent.IsFormSubmission)
            {
                resp.ProductSpecifications = (from ps in ent.ProductSpecifications
                                              select new TenderSubmissionProductSpecResponseDto
                                              {
                                                  Id = ps.SpecificationId,
                                                  SpecificationName = ps.SpecificationName,
                                                  SpecificationValue = ps.SpecificationValue
                                              }).ToList();

                resp.PurchaseCriterias = (from pc in ent.PurchaseCriterias
                                          select new TenderSubmissionPurchaseCriteriaResponseDto
                                          {
                                              Id = pc.PurchaseCriteriaId,
                                              SN = pc.SN,
                                              CriteriaName = pc.CriteriaName,
                                              Remarks = pc.Remarks
                                          }).ToList();

                resp.PriceSchedules = (from ps in ent.PriceSchedules
                                       select new TenderSubmissionPriceScheduleResponseDto
                                       {
                                           Id = ps.PriceScheduleId,
                                           ScheduleName = ps.ScheduleName,
                                           ScheduleValue = ps.ScheduleValue
                                       }).ToList();

                resp.EligibilityCriterias = (from es in ent.EligibilityCriterias
                                             select new TenderSubmissionEligibilityCriteriaResponseDto
                                             {
                                                 Id = es.EligibilityCriteriaId,
                                                 SN = es.SN,
                                                 CriteriaName = es.CriteriaName,
                                                 Remarks = es.Remarks
                                             }).ToList();




            }
            else
            {
                resp.Documents = (from d in ent.TenderSubmissionDocuments
                                  select new TenderSubmissionDocumentResponseDto
                                  {
                                      DocumentId = d.SubmissionDocumentId,
                                      DocumentName = d.DocumentName,
                                      DocumentPath = $"{basePath}{d.DocumentPath.Replace("\\", "/")}",
                                      SubmissionId = d.SubmissionId
                                  }).ToList();
            }

            resp.Company = new CompanyDto
            {
                Address1 = ent.Company.Address1,
                Address2 = ent.Company.Address2,
                Address3 = ent.Company.Address3,
                City = ent.Company.City,
                Code = ent.Company.ReferenceCode,
                Country = ent.Company.Country.Country_Name,
                Email = ent.Company.CompanyEmail,
                Id = ent.Company.CompanyId,
                Name = ent.Company.Name,
                Phone1 = ent.Company.Phone1,
                Phone2 = ent.Company.Phone2,
                Province = ent.Company.Province.Province,
                RegisteredDate = ent.Company.Date_created,
                Status = ent.Company.CompanyStatus.Status,
                Website = ent.Company.CompanyWebsite,
                Zip = ent.Company.Zip
            };

            resp.SubmissionCreatedBy = new UserProfileDto
            {
                Designation = ent.CreatedByUser.Designation,
                Email = ent.CreatedByUser.Person_email,
                FirstName = ent.CreatedByUser.First_Name,
                Id = ent.CreatedByUser.User_Id,
                LastName = ent.CreatedByUser.Last_Name,
                MiddleName = ent.CreatedByUser.Middle_Name,
                ProfilePicture = ent.CreatedByUser.ProfilePicture,
                Status = ent.CreatedByUser.UserStatus.Status
            };
            if (ent.UpdatedByUser != null)
            {
                resp.SubmissionUpdatedBy = new UserProfileDto
                {
                    Designation = ent.UpdatedByUser.Designation,
                    Email = ent.UpdatedByUser.Person_email,
                    FirstName = ent.UpdatedByUser.First_Name,
                    Id = ent.UpdatedByUser.User_Id,
                    LastName = ent.UpdatedByUser.Last_Name,
                    MiddleName = ent.UpdatedByUser.Middle_Name,
                    ProfilePicture = ent.UpdatedByUser.ProfilePicture,
                    Status = ent.UpdatedByUser.UserStatus.Status
                };
            }
            return resp;
        }

        public List<TenderSubmissionCard> ToCards(List<TenderSubmission> ents)
        {
            List<TenderSubmissionCard> cards = new List<TenderSubmissionCard>();
            foreach (var ts in ents)
            {
                TenderSubmissionCard c = new TenderSubmissionCard
                {
                    SubmissionId = ts.SubmissionId,
                    Status = ts.TenderSubmissionStatus.Status,
                    CreatedDate = ts.Date_created,
                    Title = ts.Title
                };
                cards.Add(c);
            }
            return cards;
        }
    }
}
