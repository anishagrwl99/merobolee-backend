using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
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

        public IEnumerable<TenderWatchListCard> GetAllWatchList(long userId, long companyId)
        {
            try
            {
                return (from w in meroBoleeDbContexts.WatchListEntities
                        join t in meroBoleeDbContexts.TenderEntities on w.TenderId equals t.Id
                        join c in meroBoleeDbContexts.CategoryEntities on t.CategoryId equals c.Id
                        join s in meroBoleeDbContexts.BidRequestStatusEntities on t.StatusId equals s.StatusId
                        where w.CompanyId == companyId
                        select new TenderWatchListCard
                        {
                            WatchListId = w.Id,
                            TenderId = t.Id,
                            TenderCode = t.Code,
                            TenderTitle = t.Title,
                            CategoryId = c.Id,
                            CategoryName = c.Category,
                            LiveStartDate = t.LiveStartDate,
                            StatusId = s.StatusId,
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

                    ).ToList();
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

        public bool IsTenderAddedToWatchList(long tenderId, long companyId)
        {
            try
            {
                return meroBoleeDbContexts.WatchListEntities.Where(x => x.CompanyId == companyId && x.TenderId == tenderId).Count() > 0 ;
            }
            catch 
            {

                throw;
            }
        }
    }
}
