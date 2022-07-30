
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeroBolee.Model
{
    [Table("mb_supplier_quotation")]
    public class QuotationEntity : BaseEntity
    {
        [ForeignKey("UserEntity")]
        public long UserId { get; set; }


        [ForeignKey("TenderEntity")]
        public long TenderId { get; set; }

        [ForeignKey("TenderMaterialEntity")]
        public long MaterialId { get; set; }

        [MaxLength(300)]
        [Required]
        public string Quotation { get; set; }

        public string Units { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
        
    }
}