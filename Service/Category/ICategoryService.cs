using MeroBolee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service
{
    public interface ICategoryService
    {
        GetCategoryDto AddCategory(AddCategoryDto CategoryDto);
        IEnumerable<GetCategoryDto> GetCategory(string search);
        GetCategoryDto GetCategoryDetail(int id);

        GetCategoryDto UpdateCategory( UpdateCategoryDto CategoryDto);
        void DeleteCategory(int id);
    }
}
