using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class PostRequestHelpDto
    {
        private string problemTitle;
        private string description;
        private int helpStatusid;
        private int userId;

        public string ProblemTitle { get => problemTitle; set => problemTitle = value; }
        public string Description { get => description; set => description = value; }
        public int HelpStatusId { get => helpStatusid; set => helpStatusid = value; }
        public int UserId { get => userId; set => userId = value; }
    }
}
