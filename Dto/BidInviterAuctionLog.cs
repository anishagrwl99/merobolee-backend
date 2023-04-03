using System;

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