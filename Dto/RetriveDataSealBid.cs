using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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