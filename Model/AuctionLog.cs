using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    public class AuctionLog
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LogId { get; set; }

        [Required(ErrorMessage = "User id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid user id")]
        [ForeignKey("User")]
        public long UserId { get; set; }


        [Required(ErrorMessage = "Tender id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid tender id")]
        [ForeignKey("Tender")]
        public long TenderId { get; set; }

        [Required(ErrorMessage = "Auction amount is required")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Auction position is required")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Log date is required")]
        public DateTime LogDate { get; set; }



        public virtual UserEntity User { get; set; }
        public virtual TenderEntity Tender { get; set; }
    }
}
