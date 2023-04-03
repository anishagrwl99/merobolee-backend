using System.Collections.Generic;

namespace MeroBolee.Dto
{
    public class RetriveDataSealBid
    {
        public List<TenderMaterialSealedResponseDto> materialList { get; set; }
        public long TenderId { get; set; }
        public long supplierId { get; set; }
        public decimal subsectionTotal { get; set; }

        public long materialGroupId { get; set; }

        public string materialGroupName { get; set; }
    }
}