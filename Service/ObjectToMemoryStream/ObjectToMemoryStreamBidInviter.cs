using System.Collections.Generic;
using System.IO;
using MeroBolee.Dto;


namespace MeroBolee.Service
{
    public interface IMemoryStreamServiceBidInviter
    {
        byte[] ToArray(List<BidInviterAuctionLog> logs);
    }
    public class MemoryStreamServiceBidInviter : IMemoryStreamServiceBidInviter
    {
        public byte[] ToArray(List<BidInviterAuctionLog>  logs)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (TextWriter tw = new StreamWriter(ms))
                {
                    tw.WriteLine("Position,Amount, LogDate");
                    foreach (BidInviterAuctionLog item in logs)
                    {
                        tw.WriteLine($"{item.Position},{item.Amount},{item.LogDate}");
                    }
                    tw.Flush();
                }
                byte[] content = ms.ToArray();
                ms.Close();
                return content;
            }
        }
    }
        
}