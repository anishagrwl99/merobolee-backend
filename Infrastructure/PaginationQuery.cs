using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Infrastructure
{
    public class PaginationQuery
    {
        public PaginationQuery()
        {
            pageNo = 1;
            size = 10;
        }

        public PaginationQuery(int pageNo, int Size)
        {
            this.pageNo = pageNo;
            this.size = Size;
        }
        public int pageNo { get; set; }

        public int size { get; set; }

    }
}
