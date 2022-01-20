using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetWatchListDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long CompanyId { get; set; }

        public TenderWatchlistDto Tender_Detail { get; set; }
    }
}
