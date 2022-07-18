using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddTimeDto
    {
        public int min { get;  set;}
        public long tenderId { get; set; } 
        public long status { get; set; }
    }
}