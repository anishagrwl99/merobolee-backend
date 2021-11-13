using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository
{
    public interface ICategoryRepository: IRepositoryBase<CategoryEntity>
    {
        CategoryEntity AddCategory(CategoryEntity categoryEntity);
        IEnumerable<CategoryEntity> GetCategory(string search);
        CategoryEntity GetCategoryDetail(int id);

        CategoryEntity UpdateCategory(int id, CategoryEntity categoryEntity);
        void DeleteCategory(int id);

    }
}
