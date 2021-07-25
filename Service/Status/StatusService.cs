using MeroBolee.Model;
using MeroBolee.Repository.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.Status
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository statusRepository;
        private readonly IAdminStatusRepository adminStatusRepository;
        private readonly IAuctionStatusRepository auctionStatusRepository;
        private readonly IUserStatusRepository userStatusRepository;
        public StatusService(IStatusRepository statusRepository, IAdminStatusRepository adminStatusRepository, IAuctionStatusRepository auctionStatusRepository, IUserStatusRepository userStatusRepository)
        {
            this.statusRepository = statusRepository;
            this.adminStatusRepository = adminStatusRepository;
            this.auctionStatusRepository = auctionStatusRepository;
            this.userStatusRepository = userStatusRepository;
        }

        public IEnumerable<AdminStatusEntity> GetAdminStatuses()
        {
            return adminStatusRepository.GetAdminStatuses();
        }

        public IEnumerable<AuctionStatusEntity> GetAuctionStatuses()
        {
            return auctionStatusRepository.GetAuctionStatuses();
        }

        public IEnumerable<PublishStatus> GetPublishStatuses()
        {
            return statusRepository.GetPublishStatuses();
        }

        public IEnumerable<UserStatusEntity> GetUserStatuses()
        {
            return userStatusRepository.GetUserStatuses();
        }
    }
}
