using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    /// <summary>
    /// FAQ DTO 
    /// </summary>
    public class FAQAddDto
    {

        /// <summary>
        /// A question of a FAQ section
        /// </summary>
        [Required(ErrorMessage = "FAQ question is required")]
        [MaxLength(1000, ErrorMessage = "FAQ question can be {1} character long")]
        public string Question { get; set; }

        /// <summary>
        /// An answer for a FAQ question
        /// </summary>
        [Required(ErrorMessage = "FAQ answer is required")]
        [MaxLength(5000, ErrorMessage = "FAQ answer can be {1} character long")]
        public string Answer { get; set; }

        [Required(ErrorMessage = "FAQ Type is required")]
        [MaxLength(5000, ErrorMessage = "FAQ answer can be {1} character long")]
        public string FAQType { get; set; }
    }

    /// <summary>
    /// FAQ full response Dto
    /// </summary>
    public class FAQResponseDto: FAQAddDto
    {

        /// <summary>
        /// Id of a FAQ section
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Date on which FAQ was created
        /// </summary>
        public DateTime CreatedDate { get; set; }



        /// <summary>
        /// Date on which FAQ was last modified
        /// </summary>
        public DateTime ModifiedDate { get; set; }

    }
}
