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

        public int CategoryId { get; set; }

        public int StatusId { get; set; }

        [ForeignKey("CompanyEntity")]
        public long CompanyId { get; set; }
        public DateTime Date_Created { get; set; }
        public DateTime Date_Modified { get; set; }
        public bool IsDeleted { get; set; }

        public long TenderId { get;  set; }

        public virtual CompanyEntity CompanyEntity { get; set; }
    }
}