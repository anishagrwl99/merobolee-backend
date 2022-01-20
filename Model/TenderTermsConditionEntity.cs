using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MeroBolee.Model
{
    [Table("mb_tender_term_condition")]
    public class TenderTermsConditionEntity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }


        [ForeignKey("TenderEntity")]
        [JsonIgnore]
        public long TenderId { get; set; }


        [Column(TypeName = "VARCHAR(MAX)")]
        public string TermCondition { get; set; }

        [JsonIgnore]
        public virtual TenderEntity TenderEntity { get; set; }
    }
}