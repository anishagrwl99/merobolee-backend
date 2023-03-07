using System;
using System.Collections.Generic;

namespace MeroBolee.Dto
{
    public class PostBidApprovalListDto
    {

        public int StatusId { get; set; }
        public long CompanyId { get; set; }


        public string CompanyName { get; set; }

        public List<Remarks> Remarks { get; set; }
    }

    public class PostBidDetail
    {
        public string Remarks { get; set; }
        public string Status { get; set; }

        public IEnumerable<PostBidApprovalListDto> postBidApprovalListDtos { get; set; }
    }

    public class Remarks
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
