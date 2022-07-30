using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_live_bid")]
    public class LiveBiddingEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("BidderRequestEntity")]
        public long BiddingRequestId { get; set; }

        [ForeignKey("UserEntity")]
        public long UserId { get; set; }


        [ForeignKey("TenderEntity")]
        public long TenderId { get; set; }

        public decimal TotalAmount { get; set; }


        [ForeignKey("TenderMaterialEntity")]
        public long MaterialId { get; set; }

        [MaxLength(300)]
        [Required]
        public string Quotation { get; set; }

        public string Units { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public long BatchNo { get; set; }

        public DateTime BidDate { get; set; }

        public bool IsDeleted { get; set; }
        public virtual UserEntity UserEntity { get; set; }
        public virtual TenderEntity TenderEntity { get; set; }
        public virtual TenderMaterialEntity TenderMaterialEntity { get; set; }

       
        public virtual BidRequestEntity BidderRequestEntity { get; set; }

        

    }


    [Table("mb_bid_history")]
    public class BiddingHistoryEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("BidderRequestEntity")]
        public long BiddingRequestId { get; set; }

        [ForeignKey("UserEntity")]
        public long UserId { get; set; }


        [ForeignKey("TenderEntity")]
        public long TenderId { get; set; }


        [ForeignKey("TenderMaterialEntity")]
        public long MaterialId { get; set; }

        public decimal Quotation { get; set; }

        public long BatchNo { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(10)]
        public string FinalPosition { get; set; }

        public DateTime BidDate { get; set; }

        public bool IsDeleted { get; set; }
        public virtual UserEntity UserEntity { get; set; }
        public virtual TenderEntity TenderEntity { get; set; }
        public virtual TenderMaterialEntity TenderMaterialEntity { get; set; }


        public virtual BidRequestEntity BidderRequestEntity { get; set; }

    }
}
