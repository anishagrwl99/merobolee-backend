using MeroBolee.Infrastructure;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Repository.Category
{
    public class CategoryRepository: RepositoryBase<CategoryEntity>,ICategoryRepository
    {
        private readonly IUnitOfWork unitOfWork;
        public CategoryRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory)
        {
            this.unitOfWork = unitOfWork;
        }

        public CategoryEntity AddCategory(CategoryEntity categoryEntity)
        {
            try
            {
                meroBoleeDbContexts.CategoryEntities.Add(categoryEntity);
                unitOfWork.SaveChange();
                meroBoleeDbContexts.StatusEntities.ToList();
                return categoryEntity;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
             

        public void DeleteCategory(int id)
        {
            try
            {
                meroBoleeDbContexts.CategoryEntities.Remove(GetById(id));
                unitOfWork.SaveChange();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public CategoryEntity GetCategoryDetail(int id)
        {
            try
            {
                CategoryEntity Category = meroBoleeDbContexts.CategoryEntities.Find(id);
                if (Category == null)
                {
                    return Category = null;
                }
                meroBoleeDbContexts.StatusEntities.ToList();
                return Category;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public IEnumerable<CategoryEntity> GetCategory(string search)
        {
            try
            {
                meroBoleeDbContexts.StatusEntities.ToList();
                return meroBoleeDbContexts.CategoryEntities.Where(m => (search == null)
                || (m.Category.ToLower().Contains(search.ToLower()))
                ).ToList();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public CategoryEntity UpdateCategory(int id, CategoryEntity categoryEntity)
        {
            try
            {
                CategoryEntity category = GetCategoryDetail(id);
                if (category == null)
                {
                    return category = null;
                }
                category.Category = categoryEntity.Category;
                category.Status_Id = categoryEntity.Status_Id;
                category.Date_modified = categoryEntity.Date_modified;
             //   categoryEntity.Modified_time_stamp = categoryEntity.Modified_time_stamp;
                unitOfWork.SaveChange();
                return category;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

    }
}
