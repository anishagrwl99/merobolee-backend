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
        private int status_id;
        private string status;

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity) ]
        [Column("status_id")]
        public int Status_id { get => status_id; set => status_id = value; }
        [Column ("status")] 
        public string Status { get => status; set => status = value; }
    }
}
