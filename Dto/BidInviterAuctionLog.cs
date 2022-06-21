using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class BidInviterAuctionLog
    {
        public decimal Amount { get; set; } 
        public string Position { get; set; }
        public DateTime LogDate { get; set; }

        public long TenderId { get; set; }
    }
}