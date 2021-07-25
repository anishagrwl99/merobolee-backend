using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_district")]
    public class DistrictEntity : BaseEntity 
    {
        private int district_Id;
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("district_id")]
        public int District_Id { get => district_Id; set => district_Id = value; }

        private string district_Name;
        [Column("district_title")]
        public string District_Name { get => district_Name; set => district_Name = value; }

        private int? province_Id;
        [ForeignKey("Province")]
        [Column("province_id")]
        public int? Province_Id { get => province_Id; set => province_Id = value; }

        private ProvinceEntity province;
        public ProvinceEntity Province { get => province; set => province = value; }
    }
}
