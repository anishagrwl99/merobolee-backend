using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeroBolee.Model
{
    [Table("mb_sealbid_subsectionTotal")]
    public class SealBidSubsectionTotalEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int TenderId { get; set; }
        public int CompanyId { get; set; }
        public decimal subsectionTotal { get; set; }
        public string MaterialGroup { get; set; }
    }
}