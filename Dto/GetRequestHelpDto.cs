using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetRequestHelpDto
    {
        private string problem_title;
        private string description;
        private string remark;
        private int help_status_id;
        private string requestHelpStatus;
        private long user_id;
        private string username;
        private Guid user_code;
        private DateTime? resolve_date;

        public string Problem_title { get => problem_title; set => problem_title = value; }
        public string Description { get => description; set => description = value; }
        public string Remark { get => remark; set => remark = value; }
        public int Help_status_id { get => help_status_id; set => help_status_id = value; }
        public string RequestHelpStatus { get => requestHelpStatus; set => requestHelpStatus = value; }
        public long User_id { get => user_id; set => user_id = value; }
        public string Username { get => username; set => username = value; }
        public Guid User_code { get => user_code; set => user_code = value; }
        public DateTime? Resolve_date { get => resolve_date; set => resolve_date = value; }
    }
}
