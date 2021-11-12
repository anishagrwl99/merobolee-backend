using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.WatchLIst
{
    public class WatchListRepository: RepositoryBase<WatchListEntity>,IWatchListRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public WatchListRepository(IUnitOfWork unitOfWork, IDbFactory dbFactory) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddWatchList(WatchListEntity watchList)
        {
            try
            {
                meroBoleeDbContexts.WatchListEntities.Add(watchList);
                unitOfWork.SaveChange();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<TenderCard> GetAllWatchList(long userId, long companyId)
        {
            try
            {
                return (from w in meroBoleeDbContexts.WatchListEntities
                        join t in meroBoleeDbContexts.TenderEntities on w.TenderId equals t.Tender_Id
                        join c in meroBoleeDbContexts.CategoryEntities on t.Category_Id equals c.Category_Id
                        join s in meroBoleeDbContexts.AuctionStatusEntities on t.Tender_Status_Id equals s.Status_Id
                        where w.CompanyId == companyId
                        select new TenderCard
                        {
                            TenderId = t.Tender_Id,
                            TenderCode = t.Tender_Code,
                            TenderTitle = t.Tender_Title,
                            CategoryId = c.Category_Id,
                            CategoryName = c.Category,
                            LiveStartDate = t.Live_Start_Date,
                            Status = s.Status
                        }

                    ).ToList();

                //meroBoleeDbContexts.TenderEntities.ToList();
                //meroBoleeDbContexts.CategoryEntities.ToList();
                //meroBoleeDbContexts.AdminStatusEntities.ToList();
                //return meroBoleeDbContexts.WatchListEntities.Where(m => m.User_Id == id).ToList();
            }
            catch
            {
                throw;
            }
        }

        public void RemoveWatchList(int id)
        {
            try
            {
                WatchListEntity deletewatch = meroBoleeDbContexts.WatchListEntities.Where(m => m.Id == id).First();
                meroBoleeDbContexts.WatchListEntities.Remove(deletewatch);
                unitOfWork.SaveChange();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
