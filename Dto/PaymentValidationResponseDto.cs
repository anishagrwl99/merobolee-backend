using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class PaymentValidationResponseDto
    {
        public string txnStatus { get; set; }
        public string txnId { get; set; }
        public long TenderId { get; set; }
        public long TxnAmount { get; set; }
        public long CompanyId { get; set; }
        public long UserId { get; set; }
        public string PaymentChannel { get; set; }
    }
}