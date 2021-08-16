using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.FavouriteCategory
{
    public class FavouriteCategoryRepository: RepositoryBase<FavouriteCategoryEntity>, IFavouriteCategoryRepository
    {
        private readonly IDbFactory dbFactory;
        private readonly IUnitOfWork unitOfWork;

        public FavouriteCategoryRepository(IUnitOfWork unitOfWork, IDbFactory dbFactory) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }
        public void AddFavourite(FavouriteCategoryEntity favourite)
        {
            meroBoleeDbContexts.FavouriteCategoryEntities.Add(favourite);
            unitOfWork.SaveChange();
        }

        public IEnumerable<FavouriteCategoryEntity> GetFavouriteList(int id)
        {
            return meroBoleeDbContexts.FavouriteCategoryEntities.Where(m => m.User_id == id).ToList();
        }

        public void RemoveFavourite(int id)
        {
            meroBoleeDbContexts.FavouriteCategoryEntities.Remove(GetById(id));
            unitOfWork.SaveChange();
        }
    }
}
