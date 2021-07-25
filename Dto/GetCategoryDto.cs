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
        private int status_Id;
        private string status;

        public int Id { get => id; set => id = value; }
        public string Category { get => category; set => category = value; }
        public int Status_Id { get => status_Id; set => status_Id = value; }
        public string Status { get => status; set => status = value; }
       
    }
}
