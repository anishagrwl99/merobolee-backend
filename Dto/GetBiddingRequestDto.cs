using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MeroBolee.Dto
{
    public class EnterLiveBiddingRoomResponseDto
    {
        public long BidId { get; set; }
        public long CompanyId { get; set; }
        public long TenderId { get; set; }
        public string BidRequestStatus { get; set; }
        public bool IsSuspended { get; set; }

    }

    public class BidHistoryCardDto : BidCardDto
    {
        public int PostBidStatus { get; set; }
    }
    public class BidCardDto
    {
        public long BidId { get; set; }
        public long TenderId { get; set; }
        public long CompanyId { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public string TenderTitle { get; set; }
        public string TenderCategory { get; set; }
        public DateTime BidDate { get; set; }
        public string BidStatus { get; set; }
        public string PaymentProvider { get; set; }
        public string PaymentReferenceCode { get; set; }
        public decimal Price { get; set; }
        public DateTime TenderLiveDate { get; set; }
        public string TenderCode { get; set; }
        public string Product { get; set; }

        public string Location { get; set; }

        public DateTime RegistrationTill { get; set; }

        public DateTime LiveStartDate { get; set; }

        public DateTime LiveEndDate { get; set; }

        public string PanNumber { get; set; }
    }

    public class BidDetailDto : BidCardDto
    {
        public string Remarks { get; set; }
        public DateTime RegisterDate { get; set; }

        public List<DocResponseDto> Documents { get; set; }
        public List<BidHistory> BidHistories { get; set; }
    }

    public class BidHistory
    {
        public long TenderId { get; set; }
        public long BidId { get; set; }
        public string Material { get; set; }
        public decimal Quotation { get; set; }
        public DateTime BidTime { get; set; }
        public long BatchNo { get; set; }
        public string Position { get; set; }
    }

    public class ResetBidDto
    {
        public bool IsTenderExpired { get; set; }
        public bool IsQuotationReceived { get; set; }
        public long Interval { get; set; }
        public int RemainingMinute { get; set; }
        public int RemainingSecond { get; set; }
    
        public DateTime MinQuotationRecivedAt { get; set; }

        public int RoundNumber { get; set; }
         
        public DateTime TenderLiveStartDate { get; set; }

        [JsonIgnore]
        public DateTime TenderLiveEndDate { get; set; }

        [JsonIgnore]
        public int FullIntervalCountWithoutReceivingBid { get; set; }

        public int isTimeAdded { get; set; }

        public int totalMinutesAdded { get; set; }
    }
}
