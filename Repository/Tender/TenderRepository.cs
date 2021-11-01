using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.Tender
{

    /// <summary>
    /// Tender repo impelentation
    /// </summary>
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

                meroBoleeDbContexts.AuctionStatusEntities.ToList();
                meroBoleeDbContexts.PaymentStatusEntities.ToList();
                meroBoleeDbContexts.AdminStatusEntities.ToList();
                meroBoleeDbContexts.TenderTermsConditionEntities.ToList();
                meroBoleeDbContexts.TenderMaterialEntities.ToList();
                meroBoleeDbContexts.MaterialFeatureEntities.ToList();

                meroBoleeDbContexts.UserEntities.ToList();
                meroBoleeDbContexts.CategoryEntities.ToList();
                return tenderEntity;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (DbUpdateException)
            {

                throw;
            }

            catch (Exception ex)
            {
                throw;
            }

        }


        /// <summary>
        /// Favourite tender
        /// </summary>
        /// <param name="id"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public IEnumerable<TenderEntity> FavouriteTender(int userId, string search)
        {
            try
            {
                List<TenderEntity> tenderlist = new();
                var favourite = meroBoleeDbContexts.FavouriteCategoryEntities.Where(m => m.User_id == userId).ToList();
                foreach (var item in favourite)
                {
                    var tender = meroBoleeDbContexts.TenderEntities.Where(m => (m.Category_Id == item.Category_id) && ((search == null)
                    || (m.Tender_Code.ToString().Contains(search))
                    || (m.Tender_Description.ToLower().Contains(search.ToLower()))
                    || (m.Tender_Duration.ToString().Contains(search.ToLower()))
                    || (m.Tender_Title.ToLower().Contains(search.ToLower()))
                    || (m.Tender_live_interval.ToString().Contains(search.ToLower()))
                    || (m.Live_Start_Date.ToString().Contains(search.ToLower()))
                    || (m.Live_End_Date.ToString().Contains(search.ToLower()))
                    || (m.Duration_Type.ToLower().Contains(search.ToLower()))
                    || (m.Tender_Duration.ToString().Contains(search.ToLower()))
                    //  || (m.Tender_fee.ToString().Contains(search.ToLower()))
                    || (m.AdminStatusEntity.Status.ToLower().Contains(search.ToLower()))
                    || (m.AuctionStatusEntity.Status.ToLower().Contains(search.ToLower()))
                    //|| (m.PaymentStatusEntity.Payment_status.ToLower().Contains(search.ToLower()))
                    )).ToList();
                    foreach (var items in tender)
                    {
                        tenderlist.Add(items);
                    }
                }

                meroBoleeDbContexts.AuctionStatusEntities.ToList();
                meroBoleeDbContexts.PaymentStatusEntities.ToList();
                meroBoleeDbContexts.AdminStatusEntities.ToList();
                meroBoleeDbContexts.TenderTermsConditionEntities.ToList();
                meroBoleeDbContexts.TenderMaterialEntities.ToList();
                meroBoleeDbContexts.MaterialFeatureEntities.ToList();

                meroBoleeDbContexts.UserEntities.ToList();
                meroBoleeDbContexts.CategoryEntities.ToList();
                return tenderlist;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }


        /// <summary>
        /// Marketplace tender
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IEnumerable<TenderEntity> GetMarketplaceTender(string search)
        {
            try
            {
                meroBoleeDbContexts.AuctionStatusEntities.ToList();
                meroBoleeDbContexts.PaymentStatusEntities.ToList();
                meroBoleeDbContexts.AdminStatusEntities.ToList();
                meroBoleeDbContexts.TenderTermsConditionEntities.ToList();
                meroBoleeDbContexts.TenderMaterialEntities.ToList();
                meroBoleeDbContexts.MaterialFeatureEntities.ToList();

                meroBoleeDbContexts.UserEntities.ToList();
                meroBoleeDbContexts.CategoryEntities.ToList();
                return meroBoleeDbContexts.TenderEntities
                    .Where(m => (m.AdminStatusEntity.Status.ToLower() == "approved")
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
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// bid inviter tender
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="search"></param>
        /// <param name="companyType"></param>
        /// <returns></returns>
        public IEnumerable<TenderEntity> GetMyTender(long companyId, string search, CompanyTypeEnum companyType)
        {
            if (companyType == CompanyTypeEnum.BidInviter)
            {
                return meroBoleeDbContexts.TenderEntities
                        .Include(x => x.UserEntity)
                        .Include(x => x.AuctionStatusEntity)
                        .Include(x => x.AdminStatusEntity)
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
            else
            {
                List<TenderEntity> tenders = (from req in meroBoleeDbContexts.BidderRequestEntities
                                              join ten in meroBoleeDbContexts.TenderEntities on req.Tender_Id equals ten.Tender_Id
                                              where (req.CompanyId == companyId
                                                      && ((search == null)
                                                       || (ten.Tender_Title.ToLower().Contains(search.ToLower()))
                                                 ))
                                              select ten
                         ).ToList<TenderEntity>();
                meroBoleeDbContexts.AuctionStatusEntities.ToList();
                meroBoleeDbContexts.PaymentStatusEntities.ToList();
                meroBoleeDbContexts.AdminStatusEntities.ToList();
                meroBoleeDbContexts.TenderTermsConditionEntities.ToList();
                meroBoleeDbContexts.TenderMaterialEntities.ToList();
                meroBoleeDbContexts.MaterialFeatureEntities.ToList();

                meroBoleeDbContexts.UserEntities.ToList();
                meroBoleeDbContexts.CategoryEntities.ToList();
                return tenders;
            }
        }


        /// <summary>
        /// bid inivter tender history
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public IEnumerable<TenderEntity> GetBidIniviterTenderHistory(long companyId, string search)
        {

            return meroBoleeDbContexts.TenderEntities
                    .Include(x => x.UserEntity)
                    .Include(x => x.AuctionStatusEntity)
                    .Include(x => x.AdminStatusEntity)
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


        /// <summary>
        /// bid inviter tender listing
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public IEnumerable<TenderEntity> GetBidInviterTenderListing(long companyId, string search)
        {

            return meroBoleeDbContexts.TenderEntities
                    .Include(x => x.UserEntity)
                    .Include(x => x.AuctionStatusEntity)
                    .Include(x => x.AdminStatusEntity)
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


        /// <summary>
        /// get tender by auctioneer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public IEnumerable<TenderEntity> GetTenderByAuctioneer(int userId, string search)
        {
            try
            {
                meroBoleeDbContexts.AuctionStatusEntities.ToList();
                meroBoleeDbContexts.PaymentStatusEntities.ToList();
                meroBoleeDbContexts.AdminStatusEntities.ToList();
                meroBoleeDbContexts.TenderTermsConditionEntities.ToList();
                meroBoleeDbContexts.TenderMaterialEntities.ToList();
                meroBoleeDbContexts.MaterialFeatureEntities.ToList();

                meroBoleeDbContexts.UserEntities.ToList();
                meroBoleeDbContexts.CategoryEntities.ToList();
                return meroBoleeDbContexts.TenderEntities.Where(m => (m.UserId == userId) && ((search == null)
                || (m.Tender_Code.ToString().Contains(search))
                || (m.Tender_Description.ToLower().Contains(search.ToLower()))
                || (m.Tender_Duration.ToString().Contains(search.ToLower()))
                || (m.Tender_Title.ToLower().Contains(search.ToLower()))
                || (m.Tender_live_interval.ToString().Contains(search.ToLower()))
                || (m.Live_Start_Date.ToString().Contains(search.ToLower()))
                || (m.Live_End_Date.ToString().Contains(search.ToLower()))
                || (m.Duration_Type.ToLower().Contains(search.ToLower()))
                || (m.Tender_Duration.ToString().Contains(search.ToLower()))
                //  || (m.Tender_fee.ToString().Contains(search.ToLower()))
                || (m.AdminStatusEntity.Status.ToLower().Contains(search.ToLower()))
                || (m.AuctionStatusEntity.Status.ToLower().Contains(search.ToLower()))

                //  || (m.PaymentStatusEntity.Payment_status.ToLower().Contains(search.ToLower()))
                )).ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        //public IEnumerable<TenderEntity> GetTenderByBidder()
        //{
        //    return meroBoleeDbContexts.TenderEntities.Where(m => m.AdminStatusEntity.Status.ToLower() == "approved").ToList();
        //}

        /// <summary>
        /// get tender detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TenderEntity GetTenderDetail(int id)
        {
            try
            {
                meroBoleeDbContexts.AuctionStatusEntities.ToList();
                meroBoleeDbContexts.PaymentStatusEntities.ToList();
                meroBoleeDbContexts.AdminStatusEntities.ToList();
                meroBoleeDbContexts.TenderTermsConditionEntities.Where(x => x.Tender_Id == id).ToList();
                meroBoleeDbContexts
                    .TenderMaterialEntities
                    .Include(x => x.MaterialFeatures)
                    .Where(x => x.Tender_Id == id).ToList();

                //long[] materialIds = material.Select(x => x.Id).ToArray();

                //meroBoleeDbContexts.MaterialFeatureEntities
                //    .Where(x=>x.Material_id.ToString().Contains(string.Join(",", materialIds)))
                //    .ToList();
                meroBoleeDbContexts.CategoryEntities.ToList();

                TenderEntity ent = meroBoleeDbContexts.TenderEntities.Where(m => m.Tender_Id == id).FirstOrDefault();
                meroBoleeDbContexts.UserEntities.Where(x => x.User_Id == ent.UserId).ToList();
                return ent;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }



        /// <summary>
        /// tender by status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public IEnumerable<TenderEntity> TenderByStatus(int statusId, string search)
        {
            try
            {
                meroBoleeDbContexts.AuctionStatusEntities.ToList();
                meroBoleeDbContexts.PaymentStatusEntities.ToList();
                meroBoleeDbContexts.AdminStatusEntities.ToList();
                meroBoleeDbContexts.TenderTermsConditionEntities.ToList();
                meroBoleeDbContexts.TenderMaterialEntities.ToList();
                meroBoleeDbContexts.MaterialFeatureEntities.ToList();
                meroBoleeDbContexts.CategoryEntities.ToList();

                meroBoleeDbContexts.UserEntities.ToList();
                return meroBoleeDbContexts.TenderEntities.Where(m => (m.Tender_Status_Id == statusId && m.AdminStatusEntity.Status.ToLower() == "approved") && ((search == null)
                    || (m.Tender_Code.ToString().Contains(search))
                    || (m.Tender_Description.ToLower().Contains(search.ToLower()))
                    || (m.Tender_Duration.ToString().Contains(search.ToLower()))
                    || (m.Tender_Title.ToLower().Contains(search.ToLower()))
                    || (m.Tender_live_interval.ToString().Contains(search.ToLower()))
                    || (m.Live_Start_Date.ToString().Contains(search.ToLower()))
                    || (m.Live_End_Date.ToString().Contains(search.ToLower()))
                    || (m.Duration_Type.ToLower().Contains(search.ToLower()))
                    || (m.Tender_Duration.ToString().Contains(search.ToLower()))
                    //  || (m.Tender_fee.ToString().Contains(search.ToLower()))
                    || (m.AdminStatusEntity.Status.ToLower().Contains(search.ToLower()))
                    || (m.AuctionStatusEntity.Status.ToLower().Contains(search.ToLower()))
                    //   || (m.PaymentStatusEntity.Payment_status.ToLower().Contains(search.ToLower()))
                    )).ToList();

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }


        /// <summary>
        /// upcoming tender
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IEnumerable<TenderEntity> UpcomingTender(string search)
        {
            try
            {
                meroBoleeDbContexts.AuctionStatusEntities.ToList();
                meroBoleeDbContexts.PaymentStatusEntities.ToList();
                meroBoleeDbContexts.AdminStatusEntities.ToList();
                meroBoleeDbContexts.TenderTermsConditionEntities.ToList();
                meroBoleeDbContexts.TenderMaterialEntities.ToList();
                meroBoleeDbContexts.MaterialFeatureEntities.ToList();
                meroBoleeDbContexts.CategoryEntities.ToList();

                meroBoleeDbContexts.UserEntities.ToList();
                return meroBoleeDbContexts.TenderEntities
                    .Where(m => (m.AuctionStatusEntity.Status.ToLower() == "upcoming"
                    && m.AdminStatusEntity.Status.ToLower() == "approved")
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
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// update tender
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tenderEntity"></param>
        /// <returns></returns>
        public TenderEntity UpdateTender(int id, TenderEntity tenderEntity)
        {
            try
            {
                TenderEntity tender = GetTenderDetail(id);
                tender.Tender_Title = tenderEntity.Tender_Title;
                tender.Category_Id = tenderEntity.Category_Id;
                tender.Tender_Description = tenderEntity.Tender_Description;
                tender.Tender_live_interval = tenderEntity.Tender_live_interval;
                tender.Live_Start_Date = tenderEntity.Live_Start_Date;
                tender.Live_End_Date = tenderEntity.Live_Start_Date.AddMinutes(tenderEntity.Tender_live_interval);
                tender.Tender_Duration = tenderEntity.Tender_Duration;
                tender.Duration_Type = tenderEntity.Duration_Type;
                tender.Bid_No = tenderEntity.Bid_No;
                tender.Tender_Status_Id = tenderEntity.Tender_Status_Id;
                tender.Admin_Status_Id = tenderEntity.Admin_Status_Id;
                tender.Cancel_remark = tenderEntity.Cancel_remark;
                tender.Project_Start_Date = tenderEntity.Project_Start_Date;
                tender.Source_Fund = tenderEntity.Source_Fund;
                tender.Last_Request_Date = tenderEntity.Last_Request_Date;
                //  tender.IFB_RFP_EOI1 = tenderEntity.IFB_RFP_EOI1;
                tender.TenderMaterialEntities = tenderEntity.TenderMaterialEntities;
                tender.TenderTermsConditionEntities = tenderEntity.TenderTermsConditionEntities;


                unitOfWork.SaveChange();

                meroBoleeDbContexts.AuctionStatusEntities.ToList();
                meroBoleeDbContexts.PaymentStatusEntities.ToList();
                meroBoleeDbContexts.AdminStatusEntities.ToList();
                meroBoleeDbContexts.TenderTermsConditionEntities.ToList();
                meroBoleeDbContexts.TenderMaterialEntities.ToList();
                meroBoleeDbContexts.MaterialFeatureEntities.ToList();
                meroBoleeDbContexts.CategoryEntities.ToList();
                meroBoleeDbContexts.UserEntities.ToList();
                return tender;
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
                             where t.Tender_Code == tenderCode
                             select Tuple.Create(t.Tender_Id, u.User_Id)
                     ).FirstOrDefault();
            return tender_User;
        }
    }
}
