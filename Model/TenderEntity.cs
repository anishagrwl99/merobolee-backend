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
        private DateTime last_Request_Date;
        private string source_Fund;
        private DateTime project_Start_Date;
        private DateTime live_Start_Date;
        private DateTime live_End_Date;
        private int tender_Duration;
        private string duration_Type;
        private long created_by;
        private long? approved_by;
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

        [Column("created_by")]
        [ForeignKey("CreatedByUser")]
        public long CreatedBy { get => created_by; set => created_by = value; }

        [Column("approved_by")]
        [ForeignKey("ApprovedByUser")]
        public long? ApprovedBy { get => approved_by; set => approved_by = value; }


        [Column("tender_status_id")]
        [ForeignKey("AuctionStatusEntity")]
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


        [JsonIgnore]
        public virtual CompanyEntity Company { get; set; }
        public virtual AuctionStatusEntity AuctionStatusEntity { get => auctionStatusEntity; set => auctionStatusEntity = value; }
        public virtual TenderTermsConditionEntity TenderTermsConditionEntities { get => tenderTermsConditionEntities; set => tenderTermsConditionEntities = value; }

        public virtual ICollection<TenderMaterialEntity> TenderMaterialEntities { get => tenderMaterialEntities; set => tenderMaterialEntities = value; }

        public virtual UserEntity CreatedByUser { get => userEntity; set => userEntity = value; }
        public virtual UserEntity ApprovedByUser { get => userEntity; set => userEntity = value; }
        public virtual CategoryEntity CategoryEntity { get => categoryEntity; set => categoryEntity = value; }
    }
}
