using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Infrastructure
{
    public class ErrorResponse<T>
    {
        public ErrorResponse(T response)
        {
            this.data = response;
        }

        public T data { get; set; }
    }
}
