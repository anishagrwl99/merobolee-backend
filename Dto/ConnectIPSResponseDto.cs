namespace MeroBolee.Dto
{
    public class ConnectIPSResponseDto
    {
        public string TxnId { get; set; }
        public string TxnCurrency { get; set; }
        public long TxnAmount { get; set; }
        public string TxnTime { get; set; }

        public string Remarks { get; set; }

        public string Particulars { get; set; }

        public string Token { get; set; }
        public string ReferenceId { get; set; }

        public string MerchantId { get; set; }
        public string AppName { get; set; }

        public string AppId { get; set; }
    }
}