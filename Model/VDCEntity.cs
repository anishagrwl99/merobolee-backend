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

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(300)]
        public string Name { get; set; }

        [ForeignKey("District")]
        public int? DistrictId { get; set; }

        public DistrictEntity District { get; set; }

    }
}
