
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MeroBolee.Model
{
    [Table("lk_common_status")]
    public class CommonStatus
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity) ]
        public int Id { get; set; }


        [Column (TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string Status { get; set; }
    }
}
