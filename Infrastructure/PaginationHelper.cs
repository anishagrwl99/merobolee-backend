using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Infrastructure
{
    public class PaginationHelper
    {
        public static PagedResponse<T> CreatedPaginationResponse<T>(IUriService uriService, PaginationFilter paginationFilteration, IEnumerable<T> response, int total)
        {
            int totalPage = (int)(total / paginationFilteration.pageSize);
            int totals = total % paginationFilteration.pageSize;
            if (totalPage == 0 || totalPage < (total / paginationFilteration.pageSize) || totals > 0)
            {
                totalPage ++;
            }

            var NextPage = (paginationFilteration.pageNumber >= 1 && paginationFilteration.pageNumber < totalPage)
             ? uriService.GetUri(new PaginationQuery(pageNo: paginationFilteration.pageNumber + 1, Size: paginationFilteration.pageSize)).ToString()
             : null;

            var PreviousPage = paginationFilteration.pageNumber - 1 >= 1
               ? uriService.GetUri(new PaginationQuery(pageNo: paginationFilteration.pageNumber - 1, Size: paginationFilteration.pageSize)).ToString()
               : null;

            var first = uriService.GetUri(new PaginationQuery(pageNo: 1, Size: paginationFilteration.pageSize)).ToString();
            var last = uriService.GetUri(new PaginationQuery(pageNo: totalPage, Size: paginationFilteration.pageSize)).ToString();

            return new PagedResponse<T>
            {
                data = response,
                pageNumber = paginationFilteration.pageNumber >= 1 ? paginationFilteration.pageNumber : (int?)null,
                pageSize = paginationFilteration.pageSize >= 1 ? paginationFilteration.pageSize : (int?)null,
                nextPage = response.Any() ? NextPage : null, // To check is there object or not if yes then next page
                previousPage = PreviousPage,
                firstPage = first,
                lastPage = last,
                totalCount = total,

            };

        }
    }
}