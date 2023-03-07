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
        public List<GraphPoint> PendingByCategory { get; set; }
        public List<GraphPoint> CompletedByCategory { get; set; }

        public List<GraphPoint> PendingByMonth { get; set; }
        public List<GraphPoint> CompletedByMonth { get; set; }
    }


    public class GraphPoint
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class GraphDataDto
    {
        public long TotalBudget { get; set; }
        public List<GraphData> graphDatas { get; set; }
    }
    public class GraphData
    {
        public long allocatedBudget { get; set; }
        public long fundsUsed { get; set; }
        public long fundsRemaining { get; set; }
    }
}
