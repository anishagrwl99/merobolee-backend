using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetBiddingRequestDto
    {
        private long bidid;
        private Guid requestcode;
        private long userid;
        private string username;
        private long tenderId;
        private BiddingRequestTender tenderEntity;
        private int adminStatusId;
        private AdminStatusEntity adminStatusEntity;
        private DateTime requestSendDate;
        private string remark;
        private ICollection<BidderRequestDocEntity> bidderRequestDocs;


        public long BidId
        {
            get { return bidid; }
            set { bidid = value; }
        }

        public Guid RequestCode { get => requestcode; set => requestcode = value; }
        public long UserId { get => userid; set => userid = value; }
        public string Username { get => username; set => username = value; }
        public long TenderId { get => tenderId; set => tenderId = value; }
        public BiddingRequestTender Tender { get => tenderEntity; set => tenderEntity = value; }
        public int AdminStatusId { get => adminStatusId; set => adminStatusId = value; }
        public AdminStatusEntity AdminStatus { get => adminStatusEntity; set => adminStatusEntity = value; }
        public DateTime RequestSendDate { get => requestSendDate; set => requestSendDate = value; }
        public string Remark { get => remark; set => remark = value; }
        public ICollection<BidderRequestDocEntity> BidderRequestDocs { get => bidderRequestDocs; set => bidderRequestDocs = value; }
    }


    public class ResetBidDto
    {
        public bool IsTenderExpired { get; set; }
        public bool IsQuotationReceived { get; set; }
        public long Interval { get; set; }
        public int RemainingMinute { get; set; }
        public int RemainingSecond { get; set; }
        public DateTime MinQuotationRecivedAt { get; set; }

        [JsonIgnore]
        public DateTime TenderLiveEndDate { get; set; }

        [JsonIgnore]
        public int FullIntervalCountWithoutReceivingBid { get; set; }
    }
}
