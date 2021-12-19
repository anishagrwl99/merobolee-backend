using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class TenderCardFeedbackDto
    {

        [Required(ErrorMessage = "Company id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid company id")]
        public long CompanyId { get; set; }


        [Required(ErrorMessage = "User id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid user id")]
        public long UserId { get; set; }


        [Required(ErrorMessage = "Tender id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid tender id")]
        public long TenderId { get; set; }


        [Required(ErrorMessage = "Feedback is required")]
        [MaxLength(1500, ErrorMessage = "Feedback can be {1} character long")]
        public string Feedback { get; set; }
    }

    public class TenderCardFeedbackResponseDto: TenderCardFeedbackDto
    {
        public string SenderName { get; set; }
        public string SenderCompany { get; set; }
    }
}
