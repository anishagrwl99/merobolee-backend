using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MeroBolee.Model
{
    [Table("mb_payment_details")]
    public class PaymentDetailEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TxnId { get; set; }
        public long TxnAmt { get; set; }
        public DateTime TxnDate { get; set; }
        public string TxnSts { get; set; }
        public long TenderId { get; set; }
        public long UserId { get; set; }
        public long CompanyId { get; set; }
        public string PaymentChanel { get; set; }
    }
}