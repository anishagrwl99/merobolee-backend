using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MeroBolee.Model.CommonStatus;

namespace MeroBolee.Dto
{
    public class GetCategoryDto
    {
        private int id;
        private string category;

        public int Id { get => id; set => id = value; }
        public string Category { get => category; set => category = value; }
       
    }
}
