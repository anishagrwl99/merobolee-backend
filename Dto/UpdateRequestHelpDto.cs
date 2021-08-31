using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class UpdateRequestHelpDto
    {
        private string problem_title;
        private string description;
        private string remark;
        private int help_status_id;
        private DateTime? resolve_date;

        public string Problem_title { get => problem_title; set => problem_title = value; }
        public string Description { get => description; set => description = value; }
        public string Remark { get => remark; set => remark = value; }
        public int Help_status_id { get => help_status_id; set => help_status_id = value; }
        public DateTime? Resolve_date { get => resolve_date; set => resolve_date = value; }
    }
}
