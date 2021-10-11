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
        public int BiddingRequestId { get; set; }

        [ForeignKey("UserEntity")]
        public int SupplierId { get; set; }


        [ForeignKey("TenderEntity")]
        public int TenderId { get; set; }


        [ForeignKey("TenderMaterialEntity")]
        public int MaterialId { get; set; }

        [MaxLength(300)]
        public string Quotation { get; set; }

        public DateTime BidDate { get; set; }


        public virtual UserEntity UserEntity { get; set; }
        public virtual TenderEntity TenderEntity { get; set; }
        public virtual TenderMaterialEntity TenderMaterialEntity { get; set; }

       
        public virtual BidderRequestEntity BidderRequestEntity { get; set; }

    }


    [Table("mb_bid_history")]
    public class BiddingHistoryEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("BidderRequestEntity")]
        public int BiddingRequestId { get; set; }

        [ForeignKey("UserEntity")]
        public int SupplierId { get; set; }


        [ForeignKey("TenderEntity")]
        public int TenderId { get; set; }


        [ForeignKey("TenderMaterialEntity")]
        public int MaterialId { get; set; }

        public decimal Quotation { get; set; }

        public DateTime BidDate { get; set; }


        public virtual UserEntity UserEntity { get; set; }
        public virtual TenderEntity TenderEntity { get; set; }
        public virtual TenderMaterialEntity TenderMaterialEntity { get; set; }


        public virtual BidderRequestEntity BidderRequestEntity { get; set; }

    }
}
