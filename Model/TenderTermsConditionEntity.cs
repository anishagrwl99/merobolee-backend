using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MeroBolee.Model
{
    [Table("mb_tender_term_condition")]
    public class TenderTermsConditionEntity
    {
        private int id;
        private int tender_Id;
        private TenderEntity tenderEntity;
        private string term_Condition;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [JsonIgnore]
        public int Id { get => id; set => id = value; }

        [Column("tender_id")]
        [ForeignKey("TenderEntity")]
        [JsonIgnore]
        public int Tender_Id { get => tender_Id; set => tender_Id = value; }

        [Column("term_condition")]
        public string Term_Condition { get => term_Condition; set => term_Condition = value; }
        [JsonIgnore]
        public TenderEntity TenderEntity { get => tenderEntity; set => tenderEntity = value; }
    }
}