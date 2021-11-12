using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class UpdateRequestHelpDto
    {
        private string problemTitle;
        private string description;
        private string remark;
        private int helpStatusId;
        private DateTime? resolveDate;

        public string ProblemTitle { get => problemTitle; set => problemTitle = value; }
        public string Description { get => description; set => description = value; }
        public string Remark { get => remark; set => remark = value; }
        public int HelpStatusId { get => helpStatusId; set => helpStatusId = value; }
        public DateTime? ResolveDate { get => resolveDate; set => resolveDate = value; }
    }
}
