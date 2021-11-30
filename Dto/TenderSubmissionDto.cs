using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class ChangeSubmissionStatusDto
    {
        public long UserId { get; set; }
        public long SubmissionId { get; set; }
        public int StatusId { get; set; }
    }
    public class TenderSubmissionCard
    {
        public long SubmissionId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
    }

    public class TenderSubmissionPaymentRequestDto
    {
        [Required(ErrorMessage = "Tender submission number is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid tender submission number")]
        public long SubmissionId { get; set; }


        [Required(ErrorMessage = "Payment provider name is required")]
        [MaxLength(50, ErrorMessage = "Payment provider name can be {1} character long")]
        public string PaymentProvider { get; set; }

        [Required(ErrorMessage = "Payment reference code is required")]
        [MaxLength(200, ErrorMessage = "Payment reference code can be {1} character long")]
        public string PaymentReferenceCode { get; set; }

        [Required(ErrorMessage = "Payment amount is required")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Payment amount should be positive number")]
        public decimal PaymentAmount { get; set; }
    }
    public class TenderSubmissionRequestDto
    {

        [Required(ErrorMessage = "User id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid user id")]
        public long CreatedBy { get; set; }

        
        [Required(ErrorMessage = "Company id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid company id")]
        public long CompanyId { get; set; }

        [Required(ErrorMessage = "Listing title is required")]
        [MaxLength(500, ErrorMessage = "Listing title can be {1} character long")]
        public string Title { get; set; }

        public string PaymentProvider { get; set; }

        public string PaymentReferenceCode { get; set; }
        public decimal Amount { get; set; }


        public IFormFile PriceScheduleDoc { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept terms and condition")]
        public bool AcceptTermsAndConditions { get; set; }

        public virtual ICollection<TenderSubmissionProductSpecDto> ProductSpecifications { get; set; }
        public virtual ICollection<TenderSubmissionPurchaseCriteriaDto> PurchaseCriterias { get; set; }
        public virtual ICollection<TenderSubmissionPriceScheduleDto> PriceSchedules { get; set; }
        public virtual ICollection<TenderSubmissionEligibilityCriteriaDto> EligibilityCriterias { get; set; }
    }

    public class TenderSubmissionUpdateRequestDto
    {
        [Required(ErrorMessage = "Submission id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid submission id")]
        public long SubmissionId { get; set; }

        [Required(ErrorMessage = "User id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid user id")]
        public long CreatedBy { get; set; }


        [Required(ErrorMessage = "Company id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid company id")]
        public long CompanyId { get; set; }

        [Required(ErrorMessage = "Listing title is required")]
        [MaxLength(500, ErrorMessage = "Listing title can be {1} character long")]
        public string Title { get; set; }

        public string PaymentProvider { get; set; }

        public string PaymentReferenceCode { get; set; }
        public decimal Amount { get; set; }


        public IFormFile PriceScheduleDoc { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept terms and condition")]
        public bool AcceptTermsAndConditions { get; set; }

        public virtual ICollection<TenderSubmissionProductSpecResponseDto> ProductSpecifications { get; set; }
        public virtual ICollection<TenderSubmissionPurchaseCriteriaResponseDto> PurchaseCriterias { get; set; }
        public virtual ICollection<TenderSubmissionPriceScheduleResponseDto> PriceSchedules { get; set; }
        public virtual ICollection<TenderSubmissionEligibilityCriteriaResponseDto> EligibilityCriterias { get; set; }
    }
    public class TenderSubmissionExternalDocumentRequestDto
    {

        [Required(ErrorMessage = "User id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid user id")]
        public long CreatedBy { get; set; }


        [Required(ErrorMessage = "Company id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid company id")]
        public long CompanyId { get; set; }

        [Required(ErrorMessage = "Listing title is required")]
        [MaxLength(500, ErrorMessage = "Listing title can be {1} character long")]
        public string Title { get; set; }

        public string PaymentProvider { get; set; }

        public string PaymentReferenceCode { get; set; }
        public decimal Amount { get; set; }


        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept terms and condition")]
        public bool AcceptTermsAndConditions { get; set; }

        public virtual ICollection<IFormFile> Documents { get; set; }
    }


    public class TenderSubmissionExternalDocumentUpdateRequestDto : TenderSubmissionExternalDocumentRequestDto
    {
        public long SubmissionId { get; set; }
    }

    public class TenderResponseSubmissionDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long CompanyId { get; set; }
        public string Title { get; set; }
        public string PaymentProvider { get; set; }
        public string PaymentReferenceCode { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public bool IsFormSubmission { get; set; }
        public string PriceScheduleDocName { get; set; }
        public string PriceScheduleDocPath { get; set; }
        public virtual ICollection<TenderSubmissionProductSpecResponseDto> ProductSpecifications { get; set; }
        public virtual ICollection<TenderSubmissionPurchaseCriteriaResponseDto> PurchaseCriterias { get; set; }
        public virtual ICollection<TenderSubmissionPriceScheduleResponseDto> PriceSchedules { get; set; }
        public virtual ICollection<TenderSubmissionEligibilityCriteriaResponseDto> EligibilityCriterias { get; set; }
        public virtual ICollection<TenderSubmissionDocumentResponseDto> Documents { get; set; }
        public virtual CompanyDto Company { get; set; }
        public virtual UserProfileDto SubmissionCreatedBy { get; set; }
        public virtual UserProfileDto SubmissionUpdatedBy { get; set; }
    }

    public class TenderSubmissionProductSpecDto
    {

        [Required(ErrorMessage = "Specification name is required")]
        [MaxLength(100, ErrorMessage = "Specification name can be {1} character long")]
        public string SpecificationName { get; set; }


        [Required(ErrorMessage = "Specification value is required")]
        [MaxLength(2000)]
        public string SpecificationValue { get; set; }

    }


    public class TenderSubmissionPurchaseCriteriaDto
    {

        [Required(ErrorMessage = "Serial Number is required")]
        [Range(1, SByte.MaxValue, ErrorMessage = "Invalid serial number")]
        public int SN { get; set; }

        [Required(ErrorMessage = "Criteria name is required")]
        [MaxLength(100, ErrorMessage = "Criteria name can be {1} character long")]
        public string CriteriaName { get; set; }

        [MaxLength(500, ErrorMessage = "Remarks can be {1} character long")]
        public string Remarks { get; set; }
    }


    public class TenderSubmissionPriceScheduleDto
    {

        [Required(ErrorMessage = "Price schedule name is required")]
        [MaxLength(100, ErrorMessage = "Price schedule name can be {1} character long")]
        public string ScheduleName { get; set; }

        [Required(ErrorMessage = "Price schedule value is required")]
        [MaxLength(1500, ErrorMessage = "Price schedule can be {1} character long")]
        public string ScheduleValue { get; set; }

    }

    public class TenderSubmissionEligibilityCriteriaDto
    {
        [Required(ErrorMessage = "Serial Number is required")]
        [Range(1, SByte.MaxValue, ErrorMessage = "Invalid serial number")]
        public int SN { get; set; }

        [Required(ErrorMessage = "Eligibility criteria name is required")]
        [MaxLength(100, ErrorMessage = "Eligibility criteria name can be {1} character long")]
        public string CriteriaName { get; set; }

        [MaxLength(1500, ErrorMessage = "Remarks can be {1} character long")]
        public string Remarks { get; set; }

    }

    public class TenderSubmissionDocumentResponseDto
    {
        public long SubmissionId { get; set; }
        public long DocumentId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
    }
    public class TenderSubmissionProductSpecResponseDto : TenderSubmissionProductSpecDto
    {
        public long Id { get; set; }
    }

    public class TenderSubmissionPurchaseCriteriaResponseDto : TenderSubmissionPurchaseCriteriaDto
    {
        public long Id { get; set; }
    }

    public class TenderSubmissionPriceScheduleResponseDto : TenderSubmissionPriceScheduleDto
    {
        public long Id { get; set; }
    }

    public class TenderSubmissionEligibilityCriteriaResponseDto : TenderSubmissionEligibilityCriteriaDto
    {
        public long Id { get; set; }
    }
}
