using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("lk_common_status")]
    public class CommonStatus
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity) ]
        public int Id { get; set; }


        [Column (TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string Status { get; set; }
    }
}
