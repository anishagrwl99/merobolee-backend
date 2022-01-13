using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class PostTechnicalSupportDto
    {
        private long? _id = null;

        [Required(ErrorMessage = "Sender name is required")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } 


        [Required(ErrorMessage = "Support subject is required")]
        [MaxLength(150)]
        public string Title { get; set; }


        [Required(ErrorMessage = "Support detail is required")]
        public string Description { get; set; }


        public long? UserId
        {
            get { return _id; }
            set
            {
                if(value == null || value < 1)
                {
                    _id = null;
                }
                else
                {
                    _id = value;
                }
            }
        }
    }
}
