using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Infrastructure
{
     public interface IUriService
    {
        Uri GetUri(PaginationQuery paginationQuery);
    }
}
