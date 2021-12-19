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
        public TenderEntity TenderDtoEntity(AddTenderRequestDto tenderDto)
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
                Live_Start_Date = tenderDto.LiveStartDate,
                Live_End_Date = tenderDto.LiveEndDate,
                Tender_Status_Id = 1,
                CreatedBy = tenderDto.CreatedBy,
                PerformanceRequest = tenderDto.PerformanceRequest,
                AdditionalRequest = tenderDto.AdditionalRequest,
                EligibilityCriteria = tenderDto.EligibilityCriteria,
                Location = tenderDto.Location,
                QualityRequest = tenderDto.QualityRequest,
                Price = tenderDto.Price,
                TenderTermsConditionEntities = new TenderTermsConditionEntity
                {
                    TermCondition = tenderDto.TermsAndCondition
                },
                Date_created = DateTime.Now,
                Date_modified = DateTime.Now
            };
            entity.TenderMaterialEntities = new List<TenderMaterialEntity>();
            foreach (var item in tenderDto.TenderMaterials)
            {
                TenderMaterialEntity obj = new TenderMaterialEntity
                {
                    Materials = item.Name,
                    Quantity = item.Quantity
                };
                entity.TenderMaterialEntities.Add(obj);
            }
            entity.TenderCards = new List<TenderCardEntity>();
            foreach (var item in tenderDto.TenderCards)
            {
                entity.TenderCards.Add(new TenderCardEntity
                {
                    Label = item.Label,
                    Value = item.Value
                });
            }
            return entity;
        }

        public void UpdateTenderEntity(ref TenderEntity entity, UpdateTenderRequestDto dto)
        {
            entity.Tender_Title = dto.TenderTitle;
            entity.Category_Id = dto.CategoryId;
            entity.PerformanceRequest = dto.PerformanceRequest;
            entity.Live_Start_Date = dto.LiveStartDate;
            entity.Live_End_Date = dto.LiveEndDate;
            entity.QualityRequest = dto.QualityRequest;
            entity.CompanyId = dto.CompanyId;
            entity.Date_modified = DateTime.Now;
            entity.AdditionalRequest = dto.AdditionalRequest;
            entity.EligibilityCriteria = dto.EligibilityCriteria;
            entity.Location = dto.Location;
            entity.Price = dto.Price;
            foreach (var item in dto.TenderMaterials)
            {
                var itm = entity.TenderMaterialEntities.Where(x => x.Id == item.Id).FirstOrDefault();
                if(itm == null)
                {
                    entity.TenderMaterialEntities.Add(new TenderMaterialEntity
                    {
                        Materials = item.Name,
                        Quantity = item.Quantity
                    });
                }
                else
                {
                    itm.Materials = item.Name;
                    itm.Quantity = item.Quantity;
                }
            }

            foreach (var item in dto.TenderCards)
            {
                var itm = entity.TenderCards.Where(x => x.Id == item.Id).FirstOrDefault();
                if(itm != null)
                {
                    entity.TenderCards.Add(new TenderCardEntity
                    {
                        Label = itm.Label,
                        Value = itm.Value
                    });
                }
                else
                {
                    itm.Label = item.Label;
                    itm.Value = itm.Value;
                }
            }
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
            getTender.TenderLiveInterval = tenderEntity.Tender_live_interval;
            getTender.LiveStartDate = tenderEntity.Live_Start_Date;
            getTender.LiveEndDate = tenderEntity.Live_End_Date;// tenderEntity.Live_Start_Date.AddMinutes(tenderEntity.Tender_live_interval);
            getTender.TenderStatusId = tenderEntity.Tender_Status_Id;
            getTender.TenderStatus = tenderEntity.TenderStatusEntity.Status;
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
