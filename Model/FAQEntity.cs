using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_FAQ")]
    public class FAQEntity : BaseEntity
    {
        private int faq_id;
        private string question;
        private string answer;
        private int status_id;
        private PublishStatus publishStatus;

        [Column("faq_id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FAQ_id { get => faq_id; set => faq_id = value; }
        [Column("question")]
        public string Question { get => question; set => question = value; }
        [Column("answer")]
        public string Answer { get => answer; set => answer = value; }
        [Column("status_id")]
        [ForeignKey("PublishStatus")]
        public int Status_id { get => status_id; set => status_id = value; }
        public PublishStatus PublishStatus { get => publishStatus; set => publishStatus = value; }
    }
}
