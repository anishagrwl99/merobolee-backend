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

        public IEnumerable<TenderWatchListCard> GetAllWatchList(long userId, long companyId, List<int> procurementId, List<int> algoId)
        {
            try
            {
                var obj = new List<TenderWatchListCard>();

                if (procurementId.Count==0 && algoId.Count==0)
                {
                    return (from w in meroBoleeDbContexts.WatchListEntities
                            join t in meroBoleeDbContexts.TenderEntities on w.TenderId equals t.Id
                            join c in meroBoleeDbContexts.TenderProcurementCategoryEntities on t.ProcurementCategoryId equals c.Id
                            join s in meroBoleeDbContexts.BidRequestStatusEntities on t.StatusId equals s.StatusId
                            where w.CompanyId == companyId && t.LiveStartDate > DateTimeNPT.Now
                            select new TenderWatchListCard
                            {
                                WatchListId = w.Id,
                                TenderId = t.Id,
                                TenderCode = t.Code,
                                TenderTitle = t.Title,
                                CategoryId = c.Id,
                                CategoryName = c.Title,
                                LiveStartDate = t.LiveStartDate,
                                LiveEndDate = t.LiveEndDate,
                                Product = t.Product,
                                Price = t.Price,
                                RegistrationTill = t.RegistrationTill,
                                StatusId = s.StatusId,
                                Status = s.Status,
                                Location=t.Location
                            }

                   ).ToList();
                }
                else if (procurementId.Count!=0 && algoId.Count!=0)
                {
                    foreach (var item in procurementId)
                    {
                        foreach (var algo in algoId)
                        {
                            var result= (from w in meroBoleeDbContexts.WatchListEntities
                                         join t in meroBoleeDbContexts.TenderEntities on w.TenderId equals t.Id
                                         join c in meroBoleeDbContexts.TenderProcurementCategoryEntities on t.ProcurementCategoryId equals c.Id
                                         join s in meroBoleeDbContexts.BidRequestStatusEntities on t.StatusId equals s.StatusId
                                         where w.CompanyId == companyId && t.LiveStartDate > DateTimeNPT.Now && t.ProcurementId==item && t.AlgoId==algo
                                         select new TenderWatchListCard
                                         {
                                             WatchListId = w.Id,
                                             TenderId = t.Id,
                                             TenderCode = t.Code,
                                             TenderTitle = t.Title,
                                             CategoryId = c.Id,
                                             CategoryName = c.Title,
                                             LiveStartDate = t.LiveStartDate,
                                             LiveEndDate = t.LiveEndDate,
                                             Product = t.Product,
                                             Price = t.Price,
                                             RegistrationTill = t.RegistrationTill,
                                             StatusId = s.StatusId,
                                             Status = s.Status,
                                             Location = t.Location
                                         }

                   ).ToList();

                            obj.AddRange(result);
                        }
                    }
                    return obj;
                }
                else if (procurementId.Count!=0)
                {
                    foreach (var item in procurementId)
                    {
                        var result = (from w in meroBoleeDbContexts.WatchListEntities
                                      join t in meroBoleeDbContexts.TenderEntities on w.TenderId equals t.Id
                                      join c in meroBoleeDbContexts.TenderProcurementCategoryEntities on t.ProcurementCategoryId equals c.Id
                                      join s in meroBoleeDbContexts.BidRequestStatusEntities on t.StatusId equals s.StatusId
                                      where w.CompanyId == companyId && t.LiveStartDate > DateTimeNPT.Now && t.ProcurementId == item 
                                      select new TenderWatchListCard
                                      {
                                          WatchListId = w.Id,
                                          TenderId = t.Id,
                                          TenderCode = t.Code,
                                          TenderTitle = t.Title,
                                          CategoryId = c.Id,
                                          CategoryName = c.Title,
                                          LiveStartDate = t.LiveStartDate,
                                          LiveEndDate = t.LiveEndDate,
                                          Product = t.Product,
                                          Price = t.Price,
                                          RegistrationTill = t.RegistrationTill,
                                          StatusId = s.StatusId,
                                          Status = s.Status,
                                          Location = t.Location
                                      }

                 ).ToList();

                        obj.AddRange(result);
                    }
                    return obj;
                }
                else
                {
                    foreach (var item in algoId)
                    {
                        var result = (from w in meroBoleeDbContexts.WatchListEntities
                                      join t in meroBoleeDbContexts.TenderEntities on w.TenderId equals t.Id
                                      join c in meroBoleeDbContexts.TenderProcurementCategoryEntities on t.ProcurementCategoryId equals c.Id
                                      join s in meroBoleeDbContexts.BidRequestStatusEntities on t.StatusId equals s.StatusId
                                      where w.CompanyId == companyId && t.LiveStartDate > DateTimeNPT.Now && t.AlgoId == item
                                      select new TenderWatchListCard
                                      {
                                          WatchListId = w.Id,
                                          TenderId = t.Id,
                                          TenderCode = t.Code,
                                          TenderTitle = t.Title,
                                          CategoryId = c.Id,
                                          CategoryName = c.Title,
                                          LiveStartDate = t.LiveStartDate,
                                          LiveEndDate = t.LiveEndDate,
                                          Product = t.Product,
                                          Price = t.Price,
                                          RegistrationTill = t.RegistrationTill,
                                          StatusId = s.StatusId,
                                          Status = s.Status,
                                          Location = t.Location
                                      }

                 ).ToList();

                        obj.AddRange(result);
                    }
                    return obj;
                }
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
