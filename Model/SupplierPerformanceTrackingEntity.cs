using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeroBolee.Model
{
    [Table("mb_Supplier_Performance_Tracking")]
    public class SupplierPerformanceTrackingEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long TenderId { get; set; }
        public long CompanyId { get; set; }
        public string Criteria { get; set; }
        public int Ratings { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime RatingCreatedDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
