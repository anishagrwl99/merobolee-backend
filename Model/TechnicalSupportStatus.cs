using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("lk_TechnicalSupportStatus")]
    public class TechnicalSupportStatus
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int StatusId { get; set; }


        [Column("Status", TypeName = "VARCHAR")]
        [MaxLength(50)]
        public string Status { get; set; }
    }
}
