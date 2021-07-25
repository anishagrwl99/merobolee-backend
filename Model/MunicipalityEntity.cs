using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_municipality")]
    public class MunicipalityEntity: BaseEntity
    {
        private int municipality_id;
        private string municipality_Name;
        private int? district_id;
        private DistrictEntity district;

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("municipality_id")]
        public int Municipality_id { get => municipality_id; set => municipality_id = value; }

        [Column("municipality")]
        public string Municipality_Name { get => municipality_Name; set => municipality_Name = value; }

        [Column("district_id")]
        [ForeignKey("District")]
        public int? District_id { get => district_id; set => district_id = value; }
        public DistrictEntity District { get => district; set => district = value; }
    }
}
