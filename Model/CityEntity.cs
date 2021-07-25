using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_city")]
    public class CityEntity : BaseEntity
    {
        private int city_Id;
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("city_id")]
        public int City_Id { get => city_Id; set => city_Id = value; }

        private string city_Name;
        [Column("city_title")]
        public string City_Name { get => city_Name; set => city_Name = value; }

        private int? municipality_Id;
        [ForeignKey("Municipality")]
        [Column("municipality_id")]
        public int? Municipality_Id { get => municipality_Id; set => municipality_Id = value; }

        private int? vdc_Id;
        [Column("vdc_id")]
        [ForeignKey("VDC")]
        public int? Vdc_Id { get => vdc_Id; set => vdc_Id = value; }

        private VDCEntity vdc;
        public VDCEntity VDC { get => vdc; set => vdc = value; }

        private MunicipalityEntity municipality;
        public MunicipalityEntity Municipality { get => municipality; set => municipality = value; }
       
    }
}
