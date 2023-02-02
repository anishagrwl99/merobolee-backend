namespace MeroBolee.Settings
{
    public class PaymentValues
    {
        public string MerchantId { get; set; }
        public string AppId { get; set; }
        public string AppName { get; set; }
        public string PfxPath { get; set; }
        public string BasicUsername { get; set; }
        public string BasicPassword  {get;set;}
        public string ContentType { get; set; }
        public string ValidateTxnUrl { get; set; }
        public string GetTxnDetailsUrl {get;set;}
    }
}