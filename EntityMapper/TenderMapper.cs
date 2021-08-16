using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class TenderMapper
    {
        public TenderEntity TenderDtoEntity(AddTenderDto tenderDto)
        {
            if (tenderDto == null)
            {
                return null;
            }
            return new TenderEntity
            {

                Tender_Title = tenderDto.Tender_Title,
                Category_Id = tenderDto.Category_Id,
                Tender_Description = tenderDto.Tender_Description,
                Tender_live_interval = tenderDto.Tender_live_interval,
                Live_Start_Date = tenderDto.Live_Start_Date,
                Tender_Duration = tenderDto.Tender_Duration,
                Duration_Type = tenderDto.Duration_Type,
                Bid_No = tenderDto.Bid_No,
                Tender_Status_Id = tenderDto.Tender_Status_Id,
                Admin_Status_Id = tenderDto.Admin_Status_Id,
                Cancel_remark = tenderDto.Cancel_Remark,
                Posted_By = tenderDto.Posted_By,
                Last_Request_Date= tenderDto.Last_Request_Date,
                Source_Fund= tenderDto.Source_Fund,
            //    IFB_RFP_EOI1= tenderDto.IFB_RFP_EOI1,
                Project_Start_Date= tenderDto.Project_Start_Date,
          //  Payment_Status_Id = tenderDto.Payment_Status_Id,
            TenderMaterialEntities = tenderDto.TenderMaterialEntities,
            TenderTermsConditionEntities = tenderDto.TenderTermsConditionEntities,
        };

        }
        public GetTenderDto TenderEntityToDto(TenderEntity tenderEntity)
        {
            if (tenderEntity == null)
            {
                return null;
            }

            GetTenderDto getTender = new GetTenderDto();
            getTender.Tender_Id = tenderEntity.Tender_Id;
            getTender.Tender_Code = tenderEntity.Tender_Code;
            getTender.Tender_Title = tenderEntity.Tender_Title;
            getTender.Category_Id = tenderEntity.Category_Id;
            getTender.Category = tenderEntity.CategoryEntity.Category;
            getTender.Tender_Description = tenderEntity.Tender_Description;
            getTender.Tender_live_interval = tenderEntity.Tender_live_interval;
            getTender.Live_Start_Date = tenderEntity.Live_Start_Date;
            getTender.Live_End_Date = tenderEntity.Live_Start_Date.AddMinutes(tenderEntity.Tender_live_interval);
            getTender.Project_Duration = tenderEntity.Tender_Duration;
            getTender.Duration_Type = tenderEntity.Duration_Type;
            getTender.Bid_No = tenderEntity.Bid_No;
            getTender.Tender_Status_Id = tenderEntity.Tender_Status_Id;
            getTender.AuctionStatus = tenderEntity.AuctionStatusEntity.Status;
            getTender.Admin_Status_Id = tenderEntity.Admin_Status_Id;
            getTender.AdminStatus = tenderEntity.AdminStatusEntity.Status;
            getTender.Cancel_Remark = tenderEntity.Cancel_remark;
            getTender.Posted_By = tenderEntity.Posted_By;
            getTender.UserEntity = tenderEntity.UserEntity;
            getTender.Last_Request_Date = tenderEntity.Last_Request_Date;
            getTender.Source_Fund = tenderEntity.Source_Fund;
        //    getTender.IFB_RFP_EOI1 = tenderEntity.IFB_RFP_EOI1;
            getTender.Project_Start_Date = tenderEntity.Project_Start_Date;
            getTender.Publish_Date = tenderEntity.Date_created;
      //      getTender.Publish_time = tenderEntity.Created_time_stamp;
            //getTender.Tender_fee = tenderEntity.Tender_fee;
            //getTender.Payment_Status_Id = tenderEntity.Payment_Status_Id;
            //getTender.PaymentStatus = tenderEntity.PaymentStatusEntity.Payment_status;
            getTender.TenderMaterialEntities = tenderEntity.TenderMaterialEntities;
            getTender.TenderTermsConditionEntities = tenderEntity.TenderTermsConditionEntities;
            return getTender;

        }

        public IEnumerable<GetTenderDto> TenderEntityListToDto(IEnumerable<TenderEntity> tenderEntities)
        {

            List<GetTenderDto> getTenders = new List<GetTenderDto>();
            if (tenderEntities == null)
            {
                return getTenders = null;
            }

            foreach (TenderEntity tenderEntity in tenderEntities)
            {
                getTenders.Add
                (
                    TenderEntityToDto(tenderEntity)
                );
            }
            return getTenders;
        }
    }
}
