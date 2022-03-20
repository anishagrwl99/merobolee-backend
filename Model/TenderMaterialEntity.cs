using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MeroBolee.Model
{
    [Table("mb_tender_material")]
    public class TenderMaterialEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("TenderEntity")]
        [JsonIgnore]
        public long TenderId { get; set; }


        [Column(TypeName = "VARCHAR")]
        [MaxLength(300)]
        public string Materials { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public string Units { get; set; }

        public virtual ICollection<MaterialFeatureEntity> MaterialFeatures { get; set; }

        [JsonIgnore]
        public TenderEntity TenderEntity { get; set; }
    }
}