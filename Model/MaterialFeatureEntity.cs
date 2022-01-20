using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MeroBolee.Model
{
    [Table("mb_material_feature")]
    public class MaterialFeatureEntity
    {

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("TenderMaterialEntity")]
        [JsonIgnore]
        public long MaterialId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(300)]
        public string FeatureName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(300)]
        public string FeatureValue { get; set; }


        [JsonIgnore]
        public virtual TenderMaterialEntity TenderMaterialEntity { get; set; }
    }
}