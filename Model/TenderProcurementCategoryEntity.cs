using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeroBolee.Model
{
    [Table("lk_tender_procurement_category")]
    public class TenderProcurementCategoryEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int ProcurementId { get; set; }

        public string Title { get; set; }
        public bool IsDeleted { get; set; }
    }
}
