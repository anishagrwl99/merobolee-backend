using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MeroBolee.Model
{
    [Table("mb_vendor_enlistment_annual_income")]
    public class VendorEnlistmentAnnualIncomeEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("VendorEnlistment")]
        public long VendorEnlistmentId { get; set; }
        public string FiscalYear { get; set; }
        public long IncomeSales { get; set; }
        public long ExportSales { get; set; }
        public bool IsDeleted { get; set; }

        [JsonIgnore]
        public virtual VendorEnlistmentEntity VendorEnlistment { get; set; }

    }
}
