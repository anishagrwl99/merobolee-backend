using MeroBolee.Model;
using MeroBolee.Repository.FavouriteCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.FavouriteCategory
{
    public class FavouriteCategoryService : IFavouriteCategoryService
    {
        private readonly IFavouriteCategoryRepository favouriteCategoryRepository;
        public FavouriteCategoryService(IFavouriteCategoryRepository favouriteCategoryRepository)
        {
            this.favouriteCategoryRepository = favouriteCategoryRepository;
        }

        public void AddFavourite(FavouriteCategoryEntity favourite)
        {
            favouriteCategoryRepository.AddFavourite(favourite);
        }

        public IEnumerable<FavouriteCategoryEntity> GetFavourites(int id)
        {
            return favouriteCategoryRepository.GetFavouriteList(id);
        }

        public void RemoveFavourite(int id)
        {
            favouriteCategoryRepository.RemoveFavourite(id);
        }
    }
}
