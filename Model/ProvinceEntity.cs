using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_province")]
    public class ProvinceEntity : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(300)]
        public string Name { get; set; }

        [ForeignKey("Country")]
        public int? CountryId { get; set; }

        public CountryEntity Country { get; set; }
    }
}
