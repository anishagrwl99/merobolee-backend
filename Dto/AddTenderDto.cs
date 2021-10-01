using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddTenderDto
    {
        private string tender_Title;
        private int category_Id;
        private string tender_Description;
        private int tender_live_interval;
        private DateTime live_Start_Date;
        private int tender_Duration;
        private string duration_Type;
        private int bid_No;
        private int posted_By;
        private int tender_Status_Id;
        private int admin_Status_Id;
        private string cancel_Remark;
        private DateTime last_Request_Date;
        private string source_Fund;
        private string IFB_RFP_EOI;
        private DateTime project_Start_Date;
        private ICollection<TenderMaterialEntity> tenderMaterialEntities;
        private ICollection<TenderTermsConditionEntity> tenderTermsConditionEntities;
        

        public string Tender_Title { get => tender_Title; set => tender_Title = value; }
        public int Category_Id { get => category_Id; set => category_Id = value; }
        public string Tender_Description { get => tender_Description; set => tender_Description = value; }
        public int Tender_live_interval { get => tender_live_interval; set => tender_live_interval = value; }
        public DateTime Live_Start_Date { get => live_Start_Date; set => live_Start_Date = value; }
        public int Tender_Duration { get => tender_Duration; set => tender_Duration = value; }
        public string Duration_Type { get => duration_Type; set => duration_Type = value; }
        public int Bid_No { get => bid_No; set => bid_No = value; }
        public int Posted_By { get => posted_By; set => posted_By = value; }
        public int Tender_Status_Id { get => tender_Status_Id; set => tender_Status_Id = value; }
        public int Admin_Status_Id { get => admin_Status_Id; set => admin_Status_Id = value; }
      //  public int Payment_Status_Id { get => payment_Status_Id; set => payment_Status_Id = value; }
        public ICollection<TenderMaterialEntity> TenderMaterial { get => tenderMaterialEntities; set => tenderMaterialEntities = value; }
        public ICollection<TenderTermsConditionEntity> TenderTermsCondition { get => tenderTermsConditionEntities; set => tenderTermsConditionEntities = value; }
        public string Cancel_Remark { get => cancel_Remark; set => cancel_Remark = value; }
        public DateTime Last_Request_Date { get => last_Request_Date; set => last_Request_Date = value; }
        public string Source_Fund { get => source_Fund; set => source_Fund = value; }
     //   public string IFB_RFP_EOI1 { get => IFB_RFP_EOI; set => IFB_RFP_EOI = value; }
        public DateTime Project_Start_Date { get => project_Start_Date; set => project_Start_Date = value; }
    }
}
