using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("lk_request_help_status")]
    public class RequestHelpStatus
    {
        private int status_id;
        private string request_status;

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("status_id")]
        public int Status_id { get => status_id; set => status_id = value; }
        [Column("request_status")]
        public string Request_status { get => request_status; set => request_status = value; }
    }
}
