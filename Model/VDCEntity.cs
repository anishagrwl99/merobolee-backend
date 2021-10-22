using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_vdc")]
    public class VDCEntity: BaseEntity
    {
        private int vdc_Id;
        private string vdc_Name;
        private int? district_Id;
        private DistrictEntity district;

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("vdc_id")]
        public int Vdc_Id { get => vdc_Id; set => vdc_Id = value; }

        [Column("vdc")]
        public string Vdc_Name { get => vdc_Name; set => vdc_Name = value; }

        [Column("district_id")]
        [ForeignKey("District")]
        public int? District_Id { get => district_Id; set => district_Id = value; }
        public DistrictEntity District { get => district; set => district = value; }

    }
}
