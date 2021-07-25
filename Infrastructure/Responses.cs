using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Infrastructure
{
    public class Responses<T>
    {
        public Responses()
        { }

        public Responses(T response, string statusCode, string Message)
        {
            data = response;
            this.statusCode = statusCode;
            this.Message = Message;
        }
        public T data { get; set; }
        public string statusCode { get; set; }
        public string Message { get; set; }
               
    }
  
}
