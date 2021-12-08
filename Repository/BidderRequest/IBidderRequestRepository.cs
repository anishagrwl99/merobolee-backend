using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public interface IBidderRequestRepository : IRepositoryBase<BidderRequestEntity>
    {
        Task<BidderRequestEntity> SendRequest(BidderRequestEntity bidderRequestEntity, ICollection<IFormFile> requestDoc);

        List<LiveBiddingEntity> LiveBid(List<LiveBiddingEntity> bidEntity);
        List<LiveBiddingEntity> AutoBid(List<LiveBiddingEntity> bidEntity);
        Task<List<LiveBiddingEntity>> TenderLiveBids(int tenderId);

       BidderRequestEntity ShowRequest(int requestId);

        IEnumerable<BidderRequestEntity> ShowAllRequest();

        IEnumerable<BidderRequestEntity> AllRequestByBidder(int bidderId);

        BidderRequestEntity UpdateRequest(int id, UpdateRequestDto updateRequest);

        Task<List<LiveBiddingEntity>> GetExpiredBids();

        Task<bool> DeleteLiveBids(List<LiveBiddingEntity> records);
        Task<bool> AddHistory(List<BiddingHistoryEntity> records);
        TenderEntity GetTenderDetail(long tenderId);

        void WriteAutionLogEntry(AuctionLog log);


    }
}
