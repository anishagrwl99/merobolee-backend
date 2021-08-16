using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public interface IFavouriteCategoryService
    {
        void AddFavourite(FavouriteCategoryEntity favourite);
        void RemoveFavourite(int id);
        IEnumerable<FavouriteCategoryEntity> GetFavourites(int id);
    }
}
