  using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_country")]
    public class CountryEntity : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity) ]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(10)]
        public string Code { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(5)]
        public string Abbre { get; set; }

    }
}
