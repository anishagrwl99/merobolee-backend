using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{

    /// <summary>
    /// Tender repo impelentation
    /// </summary>
    /// 
    public class TenderRepository : RepositoryBase<TenderEntity>, ITenderRepository
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="dbFactory"></param>
        public TenderRepository(IUnitOfWork unitOfWork, IDbFactory dbFactory) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Add tender to db
        /// </summary>
        /// <param name="tenderEntity"></param>
        /// <returns></returns>
        public TenderEntity AddTender(TenderEntity tenderEntity)
        {
            try
            {
                meroBoleeDbContexts.TenderEntities.Add(tenderEntity);
                unitOfWork.SaveChange();

                return tenderEntity;
            }

            catch (Exception)
            {
                throw;
            }

        }


        /// <summary>
        /// Marketplace tender
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TenderCard>> GetMarketplaceTender(string search)
        {
            try
            {
                return await (from t in meroBoleeDbContexts.TenderEntities
                              join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                              join s in meroBoleeDbContexts.TenderStatus on t.StatusId equals s.StatusId
                              join c1 in meroBoleeDbContexts.CompanyEntities on t.CompanyId equals c1.CompanyId
                              where t.StatusId == 3 && (search == null || t.Title.Contains(search))
                              select new TenderCard
                              {
                                  TenderId = t.Id,
                                  CompanyId = c1.CompanyId,
                                  CompanyName = c1.Name,
                                  TenderCode = t.Code,
                                  TenderTitle = t.Title,
                                  CategoryId = c.Id,
                                  CategoryName = c.Category,
                                  LiveStartDate = t.LiveStartDate,
                                  LiveEndDate = t.LiveEndDate,
                                  RegistrationTill = t.RegistrationTill,
                                  Status = s.Status,
                                  CardInfo = (from tc in meroBoleeDbContexts.TenderCards
                                              where tc.TenderId == t.Id
                                              select new TenderCardInfo
                                              {
                                                  Id = tc.Id,
                                                  Label = tc.Label,
                                                  Value = tc.Value
                                              }).ToList()
                              }

                ).ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// bid inivter tender history
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TenderCard>> GetBidIniviterTenderHistory(long companyId, string search)
        {
            try
            {
                return await (from t in meroBoleeDbContexts.TenderEntities
                              join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                              join s in meroBoleeDbContexts.TenderStatus on t.StatusId equals s.StatusId
                              join c1 in meroBoleeDbContexts.CompanyEntities on t.CompanyId equals c1.CompanyId
                              where t.CompanyId == companyId && t.StatusId == 3 && t.LiveEndDate < DateTime.Now
                                          && (search == null || t.Title.Contains(search))
                              select new TenderCard
                              {
                                  TenderId = t.Id,
                                  CompanyId = c1.CompanyId,
                                  CompanyName = c1.Name,
                                  TenderCode = t.Code,
                                  TenderTitle = t.Title,
                                  CategoryId = c.Id,
                                  CategoryName = c.Category,
                                  LiveStartDate = t.LiveStartDate,
                                  LiveEndDate = t.LiveEndDate,
                                  RegistrationTill = t.RegistrationTill,
                                  StatusId = t.StatusId,
                                  Status = s.Status,
                                  CardInfo = (from tc in meroBoleeDbContexts.TenderCards
                                              where tc.TenderId == t.Id
                                              select new TenderCardInfo
                                              {
                                                  Id = tc.Id,
                                                  Label = tc.Label,
                                                  Value = tc.Value
                                              }).ToList()
                              }

                    ).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }




        /// <summary>
        /// bid inivter tender active listing
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TenderCard>> GetBidIniviterTenderListing(long companyId)
        {
            try
            {
                return await (from t in meroBoleeDbContexts.TenderEntities
                              join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                              join s in meroBoleeDbContexts.TenderStatus on t.StatusId equals s.StatusId
                              join c1 in meroBoleeDbContexts.CompanyEntities on t.CompanyId equals c1.CompanyId
                              where t.CompanyId == companyId /*&& t.StatusId != 3 */ && t.LiveEndDate > DateTime.Now
                              select new TenderCard
                              {
                                  TenderId = t.Id,
                                  CompanyId = c1.CompanyId,
                                  CompanyName = c1.Name,
                                  TenderCode = t.Code,
                                  TenderTitle = t.Title,
                                  CategoryId = c.Id,
                                  CategoryName = c.Category,
                                  LiveStartDate = t.LiveStartDate,
                                  LiveEndDate = t.LiveEndDate,
                                  RegistrationTill = t.RegistrationTill,
                                  Status = s.Status,
                                  StatusId = t.StatusId,
                                  CardInfo = (from tc in meroBoleeDbContexts.TenderCards
                                              where tc.TenderId == t.Id
                                              select new TenderCardInfo
                                              {
                                                  Id = tc.Id,
                                                  Label = tc.Label,
                                                  Value = tc.Value
                                              }).ToList()
                              }

                    ).ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// get tender detail
        /// </summary>
        /// <param name="tenderId"></param>
        /// <returns></returns>
        public async Task<TenderEntity> GetTenderDetail(long tenderId)
        {
            try
            {
                TenderEntity ent = await meroBoleeDbContexts.TenderEntities
                    .Where(m => m.Id == tenderId)
                    .Include(x => x.TenderMaterialEntities)
                    .Include(x => x.TenderCards)
                    .Include(x => x.ExtraDocuments)
                    .Include(x => x.CategoryEntity)
                    .Include(x => x.CreatedByUser)
                    .Include(x => x.TenderStatusEntity)
                    .Include( x=> x.Company)
                    .FirstOrDefaultAsync();

                return ent;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<TenderEntity> GetTenderEntityOnly(long tenderId)
        {
            try
            {
                return await meroBoleeDbContexts.TenderEntities
                    .Include(x => x.ExtraDocuments)
                    .Include(x => x.TenderMaterialEntities)
                    .Include(x => x.TenderCards)
                    .Where(x => x.Id == tenderId)
                    .FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TenderEntity> GetTenderEntityOnly(long tenderId, long companyId)
        {
            try
            {
                return await (from br in meroBoleeDbContexts.BidRequestEntities
                              join t in meroBoleeDbContexts.TenderEntities on br.TenderId equals t.Id
                              where br.CompanyId == companyId && br.TenderId == tenderId
                              select t
                             ).FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// upcoming tender within 7 days
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="isAlert"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TenderCard>> UpcomingBidderTender(long companyId, bool isAlert)
        {
            try
            {
                if (isAlert)
                {
                    return await (from bd in meroBoleeDbContexts.BidRequestEntities
                                  join t in meroBoleeDbContexts.TenderEntities on bd.TenderId equals t.Id
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join ts in meroBoleeDbContexts.TenderStatus on t.StatusId equals ts.StatusId
                                  join c1 in meroBoleeDbContexts.CompanyEntities on bd.CompanyId equals c1.CompanyId
                                  where bd.CompanyId == companyId
                                        && t.StatusId == 3 //Tender should be approved
                                        && bd.BidRequestStatusId == 2 //Bid request should be approved
                                        && (t.LiveStartDate.AddDays(-7) <= DateTime.Now)//Tender live date should be within next 7 days
                                        && (t.LiveEndDate >= DateTime.Now )//Tender live end date should be future date
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      CompanyId = c1.CompanyId,
                                      CompanyName = c1.Name,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      StatusId = t.StatusId,
                                      Status = ts.Status,
                                      CardInfo = (from tc in meroBoleeDbContexts.TenderCards
                                                  where tc.TenderId == t.Id
                                                  select new TenderCardInfo
                                                  {
                                                      Id = tc.Id,
                                                      Label = tc.Label,
                                                      Value = tc.Value
                                                  }).ToList()
                                  }).ToListAsync();
                }
                else
                {
                    return await (from bd in meroBoleeDbContexts.BidRequestEntities
                                  join t in meroBoleeDbContexts.TenderEntities on bd.TenderId equals t.Id
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join ts in meroBoleeDbContexts.TenderStatus on t.StatusId equals ts.StatusId
                                  join c1 in meroBoleeDbContexts.CompanyEntities on bd.CompanyId equals c1.CompanyId
                                  where bd.CompanyId == companyId
                                        && t.StatusId == 3 //Tender should be approved
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      CompanyId = c1.CompanyId,
                                      CompanyName = c1.Name,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      StatusId = t.StatusId,
                                      Status = ts.Status,
                                      CardInfo = (from tc in meroBoleeDbContexts.TenderCards
                                                  where tc.TenderId == t.Id
                                                  select new TenderCardInfo
                                                  {
                                                      Id = tc.Id,
                                                      Label = tc.Label,
                                                      Value = tc.Value
                                                  }).ToList()
                                  }).ToListAsync();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// upcoming tender within 7 days for bid inviter
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TenderCard>> UpcomingBidInviterTender(long companyId)

        {
            try
            {
                return await (from t in meroBoleeDbContexts.TenderEntities
                              join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                              join ts in meroBoleeDbContexts.TenderStatus on t.StatusId equals ts.StatusId
                              join c1 in meroBoleeDbContexts.CompanyEntities on t.CompanyId equals c1.CompanyId
                              where t.CompanyId == companyId
                                    && t.StatusId == 3 //Tender should be approved
                                    && (t.LiveStartDate.AddDays(-7) <= DateTime.Now) //Tender live date should be within next 7 days
                              select new TenderCard
                              {
                                  TenderId = t.Id,
                                  CompanyId = c1.CompanyId,
                                  CompanyName = c1.Name,
                                  TenderCode = t.Code,
                                  TenderTitle = t.Title,
                                  CategoryId = c.Id,
                                  CategoryName = c.Category,
                                  LiveStartDate = t.LiveStartDate,
                                  LiveEndDate = t.LiveEndDate,
                                  RegistrationTill = t.RegistrationTill,
                                  StatusId = t.StatusId,
                                  Status = ts.Status,
                                  CardInfo = (from tc in meroBoleeDbContexts.TenderCards
                                              where tc.TenderId == t.Id
                                              select new TenderCardInfo
                                              {
                                                  Id = tc.Id,
                                                  Label = tc.Label,
                                                  Value = tc.Value
                                              }).ToList()
                              }).ToListAsync();


            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// upcoming tender within 7 days for bid inviter
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TenderCard>> CompanyTendersForAdmin(long? companyId)

        {
            try
            {
                if (companyId.HasValue)
                {
                    return await (from t in meroBoleeDbContexts.TenderEntities
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join ts in meroBoleeDbContexts.TenderStatus on t.StatusId equals ts.StatusId
                                  join c1 in meroBoleeDbContexts.CompanyEntities on t.CompanyId equals c1.CompanyId
                                  where t.CompanyId == companyId.Value
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      CompanyId = c1.CompanyId,
                                      CompanyName = c1.Name,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      StatusId = t.StatusId,
                                      Status = ts.Status,
                                      CardInfo = (from tc in meroBoleeDbContexts.TenderCards
                                                  where tc.TenderId == t.Id
                                                  select new TenderCardInfo
                                                  {
                                                      Id = tc.Id,
                                                      Label = tc.Label,
                                                      Value = tc.Value
                                                  }).ToList()
                                  }).OrderByDescending(x=> x.TenderId)
                                  .ToListAsync();
                }
                else
                {
                    return await (from t in meroBoleeDbContexts.TenderEntities
                                  join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                                  join ts in meroBoleeDbContexts.TenderStatus on t.StatusId equals ts.StatusId
                                  join c1 in meroBoleeDbContexts.CompanyEntities on t.CompanyId equals c1.CompanyId
                                  select new TenderCard
                                  {
                                      TenderId = t.Id,
                                      CompanyId = c1.CompanyId,
                                      CompanyName = c1.Name,
                                      TenderCode = t.Code,
                                      TenderTitle = t.Title,
                                      CategoryId = c.Id,
                                      CategoryName = c.Category,
                                      LiveStartDate = t.LiveStartDate,
                                      LiveEndDate = t.LiveEndDate,
                                      RegistrationTill = t.RegistrationTill,
                                      StatusId = t.StatusId,
                                      Status = ts.Status,
                                      CardInfo = (from tc in meroBoleeDbContexts.TenderCards
                                                  where tc.TenderId == t.Id
                                                  select new TenderCardInfo
                                                  {
                                                      Id = tc.Id,
                                                      Label = tc.Label,
                                                      Value = tc.Value
                                                  }).ToList()
                                  }).OrderByDescending(x=> x.TenderId)
                                  .ToListAsync();
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// update tender
        /// </summary>
        /// <param name="tenderEntity"></param>
        /// <returns></returns>
        public async Task<TenderEntity> UpdateTender(TenderEntity tenderEntity)
        {
            try
            {
                meroBoleeDbContexts.TenderEntities.Update(tenderEntity);
                await unitOfWork.SaveChangesAsync();

                tenderEntity.TenderStatusEntity = meroBoleeDbContexts.TenderStatus.Where(x => x.StatusId == tenderEntity.StatusId).FirstOrDefault();
                tenderEntity.TenderTermsConditionEntities = meroBoleeDbContexts.TenderTermsConditionEntities.Where(x => x.TenderId == tenderEntity.Id).FirstOrDefault();
                tenderEntity.TenderMaterialEntities = meroBoleeDbContexts.TenderMaterialEntities.Where(x => x.TenderId == tenderEntity.Id).ToList();
                tenderEntity.CategoryEntity = meroBoleeDbContexts.CategoryEntities.Where(x => x.Id == tenderEntity.CategoryId).FirstOrDefault();
                tenderEntity.ApprovedByUser = meroBoleeDbContexts.UserEntities.Where(x => x.Id == tenderEntity.ApprovedBy).FirstOrDefault();
                tenderEntity.CreatedByUser = meroBoleeDbContexts.UserEntities.Where(x => x.Id == tenderEntity.CreatedBy).FirstOrDefault();

                return tenderEntity;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public async Task<List<TenderExtraDocumentEntity>> AddTenderDocuments(List<TenderExtraDocumentEntity> entities)
        {
            try
            {
                await meroBoleeDbContexts.TenderExtraDocuments.AddRangeAsync(entities);
                await unitOfWork.SaveChangesAsync();
                return entities;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Get a tender id from a tender code
        /// </summary>
        /// <param name="tenderCode">Unique tender code of a tender</param>
        /// <returns><see cref="Tuple{T1, T2}"/></returns>
        public Tuple<long, List<long>> GetTenderIdFromCode(string tenderCode)
        {
            Tuple<long, long> tenderInfo = (from t in meroBoleeDbContexts.TenderEntities
                                            where t.Code == tenderCode
                                            select Tuple.Create(t.Id, t.CompanyId)
                                           ).FirstOrDefault();

            List<long> userIds = (from c in meroBoleeDbContexts.CompanyEntities
                                  join uc in meroBoleeDbContexts.UserCompanies on c.CompanyId equals uc.CompanyId
                                  where c.CompanyId == tenderInfo.Item2
                                  select uc.UserId
             ).ToList();

            //Tuple<long, long> tender_User = (from t in meroBoleeDbContexts.TenderEntities
            //                                 join c in meroBoleeDbContexts.CompanyEntities on t.CompanyId equals c.CompanyId
            //                                 join uc in meroBoleeDbContexts.UserCompanies on c.CompanyId equals uc.CompanyId
            //                                 join u in meroBoleeDbContexts.UserEntities on uc.UserId equals u.User_Id
            //                                 where t.Tender_Code == tenderCode && u.IsEmailReceiver == true
            //                                 select Tuple.Create(t.Tender_Id, u.User_Id)
            //                                ).FirstOrDefault();
            return Tuple.Create(tenderInfo.Item1, userIds);
        }


        public Tuple<long, List<long>> GetTenderWinnerIdFromCode(string tenderCode)
        {
            Tuple<long, long> tenderInfo = (from t in meroBoleeDbContexts.TenderEntities
                                            where t.Code == tenderCode
                                            select Tuple.Create(t.Id, t.CompanyId)
                                           ).FirstOrDefault();

            List<long> userIds = (from tw in meroBoleeDbContexts.TenderWinnerEntities
                                  join c in meroBoleeDbContexts.CompanyEntities on tw.WinnerCompanyId equals c.CompanyId
                                  join uc in meroBoleeDbContexts.UserCompanies on c.CompanyId equals uc.CompanyId
                                  where tw.TenderId == tenderInfo.Item1
                                  select uc.UserId
                                  ).ToList();

            return Tuple.Create(tenderInfo.Item1, userIds);

            //Tuple<long, long> tender_Winner = (from t in meroBoleeDbContexts.TenderEntities
            //                                   join tw in meroBoleeDbContexts.TenderWinnerEntities on t.Tender_Id equals tw.TenderId
            //                                   join c in meroBoleeDbContexts.CompanyEntities on tw.WinnerCompanyId equals c.CompanyId
            //                                   join cu in meroBoleeDbContexts.UserCompanies on c.CompanyId equals cu.CompanyId
            //                                   join u in meroBoleeDbContexts.UserEntities on cu.UserId equals u.User_Id
            //                                   where t.Tender_Code == tenderCode && u.IsEmailReceiver == true
            //                                   select Tuple.Create(t.Tender_Id, u.User_Id)
            //                                  ).FirstOrDefault();
            //return tender_Winner;
        }

        public bool EndTenderAuction(long tenderId)
        {
            try
            {
                TenderEntity te = meroBoleeDbContexts.TenderEntities.Where(x => x.Id == tenderId).FirstOrDefault();
                if (te != null)
                {
                    te.LiveEndDate = DateTime.Now;
                    te.CancelRemarks = "Bidding not received";
                    meroBoleeDbContexts.TenderEntities.Update(te);
                    unitOfWork.SaveChange();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public TenderEntity ApproveTenderByBidInviter(TenderEntity ent)
        {
            try
            {
                meroBoleeDbContexts.TenderEntities.Update(ent);
                unitOfWork.SaveChange();
                return ent;
            }
            catch
            {
                throw;
            }
        }



        public async Task SetTenderStatusToFeedback(TenderEntity tenderEntity)
        {
            try
            {
                meroBoleeDbContexts.TenderEntities.Update(tenderEntity);
                await meroBoleeDbContexts.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Tuple<decimal, DateTime, DateTime> GetMaxQuotationAllowed(long tenderId)
        {
            try
            {
                var tuple = (from te in meroBoleeDbContexts.TenderEntities
                             where te.Id == tenderId
                             select Tuple.Create(te.MaxQuotation, te.LiveStartDate, te.LiveEndDate)
                                                           ).FirstOrDefault();

                return tuple;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<bool> DeleteTender(TenderEntity entity)
        {
            try
            {
                if(entity.TenderTermsConditionEntities != null)
                {
                    meroBoleeDbContexts.TenderTermsConditionEntities.Remove(entity.TenderTermsConditionEntities);
                }

                if (entity.TenderMaterialEntities != null && entity.TenderMaterialEntities.Count > 0)
                {
                    meroBoleeDbContexts.TenderMaterialEntities.RemoveRange(entity.TenderMaterialEntities);
                }

                if (entity.TenderCards != null && entity.TenderCards.Count > 0)
                {
                    meroBoleeDbContexts.TenderCards.RemoveRange(entity.TenderCards);
                }

                if (entity.Feedbacks != null && entity.Feedbacks.Count > 0)
                {
                    meroBoleeDbContexts.TenderCardFeedbacks.RemoveRange(entity.Feedbacks);
                }

                if (entity.ExtraDocuments != null && entity.ExtraDocuments.Count > 0)
                {
                    meroBoleeDbContexts.TenderExtraDocuments.RemoveRange(entity.ExtraDocuments);
                }


                meroBoleeDbContexts.TenderEntities.Remove(entity);

                await unitOfWork.SaveChangesAsync();
                return true;
            }
            catch 
            {

                throw;
            }
        }

        public async Task<List<TenderCardFeedbackEntity>> GetTenderCardFeedback(long tenderId)
        {
            try
            {
                return await meroBoleeDbContexts.TenderCardFeedbacks.Where(x => x.TenderId == tenderId).ToListAsync();
            }
            catch 
            {

                throw;
            }
        }
    }
}
