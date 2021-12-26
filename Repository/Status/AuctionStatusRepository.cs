using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public class AuctionStatusRepository : RepositoryBase<BidRequestStatusEntity>, IAuctionStatusRepository
    {
        public AuctionStatusRepository(IDbFactory dbFactory) : base(dbFactory)
        { }

        public IEnumerable<BidRequestStatusEntity> GetAuctionStatuses()
        {
            return meroBoleeDbContexts.AuctionStatusEntities.ToList();
        }
    }
}
