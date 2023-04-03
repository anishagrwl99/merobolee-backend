using System.Collections.Generic;

namespace MeroBolee.Dto
{
    public class SealBidMaterialCacheRequestDto
    {
        public long TenderId { get; set; }
        public long CompanyId { get; set; }
        public long BiddingId { get; set; }
        public List<TenderMaterialQuotationDtoForSealBid> MaterialQuotation { get; set; }
        public string MaterialGroup { get; set; }
    }
}