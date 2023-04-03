using System;

namespace MeroBolee.Dto
{
    public class PaymentDetailTenderIdResDto
    {
        public string TxnId { get; set; }
        public long TxnAmt { get; set; }
        public DateTime TxnDate { get; set; }
        public string TxnSts { get; set; }

        public string PaymentChanel { get; set; }
        public string CompanyName { get; set; }

    }
}