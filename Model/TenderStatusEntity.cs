using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("lk_bidrequest_status")]
    public class BidRequestStatusEntity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity) ]
        public int StatusId { get; set; }
        
        
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        public string Status { get; set; }
    }


    [Table("lk_Tender_Status")]
    public class TenderStatusEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatusId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        public string Status { get; set; }
    }
}
