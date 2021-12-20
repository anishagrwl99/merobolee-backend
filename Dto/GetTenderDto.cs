using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetTenderDto
    {
        private long tenderId;
        private string tenderCode;
        private string tenderTitle;
        private int categoryId;
        private string category;
        private string tenderDescription;
        private int tenderliveinterval;
        private DateTime liveStartDate;
        private DateTime liveEndDate;
        private int projectDuration;
        private string durationType;
        private long postedBy;
        private UserEntity userEntity;
        private int tenderStatusId;
        private string auctionStatus;
        private string cancelRemark;
        private DateTime? publishDate;
        private ICollection<TenderMaterialEntity> tenderMaterialEntities;
        private TenderTermsConditionEntity tenderTermsConditionEntities;

        public long TenderId { get => tenderId; set => tenderId = value; }
        public string TenderCode { get => tenderCode; set => tenderCode = value; }
        public string TenderTitle { get => tenderTitle; set => tenderTitle = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string Category { get => category; set => category = value; }
        public string TenderDescription { get => tenderDescription; set => tenderDescription = value; }
        public int TenderLiveInterval { get => tenderliveinterval; set => tenderliveinterval = value; }
        public DateTime LiveStartDate { get => liveStartDate; set => liveStartDate = value; }
        public DateTime LiveEndDate { get => liveEndDate; set => liveEndDate = value; }
        public int ProjectDuration { get => projectDuration; set => projectDuration = value; }
        public string DurationType { get => durationType; set => durationType = value; }
        public long PostedBy { get => postedBy; set => postedBy = value; }
        public UserEntity User { get => userEntity; set => userEntity = value; }

        public int TenderStatusId { get => tenderStatusId; set => tenderStatusId = value; }
        public string TenderStatus { get => auctionStatus; set => auctionStatus = value; }
        public ICollection<TenderMaterialEntity> TenderMaterial { get => tenderMaterialEntities; set => tenderMaterialEntities = value; }
        public TenderTermsConditionEntity TenderTermsCondition { get => tenderTermsConditionEntities; set => tenderTermsConditionEntities = value; }
        public string CancelRemark { get => cancelRemark; set => cancelRemark = value; }
        public DateTime? Publish_Date { get => publishDate; set => publishDate = value; }
    }


    public class TenderCard
    {
        public long TenderId { get; set; }
        public string TenderTitle { get; set; }
        public string TenderCode { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime LiveStartDate { get; set; }
        public DateTime LiveEndDate { get; set; }
        public DateTime RegistrationTill { get; set; }
        public string Status { get; set; }

        public List<TenderCardInfo> CardInfo { get; set; }

        [JsonIgnore]
        public int StatusId { get; set; }

    }

    public class TenderCardInfo
    {
        public string Label { get; set; }
        public string Value { get; set; }
    }

    public class TenderWatchListCard: TenderCard
    {
        public int WatchListId { get; set; }
    }

    public class BidInviterTenderListing
    {
        public List<TenderCard> PendingTenders { get; set; }
        public List<TenderCard> ActiveTenders { get; set; }
    }
}
