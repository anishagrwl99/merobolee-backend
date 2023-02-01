using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Newtonsoft.Json;

namespace MeroBolee.Model
{
    [Table("mb_tender_post_bidding_remarks")]
    public class PostBidddingRemarksEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("CompanyEntity")]
        public long CompanyId { get; set; }

        public long TenderPostBiddingApprovalId { get; set; }

        public DateTime Date_Created { get; set; }

        public long TenderId { get;  set; }

        public string Remarks { get; set; }

        public virtual CompanyEntity CompanyEntity { get; set; }

    }
}