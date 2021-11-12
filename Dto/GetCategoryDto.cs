using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MeroBolee.Model.PublishStatus;

namespace MeroBolee.Dto
{
    public class GetCategoryDto
    {
        private int id;
        private string category;
        private int statusId;
        private string status;

        public int Id { get => id; set => id = value; }
        public string Category { get => category; set => category = value; }
        public int StatusId { get => statusId; set => statusId = value; }
        public string Status { get => status; set => status = value; }
       
    }
}
