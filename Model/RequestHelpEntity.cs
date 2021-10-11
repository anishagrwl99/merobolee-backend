using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_request_help")]
    public class RequestHelpEntity: BaseEntity
    {
        private int request_help_id;
        private string problem_title;
        private string description;
        private string remark;
        private int help_status_id;
        private RequestHelpStatus requestHelpStatus;
        private long user_id;
        private UserEntity userEntity;
        private DateTime? help_close_date;

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("request_help_id")]
        public int Request_help_id { get => request_help_id; set => request_help_id = value; }

        [Column("problem_title")]
        public string Problem_title { get => problem_title; set => problem_title = value; }

        [Column("description")]
        public string Description { get => description; set => description = value; }

        [Column("remark")]
        public string Remark { get => remark; set => remark = value; }

        [Column("help_status_id")]
        [ForeignKey("RequestHelpStatus")]
        public int Help_status_id { get => help_status_id; set => help_status_id = value; }

        public RequestHelpStatus RequestHelpStatus { get => requestHelpStatus; set => requestHelpStatus = value; }
      
        [Column("user_id")]
        [ForeignKey ("UserEntity")]
        public long User_id { get => user_id; set => user_id = value; }

        [JsonIgnore]
        public UserEntity UserEntity { get => userEntity; set => userEntity = value; }

        [Column("resolve_date")]
        public DateTime? Help_close_date { get => help_close_date; set => help_close_date = value; }
    }
}
