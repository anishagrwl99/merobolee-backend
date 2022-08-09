using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class QuotationResponseDto
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Units { get; set; }
        public decimal Quotation { get; set; }
    }
}