using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{

    /// <summary>
    /// Favourite category repo
    /// </summary>
    public class FavouriteCategoryRepository: RepositoryBase<FavouriteCategoryEntity>, IFavouriteCategoryRepository
    {
        private readonly IUnitOfWork unitOfWork;


        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="dbFactory"></param>
        public FavouriteCategoryRepository(IUnitOfWork unitOfWork, IDbFactory dbFactory) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Add to favourite
        /// </summary>
        /// <param name="favourite"></param>
        public void AddFavourite(FavouriteCategoryEntity favourite)
        {
            meroBoleeDbContexts.FavouriteCategoryEntities.Add(favourite);
            unitOfWork.SaveChange();
        }



        /// <summary>
        /// Get favourite list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<FavouriteCategoryEntity> GetFavouriteList(int id)
        {
            return meroBoleeDbContexts.FavouriteCategoryEntities.Where(m => m.User_id == id).ToList();
        }



        /// <summary>
        /// Remove from favourite
        /// </summary>
        /// <param name="id"></param>
        public void RemoveFavourite(int id)
        {
            meroBoleeDbContexts.FavouriteCategoryEntities.Remove(GetById(id));
            unitOfWork.SaveChange();
        }
    }
}
