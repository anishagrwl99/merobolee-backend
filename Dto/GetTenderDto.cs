using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetTenderDto
    {
        private int tender_Id;
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
        private int bid_No;
        private int posted_By;
        private UserEntity userEntity;
        private int tender_Status_Id;
        private string auctionStatus;
        private int admin_Status_Id;
        private string adminStatus;
        private float tender_fee;
        private DateTime last_Request_Date;
        private string source_Fund;
        private string IFB_RFP_EOI;
        private DateTime project_Start_Date;
        private string cancel_Remark;
        private DateTime? publish_Date;
        private TimeSpan publish_time;
        //private int payment_Status_Id;
        //private string paymentStatus;
        private ICollection<TenderMaterialEntity> tenderMaterialEntities;
        private ICollection<TenderTermsConditionEntity> tenderTermsConditionEntities;

        public int Tender_Id { get => tender_Id; set => tender_Id = value; }
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
        public int Bid_No { get => bid_No; set => bid_No = value; }
        public int Posted_By { get => posted_By; set => posted_By = value; }
        public UserEntity UserEntity { get => userEntity; set => userEntity = value; }

        public int Tender_Status_Id { get => tender_Status_Id; set => tender_Status_Id = value; }
        public string AuctionStatus { get => auctionStatus; set => auctionStatus = value; }
        public int Admin_Status_Id { get => admin_Status_Id; set => admin_Status_Id = value; }
        public string AdminStatus { get => adminStatus; set => adminStatus = value; }
        public float Tender_fee { get => tender_fee; set => tender_fee = value; }
        //public int Payment_Status_Id { get => payment_Status_Id; set => payment_Status_Id = value; }
        //public string PaymentStatus { get => paymentStatus; set => paymentStatus = value; }
        public ICollection<TenderMaterialEntity> TenderMaterialEntities { get => tenderMaterialEntities; set => tenderMaterialEntities = value; }
        public ICollection<TenderTermsConditionEntity> TenderTermsConditionEntities { get => tenderTermsConditionEntities; set => tenderTermsConditionEntities = value; }
        public string Cancel_Remark { get => cancel_Remark; set => cancel_Remark = value; }
        public DateTime Last_Request_Date { get => last_Request_Date; set => last_Request_Date = value; }
        public string Source_Fund { get => source_Fund; set => source_Fund = value; }
     //   public string IFB_RFP_EOI1 { get => IFB_RFP_EOI; set => IFB_RFP_EOI = value; }
        public DateTime Project_Start_Date { get => project_Start_Date; set => project_Start_Date = value; }
        public DateTime? Publish_Date { get => publish_Date; set => publish_Date = value; }
        public TimeSpan Publish_time { get => publish_time; set => publish_time = value; }
    }
}
