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

        private DateTime GetTenderEndDate(DateTime startDateTime, int tenderDuration, string durationUnit)
        {
            switch(durationUnit.ToLowerInvariant())
            {
                case "minute":
                case "minutes":
                    return startDateTime.AddMinutes(tenderDuration);

                case "day":
                case "days":
                    return startDateTime.AddDays(tenderDuration);

                case "week":
                case "weeks":
                    return startDateTime.AddDays(tenderDuration * 7);

                case "month":
                case "months":
                    return startDateTime.AddMonths(tenderDuration);

                case "year":
                case "years":
                    return startDateTime.AddYears(tenderDuration);

                default:
                    return startDateTime.AddMinutes(tenderDuration);
            }
        }
        public TenderEntity TenderDtoEntity(AddTenderDto tenderDto)
        {
            if (tenderDto == null)
            {
                return null;
            }
            TenderEntity entity =  new TenderEntity
            {
                CompanyId = tenderDto.CompanyId,
                Tender_Title = tenderDto.TenderTitle,
                Category_Id = tenderDto.CategoryId,
                Tender_Description = tenderDto.TenderDescription,
                Tender_live_interval = tenderDto.Tenderliveinterval,
                Live_Start_Date = tenderDto.LiveStartDate,
                Live_End_Date = GetTenderEndDate(tenderDto.LiveStartDate, tenderDto.TenderDuration, tenderDto.DurationType),
                Tender_Duration = tenderDto.TenderDuration,
                Duration_Type = tenderDto.DurationType,
                Tender_Status_Id = tenderDto.TenderStatusId,
                CreatedBy = tenderDto.CreatedBy,
                TenderTermsConditionEntities = new TenderTermsConditionEntity
                {
                    TermCondition = tenderDto.TermsAndCondition
                },
                Date_created = DateTime.Now,
                Date_modified = DateTime.Now
            };
            entity.TenderMaterialEntities = new List<TenderMaterialEntity>();
            foreach (var item in tenderDto.TenderMaterial)
            {
                TenderMaterialEntity obj = new TenderMaterialEntity
                {
                    Materials = item.Name,
                    Quantity = item.Quantity
                };
                obj.MaterialFeatures = new List<MaterialFeatureEntity>();
                foreach (var feature in item.Features)
                {
                    MaterialFeatureEntity f = new MaterialFeatureEntity
                    {
                        FeatureName = feature.FeatureName,
                        FeatureValue = feature.FeatureValue
                    };
                    obj.MaterialFeatures.Add(f);
                }
                entity.TenderMaterialEntities.Add(obj);
            }
            return entity;
        }
        public GetTenderDto TenderEntityToDto(TenderEntity tenderEntity)
        {
            if (tenderEntity == null)
            {
                return null;
            }

            GetTenderDto getTender = new GetTenderDto();
            getTender.TenderId = tenderEntity.Tender_Id;
            getTender.TenderCode = tenderEntity.Tender_Code;
            getTender.TenderTitle = tenderEntity.Tender_Title;
            getTender.CategoryId = tenderEntity.Category_Id;
            getTender.Category = tenderEntity.CategoryEntity.Category;
            getTender.TenderDescription = tenderEntity.Tender_Description;
            getTender.TenderLiveInterval = tenderEntity.Tender_live_interval;
            getTender.LiveStartDate = tenderEntity.Live_Start_Date;
            getTender.LiveEndDate = tenderEntity.Live_End_Date;// tenderEntity.Live_Start_Date.AddMinutes(tenderEntity.Tender_live_interval);
            getTender.ProjectDuration = tenderEntity.Tender_Duration;
            getTender.DurationType = tenderEntity.Duration_Type;
            getTender.TenderStatusId = tenderEntity.Tender_Status_Id;
            getTender.AuctionStatus = tenderEntity.AuctionStatusEntity.Status;
            getTender.CancelRemark = tenderEntity.Cancel_remark;
            getTender.PostedBy = tenderEntity.CreatedBy;
            getTender.User = tenderEntity.CreatedByUser;
            getTender.Publish_Date = tenderEntity.Date_created;
            getTender.TenderMaterial = tenderEntity.TenderMaterialEntities;
            getTender.TenderTermsCondition = tenderEntity.TenderTermsConditionEntities;
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
