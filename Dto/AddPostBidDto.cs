using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeroBolee.Dto
{
    public class AddPostBidDto
    {
        [Required(ErrorMessage = "Tender id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid tender id")]
        public long TenderId { get; set; }

        [Required(ErrorMessage = "Company id is required")]
        public List<long>  CompanyIds { get; set; }

        [Required(ErrorMessage = "User id is required")]
        public List<long>  UserIds { get; set; }
    }

    public class PostBidDtoList
    {
        public long TenderId { get; set; }

        public string TenderTitle { get; set; }
        public string Status { get; set; }
        public int StatusId { get; set; }

        public int RemarksStatusId { get; set; }
    }
}
