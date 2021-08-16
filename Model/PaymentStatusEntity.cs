using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeroBolee.Model
{
    [Table("mb_payment_status")]
    public class PaymentStatusEntity
    {
        private int id;
        private string payment_status;

        [Column("id")]
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get => id; set => id = value; }

        [Column("payment_status")]
        public string Payment_status { get => payment_status; set => payment_status = value; }
    }
}