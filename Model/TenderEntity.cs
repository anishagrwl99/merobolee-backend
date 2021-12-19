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
        private long tender_Id;
        private string tender_Code;
        private string tender_Title;
        private int category_Id;
        private CategoryEntity categoryEntity;
        private int tender_live_interval;
        private DateTime live_Start_Date;
        private DateTime live_End_Date;
        private long created_by;
        private long? approved_by;
        private UserEntity userEntity;
        private int tender_Status_Id;
        private TenderStatusEntity tenderStatusEntity;
        private string cancel_remark;
        private long company_id;
        //private int payment_Status_Id;
        //private PaymentStatusEntity paymentStatusEntity;
        private ICollection<TenderMaterialEntity> tenderMaterialEntities;
        private TenderTermsConditionEntity tenderTermsConditionEntities;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tender_id")]
        public long Tender_Id { get => tender_Id; set => tender_Id = value; }

        [Column("category_id")]
        [ForeignKey("CategoryEntity")]
        public int Category_Id { get => category_Id; set => category_Id = value; }

        [Column("tender_code")]
        [MaxLength(20)]
        public string Tender_Code { get => tender_Code; set => tender_Code = value; }

        [Column("tender_title")]
        public string Tender_Title { get => tender_Title; set => tender_Title = value; }


        [Column("live_interval")]
        public int Tender_live_interval { get => tender_live_interval; set => tender_live_interval = value; }

        [Required]
        public DateTime RegistrationTill { get; set; }

        [Column("start_date")]
        public DateTime Live_Start_Date { get => live_Start_Date; set => live_Start_Date = value; }


        [Column("end_date")]
        public DateTime Live_End_Date { get => live_End_Date; set => live_End_Date = value; }


        [Column("created_by")]
        [ForeignKey("CreatedByUser")]
        public long CreatedBy { get => created_by; set => created_by = value; }

        [Column("approved_by")]
        [ForeignKey("ApprovedByUser")]
        public long? ApprovedBy { get => approved_by; set => approved_by = value; }


        [Column("tender_status_id")]
        [ForeignKey("TenderStatusEntity")]
        public int Tender_Status_Id { get => tender_Status_Id; set => tender_Status_Id = value; }

               
        [Column("cancel_remark")]
        public string Cancel_remark { get => cancel_remark; set => cancel_remark = value; }



        [ForeignKey("Company")]
        [Column("company_id")]
        public long CompanyId
        {
            get { return company_id; }
            set { company_id = value; }
        }

        public string Location { get; set; }
        public string QualityRequest { get; set; }
        public string PerformanceRequest { get; set; }
        public string EligibilityCriteria { get; set; }
        public string AdditionalRequest { get; set; }
        public decimal Price { get; set; }

        public string TenderDetailDocTitle { get; set; }
        public string TenderDetailDocPath { get; set; }
        public string TermsAndConditionDocPath { get; set; }

        [JsonIgnore]
        public virtual CompanyEntity Company { get; set; }
        public virtual TenderStatusEntity TenderStatusEntity { get => tenderStatusEntity; set => tenderStatusEntity = value; }
        public virtual TenderTermsConditionEntity TenderTermsConditionEntities { get => tenderTermsConditionEntities; set => tenderTermsConditionEntities = value; }

        public virtual ICollection<TenderMaterialEntity> TenderMaterialEntities { get => tenderMaterialEntities; set => tenderMaterialEntities = value; }

        public virtual UserEntity CreatedByUser { get => userEntity; set => userEntity = value; }
        public virtual UserEntity ApprovedByUser { get => userEntity; set => userEntity = value; }
        public virtual CategoryEntity CategoryEntity { get => categoryEntity; set => categoryEntity = value; }

        [JsonIgnore]
        public virtual ICollection<TenderCardEntity> TenderCards { get; set; }

        [JsonIgnore]
        public virtual ICollection<TenderCardFeedbackEntity> Feedbacks { get; set; }

        [JsonIgnore]
        public virtual ICollection<TenderExtraDocumentEntity> ExtraDocuments { get; set; }

    }


    [Table("mb_TenderCard")]
    public class TenderCardEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("Tender")]
        public long TenderId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(200)]
        public string Label { get; set; }


        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(500)]
        public string Value { get; set; }


        [JsonIgnore]
        public virtual TenderEntity Tender { get; set; }
    }


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
        [MaxLength(100)]
        public string DocTitle { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(1500)]
        public string DocPath { get; set; }


        [JsonIgnore]
        public virtual TenderEntity Tender { get; set; }

        [JsonIgnore]
        public virtual CompanyEntity Company { get; set; }

        [JsonIgnore]
        public virtual UserEntity User { get; set; }
    }
}
