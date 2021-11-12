using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MeroBolee.Model
{
    [Table("mb_material_feature")]
    public class MaterialFeatureEntity
    {
        private long id;
        private long material_id;
        private TenderMaterialEntity tenderMaterialEntity;
        private string featureName;
        private string featureValue;

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [JsonIgnore]
        public long Id { get => id; set => id = value; }

        [Column("material_id")]
        [ForeignKey("TenderMaterialEntity")]
        [JsonIgnore]
        public long MaterialId { get => material_id; set => material_id = value; }
       

        [Column("feature_name")]
        public string FeatureName { get => featureName; set => featureName = value; }

        

        [Column("feature_value")]
        public string FeatureValue
        {
            get { return featureValue; }
            set { featureValue = value; }
        }


        [JsonIgnore]
        public virtual TenderMaterialEntity TenderMaterialEntity { get => tenderMaterialEntity; set => tenderMaterialEntity = value; }
    }
}