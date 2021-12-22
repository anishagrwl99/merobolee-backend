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
                //tenderEntity.Live_End_Date = tenderEntity.Live_Start_Date.AddMinutes(tenderEntity.Tender_live_interval);
                //tenderEntity.Date_created = DateTime.Now;
                meroBoleeDbContexts.TenderEntities.Add(tenderEntity);
                unitOfWork.SaveChange();

                meroBoleeDbContexts.TenderStatus.ToList();
                meroBoleeDbContexts.PaymentStatusEntities.ToList();
                meroBoleeDbContexts.AdminStatusEntities.ToList();
                meroBoleeDbContexts.TenderTermsConditionEntities.ToList();
                meroBoleeDbContexts.TenderMaterialEntities.ToList();
                meroBoleeDbContexts.MaterialFeatureEntities.ToList();

                meroBoleeDbContexts.UserEntities.ToList();
                meroBoleeDbContexts.CategoryEntities.ToList();
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
        public IEnumerable<TenderCard> GetMarketplaceTender(string search)
        {
            try
            {
                return (from t in meroBoleeDbContexts.TenderEntities
                        join c in meroBoleeDbContexts.CategoryEntities on t.Category_Id equals c.Category_Id
                        join s in meroBoleeDbContexts.TenderStatus on t.Tender_Status_Id equals s.StatusId
                        where t.Tender_Status_Id == 3 && (search == null || t.Tender_Title.Contains(search))
                        select new TenderCard
                        {
                            TenderId = t.Tender_Id,
                            TenderCode = t.Tender_Code,
                            TenderTitle = t.Tender_Title,
                            CategoryId = c.Category_Id,
                            CategoryName = c.Category,
                            LiveStartDate = t.Live_Start_Date,
                            LiveEndDate = t.Live_End_Date,
                            RegistrationTill = t.RegistrationTill,
                            Status = s.Status,
                            CardInfo = (from tc in meroBoleeDbContexts.TenderCards
                                        where tc.TenderId == t.Tender_Id
                                        select new TenderCardInfo
                                        {
                                            Id = tc.Id,
                                            Label = tc.Label,
                                            Value = tc.Value
                                        }).ToList()
                        }

                ).ToList();
                /*
                meroBoleeDbContexts.AuctionStatusEntities.ToList();
                meroBoleeDbContexts.PaymentStatusEntities.ToList();
                meroBoleeDbContexts.AdminStatusEntities.ToList();
                meroBoleeDbContexts.TenderTermsConditionEntities.ToList();
                meroBoleeDbContexts.TenderMaterialEntities.ToList();
                meroBoleeDbContexts.MaterialFeatureEntities.ToList();

                meroBoleeDbContexts.UserEntities.ToList();
                meroBoleeDbContexts.CategoryEntities.ToList();
                return meroBoleeDbContexts.TenderEntities
                    .Where(m => (m.Tender_Status_Id != 1)//not in approval
                    //&& (m.Live_Start_Date>= DateTime.Now)
                    && ((search == null)
                //|| (m.Tender_Code.ToString().Contains(search))
                //|| (m.Tender_Description.ToLower().Contains(search.ToLower()))
                //|| (m.Tender_Duration.ToString().Contains(search.ToLower()))
                || (m.Tender_Title.ToLower().Contains(search.ToLower()))
                //|| (m.Tender_live_interval.ToString().Contains(search.ToLower()))
                //|| (m.Live_Start_Date.ToString().Contains(search.ToLower()))
                //|| (m.Live_End_Date.ToString().Contains(search.ToLower()))
                //|| (m.Duration_Type.ToLower().Contains(search.ToLower()))
                //|| (m.Tender_Duration.ToString().Contains(search.ToLower()))
                //|| (m.Tender_fee.ToString().Contains(search.ToLower()))
                //|| (m.AdminStatusEntity.Status.ToLower().Contains(search.ToLower()))
                //|| (m.AuctionStatusEntity.Status.ToLower().Contains(search.ToLower()))
                //|| (m.PaymentStatusEntity.Payment_status.ToLower().Contains(search.ToLower()))
                )).ToList();
                */
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
        public IEnumerable<TenderCard> GetBidIniviterTenderHistory(long companyId, string search)
        {
            try
            {
                return (from t in meroBoleeDbContexts.TenderEntities
                        join c in meroBoleeDbContexts.CategoryEntities on t.Category_Id equals c.Category_Id
                        join s in meroBoleeDbContexts.TenderStatus on t.Tender_Status_Id equals s.StatusId
                        where t.CompanyId == companyId && t.Tender_Status_Id == 3 && t.Live_End_Date < DateTime.Now 
                                    && (search == null || t.Tender_Title.Contains(search))
                        select new TenderCard
                        {
                            TenderId = t.Tender_Id,
                            TenderCode = t.Tender_Code,
                            TenderTitle = t.Tender_Title,
                            CategoryId = c.Category_Id,
                            CategoryName = c.Category,
                            LiveStartDate = t.Live_Start_Date,
                            LiveEndDate = t.Live_End_Date,
                            RegistrationTill = t.RegistrationTill,
                            StatusId = t.Tender_Status_Id,
                            Status = s.Status,
                            CardInfo = (from tc in meroBoleeDbContexts.TenderCards
                                        where tc.TenderId == t.Tender_Id
                                        select new TenderCardInfo
                                        {
                                            Id = tc.Id,
                                            Label = tc.Label,
                                            Value = tc.Value
                                        }).ToList()
                        }

                    ).ToList();
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
        /// <param name="search"></param>
        /// <returns></returns>
        public IEnumerable<TenderCard> GetBidIniviterTenderListing(long companyId, string search)
        {
            try
            {
                return (from t in meroBoleeDbContexts.TenderEntities
                        join c in meroBoleeDbContexts.CategoryEntities on t.Category_Id equals c.Category_Id
                        join s in meroBoleeDbContexts.TenderStatus on t.Tender_Status_Id equals s.StatusId
                        where t.CompanyId == companyId && t.Tender_Status_Id != 4 && (search == null || t.Tender_Title.Contains(search))
                        select new TenderCard
                        {
                            TenderId = t.Tender_Id,
                            TenderCode = t.Tender_Code,
                            TenderTitle = t.Tender_Title,
                            CategoryId = c.Category_Id,
                            CategoryName = c.Category,
                            LiveStartDate = t.Live_Start_Date,
                            LiveEndDate = t.Live_End_Date,
                            RegistrationTill = t.RegistrationTill,
                            Status = s.Status,
                            StatusId = t.Tender_Status_Id,
                            CardInfo = (from tc in meroBoleeDbContexts.TenderCards
                                        where tc.TenderId == t.Tender_Id
                                        select new TenderCardInfo
                                        {
                                            Id = tc.Id,
                                            Label = tc.Label,
                                            Value = tc.Value
                                        }).ToList()
                        }

                    ).ToList();

                //return meroBoleeDbContexts.TenderEntities
                //        .Include(x => x.CreatedByUser)
                //        .Include(x => x.AuctionStatusEntity)
                //        .Include(x => x.TenderMaterialEntities)
                //        .Include(x => x.TenderTermsConditionEntities)
                //        .Include(x => x.CategoryEntity)
                //        .Where(m => m.CompanyId == companyId
                //                    && (m.Tender_Status_Id != 2)
                //                    && ((search == null)
                //        //|| (m.Tender_Code.ToString().Contains(search))
                //        || (m.Tender_Title.ToLower().Contains(search.ToLower()))
                //    )).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// bid inviter tender listing
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public IEnumerable<TenderEntity> GetBidInviterTenderListing(long companyId, string search)
        {

            return meroBoleeDbContexts.TenderEntities
                    .Include(x => x.CreatedByUser)
                    .Include(x => x.TenderStatusEntity)
                    .Include(x => x.TenderMaterialEntities)
                    .Include(x => x.TenderTermsConditionEntities)
                    .Include(x => x.CategoryEntity)
                    .Where(m => m.CompanyId == companyId
                    //&& (m.Live_Start_Date>= DateTime.Now)
                    && ((search == null)
                //|| (m.Tender_Code.ToString().Contains(search))
                //|| (m.Tender_Description.ToLower().Contains(search.ToLower()))
                //|| (m.Tender_Duration.ToString().Contains(search.ToLower()))
                || (m.Tender_Title.ToLower().Contains(search.ToLower()))
                //|| (m.Tender_live_interval.ToString().Contains(search.ToLower()))
                //|| (m.Live_Start_Date.ToString().Contains(search.ToLower()))
                //|| (m.Live_End_Date.ToString().Contains(search.ToLower()))
                //|| (m.Duration_Type.ToLower().Contains(search.ToLower()))
                //|| (m.Tender_Duration.ToString().Contains(search.ToLower()))
                //|| (m.Tender_fee.ToString().Contains(search.ToLower()))
                //|| (m.AdminStatusEntity.Status.ToLower().Contains(search.ToLower()))
                //|| (m.AuctionStatusEntity.Status.ToLower().Contains(search.ToLower()))
                //|| (m.PaymentStatusEntity.Payment_status.ToLower().Contains(search.ToLower()))
                )).ToList();

        }

        //public IEnumerable<TenderEntity> GetTenderByBidder()
        //{
        //    return meroBoleeDbContexts.TenderEntities.Where(m => m.AdminStatusEntity.Status.ToLower() == "approved").ToList();
        //}

        /// <summary>
        /// get tender detail
        /// </summary>
        /// <param name="tenderId"></param>
        /// <returns></returns>
        public TenderEntity GetTenderDetail(long tenderId)
        {
            try
            {
               // meroBoleeDbContexts.AuctionStatusEntities.ToList();
                //meroBoleeDbContexts.PaymentStatusEntities.ToList();
               // meroBoleeDbContexts.AdminStatusEntities.ToList();
                //meroBoleeDbContexts.TenderTermsConditionEntities.Where(x => x.TenderId == tenderId).ToList();
                //meroBoleeDbContexts
                //    .TenderMaterialEntities
                //    .Include(x => x.MaterialFeatures)
                //    .Where(x => x.TenderId == tenderId).ToList();

                //long[] materialIds = material.Select(x => x.Id).ToArray();

                //meroBoleeDbContexts.MaterialFeatureEntities
                //    .Where(x=>x.Material_id.ToString().Contains(string.Join(",", materialIds)))
                //    .ToList();
               // meroBoleeDbContexts.CategoryEntities.ToList();

                TenderEntity ent = meroBoleeDbContexts.TenderEntities
                    .Where(m => m.Tender_Id == tenderId)
                    .Include(x=> x.TenderMaterialEntities)
                    .Include(x => x.TenderCards)
                    .Include(x => x.ExtraDocuments)
                    .Include(x=> x.CategoryEntity)
                    .Include(x=> x.CreatedByUser)
                    .FirstOrDefault();

                //meroBoleeDbContexts
                //    .UserEntities
                //    .Where(x => x.User_Id == ent.CreatedBy)
                //    .ToList();
                return ent;

            }
            catch (Exception)
            {
                throw;
            }
        }




        /// <summary>
        /// upcoming tender within 7 days
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IEnumerable<TenderCard> UpcomingTender(string search)
        {
            try
            {
                return (from t in meroBoleeDbContexts.TenderEntities
                        join c in meroBoleeDbContexts.CategoryEntities on t.Category_Id equals c.Category_Id
                        join s in meroBoleeDbContexts.AuctionStatusEntities on t.Tender_Status_Id equals s.Status_Id
                        where t.Tender_Status_Id == 3 && (search == null || t.Tender_Title.Contains(search))
                            && (t.Live_Start_Date >= DateTime.Now && t.Live_Start_Date <= DateTime.Now.AddDays(7))
                        select new TenderCard
                        {
                            TenderId = t.Tender_Id,
                            TenderCode = t.Tender_Code,
                            TenderTitle = t.Tender_Title,
                            CategoryId = c.Category_Id,
                            CategoryName = c.Category,
                            LiveStartDate = t.Live_Start_Date,
                            LiveEndDate = t.Live_End_Date,
                            RegistrationTill = t.RegistrationTill,
                            StatusId = t.Tender_Status_Id,
                            Status = s.Status,
                            CardInfo = (from tc in meroBoleeDbContexts.TenderCards
                                        where tc.TenderId == t.Tender_Id
                                        select new TenderCardInfo
                                        {
                                            Id = tc.Id,
                                            Label = tc.Label,
                                            Value = tc.Value
                                        }).ToList()
                        }

               ).ToList();
                /*
                meroBoleeDbContexts.AuctionStatusEntities.ToList();
                meroBoleeDbContexts.PaymentStatusEntities.ToList();
                meroBoleeDbContexts.AdminStatusEntities.ToList();
                meroBoleeDbContexts.TenderTermsConditionEntities.ToList();
                meroBoleeDbContexts.TenderMaterialEntities.ToList();
                meroBoleeDbContexts.MaterialFeatureEntities.ToList();
                meroBoleeDbContexts.CategoryEntities.ToList();

                meroBoleeDbContexts.UserEntities.ToList();
                return meroBoleeDbContexts.TenderEntities
                    .Where(m => (m.Live_Start_Date >= DateTime.Now && m.Live_Start_Date <= DateTime.Now.AddDays(7))
                    && (m.Tender_Status_Id == 2) // Only Approved Tender
                    && ((search == null)
                    //|| (m.Tender_Code.ToString().Contains(search))
                    //|| (m.Tender_Description.ToLower().Contains(search.ToLower()))
                    //|| (m.Tender_Duration.ToString().Contains(search.ToLower()))
                    || (m.Tender_Title.ToLower().Contains(search.ToLower()))
                    //|| (m.Tender_live_interval.ToString().Contains(search.ToLower()))
                    //|| (m.Live_Start_Date.ToString().Contains(search.ToLower()))
                    //|| (m.Live_End_Date.ToString().Contains(search.ToLower()))
                    //|| (m.Duration_Type.ToLower().Contains(search.ToLower()))
                    //|| (m.Tender_Duration.ToString().Contains(search.ToLower()))
                    //|| (m.Tender_fee.ToString().Contains(search.ToLower()))
                    //|| (m.AdminStatusEntity.Status.ToLower().Contains(search.ToLower()))
                    //|| (m.AuctionStatusEntity.Status.ToLower().Contains(search.ToLower()))
                    //   || (m.PaymentStatusEntity.Payment_status.ToLower().Contains(search.ToLower()))
                    )).ToList();
                */
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

                meroBoleeDbContexts.TenderStatus.ToList();
                meroBoleeDbContexts.PaymentStatusEntities.ToList();
                meroBoleeDbContexts.TenderTermsConditionEntities.ToList();
                meroBoleeDbContexts.TenderMaterialEntities.ToList();
                meroBoleeDbContexts.MaterialFeatureEntities.ToList();
                meroBoleeDbContexts.CategoryEntities.ToList();
                meroBoleeDbContexts.UserEntities.ToList();
                return tenderEntity;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }


        /// <summary>
        /// Get a tender id from a tender code
        /// </summary>
        /// <param name="tenderCode">Unique tender code of a tender</param>
        /// <returns><see cref="Tuple{T1, T2}"/></returns>
        public Tuple<long, long> GetTenderIdFromCode(string tenderCode)
        {

            Tuple<long, long> tender_User = (from t in meroBoleeDbContexts.TenderEntities
                                             join c in meroBoleeDbContexts.CompanyEntities on t.CompanyId equals c.CompanyId
                                             join uc in meroBoleeDbContexts.UserCompanies on c.CompanyId equals uc.CompanyId
                                             join u in meroBoleeDbContexts.UserEntities on uc.UserId equals u.User_Id
                                             where t.Tender_Code == tenderCode && u.IsEmailReceiver == true
                                             select Tuple.Create(t.Tender_Id, u.User_Id)
                                            ).FirstOrDefault();
            return tender_User;
        }


        public Tuple<long, long> GetTenderWinnerIdFromCode(string tenderCode)
        {
            Tuple<long, long> tender_Winner = (from t in meroBoleeDbContexts.TenderEntities
                                               join tw in meroBoleeDbContexts.TenderWinnerEntities on t.Tender_Id equals tw.TenderId
                                               join c in meroBoleeDbContexts.CompanyEntities on tw.WinnerCompanyId equals c.CompanyId
                                               join cu in meroBoleeDbContexts.UserCompanies on c.CompanyId equals cu.CompanyId
                                               join u in meroBoleeDbContexts.UserEntities on cu.UserId equals u.User_Id
                                               where t.Tender_Code == tenderCode && u.IsEmailReceiver == true
                                               select Tuple.Create(t.Tender_Id, u.User_Id)
                                              ).FirstOrDefault();
            return tender_Winner;
        }

        public bool EndTenderAuction(long tenderId)
        {
            try
            {
                TenderEntity te = meroBoleeDbContexts.TenderEntities.Where(x => x.Tender_Id == tenderId).FirstOrDefault();
                if (te != null)
                {
                    te.Live_End_Date = DateTime.Now;
                    te.Cancel_remark = "Bidding not received";
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
    }
}
