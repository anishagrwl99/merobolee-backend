using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeroBolee.Model
{
    [Table("lk_tender_post_bidding_status")]
    public class TenderPostBidStatusEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatusId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        public string Status { get; set; }
    }
}
