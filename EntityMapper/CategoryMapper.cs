using MeroBolee.Dto;
using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.EntityMapper
{
    public class CategoryMapper
    {
        public CategoryEntity CategoryDtoEntity(AddCategoryDto addCategoryDto)
        {
            if (addCategoryDto == null)
            {
                return null;
            }
            return new CategoryEntity
            {
                Category = addCategoryDto.Category,
                Date_created = DateTime.Now,
                Date_modified = DateTime.Now
            };

        }

        public GetCategoryDto CategoryEntityToDto(CategoryEntity categoryEntity)
        {
            if (categoryEntity == null)
            {
                return null;
            }
            return new GetCategoryDto
            {
                Id = categoryEntity.Category_Id,
                Category = categoryEntity.Category
            };

        }

        public IEnumerable<GetCategoryDto> CategoryEntityListToDto(IEnumerable<CategoryEntity> categoryEntities)
        {

            List<GetCategoryDto> getCategory = new List<GetCategoryDto>();
            if (categoryEntities == null)
            {
                return getCategory = null;
            }
            foreach (CategoryEntity category in categoryEntities)
            {
                getCategory.Add
                (
                  new GetCategoryDto
                  {
                      Id = category.Category_Id,
                      Category = category.Category 
                  }
                );
            }
            return getCategory;
        }

    }
}
