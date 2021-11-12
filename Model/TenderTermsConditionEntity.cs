using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MeroBolee.Model
{
    [Table("mb_tender_term_condition")]
    public class TenderTermsConditionEntity
    {
        private long id;
        private long tender_Id;
        private TenderEntity tenderEntity;
        private string term_Condition;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [JsonIgnore]
        public long Id { get => id; set => id = value; }

        [Column("tender_id")]
        [ForeignKey("TenderEntity")]
        [JsonIgnore]
        public long TenderId { get => tender_Id; set => tender_Id = value; }

        [Column("term_condition")]
        public string TermCondition { get => term_Condition; set => term_Condition = value; }
        
        [JsonIgnore]
        public virtual TenderEntity TenderEntity { get => tenderEntity; set => tenderEntity = value; }
    }
}