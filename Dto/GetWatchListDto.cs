namespace MeroBolee.Dto
{
    public class GetWatchListDto
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public long CompanyId { get; set; }

        public TenderWatchlistDto Tender_Detail { get; set; }
    }
}
