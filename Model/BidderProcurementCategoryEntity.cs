using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeroBolee.Model
{
    [Table("mb_bidder_procurement_category")]

    public class BidderProcurementCategoryEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("VendorEnlistment")]
        public long VendorEnlistmentId { get; set; }

        [ForeignKey("ProcurementCategory")]
        public long ProcurementCategoryId { get; set; }

        public bool IsDeleted { get; set; }

        public virtual VendorEnlistmentEntity VendorEnlistment { get; set; }
        public virtual TenderProcurementCategoryEntity ProcurementCategory { get; set; }
    }
}
