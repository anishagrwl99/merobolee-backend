using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MeroBolee.Model.PublishStatus;

namespace MeroBolee.Dto
{
    /// <summary>
    /// Add category dto
    /// </summary>
    public class AddCategoryDto
    {
        private string category;

        private int status_Id;

        /// <summary>
        /// Category test
        /// </summary>
        public string Category { get => category; set => category = value; }

        /// <summary>
        /// Status id
        /// </summary>
        public int Status_Id { get => status_Id; set => status_Id = value; }
    }
}
