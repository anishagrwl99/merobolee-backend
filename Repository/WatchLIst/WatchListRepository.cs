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
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public IEnumerable<WatchListEntity> GetAllWatchList(int id)
        {
            try
            {
                meroBoleeDbContexts.TenderEntities.ToList();
                meroBoleeDbContexts.CategoryEntities.ToList();
                meroBoleeDbContexts.AdminStatusEntities.ToList();
                return meroBoleeDbContexts.WatchListEntities.Where(m => m.User_Id == id).ToList();
            }
            catch (Exception)
            {
                throw new Exception();
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
