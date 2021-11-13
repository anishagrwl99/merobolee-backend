using MeroBolee.Model;
using MeroBolee.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository statusRepository;
        private readonly IAdminStatusRepository adminStatusRepository;
        private readonly IAuctionStatusRepository auctionStatusRepository;
        private readonly IUserStatusRepository userStatusRepository;
        private readonly IPaymentStatusRepository paymentStatusRepository;
        private readonly IRequestStatusRepository requestStatusRepository;
        public StatusService(IStatusRepository statusRepository, IAdminStatusRepository adminStatusRepository, IAuctionStatusRepository auctionStatusRepository, IUserStatusRepository userStatusRepository, IPaymentStatusRepository paymentStatusRepository, IRequestStatusRepository requestStatusRepository)
        {
            this.statusRepository = statusRepository;
            this.adminStatusRepository = adminStatusRepository;
            this.auctionStatusRepository = auctionStatusRepository;
            this.userStatusRepository = userStatusRepository;
            this.paymentStatusRepository = paymentStatusRepository;
            this.requestStatusRepository = requestStatusRepository;
        }

        public IEnumerable<AdminStatusEntity> GetAdminStatuses()
        {
            return adminStatusRepository.GetAdminStatuses();
        }

        public IEnumerable<AuctionStatusEntity> GetAuctionStatuses()
        {
            return auctionStatusRepository.GetAuctionStatuses();
        }

        public IEnumerable<PaymentStatusEntity> GetPaymentStatuses()
        {
            return paymentStatusRepository.GetPaymentStatusEntities();
        }

        public IEnumerable<PublishStatus> GetPublishStatuses()
        {
            return statusRepository.GetPublishStatuses();
        }

        public IEnumerable<RequestHelpStatus> GetRequestHelpStatuses()
        {
            return requestStatusRepository.GetRequestHelpStatus();
        }

        public IEnumerable<UserStatusEntity> GetUserStatuses()
        {
            return userStatusRepository.GetUserStatuses();
        }
    }
}
