using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_correspondence_email")]
    public class CorrespondenceEmailEntity
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int SenderUserId { get; set; }

        [ForeignKey("Tender")]
        public int TenderId { get; set; }

        public string Subject { get; set; }

        public string MailBody { get; set; }

        public bool IsRead { get; set; }
        public string Attachments { get; set; }
        public DateTime EmailSentOn { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual UserEntity User{ get; set; }
        public virtual TenderEntity Tender{ get; set; }
    }
}
