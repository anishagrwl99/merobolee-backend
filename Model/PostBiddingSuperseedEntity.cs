using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace MeroBolee.Model
{
    [Table("mb_tender_post_bidding_superseed")]
    public class PostBiddingSuperseedEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long UserId { get; set; }

        public DateTime Date_Created { get; set; }

        public long TenderId { get; set; }

        public string Remarks { get; set; }
        public string Bid { get; set; }
        public string Status { get; set; }
    }
}
