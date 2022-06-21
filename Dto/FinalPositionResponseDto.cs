using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class FinalPositionResponseDto
    {
        public decimal Amount { get; set; }
        public String position { get; set; }

        public long userId { get; set; }

        public String companyName { get; set; }
    }
}