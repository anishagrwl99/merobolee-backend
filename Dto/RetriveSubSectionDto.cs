using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class RetriveSubSectionDto
    {
        public decimal totalAmount { get; set; }
        public Dictionary<string, decimal> subsectionTotal {get;set;}

}
}