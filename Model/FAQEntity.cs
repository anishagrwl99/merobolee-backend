using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_FAQ")]
    public class FAQEntity : BaseEntity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        
        [Column(TypeName = "VARCHAR")]
        [MaxLength(1000)]
        public string Question { get; set; }


        [Column(TypeName = "VARCHAR")]
        [MaxLength(5000)]
        public string Answer { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(5000)]
        public string FAQType { get; set; }
    }
}
