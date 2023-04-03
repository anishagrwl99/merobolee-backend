namespace MeroBolee.Dto
{
    public class NhclValidateTxnReq
    {
        public string merchantId { get; set; }
        public string appId { get; set; }
        public string referenceId { get; set; }
        public string txnAmt { get; set; }
        public string token { get; set; }
    }
}