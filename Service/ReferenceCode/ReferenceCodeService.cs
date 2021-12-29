using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public enum ReferenceEnum
    {
        Bidder,
        BidInviter,
        Tender
    }
    public interface IReferenceCodeService
    {
        Task<string> GenerateCode(ReferenceEnum type);
    }
    public class ReferenceCodeService : IReferenceCodeService
    {
        public Task<string> GenerateCode(ReferenceEnum type)
        {
            return Task.Run(() =>
            {
                string val = "";
                string uniqueVal = DateTime.Now.ToString("yyMMdd");
                switch (type)
                {
                    case ReferenceEnum.Bidder:
                        return $"SP{uniqueVal}";
                    case ReferenceEnum.BidInviter:
                        return $"BI{uniqueVal}";
                    case ReferenceEnum.Tender:
                        return $"T{uniqueVal}";
                }

                return val;
            });
        }
    }
}
