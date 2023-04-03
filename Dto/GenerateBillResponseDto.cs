using System.Collections.Generic;

namespace MeroBolee.Dto
{
    public class GenerateBillResponseDto
    {
        public List<QuotationResponseDto> QuotationResponseDtoList { get; set;}
        public string FinalPosition { get; set;}

        public decimal TotalQuotation { get; set; }

        public string CompanyName { get; set; }

        public long UserId { get; set; }
        
        public long CompanyId { get; set; }
        
        public string PanNumber { get; set; }
    }
}