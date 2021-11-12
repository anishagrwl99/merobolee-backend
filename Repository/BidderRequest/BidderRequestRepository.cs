using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MeroBolee.Service;

namespace MeroBolee.Repository.BidderRequest
{
    public class BidderRequestRepository : RepositoryBase<BidderRequestEntity>, IBidderRequestRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private IUploadFile uploadImage;

        public BidderRequestRepository(IUnitOfWork unitOfWork, IUploadFile uploadFileService, IDbFactory dbFactory) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
            uploadImage = uploadFileService;
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
                BidderRequestEntity ent = meroBoleeDbContexts.BidderRequestEntities
                                            .Include(x => x.UserEntity)
                                            .Include(x => x.AdminStatusEntity)
                                            .Where(x => x.Request_Id == bidderRequestEntity.Request_Id)
                                            .FirstOrDefault();
                TenderEntity tender = meroBoleeDbContexts
                                           .TenderEntities
                                           .Include(x => x.CategoryEntity)
                                           .Include(x => x.TenderMaterialEntities)
                                           .Include(x => x.TenderTermsConditionEntities)
                                           .Where(m => m.Tender_Id == bidderRequestEntity.Tender_Id)
                                           .FirstOrDefault();

                if (ent == null)
                {
                    if (tender != null)
                    {
                        if (bidderRequestEntity.Request_Send_Date >= tender.Live_End_Date)
                        {
                            return null;
                        }
                        meroBoleeDbContexts.BidderRequestEntities.Add(bidderRequestEntity);
                        unitOfWork.SaveChange();
                        //meroBoleeDbContexts.UserEntities.ToList();
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
                        bidderRequestEntity.UserEntity = meroBoleeDbContexts.UserEntities.Where(x => x.User_Id == bidderRequestEntity.User_id).FirstOrDefault();
                        bidderRequestEntity.AdminStatusEntity = meroBoleeDbContexts.AdminStatusEntities.Where(x => x.Status_Id == bidderRequestEntity.Admin_Status_Id).FirstOrDefault();
                        bidderRequestEntity.TenderEntity = tender;
                        return bidderRequestEntity;
                    }
                    return null;
                }
                ent.TenderEntity = tender;
                return ent;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<LiveBiddingEntity> AutoBid(List<LiveBiddingEntity> bidEntity)
        {
            try
            {
                var tenderEntity = meroBoleeDbContexts.TenderEntities
                    .Where(x => x.Tender_Id == bidEntity.FirstOrDefault().TenderId)
                    .FirstOrDefault();
                foreach (var bidItem in bidEntity)
                {
                    bidItem.TenderEntity = tenderEntity;
                }
                return bidEntity;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<LiveBiddingEntity> LiveBid(List<LiveBiddingEntity> bidEntity)
        {
            try
            {
                var tenderEntity = meroBoleeDbContexts.TenderEntities
                    .Where(x => x.Tender_Id == bidEntity.FirstOrDefault().TenderId)
                    .FirstOrDefault();
                //bidEntity.TenderEntity = meroBoleeDbContexts.TenderEntities
                //    .Where(x => x.Tender_Id == bidEntity.TenderId)
                //    .FirstOrDefault();
                if (bidEntity.FirstOrDefault().BidDate <= tenderEntity.Live_End_Date)
                {
                    meroBoleeDbContexts.LiveBiddingEntities.AddRange(bidEntity);
                    unitOfWork.SaveChange();

                    foreach (var bidItem in bidEntity)
                    {
                        bidItem.TenderEntity = tenderEntity;
                    }
                    return bidEntity;
                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<LiveBiddingEntity>> TenderLiveBids(int tenderId)
        {
            try
            {
                /*
                  var query = context.Orders
                                .GroupBy(o => new { o.CustomerId, o.EmployeeId })
                                .Select(g => new
                                    {
                                      g.Key.CustomerId,
                                      g.Key.EmployeeId,
                                      Sum = g.Sum(o => o.Amount),
                                      Min = g.Min(o => o.Amount),
                                      Max = g.Max(o => o.Amount),
                                      Avg = g.Average(o => o.Amount)
                                    });
                 * 
                 * 
                 * */

                List<LiveBiddingEntity> bids = await meroBoleeDbContexts.LiveBiddingEntities
                    .GroupBy(o => new { o.UserId, o.TenderId, o.MaterialId })
                    .Select(g => new LiveBiddingEntity
                    {
                        UserId = g.Key.UserId,
                        TenderId = g.Key.TenderId,
                        MaterialId = g.Key.MaterialId,
                        Quotation = g.Min(o => o.Quotation)
                    }).ToListAsync();
                return bids;

            }
            catch (Exception)
            {

                throw;
            }
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
                bidderRequest.Admin_Status_Id = updateRequest.StatusId;
                bidderRequest.Remark = updateRequest.Remark;
                bidderRequest.Date_modified = DateTime.Now;
                return bidderRequest;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Task<List<LiveBiddingEntity>> GetExpiredBids()
        {

            try
            {
                return Task.Run<List<LiveBiddingEntity>>(() =>
                {
                    var list = from t in meroBoleeDbContexts.TenderEntities
                               join b in meroBoleeDbContexts.LiveBiddingEntities on t.Tender_Id equals b.TenderId
                               where t.Live_End_Date < DateTime.Now
                               select new LiveBiddingEntity
                               {
                                   Id = b.Id,
                                   BiddingRequestId = b.BiddingRequestId,
                                   UserId = b.UserId,
                                   TenderId = b.TenderId,
                                   MaterialId = b.MaterialId,
                                   Quotation = b.Quotation,
                                   BidDate = b.BidDate
                               };
                    return list.ToList<LiveBiddingEntity>();
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> DeleteLiveBids(List<LiveBiddingEntity> records)
        {
            try
            {
                return Task.Run<bool>(() =>
                {
                    meroBoleeDbContexts.LiveBiddingEntities.RemoveRange(records);
                    unitOfWork.SaveChange();
                    return true;
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Task<bool> AddHistory(List<BiddingHistoryEntity> records)
        {
            try
            {
                return Task.Run<bool>(async () =>
                {
                    await meroBoleeDbContexts.BiddingHistoryEntities.AddRangeAsync(records);
                    unitOfWork.SaveChange();
                    return true;
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TenderEntity GetTenderDetail(long tenderId)
        {
            return meroBoleeDbContexts.TenderEntities
                .Where(x => x.Tender_Id == tenderId)
                .FirstOrDefault();
        }
    }
}
