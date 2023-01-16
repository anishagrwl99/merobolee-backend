using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_tender")]
    public class TenderEntity : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("CategoryEntity")]
        public int CategoryId { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string Code { get; set; }


        [MaxLength(200)]
        [Column(TypeName = "VARCHAR")]
        public string Title { get; set; }

        [Range(1, 100)]
        public int LiveInterval { get; set; }

        [Required]
        public DateTime RegistrationTill { get; set; }

        public DateTime LiveStartDate { get; set; }


        public DateTime LiveEndDate { get; set; }


        [ForeignKey("CreatedByUser")]
        public long CreatedBy { get; set; }

        [ForeignKey("ApprovedByUser")]
        public long? ApprovedBy { get; set; }


        [ForeignKey("TenderStatusEntity")]
        public int StatusId { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "VARCHAR")]
        public string CancelRemarks { get; set; }



        [ForeignKey("Company")]
        public long CompanyId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(7000)]
        public string Location { get; set; }


        [Column(TypeName = "VARCHAR")]
        [MaxLength(7000)]
        public string QualityRequest { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(7000)]
        public string PerformanceRequest { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(7000)]
        public string EligibilityCriteria { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(7000)]
        public string AdditionalRequest { get; set; }


        public decimal Price { get; set; }
        public decimal MaxQuotation { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(150)]
        public string TenderDetailDocTitle { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(1500)]
        public string TenderDetailDocPath { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(1500)]
        public string TermsAndConditionDocPath { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(150)]
        public string Product { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(3999)]
        public string AlgoName { get; set; }

        public int CommunityApprovalStatus { get; set; }

        public DateTime DateOfExecution { get; set; }

        [JsonIgnore]
        public virtual CompanyEntity Company { get; set; }
        public virtual TenderStatusEntity TenderStatusEntity { get; set; }
        public virtual TenderTermsConditionEntity TenderTermsConditionEntities { get; set; }

        public virtual ICollection<TenderMaterialEntity> TenderMaterialEntities { get; set; }

        public virtual UserEntity CreatedByUser { get; set; }
        public virtual UserEntity ApprovedByUser { get; set; }
        public virtual CategoryEntity CategoryEntity { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<TenderCardEntity> TenderCards { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<AuctionLog> AuctionLogs { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<BiddingHistoryEntity> BiddingHistories { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<BidRequestEntity> BidRequests { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<LiveBiddingEntity> LiveBiddings { get; set; }
        //
        [JsonIgnore]
        public virtual ICollection<TenderCardFeedbackEntity> Feedbacks { get; set; }

        [JsonIgnore]
        public virtual ICollection<TenderExtraDocumentEntity> ExtraDocuments { get; set; }

    }


    //[Table("mb_TenderCard")]
    //public class TenderCardEntity
    //{
    //    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public long Id { get; set; }

    //    [ForeignKey("Tender")]
    //    public long TenderId { get; set; }

    //    [Required]
    //    [Column(TypeName = "VARCHAR")]
    //    [MaxLength(200)]
    //    public string Label { get; set; }


    //    [Required]
    //    [Column(TypeName = "VARCHAR")]
    //    [MaxLength(500)]
    //    public string Value { get; set; }


    //    [JsonIgnore]
    //    public virtual TenderEntity Tender { get; set; }
    //}


    [Table("mb_Tender_Card_Feeback")]
    public class TenderCardFeedbackEntity: BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("Tender")]
        [Required]
        public long TenderId { get; set; }

        [ForeignKey("Company")]
        [Required]
        public long CompanyId { get; set; }

        [ForeignKey("User")]
        [Required]
        public long UserId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(1500)]
        public string Feeback { get; set; }
        public bool IsDeleted { get; set; }
        [JsonIgnore]
        public virtual TenderEntity Tender { get; set; }

        [JsonIgnore]
        public virtual CompanyEntity Company { get; set; }

        [JsonIgnore]
        public virtual UserEntity User { get; set; }
    }


    [Table("mb_Tender_ExtraDocuments")]
    public class TenderExtraDocumentEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("Tender")]
        public long TenderId { get; set; }

        [ForeignKey("Company")]
        [Required]
        public long CompanyId { get; set; }

        [ForeignKey("User")]
        [Required]
        public long UserId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string DocTitle { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(1500)]
        public string DocPath { get; set; }

        public bool IsDeleted { get; set; }
        [JsonIgnore]
        public virtual TenderEntity Tender { get; set; }

        [JsonIgnore]
        public virtual CompanyEntity Company { get; set; }

        [JsonIgnore]
        public virtual UserEntity User { get; set; }
    }
}
