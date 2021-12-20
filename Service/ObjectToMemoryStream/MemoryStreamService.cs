using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public interface IMemoryStreamService
    {
        byte[] ToArray(List<AuctionLog> logs);
    }
    public class MemoryStreamService : IMemoryStreamService
    {
        public byte[] ToArray(List<AuctionLog>  logs)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (TextWriter tw = new StreamWriter(ms))
                {
                    tw.WriteLine("Company,Bidding Time, Amount, Position");
                    foreach (AuctionLog item in logs)
                    {
                        tw.WriteLine($"{item.Company.Name},{item.LogDate},{item.Amount},{item.Position}");
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
