using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeroBolee.Model
{
    [Table("mb_vendor_enlistment_references")]
    public class VendorEnlistmentReferencesEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("VendorEnlistment")]
        public long VendorEnlistmentId { get; set; }

        public string Name { get; set; }
        public string Country { get; set; }
        public string TypeOfContract { get; set; }
        public string Value { get; set; }
        public int Year{ get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string Email{ get; set; }
        public bool IsDeleted { get; set; }

        [JsonIgnore]
        public virtual VendorEnlistmentEntity VendorEnlistment { get; set; }
    }
}
