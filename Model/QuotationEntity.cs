
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MeroBolee.Model
{
    [Table("mb_supplier_quotation")]
    public class QuotationEntity 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public long UserId { get; set; }

        [ForeignKey("TenderEntities")]
        public long TenderId { get; set; }

        public int MaterialId { get; set; }

        [MaxLength(300)]
        [Required]
        public string Quotation { get; set; }

        public string Units { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public string Remarks { get; set; }
        
        public DateTime BidDate { get; set; }

        [JsonIgnore]
        public virtual TenderEntity TenderEntities { get; set; }

    }
}