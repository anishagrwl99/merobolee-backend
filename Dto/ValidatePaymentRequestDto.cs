using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class ValidatePaymentRequestDto
    {
        public string txnId { get; set;}
        public string landingPage { get; set; }
    }
}