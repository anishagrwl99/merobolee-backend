using System;

namespace MeroBolee.Dto
{
    public class TenderWatchlistDto
    {


        public long TenderId { get; set; }
        public string TenderCode { get; set; }
        public string TenderTitle { get; set; }
        public long CategoryId { get; set; }
        public WatchCategoryDto Category { get; set; }
        public string TenderDescription { get; set; }

        public DateTime LiveStartDate { get; set; }
        public DateTime LiveEndDate { get; set; }
        public int TenderDuration { get; set; }
        public string DurationType { get; set; }
        public DateTime? PublishDate { get; set; }
        public int StatusId { get; set; }
    }
}
