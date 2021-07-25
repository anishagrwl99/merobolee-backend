using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.Status
{
    public class AuctionStatusRepository : RepositoryBase<AuctionStatusEntity>, IAuctionStatusRepository
    {
        public AuctionStatusRepository(IDbFactory dbFactory) : base(dbFactory)
        { }

        public IEnumerable<AuctionStatusEntity> GetAuctionStatuses()
        {
            return meroBoleeDbContexts.AuctionStatusEntities.ToList();
        }
    }
}
