using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class BiddingRequestMapper
    {

        public LiveBiddingEntity MaterialBiddingDtoToLiveBiddingEntity(TenderMaterialBiddingDto dto)
        {
            if(dto == null)
            {
                return null;
            }
            return new LiveBiddingEntity
            {
                BiddingRequestId = dto.BiddingId,
                SupplierId = dto.SupplierId,
                TenderId = dto.TenderId,
                MaterialId = dto.MaterialId,
                Quotation = dto.Quotation,
                BidDate = dto.BiddingDate
            };
        }
        public TenderMaterialBiddingDto LiveBiddingEntityToMaterialBiddingDto(LiveBiddingEntity e)
        {
            if (e == null)
            {
                return null;
            }
            return new TenderMaterialBiddingDto
            {
                BiddingId = e.BiddingRequestId,
                SupplierId = e.SupplierId,
                TenderId = e.TenderId,
                MaterialId = e.MaterialId,
                Quotation = e.Quotation,
                BiddingDate = e.BidDate
            };
        }

        public BidderRequestEntity BidderRequestDtoRequest(AddBiddingRequestDto addBiddingRequest)
        {
            if (addBiddingRequest == null)
            {
                return null;
            }
            else 
            {
                return new BidderRequestEntity
                {
                    User_id = addBiddingRequest.User_id,
                    Tender_Id= addBiddingRequest.Tender_Id,
                    Admin_Status_Id= addBiddingRequest.Admin_Status_Id,
                    Request_Send_Date = addBiddingRequest.BiddingTime
                };
            }
        
        }

        public GetBiddingRequestDto BidderRequestToEntity(BidderRequestEntity bidderRequestEntity)
        {
            if (bidderRequestEntity == null)
            {
                return null;
            }
            else
            {
                return new GetBiddingRequestDto
                {
                   Request_code= bidderRequestEntity.Request_code,
                   User_id= bidderRequestEntity.User_id,
                   Username= bidderRequestEntity.UserEntity.Username,
                   Admin_Status_Id= bidderRequestEntity.Admin_Status_Id,
                   AdminStatusEntity= bidderRequestEntity.AdminStatusEntity,
                   Request_Send_Date= bidderRequestEntity.Request_Send_Date,
                   Remark= bidderRequestEntity.Remark,
                   BidderRequestDocs= bidderRequestEntity.BidderRequestDocs,
                   TenderEntity= TenderEntityToDto(bidderRequestEntity.TenderEntity),

                };
            }

        }

        public BiddingRequestTender TenderEntityToDto(TenderEntity tenderEntity)
        {
            if (tenderEntity == null)
            {
                return null;
            }
            else 
            {
                return new BiddingRequestTender
                {
                    Tender_Code= tenderEntity.Tender_Code,
                    Tender_Title=tenderEntity.Tender_Title,
                    Category_Id= tenderEntity.Category_Id,
                    Category= tenderEntity.CategoryEntity.Category,
                    Tender_Description= tenderEntity.Tender_Description,
                    Tender_live_interval= tenderEntity.Tender_live_interval,
                    Live_Start_Date= tenderEntity.Live_Start_Date,
                    Live_End_Date=tenderEntity.Live_End_Date,
                    Project_Duration= tenderEntity.Tender_Duration,
                    Duration_Type= tenderEntity.Duration_Type,
                    Publish_Date= tenderEntity.Date_created,
                    Last_Request_Date= tenderEntity.Last_Request_Date,
                    Project_Start_Date= tenderEntity.Project_Start_Date,
                    TenderMaterialEntities= tenderEntity.TenderMaterialEntities,
                    TenderTermsConditionEntities= tenderEntity.TenderTermsConditionEntities

                };
            }
        
        }

        public IEnumerable<GetBiddingRequestDto> BidderRequestToDto(IEnumerable<BidderRequestEntity> bidderRequests)
        {
            if (bidderRequests == null)
            {
                return null;
            }

            else 
            {
                List<GetBiddingRequestDto> getBiddings = new List<GetBiddingRequestDto>();
                foreach (BidderRequestEntity requestEntity in bidderRequests)
                {
                    getBiddings.Add(BidderRequestToEntity(requestEntity));
                };
                return getBiddings;                
            
            }
        
        }
    }
}
