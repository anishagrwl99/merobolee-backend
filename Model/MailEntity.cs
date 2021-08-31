using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_mail_data")]
    public class MailEntity : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("mail_id")]
        public int Mail_id { get; set; }

        [Column("from_email")]
        public string FromEmail { get; set; }

        [Column("cc")]
        public string CC { get; set; }

        [Column("Bcc")]
        public string Bcc { get; set;}

        [Column("to_email")]
        public string ToEmail { get; set; }

        [Column("subject")]
        public string Subject { get; set; }

        [Column("body")]
        public string Body { get; set; }

        public ICollection<MailAttachmentEntity> Attachments { get; set; }
    }
}
