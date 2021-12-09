using MeroBolee.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class UpdateRequestDto
    {
        private int statusId;
        private string remark;

        public int StatusId { get => statusId; set => statusId = value; }
        public string Remark { get => remark; set => remark = value; }
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
