using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Newtonsoft.Json;

namespace MeroBolee.Model
{
    [Table("mb_tender_post_bidding_approval")]
    public class PostBidddingApprovalEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long UserId { get; set; }

        [ForeignKey("TenderPostBidStatusEntity")]
        public int StatusId { get; set; }

        [ForeignKey("CompanyEntity")]
        public long CompanyId { get; set; }
        public DateTime Date_Created { get; set; }
        public DateTime Date_Modified { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("TenderEntity")]
        public long TenderId { get;  set; }
        public int RemarksStatusId { get;  set; }

        public virtual CompanyEntity CompanyEntity { get; set; }
        public virtual TenderEntity TenderEntity { get; set; }
        public virtual TenderPostBidStatusEntity TenderPostBidStatusEntity { get; set; }
    }
}