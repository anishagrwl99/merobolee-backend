using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.FavouriteCategory
{
    public interface IFavouriteCategoryRepository : IRepositoryBase<FavouriteCategoryEntity>
    {
        void AddFavourite(FavouriteCategoryEntity favourite);
        void RemoveFavourite(int id);

        IEnumerable<FavouriteCategoryEntity> GetFavouriteList(int id);


    }
}
