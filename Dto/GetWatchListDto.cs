using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetWatchListDto
    {
        private int id;
        private long userid;
        private long companyId;
        private TenderWatchlistDto tender_Detail;

        public int Id { get => id; set => id = value; }
        public long UserId { get => userid; set => userid = value; }
        public long CompanyId { get => companyId; set => companyId = value; }

        public TenderWatchlistDto Tender_Detail { get => tender_Detail; set => tender_Detail = value; }
    }
}
