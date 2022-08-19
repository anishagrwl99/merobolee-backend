using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class OtherModePaymentRequestDto
    {
        public long TenderId { get; set; }
        public string PaymentChannel { get; set; }
        public long CompanyId { get; set; }
        public long TxnAmount { get; set; }

    }
}