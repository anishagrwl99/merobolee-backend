using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeroBolee.Dto
{
    public class GraphRequestDto
    {
        [Required(ErrorMessage = "Company id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid company id")]
        public long CompanyId { get; set; }

        [Required(ErrorMessage = "User id is required")]
        [Range (1, long.MaxValue, ErrorMessage = "Invalid user id")]
        public long UserId { get; set; }
    }



    public class SupplierGraphDto
    {
        public List<GraphPoint>  RegisteredByCategory { get; set; }
        public List<GraphPoint>  RegisteredByMonth { get; set; }
        public List<GraphPoint>  WonByCategory { get; set; }
        public List<GraphPoint>  WonByMonth { get; set; }
    }

    public class BidInviterGraphDto
    {
        public List<GraphPoint> Invited { get; set; }
        public List<GraphPoint> Pending { get; set; }
        public List<GraphPoint> Completed { get; set; }
    }


    public class GraphPoint
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
