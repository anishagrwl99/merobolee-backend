using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class WatchCategoryDto
    {
        private int id;
        private string categgory;

        public int Id { get => id; set => id = value; }
        public string Categgory { get => categgory; set => categgory = value; }
    }
}
