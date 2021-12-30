using MeroBolee.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{

    public class BidWinnerRequestDto
    {
        [Required(ErrorMessage = "Company id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid company id")]
        public long CompanyId { get; set; }

        [Required(ErrorMessage = "Tender id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid tender id")]
        public long TenderId { get; set; }
    }
    public class BidUpdateRequestDto
    {

        [Required(ErrorMessage = "Bid request id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid bid request id")]
        public long BidId { get; set; }

        [Required(ErrorMessage = "Company id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid company id")]
        public long CompanyId { get; set; }

        [Required(ErrorMessage = "Tender id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid tender id")]
        public long TenderId { get; set; }

        [Required(ErrorMessage = "Status id is required")]
        [Range(1, byte.MaxValue, ErrorMessage = "Invalid company id")]
        public int StatusId { get; set; }


        public string Remark { get; set; }
    }


    public class AuctionLogRequestDto
    {

        [Required(ErrorMessage = "Company number is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid company number")]
        public long CompanyId { get; set; }

        [Required(ErrorMessage = "Tender number is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid tender number")]
        public long TenderId { get; set; }
    }
}
