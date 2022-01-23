using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class SendEmailDto
    {
        [Required(ErrorMessage = "User company id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid company id")]
        public long CompanyId { get; set; }

        [Required(ErrorMessage = "Sender user id is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid user id")]
        public long UserId { get; set; }


        [Required(ErrorMessage = "Tender code is required to send an email")]
        [MaxLength(20, ErrorMessage = "Tender code can be {1} character long")]
        public string TenderCode { get; set; }


        [Required(ErrorMessage = "Email subject is required.")]
        [MaxLength(100, ErrorMessage = "Subject can be {1} characters long")]
        public string Subject { get; set; }


        [Required(ErrorMessage = "Email body is required.")]
        public string Body { get; set; }
    }

    public class ReplyEmailDto: SendEmailDto
    {

        [Required(ErrorMessage = "Parent email id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid parent email id")]
        public long EmailId { get; set; }
    }


    public class EmailResponseDto
    {
        public long EmailId { get; set; }
        public long SenderUserId { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsRead { get; set; }

        public DateTime SentDate { get; set; }
        public string AuthorName { get; set; }

        public string TenderCode { get; set; }

        public bool IsPostAuctionEmail { get; set; }

    }

    public class TechnicalSupportEmailResponseDto
    {
        public long SupportId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime DateCreated { get; set; }
        public bool CanReply { get; set; }
        public long? SenderId { get; set; }
    }
}
