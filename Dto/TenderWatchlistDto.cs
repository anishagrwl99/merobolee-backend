using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class TenderWatchlistDto
    {
        private long tenderId;
        private string tenderCode;
        private string tenderTitle;
        private int categoryId;
        private WatchCategoryDto category;
        private string tenderDescription;
        private DateTime liveStartDate;
        private DateTime liveEndDate;
        private int tenderDuration;
        private string durationType;
        private DateTime? publishDate;
    //    private TimeSpan publish_Time;
        private int statusid;
        private AdminStatusEntity status;

        public long TenderId { get => tenderId; set => tenderId = value; }
        public string TenderCode { get => tenderCode; set => tenderCode = value; }
        public string TenderTitle { get => tenderTitle; set => tenderTitle = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public WatchCategoryDto Category { get => category; set => category = value; }
        public string TenderDescription { get => tenderDescription; set => tenderDescription = value; }
       
        public DateTime LiveStartDate { get => liveStartDate; set => liveStartDate = value; }
        public DateTime LiveEndDate { get => liveEndDate; set => liveEndDate = value; }
        public int TenderDuration { get => tenderDuration; set => tenderDuration = value; }
        public string DurationType { get => durationType; set => durationType = value; }
        public DateTime? PublishDate { get => publishDate; set => publishDate = value; }
     //   public TimeSpan Publish_Time { get => publish_Time; set => publish_Time = value; }
        public int StatusId { get => statusid; set => statusid = value; }
        public AdminStatusEntity Status { get => status; set => status = value; }
    }
}
