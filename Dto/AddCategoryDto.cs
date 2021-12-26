using System;
using System.Collections.Generic;
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
        private string category;

        private int statusId;

        /// <summary>
        /// Category test
        /// </summary>
        public string Category { get => category; set => category = value; }

        /// <summary>
        /// Status id
        /// </summary>
        public int StatusId { get => statusId; set => statusId = value; }
    }
}
