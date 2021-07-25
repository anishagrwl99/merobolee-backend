using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.Status
{
    public interface IStatusService
    {
        IEnumerable<PublishStatus> GetPublishStatuses();
        IEnumerable<AdminStatusEntity> GetAdminStatuses();
        IEnumerable<AuctionStatusEntity> GetAuctionStatuses();
        IEnumerable<UserStatusEntity> GetUserStatuses();

    }
}
