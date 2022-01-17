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

        [Required(ErrorMessage = "Phone number is required")]
        [MaxLength(22)]
        public string PhoneNumber { get; set; }
    }


    public class ReplyTechnicalSupportDto
    {
        [Required(ErrorMessage = "Sender name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Sender email is required")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Body is required")]
        public string Body { get; set; }


        [Required(ErrorMessage = "Sender Id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid sender id")]
        public long ReplyUserId { get; set; }


        [Required(ErrorMessage = "Help request sender user id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid help request user id")]
        public long SenderUserId { get; set; }
    }
}
