using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_municipality")]
    public class MunicipalityEntity: BaseEntity
    {

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MunicipalityId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(300)]
        public string MunicipalityName { get; set; }

        [ForeignKey("District")]
        public int? DistrictId { get; set; }


        public DistrictEntity District { get; set; }

    }
}
