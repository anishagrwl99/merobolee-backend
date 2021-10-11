using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MeroBolee.Model
{
    [Table("mb_tender_material")]
    public class TenderMaterialEntity
    {
        private long id;
        private long tender_Id;
        private TenderEntity tenderEntity;
        private string materials;
        private int quantity;
        private ICollection<MaterialFeatureEntity> materialFeatureEntities;

        [Column("id")]
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long Id { get => id; set => id = value; }

        [Column("tender_id")]
        [ForeignKey("TenderEntity")]
        [JsonIgnore]
        public long Tender_Id { get => tender_Id; set => tender_Id = value; }
        

        [Column("material")]
        public string Materials { get => materials; set => materials = value; }

        [Column("quantity")]
        public int Quantity { get => quantity; set => quantity = value; }


        [JsonIgnore]
        public virtual ICollection<MaterialFeatureEntity> MaterialFeatures { get => materialFeatureEntities; set => materialFeatureEntities = value; }

        [JsonIgnore]
        public virtual TenderEntity TenderEntity { get => tenderEntity; set => tenderEntity = value; }
    }
}