using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Infrastructure
{
    public class PaginationMapper
    {
        public PaginationFilter PaginationMap(PaginationQuery paginationQuery)
        {
            if (paginationQuery == null)
            {
                PaginationQuery pagination = new PaginationQuery();
                return new PaginationFilter
                {
                    pageNumber = pagination.pageNo,
                    pageSize = pagination.size
                };
            }
            return new PaginationFilter
            {
                pageNumber = paginationQuery.pageNo,
                pageSize = paginationQuery.size

            };
        }
    }
}
