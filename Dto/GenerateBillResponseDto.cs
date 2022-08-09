using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GenerateBillResponseDto
    {
        public List<QuotationResponseDto> QuotationResponseDtoList { get; set;}
        public string FinalPosition { get; set;}

        public decimal TotalQuotation { get; set; }

        public string CompanyName { get; set; }
    }
}