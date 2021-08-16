using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class TenderWatchlistDto
    {
        private int tender_Id;
        private Guid tender_Code;
        private string tender_Title;
        private int category_Id;
        private WatchCategoryDto category;
        private string tender_Description;
        private DateTime last_Request_Date;
        private string source_Fund;
        private string IFB_RFP_EOI;
        private DateTime project_Start_Date;
        private DateTime live_Start_Date;
        private DateTime live_End_Date;
        private int tender_Duration;
        private string duration_Type;
        private DateTime? publish_Date;
    //    private TimeSpan publish_Time;
        private int status_id;
        private AdminStatusEntity status;

        public int Tender_Id { get => tender_Id; set => tender_Id = value; }
        public Guid Tender_Code { get => tender_Code; set => tender_Code = value; }
        public string Tender_Title { get => tender_Title; set => tender_Title = value; }
        public int Category_Id { get => category_Id; set => category_Id = value; }
        public WatchCategoryDto Category { get => category; set => category = value; }
        public string Tender_Description { get => tender_Description; set => tender_Description = value; }
        public DateTime Last_Request_Date { get => last_Request_Date; set => last_Request_Date = value; }
        public string Source_Fund { get => source_Fund; set => source_Fund = value; }
        public string IFB_RFP_EOI1 { get => IFB_RFP_EOI; set => IFB_RFP_EOI = value; }
        public DateTime Project_Start_Date { get => project_Start_Date; set => project_Start_Date = value; }
        public DateTime Live_Start_Date { get => live_Start_Date; set => live_Start_Date = value; }
        public DateTime Live_End_Date { get => live_End_Date; set => live_End_Date = value; }
        public int Tender_Duration { get => tender_Duration; set => tender_Duration = value; }
        public string Duration_Type { get => duration_Type; set => duration_Type = value; }
        public DateTime? Publish_Date { get => publish_Date; set => publish_Date = value; }
     //   public TimeSpan Publish_Time { get => publish_Time; set => publish_Time = value; }
        public int Status_id { get => status_id; set => status_id = value; }
        public AdminStatusEntity Status { get => status; set => status = value; }
    }
}
