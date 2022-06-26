using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class ConnectIPSResponseDto
    {
        public string TxnId { get; set; }
        public string TxnCurrency { get; set; }
        public decimal TxnAmount { get; set; }
        public DateTime TxnTime { get; set; }

        public string Remarks { get; set; }

        public string Particulars { get; set; }

        public string Token { get; set; }
        public string ReferenceId { get; set; }
    }
}