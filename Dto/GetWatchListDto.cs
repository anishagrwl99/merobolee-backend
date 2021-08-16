using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetWatchListDto
    {
        private int id;
        private int user_id;
        private TenderWatchlistDto tender_Detail;

        public int Id { get => id; set => id = value; }
        public int User_id { get => user_id; set => user_id = value; }
        public TenderWatchlistDto Tender_Detail { get => tender_Detail; set => tender_Detail = value; }
    }
}
