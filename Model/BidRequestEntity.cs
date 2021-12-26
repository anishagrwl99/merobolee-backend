using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_bid_request")]
    public class BidRequestEntity: BaseEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long Id { get; set; }

        [ForeignKey("BidRequestStatus")]
        public int BidRequestStatusId { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }
        

        [ForeignKey("Tender")]
        public long TenderId { get; set; }



        [ForeignKey("Company")]
        public long CompanyId { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string Remark { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string PaymentReferenceCode { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        public string PaymentProvider { get; set; }


        public decimal Amount { get; set; }



        public ICollection<BidderRequestDocEntity> BidderRequestDocs { get; set; }

        [JsonIgnore]
        public virtual List<LiveBiddingEntity> LiveBidding { get; set; }
        [JsonIgnore]
        public virtual List<BiddingHistoryEntity> BiddingHistories { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual UserCompany Company { get; set; }
        public TenderEntity Tender { get; set; }
        public BidRequestStatusEntity BidRequestStatus { get; set; }
    }
}
