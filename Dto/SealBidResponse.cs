using System.Collections.Generic;

namespace MeroBolee.Dto
{
    public class SealBidResponse
    {
        public bool IsBidSuccess { get; set; }
        public Dictionary<string, List<TenderMaterialQuotationDtoForSealBid>> MaterialQuotation { get; set; }

        public Dictionary<string, decimal> subsectionTotal { get; set; }
        public decimal CurrentQuotation { get; set; }
        public string message { get; set; }
    }
}