using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.BidderRequest
{
    public class BidderRequestRepository: RepositoryBase<BidderRequestEntity>, IBidderRequestRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private UploadImage uploadImage = new UploadImage();

        public BidderRequestRepository(IUnitOfWork unitOfWork, IDbFactory dbFactory): base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<BidderRequestEntity> AllRequestByBidder(int bidderId)
        {
            meroBoleeDbContexts.BidderRequestDocEntities.ToList();
            meroBoleeDbContexts.TenderEntities.ToList();
            meroBoleeDbContexts.AdminStatusEntities.ToList();
            meroBoleeDbContexts.UserEntities.ToList();
            return meroBoleeDbContexts.BidderRequestEntities.Where(m => m.User_id == bidderId).ToList();
        }

        public async Task<BidderRequestEntity> SendRequest(BidderRequestEntity bidderRequestEntity, ICollection<IFormFile> requestDoc)
        {
            try
            {
                TenderEntity tender = meroBoleeDbContexts.TenderEntities.Where(m => m.Tender_Id == bidderRequestEntity.Tender_Id).First();

                if (bidderRequestEntity.Request_Send_Date < tender.Last_Request_Date)
                {
                    return null;
                }
                meroBoleeDbContexts.BidderRequestEntities.Add(bidderRequestEntity);
                unitOfWork.SaveChange();
                if (bidderRequestEntity.BidderRequestDocs == null)
                {
                    bidderRequestEntity.BidderRequestDocs = null;

                }
                else
                {
                    foreach (var doc in requestDoc)
                    {
                        meroBoleeDbContexts.BidderRequestDocEntities.Add(new BidderRequestDocEntity
                        {
                            Request_id = bidderRequestEntity.Request_Id,
                            Document = await uploadImage.Upload(doc, bidderRequestEntity.UserEntity.Username)
                        }
                        );
                        unitOfWork.SaveChange();
                    }
                }

               
                return bidderRequestEntity;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public IEnumerable<BidderRequestEntity> ShowAllRequest()
        {
            meroBoleeDbContexts.BidderRequestDocEntities.ToList();
            meroBoleeDbContexts.TenderEntities.ToList();
            meroBoleeDbContexts.AdminStatusEntities.ToList();
            meroBoleeDbContexts.UserEntities.ToList();
            return meroBoleeDbContexts.BidderRequestEntities.ToList();
        }

        public BidderRequestEntity ShowRequest(int requestId)
        {
            meroBoleeDbContexts.BidderRequestDocEntities.ToList();
            meroBoleeDbContexts.TenderEntities.ToList();
            meroBoleeDbContexts.AdminStatusEntities.ToList();
            meroBoleeDbContexts.UserEntities.ToList();
            return meroBoleeDbContexts.BidderRequestEntities.Where(m => m.Request_Id == requestId).FirstOrDefault();
        }

        public BidderRequestEntity UpdateRequest(int id, UpdateRequestDto updateRequest)
        {
            try
            {
                BidderRequestEntity bidderRequest = meroBoleeDbContexts.BidderRequestEntities.Where(m => m.User_id == id).First();
                bidderRequest.Admin_Status_Id = updateRequest.Status_Id;
                bidderRequest.Remark =updateRequest.Remark ;
                bidderRequest.Date_modified = DateTime.Now;
                return bidderRequest;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
