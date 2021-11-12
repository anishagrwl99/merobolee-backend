using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class BiddingRequestTender
    {
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
        private DateTime? publishDate;
       // private TimeSpan publish_time;
        private DateTime lastRequestDate;
        private DateTime projectStartDate;
        private ICollection<TenderMaterialEntity> tenderMaterialEntities;
        private TenderTermsConditionEntity tenderTermsConditionEntities;

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
        public DateTime? PublishDate { get => publishDate; set => publishDate = value; }
    //    public TimeSpan Publish_time { get => publish_time; set => publish_time = value; }
        public DateTime LastRequestDate { get => lastRequestDate; set => lastRequestDate = value; }
        public DateTime Project_Start_Date { get => projectStartDate; set => projectStartDate = value; }
        public ICollection<TenderMaterialEntity> TenderMaterials { get => tenderMaterialEntities; set => tenderMaterialEntities = value; }
        public TenderTermsConditionEntity TenderTermsCondition { get => tenderTermsConditionEntities; set => tenderTermsConditionEntities = value; }
    }
}
