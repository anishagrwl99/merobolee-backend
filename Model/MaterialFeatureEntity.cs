using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MeroBolee.Model
{
    [Table("mb_material_feature")]
    public class MaterialFeatureEntity
    {
        private int id;
        //private int material_id;
        //private TenderMaterialEntity tenderMaterialEntity;
        private string feature;

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [JsonIgnore]
        public int Id { get => id; set => id = value; }

        //[Column("material_id")]
        //[ForeignKey("TenderMaterialEntity")]
        //[JsonIgnore]
        //public int Material_id { get => material_id; set => material_id = value; }
        //[JsonIgnore]
        //public TenderMaterialEntity TenderMaterialEntity { get => tenderMaterialEntity; set => tenderMaterialEntity = value; }
        
        [Column("feature")]
        public string Feature { get => feature; set => feature = value; }
    }
}