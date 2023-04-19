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

        private ICryptoService cryptoService;


        /// <summary>
        /// Default const
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="uploadFileService"></param>
        /// <param name="dbFactory"></param>
        /// <param name="cryptoService"></param>
        public BidderRequestRepository(IUnitOfWork unitOfWork, IUploadFile uploadFileService, IDbFactory dbFactory, ICryptoService cryptoService) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
            uploadImage = uploadFileService;
            this.cryptoService = cryptoService;
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
        /// <param name="procurementId"></param>
        /// <param name="algoId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<BidRequestEntity>> SupplierBidHistory(long supplierCompanyId, List<int> procurementId, List<int> algoId)
        {
            try
            {
                var obj = new List<BidRequestEntity>();

                if (procurementId.Count==0 && algoId.Count==0)
                {
                   return await meroBoleeDbContexts.BidRequestEntities
                        .Include(x => x.Tender)
                        //.Include(x => x.Tender.TenderCards)
                        .Include(x => x.Tender.CategoryEntity)
                        .Include(x => x.BidRequestStatus)
                        .Where(x => x.CompanyId == supplierCompanyId && x.Tender.LiveEndDate < DateTimeNPT.Now)
                        .ToListAsync();
                }

                else if (procurementId.Count != 0 && algoId.Count != 0)
                {
                    foreach (var item in procurementId)
                    {
                        foreach (var algo in algoId)
                        {
                            var result = await meroBoleeDbContexts.BidRequestEntities
                      .Include(x => x.Tender)
                      //.Include(x => x.Tender.TenderCards)
                      .Include(x => x.Tender.CategoryEntity)
                      .Include(x => x.BidRequestStatus)
                      .Where(x => x.CompanyId == supplierCompanyId && x.Tender.LiveEndDate < DateTimeNPT.Now && x.Tender.ProcurementId==item && x.Tender.AlgoId==algo)
                      .ToListAsync();

                            obj.AddRange(result);
                        }
                    }

                    return obj;

                }
                else if (procurementId.Count!=0)
                {
                    foreach (var item in procurementId)
                    {
                        var result = await meroBoleeDbContexts.BidRequestEntities
                    .Include(x => x.Tender)
                    //.Include(x => x.Tender.TenderCards)
                    .Include(x => x.Tender.CategoryEntity)
                    .Include(x => x.BidRequestStatus)
                    .Where(x => x.CompanyId == supplierCompanyId && x.Tender.LiveEndDate < DateTimeNPT.Now && x.Tender.ProcurementId == item)
                    .ToListAsync();

                        obj.AddRange(result);
                    }
                    return obj;
                }
                else
                {
                    foreach (var item in algoId)
                    {
                        var result = await meroBoleeDbContexts.BidRequestEntities
                    .Include(x => x.Tender)
                    //.Include(x => x.Tender.TenderCards)
                    .Include(x => x.Tender.CategoryEntity)
                    .Include(x => x.BidRequestStatus)
                    .Where(x => x.CompanyId == supplierCompanyId && x.Tender.LiveEndDate < DateTimeNPT.Now && x.Tender.AlgoId == item)
                    .ToListAsync();

                        obj.AddRange(result);
                    }
                    return obj;
                }
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

        public List<SealBidEntity> SealBid(List<SealBidEntity> bidEntity)
        {
            try
            {
                var tenderEntity = meroBoleeDbContexts.TenderEntities
                    .Where(x => x.Id == bidEntity.FirstOrDefault().TenderId)
                    .FirstOrDefault();
                //bidEntity.TenderEntity = meroBoleeDbContexts.TenderEntities
                //    .Where(x => x.Tender_Id == bidEntity.TenderId)
                //    .FirstOrDefault();
                if (bidEntity.FirstOrDefault().BidDate <= tenderEntity.RegistrationTill)
                {
                    meroBoleeDbContexts.SealBidEntities.AddRange(bidEntity);
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

        public List<SealBidEntity> SealBidEdit(List<SealBidEntity> bidEntity)
        {
            try
            {
                var tenderEntity = meroBoleeDbContexts.TenderEntities
                    .Where(x => x.Id == bidEntity.FirstOrDefault().TenderId)
                    .FirstOrDefault();
                //bidEntity.TenderEntity = meroBoleeDbContexts.TenderEntities
                //    .Where(x => x.Tender_Id == bidEntity.TenderId)
                //    .FirstOrDefault();
                if (bidEntity.FirstOrDefault().BidDate <= tenderEntity.RegistrationTill)
                {
                    meroBoleeDbContexts.SealBidEntities.UpdateRange(bidEntity);
                    unitOfWork.SaveChange();

                    foreach (var bidItem in bidEntity)
                    {
                        bidItem.TenderEntity = tenderEntity;
                    }
                    UpdateTotalEditSealBid(bidEntity.FirstOrDefault().TenderId, bidEntity.FirstOrDefault().UserId);
                    return bidEntity;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UpdateTotalEditSealBid(long tenderId, long userId)
        {
            try
            {
                List<SealBidSubsectionTotalEntity> subsectionTotal = meroBoleeDbContexts.SealBidSubsectionTotalEntities.Where(x => x.TenderId == tenderId).Where(x => x.UserId == userId).ToList();
                decimal totalAmount = subsectionTotal.Sum(x => x.subsectionTotal);
                
                (from p in meroBoleeDbContexts.SealBidEntities 
                    where p.UserId == userId && p.TenderId == tenderId select p).ToList()
                                        .ForEach(x => x.TotalAmount = totalAmount);
                unitOfWork.SaveChangesAsync();
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
                List<LiveBiddingEntity> bids = await meroBoleeDbContexts.LiveBiddingEntities.Where(x => x.TenderId == tenderId)
                    .Select(g => new LiveBiddingEntity
                    {
                        UserId = g.UserId,
                        TenderId = g.TenderId,
                        MaterialId = g.MaterialId,
                        Quotation = g.Quotation,
                        BatchNo = g.BatchNo,
                        TenderEntity = tenderEntity,
                        TotalAmount = g.TotalAmount

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
                               where t.LiveEndDate < DateTimeNPT.Now
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

        public Task<List<SealBidEntity>> GetExpiredBidsForSeal()
        {

            try
            {
                return Task.Run<List<SealBidEntity>>(() =>
                {
                    var list = from t in meroBoleeDbContexts.TenderEntities
                               join b in meroBoleeDbContexts.SealBidEntities on t.Id equals b.TenderId
                               where t.RegistrationTill < DateTimeNPT.Now
                               select new SealBidEntity
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
                    return list.ToList<SealBidEntity>();
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
        public async Task<List<BidInviterAuctionLog>> GetTenderAuctionLogForBidInviter(long tenderId)
        {
            try
            {
                var auctionLogBidInviter = await meroBoleeDbContexts.AuctionLogs
                    .Where(x => x.TenderId == tenderId)
                    .Select(x => new
                    {
                        Amount = x.Amount,
                        Position = x.Position,
                        LogDate = x.LogDate,
                        TenderId = x.TenderId
                    }).ToListAsync();

                List<BidInviterAuctionLog> auctionLogs = new List<BidInviterAuctionLog>();
                for (int i = 0; i < auctionLogBidInviter.Count;i++) {
                    var a = auctionLogBidInviter[i];
                    BidInviterAuctionLog bidInviterAuctionLog = new BidInviterAuctionLog();
                    bidInviterAuctionLog.Amount = a.Amount;
                    bidInviterAuctionLog.LogDate = a.LogDate;
                    bidInviterAuctionLog.Position = a.Position;
                    bidInviterAuctionLog.TenderId = a.TenderId;
                    auctionLogs.Add(bidInviterAuctionLog);
                }

                return auctionLogs;
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

        public async Task<List<PositionAmountDto>> GetFinalBiddingPosition(long tenderId)
        {
            try
            {
                List<AuctionLog> auctionLog = meroBoleeDbContexts.AuctionLogs.Where(x => x.TenderId == tenderId).ToList();
                int AlgoId = meroBoleeDbContexts.TenderEntities.Where(x => x.Id == tenderId).Select(x => x.AlgoId).FirstOrDefault();
                if(AlgoId == 1) 
                {
                var position = auctionLog.GroupBy(x => new { x.TenderId, x.UserId })
                .Select(x => new
                {
                    Amount = x.Min(o => o.Amount),
                    UserId = x.Key.UserId
                }).OrderBy(x => x.Amount).ToArray();

                List<PositionAmountDto> getFinalPosition = new List<PositionAmountDto>();
                for (int i = 0; i < position.Length; i++)
                {
                    var item = position[i];
                    PositionAmountDto positionAmountDto = new PositionAmountDto();
                    positionAmountDto.Amount = item.Amount;
                    positionAmountDto.UserId = item.UserId;
                    getFinalPosition.Add(positionAmountDto);

                }
                return getFinalPosition;
                } 
                else 
                {
                    var position = auctionLog.GroupBy(x => new { x.TenderId, x.UserId })
                    .Select(x => new
                    {
                        Amount = x.Max(o => o.Amount),
                        UserId = x.Key.UserId
                    }).OrderByDescending(x => x.Amount).ToArray();

                    List<PositionAmountDto> getFinalPosition = new List<PositionAmountDto>();
                    for (int i = 0; i < position.Length; i++)
                    {
                        var item = position[i];
                        PositionAmountDto positionAmountDto = new PositionAmountDto();
                        positionAmountDto.Amount = item.Amount;
                        positionAmountDto.UserId = item.UserId;
                        getFinalPosition.Add(positionAmountDto);

                    }
                    return getFinalPosition;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<PositionAmountDto>> GetFinalSealBiddingPositionTopBottom(long tenderId)
        {
            try
            {
                List<SealBidSubsectionTotalEntity> auctionLog = await meroBoleeDbContexts.SealBidSubsectionTotalEntities.Where(x => x.TenderId == tenderId).ToListAsync();

                var position = auctionLog.GroupBy(x => new { x.TenderId, x.UserId })
                .Select(x => new
                {
                    Amount = x.Sum(o => o.subsectionTotal),
                    UserId = x.Key.UserId
                }).OrderBy(x => x.Amount).ToArray();

                List<PositionAmountDto> getFinalPosition = new List<PositionAmountDto>();
                for (int i = 0; i < position.Length; i++)
                {
                    var item = position[i];
                    PositionAmountDto positionAmountDto = new PositionAmountDto();
                    positionAmountDto.Amount = item.Amount;
                    positionAmountDto.UserId = item.UserId;
                    getFinalPosition.Add(positionAmountDto);

                }
                return getFinalPosition;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<PositionAmountDto>> GetFinalSealBiddingPositionBottomTop(long tenderId)
        {
            try
            {
                List<SealBidSubsectionTotalEntity> auctionLog = await meroBoleeDbContexts.SealBidSubsectionTotalEntities.Where(x => x.TenderId == tenderId).ToListAsync();

                var position = auctionLog.GroupBy(x => new { x.TenderId, x.UserId })
                .Select(x => new
                {
                    Amount = x.Sum(o => o.subsectionTotal),
                    UserId = x.Key.UserId
                }).OrderByDescending(x => x.Amount).ToArray();

                List<PositionAmountDto> getFinalPosition = new List<PositionAmountDto>();
                for (int i = 0; i < position.Length; i++)
                {
                    var item = position[i];
                    PositionAmountDto positionAmountDto = new PositionAmountDto();
                    positionAmountDto.Amount = item.Amount;
                    positionAmountDto.UserId = item.UserId;
                    getFinalPosition.Add(positionAmountDto);

                }
                return getFinalPosition;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<Tuple<long, Tuple<string, string>>> FindCompanyName(long userId)
        {
            try
            {

                long companyId = meroBoleeDbContexts.UserCompanies.Where(x => x.UserId == userId).Select(x => x.CompanyId).FirstOrDefault();
                var companyName = meroBoleeDbContexts.CompanyEntities.Where(x => x.CompanyId == companyId).Select(x => new {x.Name, x.PANNumber}).FirstOrDefault();
                
                return new Tuple<long, Tuple<string, string>>(companyId, new Tuple<string, string>(companyName.Name, companyName.PANNumber));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<QuotationEntity>> SaveToQuotationEntity(List<QuotationEntity> quotations) 
        {
            try 
            {
                meroBoleeDbContexts.QuotationEntities.AddRange(quotations);
                await unitOfWork.SaveChangesAsync();
                return quotations;
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public async Task<List<QuotationSealBidEntity>> SaveToQuotationEntitySealBid(List<QuotationSealBidEntity> quotations) 
        {
            try 
            {
                meroBoleeDbContexts.QuotationSealBidEntities.AddRange(quotations);
                await unitOfWork.SaveChangesAsync();
                return quotations;
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public async Task<List<QuotationSealBidEntity>> EditToQuotationEntitySealBid(List<QuotationSealBidEntity> quotations, long tenderId, long userId) 
        {
            try 
            {
                List<QuotationSealBidEntity> updatedList = new List<QuotationSealBidEntity>();
                foreach (QuotationSealBidEntity quotationSealBidEntity in quotations) 
                {
                    int id = meroBoleeDbContexts.QuotationSealBidEntities.Where(x => x.MaterialId == quotationSealBidEntity.MaterialId).Where(x => x.TenderId == tenderId).Where(x => x.UserId == userId).Select(x => x.Id).FirstOrDefault();
                    quotationSealBidEntity.Id = id;
                    updatedList.Add(quotationSealBidEntity);
                }
                meroBoleeDbContexts.QuotationSealBidEntities.UpdateRange(updatedList);
                await unitOfWork.SaveChangesAsync();
                return updatedList;
            }
            catch (Exception) 
            {
                throw;
            }
        }


        public async Task<List<SealBidSubsectionTotalEntity>> SaveToSubsectionTotalEntity(List<SealBidSubsectionTotalEntity> subsectionTotal) 
        {
            try 
            {
                meroBoleeDbContexts.SealBidSubsectionTotalEntities.AddRange(subsectionTotal);
                await unitOfWork.SaveChangesAsync();
                return subsectionTotal;
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public async Task<List<SealBidSubsectionTotalEntity>> SaveToSubsectionTotalEntityEdit(List<SealBidSubsectionTotalEntity> subsectionTotal, long tenderId, long userId) 
        {
            try 
            {
                List<SealBidSubsectionTotalEntity> updatedList = new List<SealBidSubsectionTotalEntity>();
                foreach(SealBidSubsectionTotalEntity sealBidSubsectionTotalEntity in subsectionTotal) 
                {
                    int id = meroBoleeDbContexts.SealBidSubsectionTotalEntities.Where(x => x.MaterialGroup.Equals(sealBidSubsectionTotalEntity.MaterialGroup)).Where(x => x.TenderId == tenderId).Where(x => x.UserId == userId).Select(x => x.Id).FirstOrDefault();
                    sealBidSubsectionTotalEntity.Id = id;
                    updatedList.Add(sealBidSubsectionTotalEntity);
                }
                meroBoleeDbContexts.SealBidSubsectionTotalEntities.UpdateRange(updatedList);
                await unitOfWork.SaveChangesAsync();
                return subsectionTotal;
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public async Task<List<QuotationResponseDto>> GenerateBill(long TenderId, long UserId) 
        {
            try
            {
                List<QuotationEntity> quotationEntities = meroBoleeDbContexts.QuotationEntities.Where(x => x.TenderId == TenderId).Where(x => x.UserId == UserId).OrderByDescending(x => x.BidDate).ToList();
                var quote = quotationEntities.GroupBy(x => new { x.MaterialId })
                .Select(x => new
                {
                    MaterailId = x.Key.MaterialId,
                    UnitPrice = x.FirstOrDefault().UnitPrice,
                    Remarks = x.LastOrDefault().Remarks,
                    Quantity = x.LastOrDefault().Quantity, 
                    Units = x.LastOrDefault().Units,
                    BidDate = x.LastOrDefault().BidDate
                }).OrderByDescending(x => x.BidDate).ThenBy(x => x.MaterailId).ToArray();

                List<QuotationResponseDto> quotationResponseDtoList = new List<QuotationResponseDto>();
                for (int i = 0; i < quote.Length; i++)
                {
                    QuotationResponseDto quotationResponseDto = new QuotationResponseDto();
                    quotationResponseDto.UnitPrice = quote[i].UnitPrice;
                    quotationResponseDto.MaterialId = quote[i].MaterailId;
                    quotationResponseDto.Quantity = quote[i].Quantity;
                    quotationResponseDto.Remarks = quote[i].Remarks;
                    quotationResponseDto.Units = quote[i].Units;
                    quotationResponseDto.Quotation = quote[i].UnitPrice * quote[i].Quantity;
                    quotationResponseDto.MaterialName = await meroBoleeDbContexts.TenderMaterialEntities.Where(x => x.Id == quote[i].MaterailId).Where(x => x.TenderId == TenderId).Select(x => x.Materials).FirstOrDefaultAsync();
                    quotationResponseDtoList.Add(quotationResponseDto);
                }


                Console.WriteLine(quote);
                return quotationResponseDtoList;
            } 
           catch 
           {
                throw;
            }
        }

        public async Task<bool> SealBidCheckIfSubmitted(long tenderId, long supplierId) 
        {
            try 
            {
                var quotationSealBidEntity = await meroBoleeDbContexts.QuotationSealBidEntities.Where(x => x.TenderId == tenderId).Where(x => x.UserId == supplierId).FirstOrDefaultAsync();
                var sealBidSubsectionTotalEntity = await meroBoleeDbContexts.SealBidSubsectionTotalEntities.Where(x => x.UserId == supplierId).Where(x => x.TenderId == tenderId).FirstOrDefaultAsync();
                if(quotationSealBidEntity != null && sealBidSubsectionTotalEntity != null) return true;
                return false;
            }
            catch 
            {
                throw;
            }
        }

        public Tuple<int, DateTime> findAlgoIdAndLiveEndDate(long TenderId)
        {
            try
            {
                var values = meroBoleeDbContexts.TenderEntities.Where(x => x.Id == TenderId).Select(
                    x => new {AlgoId = x.AlgoId , LivEndDate = x.LiveEndDate}).FirstOrDefault();
                return Tuple.Create(values.AlgoId, values.LivEndDate);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> CheckTenderComplete(long tenderId)
        {
            try
            {
                return await meroBoleeDbContexts.TenderEntities.AnyAsync(x => x.Id == tenderId && x.IsDeleted==false && x.PostBidStatus!=3);
            }
            catch 
            {

                throw;
            }
        }
    }
}
