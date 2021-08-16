using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.BidderRequest
{
    public interface IBidderRequestRepository : IRepositoryBase<BidderRequestEntity>
    {
        BidderRequestEntity SendRequest(BidderRequestEntity bidderRequestEntity);
        BidderRequestEntity UpdateRequest(int id, int  admin_status_id);
    }
}
