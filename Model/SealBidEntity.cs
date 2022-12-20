using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeroBolee.Model
{
    [Table("mb_seal_bid")]
    public class SealBidEntity
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

        public string MaterialGroup { get; set; }

        public DateTime BidDate { get; set; }

        public bool IsDeleted { get; set; }
        public virtual UserEntity UserEntity { get; set; }
        public virtual TenderEntity TenderEntity { get; set; }
        public virtual TenderMaterialEntity TenderMaterialEntity { get; set; }
        public virtual BidRequestEntity BidderRequestEntity { get; set; }
    }
}