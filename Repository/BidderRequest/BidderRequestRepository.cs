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

namespace MeroBolee.Repository
{
    public class BidderRequestRepository : RepositoryBase<BidRequestEntity>, IBidderRequestRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private IUploadFile uploadImage;


        /// <summary>
        /// Default const
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="uploadFileService"></param>
        /// <param name="dbFactory"></param>
        public BidderRequestRepository(IUnitOfWork unitOfWork, IUploadFile uploadFileService, IDbFactory dbFactory) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
            uploadImage = uploadFileService;
        }


        /// <summary>
        /// Return a bid request entity
        /// </summary>
        /// <param name="tenderId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<BidRequestEntity> GetBidRequestEntityOnly(long tenderId, long companyId)
        {
            try
            {
                return await meroBoleeDbContexts.BidRequestEntities
                    .Include(x=> x.BidderRequestDocs)
                    .Where(x => x.CompanyId == companyId && x.TenderId == tenderId)
                    .FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get a bid request entity
        /// </summary>
        /// <param name="bidId"></param>
        /// <returns></returns>
        public async Task<BidRequestEntity> GetBidRequestEntityOnly(long bidId)
        {
            try
            {
                return await meroBoleeDbContexts.BidRequestEntities
                    .Include(x => x.BidderRequestDocs)
                    .Include(x => x.BidRequestStatus)
                    .Include(x => x.Tender)
                    .Include(x => x.Tender.CategoryEntity)
                    .Include(x => x.Company)
                    .Include(x => x.User)
                    .Where(x =>  x.Id == bidId)
                    .FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Update bid request entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<BidRequestEntity> UpdateBidRequest(BidRequestEntity entity)
        {
            try
            {
                meroBoleeDbContexts.BidRequestEntities.Update(entity);
                await unitOfWork.SaveChangesAsync();

                entity.BidRequestStatus = await meroBoleeDbContexts.BidRequestStatusEntities
                                .Where(x => x.StatusId == entity.BidRequestStatusId)
                                .FirstOrDefaultAsync();
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// List all expired tenders on which a supplier has registered for
        /// </summary>
        /// <param name="supplierCompanyId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<BidRequestEntity>> SupplierBidHistory(long supplierCompanyId)
        {
            try
            {
                return await meroBoleeDbContexts.BidRequestEntities
                        .Include(x => x.Tender)
                        //.Include(x => x.Tender.TenderCards)
                        .Include(x => x.Tender.CategoryEntity)
                        .Include(x => x.BidRequestStatus)
                        .Where(x => x.CompanyId == supplierCompanyId && x.Tender.LiveEndDate < DateTime.Now)
                        .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<TenderWinnerEntity>> GetSupplierWinningBids(long supplierCompanyId)
        {
            try
            {
                return await meroBoleeDbContexts.TenderWinnerEntities
                    .Where(x => x.WinnerCompanyId == supplierCompanyId)
                    .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Register into tender for bidding
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<BidRequestEntity> RegisterForBidding(BidRequestEntity entity)
        {
            try
            {
                meroBoleeDbContexts.BidRequestEntities.Add(entity);
                await unitOfWork.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<bool> SubmitDocumentRegisterForBidding(List<BidderRequestDocEntity> documents)
        {
            try
            {
                meroBoleeDbContexts.BidderRequestDocEntities.AddRange(documents);
                await unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Return a bid request for business validation
        /// </summary>
        /// <param name="tenderId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<BidRequestEntity> EnterLiveBiddingRoom(long tenderId, long companyId)
        {
            try
            {
                return await meroBoleeDbContexts.BidRequestEntities
                    .Where(x => x.TenderId == tenderId && x.CompanyId == companyId)
                    .Include(x => x.Tender)
                    .Include(x => x.BidRequestStatus)
                    .Include(x => x.BidderRequestDocs)
                    .FirstOrDefaultAsync();
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
                    .Where(x => x.Id == bidEntity.FirstOrDefault().TenderId)
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
                    .Where(x => x.Id == bidEntity.FirstOrDefault().TenderId)
                    .FirstOrDefault();
                //bidEntity.TenderEntity = meroBoleeDbContexts.TenderEntities
                //    .Where(x => x.Tender_Id == bidEntity.TenderId)
                //    .FirstOrDefault();
                if (bidEntity.FirstOrDefault().BidDate <= tenderEntity.LiveEndDate)
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
        public async Task<List<LiveBiddingEntity>> TenderLiveBids(long tenderId)
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
                var tenderEntity = meroBoleeDbContexts.TenderEntities
                   .Where(x => x.Id == tenderId)
                   .FirstOrDefault();
                List<LiveBiddingEntity> bids = await meroBoleeDbContexts.LiveBiddingEntities
                    .Select(g => new LiveBiddingEntity
                    {
                        UserId = g.UserId,
                        TenderId = g.TenderId,
                        MaterialId = g.MaterialId,
                        Quotation = g.Quotation,
                        BatchNo = g.BatchNo,
                        TenderEntity= tenderEntity

                    }).ToListAsync();
                
                return bids;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<BidRequestEntity>> ShowAllRegistration(long tenderId)
        {
            try
            {
                return await meroBoleeDbContexts.BidRequestEntities
                           .Include(x => x.Tender)
                           .Include(x => x.Tender.CategoryEntity)
                           .Include(x => x.BidRequestStatus)
                           .Include(x => x.Company)
                           .Include(x => x.User)
                           .Where(x => x.TenderId == tenderId)
                           .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<IEnumerable<OnlineSuppliers>> ShowAllOnlineSuppliers(long tenderId)
        {
            try
            {
                List<OnlineSuppliers> suppliers = await (from br in meroBoleeDbContexts.BidRequestEntities
                        join c in meroBoleeDbContexts.CompanyEntities on br.CompanyId equals c.CompanyId
                        join lb in meroBoleeDbContexts.LiveBiddingEntities on br.TenderId equals lb.TenderId into live
                        from sub in live.DefaultIfEmpty()
                        where br.TenderId == tenderId
                        select new OnlineSuppliers
                        {
                            CompanyId = br.CompanyId,
                            CompanyName = c.Name,
                            Status = sub.TenderId > 0? "Online" : "Offline"
                        }).ToListAsync();

                return suppliers;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Return bid detail
        /// </summary>
        /// <param name="bidId"></param>
        /// <param name="companyId"></param>
        /// <param name="tenderId"></param>
        /// <returns></returns>
        public async Task<BidRequestEntity> BidDetail(long bidId, long companyId, long tenderId)
        {
            try
            {
                return await meroBoleeDbContexts.BidRequestEntities
                        .Include(x => x.BidRequestStatus)
                        .Include(x => x.BidderRequestDocs)
                        .Include(x => x.BiddingHistories)
                        .Include(x => x.Tender)
                        .Include(x => x.Tender.CategoryEntity)
                        .Include(x => x.Company)
                        .Include(x => x.User)
                        .Include(x => x.Tender.TenderMaterialEntities)
                        .Where(x => x.Id == bidId && x.CompanyId == companyId && x.TenderId == tenderId)
                        .FirstOrDefaultAsync();
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
                               join b in meroBoleeDbContexts.LiveBiddingEntities on t.Id equals b.TenderId
                               where t.LiveEndDate < DateTime.Now
                               select new LiveBiddingEntity
                               {
                                   Id = b.Id,
                                   BiddingRequestId = b.BiddingRequestId,
                                   UserId = b.UserId,
                                   TenderId = b.TenderId,
                                   MaterialId = b.MaterialId,
                                   Quotation = b.Quotation,
                                   BidDate = b.BidDate,
                                   BatchNo = b.BatchNo,
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
                .Where(x => x.Id == tenderId)
                .FirstOrDefault();
        }
        public TenderEntity UpdateLiveEndDate(long tenderId,DateTime liveEndDate)
        {
            var tender = meroBoleeDbContexts.TenderEntities
               .Where(x => x.Id == tenderId)
               .FirstOrDefault();
            tender.LiveEndDate = liveEndDate;
            unitOfWork.SaveChange();

            return tender;
        }
        public void WriteAutionLogEntry(AuctionLog log)
        {
            try
            {
                meroBoleeDbContexts.AuctionLogs.Add(log);
                unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool>  IsBidderRegistered(long companyId, long tenderId, long biddingId)
        {
            try
            {
                var info =  await meroBoleeDbContexts.BidRequestEntities
                    .Where(x => x.CompanyId == companyId && x.TenderId == tenderId)
                    .Select(x => new { 
                            x.Id , 
                            x.BidRequestStatusId 
                        })
                    .FirstOrDefaultAsync();


                bool isRegistered = false;

                if (info != null && info.Id > 0 && info.BidRequestStatusId == 2) //2 Status is approved
                {
                    isRegistered = true;
                    var bidTimeRange = await meroBoleeDbContexts.TenderEntities
                        .Where(x=> x.Id == tenderId)
                        .Select(x=> new
                        {
                            x.LiveStartDate,
                            x.LiveEndDate
                        })
                        .FirstOrDefaultAsync();

                    //if bidding time is in future don't allow bidding
                    if (bidTimeRange.LiveStartDate > DateTimeNPT.Now || bidTimeRange.LiveEndDate < DateTimeNPT.Now) isRegistered = false;

                    //user is using different bid id to bid 
                    if (biddingId != info.Id) isRegistered = false; 

                }

                return isRegistered;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<AuctionLog>> GetTenderAuctionLog(long companyId, long tenderId)
        {
            try
            {
                return await meroBoleeDbContexts.AuctionLogs
                    .Where(x => x.CompanyId == companyId && x.TenderId == tenderId)
                    .Include(x => x.Company)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<AuctionLog>> GetAuctionLogForAdmin(long tenderId)
        {
            try
            {
                return await meroBoleeDbContexts.AuctionLogs
                    .Where(x =>x.TenderId == tenderId && !x.IsDeleted)
                    .Include(x => x.Company)
                    .Include(x=>x.User)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<AuctionLog> LogActivityForAdmin(long tenderId,long logId)
        {
            try
            {
                return await meroBoleeDbContexts.AuctionLogs
                    .Where(x => x.TenderId == tenderId && !x.IsDeleted && x.LogId==logId)
                    .Include(x => x.Company)
                    .Include(x => x.User)
                    .FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BidRequestEntity> UpdateSuspendStatusBidRequest(BidRequestEntity entity)
        {
            try
            {             
                meroBoleeDbContexts.BidRequestEntities.Update(entity);
                await unitOfWork.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<BidRequestEntity>> GetBidRequestEntity(long tenderId,long userId, long companyId)
        {
            try
            {
                return await meroBoleeDbContexts.BidRequestEntities
                    .Where(x => x.CompanyId == companyId && x.TenderId == tenderId && x.UserId==userId)
                    .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<AuctionLog>> GetTenderAuctionLogForBidInviter(long tenderId)
        {
            try
            {
                return await meroBoleeDbContexts.AuctionLogs
                    .Where(x => x.TenderId == tenderId)
                    .Include(x => x.Company)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<AuctionLog> UpdateAuctionLog(AuctionLog auctionLogEntity, BidRequestEntity bidRequestEntity)
        {
            try
            {
                meroBoleeDbContexts.AuctionLogs.Update(auctionLogEntity);
                meroBoleeDbContexts.BidRequestEntities.Update(bidRequestEntity);

                await unitOfWork.SaveChangesAsync();               

                return auctionLogEntity;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        public async Task<bool> CheckTenderWinner(long tenderId)
        {
            try
            {
                return await meroBoleeDbContexts.TenderWinnerEntities
                    .AnyAsync(x=> x.TenderId == tenderId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TenderWinnerEntity> SetTenderWinner(TenderWinnerEntity ent)
        {
            try
            {
                meroBoleeDbContexts.TenderWinnerEntities.Add(ent);
                await unitOfWork.SaveChangesAsync();
                return ent; 
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Determines whether [is supplier registered] [the specified company identifier].
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="tenderId">The tender identifier.</param>
        /// <returns></returns>
        public async Task<bool> IsSupplierRegistered(long companyId, long tenderId)
        {
            try
            {
                return await meroBoleeDbContexts.BidRequestEntities.AnyAsync(x => x.CompanyId == companyId && x.TenderId == tenderId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
