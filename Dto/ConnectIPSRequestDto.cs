using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class ConnectIPSRequestDto
    {
        public decimal TxnAmt { get; set; }
        public string Remarks {get; set;}

        public long UserId { get; set; }

        public long CompanyId { get; set; }
    }
}