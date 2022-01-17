using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static MeroBolee.Model.CommonStatus;

namespace MeroBolee.Dto
{
    /// <summary>
    /// Add category dto
    /// </summary>
    public class AddCategoryDto
    {
        [Required(ErrorMessage = "Category name is required")]
        [MaxLength(100, ErrorMessage = "Category name can be {1} character long")]
        public string Category { get; set; }

    }


    public class UpdateCategoryDto : AddCategoryDto
    {
        [Required(ErrorMessage = "Category id is required")]
        [Range(1, byte.MaxValue, ErrorMessage = "Invalid category id")]
        public int Id { get; set; }
    }
}
