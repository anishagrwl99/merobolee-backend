using MeroBolee.Dto;
using MeroBolee.Model;
using MeroBolee.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class BiddingRequestMapper
    {

        public List<LiveBiddingEntity> MaterialBiddingDtoToLiveBiddingEntity(TenderMaterialBiddingDto dto, ICryptoService cryptoService, long batchNo)
        {
            if (dto == null)
            {
                return null;
            }
            List<LiveBiddingEntity> entities = new List<LiveBiddingEntity>();
            foreach (var item in dto.MaterialQuotation)
            {
                entities.Add(new  LiveBiddingEntity
                {
                    BiddingRequestId = dto.BiddingId,
                    UserId = dto.SupplierId,
                    TenderId = dto.TenderId,
                    MaterialId = item.MaterialId,
                    Quotation = cryptoService.Encrypt(item.Quotation.ToString()),
                    BidDate = dto.BiddingDate,
                    BatchNo = batchNo
                });
            }
            return entities;
            
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
                SupplierId = e.UserId,
                TenderId = e.TenderId,
                MaterialQuotation = new List<TenderMaterialQuotationDto>
                {
                    new TenderMaterialQuotationDto
                    {
                        MaterialId = e.MaterialId,
                        Quotation = Convert.ToDecimal(e.Quotation),
                    }
                },

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
                    User_id = addBiddingRequest.UserId,
                    Tender_Id = addBiddingRequest.TenderId,
                    CompanyId = addBiddingRequest.CompanyId,
                    Admin_Status_Id = 1,
                    Request_Send_Date = addBiddingRequest.BiddingTime,
                    Request_code = Guid.NewGuid(),
                    Date_created = addBiddingRequest.BiddingTime,
                    Date_modified = addBiddingRequest.BiddingTime
                };
            }

        }

        public GetBiddingRequestDto EnterBiddingRoomToEntity(BidderRequestEntity bidderRequestEntity)
        {
            if (bidderRequestEntity == null)
            {
                return null;
            }
            else
            {
                return new GetBiddingRequestDto
                {
                    BidId = bidderRequestEntity.Request_Id,
                    RequestCode = bidderRequestEntity.Request_code,
                    UserId = bidderRequestEntity.User_id,
                    Username = bidderRequestEntity.UserEntity.Username,
                    AdminStatusId = bidderRequestEntity.Admin_Status_Id,
                    //AdminStatus = bidderRequestEntity.AdminStatusEntity,
                    RequestSendDate = bidderRequestEntity.Request_Send_Date,
                    Remark = bidderRequestEntity.Remark,
                    TenderId = bidderRequestEntity.Tender_Id
                    //BidderRequestDocs = bidderRequestEntity.BidderRequestDocs,
                    //Tender = TenderEntityToDto(bidderRequestEntity.TenderEntity)
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
                    BidId = bidderRequestEntity.Request_Id,
                    RequestCode = bidderRequestEntity.Request_code,
                    UserId = bidderRequestEntity.User_id,
                    Username = bidderRequestEntity.UserEntity.Username,
                    AdminStatusId = bidderRequestEntity.Admin_Status_Id,
                    //AdminStatus = bidderRequestEntity.AdminStatusEntity,
                    RequestSendDate = bidderRequestEntity.Request_Send_Date,
                    Remark = bidderRequestEntity.Remark,
                    TenderId = bidderRequestEntity.Tender_Id,
                    BidderRequestDocs = bidderRequestEntity.BidderRequestDocs,
                    Tender = TenderEntityToDto(bidderRequestEntity.TenderEntity)
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
                    TenderCode = tenderEntity.Tender_Code,
                    TenderTitle = tenderEntity.Tender_Title,
                    CategoryId = tenderEntity.Category_Id,
                    Category = tenderEntity.CategoryEntity.Category,
                    TenderLiveInterval = tenderEntity.Tender_live_interval,
                    LiveStartDate = tenderEntity.Live_Start_Date,
                    LiveEndDate = tenderEntity.Live_End_Date,
                    PublishDate = tenderEntity.Date_created,
                    TenderMaterials = tenderEntity.TenderMaterialEntities,
                    TenderTermsCondition = tenderEntity.TenderTermsConditionEntities
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
