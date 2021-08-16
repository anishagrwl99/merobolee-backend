using MeroBolee.Infrastructure;
using MeroBolee.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.Tender
{
    public class TenderRepository : RepositoryBase<TenderEntity> , ITenderRepository
    {
        private readonly IDbFactory dbFactory;
        private readonly IUnitOfWork unitOfWork;

        public TenderRepository(IUnitOfWork unitOfWork, IDbFactory dbFactory) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public TenderEntity AddTender(TenderEntity tenderEntity)
        {
            try
            {
                tenderEntity.Live_End_Date = tenderEntity.Live_Start_Date.AddMinutes(tenderEntity.Tender_live_interval);
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
                throw new ArgumentNullException();
    }
            catch (DbUpdateException)
            {
               
                throw new DbUpdateException();
}

            catch (Exception)
{
    throw new Exception();
}

        }

        public IEnumerable<TenderEntity> FavouriteTender(int id, string search)
        {
            try
            {
                List<TenderEntity> tenderlist = new List<TenderEntity>();
                var favourite = meroBoleeDbContexts.FavouriteCategoryEntities.Where(m => m.User_id == id).ToList();
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

        public IEnumerable<TenderEntity> GetAllTender(string search)
        {
            try { 
            meroBoleeDbContexts.AuctionStatusEntities.ToList();
            meroBoleeDbContexts.PaymentStatusEntities.ToList();
            meroBoleeDbContexts.AdminStatusEntities.ToList();
            meroBoleeDbContexts.TenderTermsConditionEntities.ToList();
            meroBoleeDbContexts.TenderMaterialEntities.ToList();
            meroBoleeDbContexts.MaterialFeatureEntities.ToList();

                meroBoleeDbContexts.UserEntities.ToList();
                meroBoleeDbContexts.CategoryEntities.ToList();
                return meroBoleeDbContexts.TenderEntities.Where(m => (m.AdminStatusEntity.Status.ToLower() == "approved") &&((search == null)
                || (m.Tender_Code.ToString().Contains(search))
                || (m.Tender_Description.ToLower().Contains(search.ToLower()))
                || (m.Tender_Duration.ToString().Contains(search.ToLower()))
                || (m.Tender_Title.ToLower().Contains(search.ToLower()))
                || (m.Tender_live_interval.ToString().Contains(search.ToLower()))
                || (m.Live_Start_Date.ToString().Contains(search.ToLower()))
                || (m.Live_End_Date.ToString().Contains(search.ToLower()))
                || (m.Duration_Type.ToLower().Contains(search.ToLower()))
                || (m.Tender_Duration.ToString().Contains(search.ToLower()))
            //    || (m.Tender_fee.ToString().Contains(search.ToLower()))
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

        public IEnumerable<TenderEntity> GetTenderByAuctioneer(int id, string search)
        {
            try { 
            meroBoleeDbContexts.AuctionStatusEntities.ToList();
            meroBoleeDbContexts.PaymentStatusEntities.ToList();
            meroBoleeDbContexts.AdminStatusEntities.ToList();
            meroBoleeDbContexts.TenderTermsConditionEntities.ToList();
            meroBoleeDbContexts.TenderMaterialEntities.ToList();
            meroBoleeDbContexts.MaterialFeatureEntities.ToList();

                meroBoleeDbContexts.UserEntities.ToList();
                meroBoleeDbContexts.CategoryEntities.ToList();
                return meroBoleeDbContexts.TenderEntities.Where(m =>( m.Posted_By == id) && ((search == null)
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

        public TenderEntity GetTenderDetail(int id)
        {
            try { 
            meroBoleeDbContexts.AuctionStatusEntities.ToList();
            meroBoleeDbContexts.PaymentStatusEntities.ToList();
            meroBoleeDbContexts.AdminStatusEntities.ToList();
            meroBoleeDbContexts.TenderTermsConditionEntities.ToList();
            meroBoleeDbContexts.TenderMaterialEntities.ToList();
            meroBoleeDbContexts.MaterialFeatureEntities.ToList();
                meroBoleeDbContexts.CategoryEntities.ToList();

                meroBoleeDbContexts.UserEntities.ToList();
                return meroBoleeDbContexts.TenderEntities.Where(m => m.Tender_Id ==id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public IEnumerable<TenderEntity> TenderByStatus(int id, string search)
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
                return meroBoleeDbContexts.TenderEntities.Where(m => (m.Tender_Status_Id == id && m.AdminStatusEntity.Status.ToLower() == "approved") && ((search == null)
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
                return meroBoleeDbContexts.TenderEntities.Where(m => (m.AuctionStatusEntity.Status.ToLower() == "upcoming" && m.AdminStatusEntity.Status.ToLower() == "approved") && ((search == null)
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

        public TenderEntity UpdateTender(int id, TenderEntity tenderEntity)
        {
            try { 
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
    }
}
