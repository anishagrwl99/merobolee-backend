using System.Collections.Generic;

namespace MeroBolee.Dto
{
    public class RetriveSubSectionDto
    {
        public decimal totalAmount { get; set; }
        public Dictionary<string, decimal> subsectionTotal {get;set;}

}
}