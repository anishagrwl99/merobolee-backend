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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string Name { get; set; }

        [ForeignKey("Municipality")]
        public int? MunicipalityId { get; set; }

        [ForeignKey("VDC")]
        public int? VdcId { get; set; }

        public VDCEntity VDC { get; set; }

        public MunicipalityEntity Municipality { get; set; }
       
    }
}
