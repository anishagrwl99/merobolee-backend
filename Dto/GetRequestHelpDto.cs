using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetRequestHelpDto
    {
        private string problemtitle;
        private string description;
        private string remark;
        private int helpstatusid;
        private string requestHelpStatus;
        private long userid;
        private string username;
        private Guid usercode;
        private DateTime? resolvedate;

        public string ProblemTitle { get => problemtitle; set => problemtitle = value; }
        public string Description { get => description; set => description = value; }
        public string Remark { get => remark; set => remark = value; }
        public int HelpStatusId { get => helpstatusid; set => helpstatusid = value; }
        public string RequestHelpStatus { get => requestHelpStatus; set => requestHelpStatus = value; }
        public long UserId { get => userid; set => userid = value; }
        public string Username { get => username; set => username = value; }
        public Guid UserCode { get => usercode; set => usercode = value; }
        public DateTime? ResolvDate { get => resolvedate; set => resolvedate = value; }
    }
}
