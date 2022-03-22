using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_bidder_request_doc")]
    public class BidderRequestDocEntity
    {
        

        [JsonIgnore]
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }


        [Required]
        [MaxLength(200)]
        [Column(TypeName = "VARCHAR")]
        public string DocTitle { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(1500)]
        public string DocPath{ get; set; }

        [ForeignKey("BidderRequest")]
        public long BidRequestId { get; set; }
        public bool IsDeleted { get; set; }
        [JsonIgnore]
        public virtual BidRequestEntity BidderRequest { get; set; }
    }
}
