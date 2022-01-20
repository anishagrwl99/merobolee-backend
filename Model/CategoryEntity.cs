using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static MeroBolee.Model.CommonStatus;

namespace MeroBolee.Model
{
    [Table("lk_category")]
    public class CategoryEntity : BaseEntity
    {

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string Category { get; set; }

    }
}
