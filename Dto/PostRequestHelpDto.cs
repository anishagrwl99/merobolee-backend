using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class PostRequestHelpDto
    {
        private string problem_title;
        private string description;
        private int help_status_id;
        private int user_id;

        public string Problem_title { get => problem_title; set => problem_title = value; }
        public string Description { get => description; set => description = value; }
        public int Help_status_id { get => help_status_id; set => help_status_id = value; }
        public int User_id { get => user_id; set => user_id = value; }
    }
}
