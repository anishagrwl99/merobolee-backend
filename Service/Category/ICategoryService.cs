using MeroBolee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Service.Category
{
    public interface ICategoryService
    {
        GetCategoryDto AddCategory(AddCategoryDto CategoryDto);
        IEnumerable<GetCategoryDto> GetCategory(string search);
        GetCategoryDto GetCategoryDetail(int id);

        GetCategoryDto UpdateCategory(int id, AddCategoryDto CategoryDto);
        void DeleteCategory(int id);
    }
}
