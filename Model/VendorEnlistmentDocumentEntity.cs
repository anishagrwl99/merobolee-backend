using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MeroBolee.Model
{

    [Table("mb_vendor_enlistment_document")]
    public class VendorEnlistmentDocumentEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("VendorEnlistment")]
        public long VendorEnlistmentId { get; set; }
        [ForeignKey("Document")]
        public int DocumentTypeId { get; set; }
        public string DocumentPath { get; set; }
        public bool IsDeleted { get; set; }

        [JsonIgnore]
        public virtual VendorEnlistmentEntity VendorEnlistment { get; set; }
        [JsonIgnore]
        public virtual DocumentTypeEntity Document { get; set; }
    }
}
