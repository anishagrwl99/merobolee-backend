using MeroBolee.Dto;
using MeroBolee.EntityMapper;
using MeroBolee.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public class CategoryService:CategoryMapper,ICategoryService
    {
        private readonly ICategoryRepository CategoryRepository;
        public CategoryService(ICategoryRepository CategoryRepository)
        {
            this.CategoryRepository = CategoryRepository;
        }

        public GetCategoryDto AddCategory(AddCategoryDto CategoryDto)
        {
            return CategoryEntityToDto(CategoryRepository.AddCategory(CategoryDtoEntity(CategoryDto)));
        }

        public void DeleteCategory(int id)
        {
            CategoryRepository.DeleteCategory(id);
        }

        public GetCategoryDto GetCategoryDetail(int id)
        {
            return CategoryEntityToDto(CategoryRepository.GetCategoryDetail(id));
        }

        public IEnumerable<GetCategoryDto> GetCategory(string search)
        {
            return CategoryEntityListToDto(CategoryRepository.GetCategory(search));
        }

        public GetCategoryDto UpdateCategory(int id, AddCategoryDto CategoryDto)
        {
            return CategoryEntityToDto(CategoryRepository.UpdateCategory(id, CategoryDtoEntity(CategoryDto)));
        }

    }
}
