using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Model
{

    [Table("lk_TenderSubmissionStatus")]
    public class TenderSubmissionStatus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string Status { get; set; }
    }


    [Table("mb_TenderSubmission")]
    public class TenderSubmission : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SubmissionId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(500)]
        public string Title { get; set; }

        [Required]
        [ForeignKey("CreatedByUser")]
        public long CreatedBy { get; set; }

        [Required]
        [ForeignKey("Company")]
        public long CompanyId { get; set; }

        [ForeignKey("TenderSubmissionStatus")]
        public int StatusId { get; set; }


        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        public string PaymentProvider { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(200)]
        public string PaymentReferenceCode { get; set; }

        public decimal Amount { get; set; }

        [ForeignKey("UpdatedByUser")]
        public long? UpdatedBy { get; set; }

        [Required]
        public bool IsFormSubmission { get; set; }


        [Column(TypeName = "VARCHAR")]
        [MaxLength(150)]
        public string PriceScheduleDocName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(1500)]
        public string PriceScheduleDocPath { get; set; }
        

        public virtual TenderSubmissionStatus TenderSubmissionStatus { get; set; }
        public virtual UserEntity CreatedByUser { get; set; }
        public virtual UserEntity UpdatedByUser { get; set; }
        public virtual CompanyEntity Company { get; set; }
        public virtual ICollection<TenderSubmissionProductSpec> ProductSpecifications { get; set; }
        public virtual ICollection<TenderSubmissionPurchaseCriteria> PurchaseCriterias { get; set; }
        public virtual ICollection<TenderSubmissionPriceSchedule> PriceSchedules { get; set; }
        public virtual ICollection<TenderSubmissionEligibilityCriteria> EligibilityCriterias { get; set; }
        public virtual ICollection<TenderSubmissionDocuments> TenderSubmissionDocuments { get; set; }
        public virtual ICollection<TenderSubmissionAdditionalDocument> AdditionalDocuments { get; set; }
    }

    [Table("mb_TenderSubmisssionDocument")]
    public class TenderSubmissionDocuments
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SubmissionDocumentId { get; set; }

        [ForeignKey("TenderSubmission")]
        public long SubmissionId { get; set; }


        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(200)]
        public string DocumentName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(1500)]
        public string DocumentPath { get; set; }

        public virtual TenderSubmission TenderSubmission { get; set; }
    }

    [Table("mb_TenderSubmissionProductSpec")]
    public class TenderSubmissionProductSpec
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SpecificationId { get; set; }


        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string SpecificationName { get; set; }


        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(2000)]
        public string SpecificationValue { get; set; }

        [Required]
        public int RowNo { get; set; }

        [ForeignKey("TenderSubmission")]
        public long TenderSubmissionId { get; set; }


        [JsonIgnore]
        public virtual TenderSubmission TenderSubmission { get; set; }
    }


    [Table("mb_TenderSubmissionPurchaseCriteria")]
    public class TenderSubmissionPurchaseCriteria
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PurchaseCriteriaId { get; set; }

        [Required]
        public int SN { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string CriteriaName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(500)]
        public string Remarks { get; set; }

        [ForeignKey("TenderSubmission")]
        public long TenderSubmissionId { get; set; }

        [JsonIgnore]
        public virtual TenderSubmission TenderSubmission { get; set; }
    }


    [Table("mb_TenderSubmissionPriceSchedule")]
    public class TenderSubmissionPriceSchedule
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PriceScheduleId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string ScheduleName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(1500)]
        public string ScheduleValue { get; set; }

        [Required]
        public int RowNo { get; set; }

        [ForeignKey("TenderSubmission")]
        public long TenderSubmissionId { get; set; }

        [JsonIgnore]
        public virtual TenderSubmission TenderSubmission { get; set; }
    }


    [Table("mb_TenderSubmissionEligibilityCriteria")]
    public class TenderSubmissionEligibilityCriteria
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EligibilityCriteriaId { get; set; }


        [Required]
        public int SN { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string CriteriaName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(1500)]
        public string Remarks { get; set; }

        [ForeignKey("TenderSubmission")]
        public long TenderSubmissionId { get; set; }

        [JsonIgnore]
        public virtual TenderSubmission TenderSubmission { get; set; }
    }


    [Table("mb_TenderSubmissionAdditionalDocument")]
    public class TenderSubmissionAdditionalDocument
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("TenderSubmission")]
        public long TenderSubmissionId { get; set; }



        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(300)]
        public string DocTitle { get; set; }



        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(1500)]
        public string DocPath { get; set; }

        public virtual TenderSubmission Submission { get; set; }

    }
}
