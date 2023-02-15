using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class TenderApproveDto
    {
        [Required(ErrorMessage = "Tender id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid tender id")]
        public long TenderId { get; set; }

        [Required(ErrorMessage = "Company id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid company id")]
        public long CompanyId { get; set; }

        [Required(ErrorMessage = "Approve user id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid approve user id")]
        public long UserId { get; set; }
    }

    public class TenderApproveDtoByAdmin : TenderApproveDto
    {
        public bool status { get; set; }
    }

    public class PostBidApproveDDtoByBidInviter : TenderApproveDto
    {
        public string Remarks { get; set; }

    }

    public class GenerateNewRequestDtoByAdmin : PostBidApproveDDtoByBidInviter
    {
        public long BidInviterId { get; set; }

    }

    public class VerifyOtpDto : TenderApproveDto
    {
        public string OtpCode { get; set; }

    }
}
