using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Infrastructure
{
    public class PagedResponse <T>
    {
        public PagedResponse() { }
        public PagedResponse(IEnumerable<T> data, int total)
        {
            this.data = data;
            totalCount = total;
        }

        public IEnumerable<T> data { get; set; }
        public int? pageNumber { get; set; }
        public int? pageSize { get; set; }
        public string nextPage { get; set; }
        public string previousPage { get; set; }
        public int totalCount { get; set; }
        public string firstPage { get; set; }
        public string lastPage { get; set; }

    }
}
