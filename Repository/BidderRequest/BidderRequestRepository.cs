using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            meroBoleeDbContexts.CategoryEntities.ToList();
            return meroBoleeDbContexts.BidderRequestEntities.Where(m => m.User_id == bidderId).ToList();
        }

        public async Task<BidderRequestEntity> SendRequest(BidderRequestEntity bidderRequestEntity, ICollection<IFormFile> requestDoc)
        {
            try
            {
                TenderEntity tender = meroBoleeDbContexts
                                        .TenderEntities
                                        .Include(x=>x.CategoryEntity)
                                        .Include(x=>x.TenderMaterialEntities)
                                        .Include(x=>x.TenderTermsConditionEntities)
                                        .Where(m => m.Tender_Id == bidderRequestEntity.Tender_Id)
                                        .FirstOrDefault();

                

                if (tender != null)
                {
                    if (bidderRequestEntity.Request_Send_Date < tender.Last_Request_Date)
                    {
                        return null;
                    }
                    meroBoleeDbContexts.BidderRequestEntities.Add(bidderRequestEntity);
                    unitOfWork.SaveChange();
                    meroBoleeDbContexts.UserEntities.ToList();
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
                    bidderRequestEntity.UserEntity = meroBoleeDbContexts.UserEntities.Where(x=> x.User_Id == bidderRequestEntity.User_id).FirstOrDefault();
                    bidderRequestEntity.AdminStatusEntity = meroBoleeDbContexts.AdminStatusEntities.Where(x => x.Status_Id == bidderRequestEntity.Admin_Status_Id).FirstOrDefault();
                    return bidderRequestEntity;
                }
                return null;
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<LiveBiddingEntity> LiveBid(LiveBiddingEntity bidEntity)
        {
            try
            {
                meroBoleeDbContexts.liveBiddingEntities.Add(bidEntity);
                unitOfWork.SaveChange();
                return bidEntity;
            }
            catch (Exception ex)
            {

                throw;
            }
            return null;
        }
        public IEnumerable<BidderRequestEntity> ShowAllRequest()
        {
            meroBoleeDbContexts.BidderRequestDocEntities.ToList();
            meroBoleeDbContexts.TenderEntities.ToList();
            meroBoleeDbContexts.AdminStatusEntities.ToList();
            meroBoleeDbContexts.UserEntities.ToList();
            meroBoleeDbContexts.CategoryEntities.ToList();
            return meroBoleeDbContexts.BidderRequestEntities.ToList();
        }

        public BidderRequestEntity ShowRequest(int requestId)
        {
            meroBoleeDbContexts.BidderRequestDocEntities.ToList();
            meroBoleeDbContexts.TenderEntities.ToList();
            meroBoleeDbContexts.AdminStatusEntities.ToList();
            meroBoleeDbContexts.UserEntities.ToList();
            meroBoleeDbContexts.CategoryEntities.ToList();
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
                throw;
            }
        }
    }
}
