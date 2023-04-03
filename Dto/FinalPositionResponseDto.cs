using System;

namespace MeroBolee.Dto
{
    public class FinalPositionResponseDto
    {
        public decimal Amount { get; set; }
        public String position { get; set; }

        public long userId { get; set; }
        
        public long CompanyId { get; set; }

        public String companyName { get; set; }
        
        public string PanNumber { get; set; }
    }
}