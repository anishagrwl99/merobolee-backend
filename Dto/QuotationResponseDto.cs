namespace MeroBolee.Dto
{
    public class QuotationResponseDto
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Units { get; set; }
        public decimal Quotation { get; set; }

        public string Remarks { get; set; }
    }
}