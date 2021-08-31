using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class BiddingRequestTender
    {
        private Guid tender_Code;
        private string tender_Title;
        private int category_Id;
        private string category;
        private string tender_Description;
        private int tender_live_interval;
        private DateTime live_Start_Date;
        private DateTime live_End_Date;
        private int project_Duration;
        private string duration_Type;
        private DateTime? publish_Date;
       // private TimeSpan publish_time;
        private DateTime last_Request_Date;
        private DateTime project_Start_Date;
        private ICollection<TenderMaterialEntity> tenderMaterialEntities;
        private ICollection<TenderTermsConditionEntity> tenderTermsConditionEntities;

        public Guid Tender_Code { get => tender_Code; set => tender_Code = value; }
        public string Tender_Title { get => tender_Title; set => tender_Title = value; }
        public int Category_Id { get => category_Id; set => category_Id = value; }
        public string Category { get => category; set => category = value; }
        public string Tender_Description { get => tender_Description; set => tender_Description = value; }
        public int Tender_live_interval { get => tender_live_interval; set => tender_live_interval = value; }
        public DateTime Live_Start_Date { get => live_Start_Date; set => live_Start_Date = value; }
        public DateTime Live_End_Date { get => live_End_Date; set => live_End_Date = value; }
        public int Project_Duration { get => project_Duration; set => project_Duration = value; }
        public string Duration_Type { get => duration_Type; set => duration_Type = value; }
        public DateTime? Publish_Date { get => publish_Date; set => publish_Date = value; }
    //    public TimeSpan Publish_time { get => publish_time; set => publish_time = value; }
        public DateTime Last_Request_Date { get => last_Request_Date; set => last_Request_Date = value; }
        public DateTime Project_Start_Date { get => project_Start_Date; set => project_Start_Date = value; }
        public ICollection<TenderMaterialEntity> TenderMaterialEntities { get => tenderMaterialEntities; set => tenderMaterialEntities = value; }
        public ICollection<TenderTermsConditionEntity> TenderTermsConditionEntities { get => tenderTermsConditionEntities; set => tenderTermsConditionEntities = value; }
    }
}
