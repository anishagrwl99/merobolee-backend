using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_bidder_request")]
    public class BidderRequestEntity: BaseEntity
    {
        private long request_Id;
        private Guid request_code;
        private long user_id;
        private long company_id;
        private UserEntity userEntity;
        private long tender_Id;
        private TenderEntity tenderEntity;
        private int admin_Status_Id;
        private AdminStatusEntity adminStatusEntity;
        private DateTime request_Send_Date;
        private string remark;
        private ICollection<BidderRequestDocEntity> bidderRequestDocs;

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("request_id")]
        [JsonIgnore]
        public long Request_Id { get => request_Id; set => request_Id = value; }

        [Column("request_code")]
        public Guid Request_code { get => request_code; set => request_code = value; }
        [Column("user_id")]
        [ForeignKey("UserEntity")]
        public long User_id { get => user_id; set => user_id = value; }
        public UserEntity UserEntity { get => userEntity; set => userEntity = value; }

        [Column("tender_id")]
        [ForeignKey("TenderEntity")]
        public long Tender_Id { get => tender_Id; set => tender_Id = value; }
        public TenderEntity TenderEntity { get => tenderEntity; set => tenderEntity = value; }

        [Column("admin_status_id")]
        [ForeignKey("AdminStatusEntity")]
        public int Admin_Status_Id { get => admin_Status_Id; set => admin_Status_Id = value; }
        public AdminStatusEntity AdminStatusEntity { get => adminStatusEntity; set => adminStatusEntity = value; }
       
        [Column("request_send_date")]
        public DateTime Request_Send_Date { get => request_Send_Date; set => request_Send_Date = value; }

        [Column("remark")]
        public string Remark { get => remark; set => remark = value; }


        
        [Column("company_id")]
        public long CompanyId
        {
            get { return company_id; }
            set { company_id = value; }
        }

        public ICollection<BidderRequestDocEntity> BidderRequestDocs { get => bidderRequestDocs; set => bidderRequestDocs = value; }

        public virtual List<LiveBiddingEntity> LiveBiddingEntities { get; set; }

    }
}
