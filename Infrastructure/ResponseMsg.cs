using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Infrastructure
{
    public class ResponseMsg
    {
        public string statusCode { get; set; }
        public string Message { get; set; }

        public object Data { get; set; }
    }
}
