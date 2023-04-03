using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MeroBolee.Model
{
    [Table("mb_vendor_enlistment_BankInfo")]
    public class VendorEnlistmentBankInfoEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("VendorEnlistment")]
        public long VendorEnlistmentId { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string SwiftCode { get; set; }
        public string Address { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; }

        [JsonIgnore]
        public virtual VendorEnlistmentEntity VendorEnlistment { get; set; }
    }
}
