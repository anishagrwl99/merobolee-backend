using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
 
    [Table("mb_AuctionLog")]
    public class AuctionLog
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LogId { get; set; }

        [Required(ErrorMessage = "User id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid user id")]
        [ForeignKey("User")]
        [JsonIgnore]
        public long UserId { get; set; }


        [Required(ErrorMessage = "Tender id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid tender id")]
        [ForeignKey("Tender")]
        [JsonIgnore]
        public long TenderId { get; set; }

        [Required(ErrorMessage = "Company id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid company id")]
        [ForeignKey("Company")]
        [JsonIgnore]
        public long CompanyId { get; set; }

        [Required(ErrorMessage = "Bid request id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid bid request id")]
        [ForeignKey("BidRequest")]
        [JsonIgnore]
        public long BiddingId { get; set; }

        [Required(ErrorMessage = "Auction amount is required")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Auction position is required")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Log date is required")]
        public DateTime LogDate { get; set; }


        [JsonIgnore]
        public virtual UserEntity User { get; set; }

        [JsonIgnore]
        public virtual TenderEntity Tender { get; set; }

        [JsonIgnore]
        public virtual CompanyEntity Company { get; set; }

        public virtual BidRequestEntity BidRequest { get; set; }
    }
}
