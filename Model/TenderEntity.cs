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
        private string tender_Description;
        private int tender_live_interval;
        private DateTime  last_Request_Date;
        private string source_Fund;
        private DateTime project_Start_Date;
        private DateTime live_Start_Date;
        private DateTime live_End_Date;
        private int tender_Duration;
        private string duration_Type;
        private int bid_No;
        private long posted_By;
        private UserEntity userEntity;
        private int tender_Status_Id;
        private AuctionStatusEntity auctionStatusEntity;
        private int admin_Status_Id;
        private AdminStatusEntity adminStatusEntity;
        private string cancel_remark;
        private long company_id;
        //private int payment_Status_Id;
        //private PaymentStatusEntity paymentStatusEntity;
        private ICollection<TenderMaterialEntity> tenderMaterialEntities;
        private TenderTermsConditionEntity tenderTermsConditionEntities;

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tender_id")]
        public long Tender_Id { get => tender_Id; set => tender_Id = value; }

        [Column("tender_code")]
        [MaxLength(20)]
        public string Tender_Code { get => tender_Code; set => tender_Code = value; }

        [Column("tender_title")]
        public string Tender_Title { get => tender_Title; set => tender_Title = value; }

        [Column("category_id")]
        [ForeignKey("CategoryEntity")]
        public int Category_Id { get => category_Id; set => category_Id = value; }
        public CategoryEntity CategoryEntity { get => categoryEntity; set => categoryEntity = value; }
        [Column("description")]
        public string Tender_Description { get => tender_Description; set => tender_Description = value; }
        [Column("live_interval")]
        public int Tender_live_interval { get => tender_live_interval; set => tender_live_interval = value; }
        [Column("start_date")]
        public DateTime Live_Start_Date { get => live_Start_Date; set => live_Start_Date = value; }
        [Column("end_date")]
        public DateTime Live_End_Date { get => live_End_Date; set => live_End_Date = value; }
        [Column("duration")]
        public int Tender_Duration { get => tender_Duration; set => tender_Duration = value; }
        [Column("duration_type")]
        public string Duration_Type { get => duration_Type; set => duration_Type = value; }
        [Column("bid_no")]
        public int Bid_No { get => bid_No; set => bid_No = value; }
        [Column("posted_by")]
        [ForeignKey("UserEntity")]
        public long UserId { get => posted_By; set => posted_By = value; }
        public UserEntity UserEntity { get => userEntity; set => userEntity = value; }
        [Column("tender_status_id")]
        [ForeignKey("AuctionStatusEntity")]
        public int Tender_Status_Id { get => tender_Status_Id; set => tender_Status_Id = value; }
        public AuctionStatusEntity AuctionStatusEntity { get => auctionStatusEntity; set => auctionStatusEntity = value; }
        [Column("admin_status_id")]
        [ForeignKey("AdminStatusEntity")]
        public int Admin_Status_Id { get => admin_Status_Id; set => admin_Status_Id = value; }
        public AdminStatusEntity AdminStatusEntity { get => adminStatusEntity; set => adminStatusEntity = value; }
        //[Column("payment_status_id")]
        //[ForeignKey("PaymentStatusEntity")]
        //public int Payment_Status_Id { get => payment_Status_Id; set => payment_Status_Id = value; }
        //public PaymentStatusEntity PaymentStatusEntity { get => paymentStatusEntity; set => paymentStatusEntity = value; }
        public ICollection<TenderMaterialEntity> TenderMaterialEntities { get => tenderMaterialEntities; set => tenderMaterialEntities = value; }
        public TenderTermsConditionEntity TenderTermsConditionEntities { get => tenderTermsConditionEntities; set => tenderTermsConditionEntities = value; }
       [Column("cancel_remark")]
        public string Cancel_remark { get => cancel_remark; set => cancel_remark = value; }
        [Column("last_request_date")]
        public DateTime Last_Request_Date { get => last_Request_Date; set => last_Request_Date = value; }
        [Column("source_fund")]
        public string Source_Fund { get => source_Fund; set => source_Fund = value; }
        //[Column("IFB_RFB_EOI")]
        //public string IFB_RFP_EOI1 { get => IFB_RFP_EOI; set => IFB_RFP_EOI = value; }
        [Column("project_start_date")]
        public DateTime Project_Start_Date { get => project_Start_Date; set => project_Start_Date = value; }


        [ForeignKey("Company")]
        [Column("company_id")]
        public long CompanyId {
            get { return company_id; }
            set { company_id = value; }
        }


        [JsonIgnore]
        public virtual CompanyEntity Company { get; set; }
    }
}
