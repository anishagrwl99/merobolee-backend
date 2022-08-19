using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class ValidateTxnResponse
    {
        public string status { get; set; }
        public string statusDesc { get; set; }

        public string referenceId { get; set; }
    }
}