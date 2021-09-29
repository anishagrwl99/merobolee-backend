using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeroBolee.Model
{
    [Table("mb_clarification_email")]
    public class ClarificationEmailEntity
    {
        public int Id { get; set; }

        [ForeignKey("UserEntity")]
        public int SenderUserId { get; set; }

        [ForeignKey("CorrespondenceEmailEntity")]
        public int CorrespondenceId { get; set; }
        public string Subject { get; set; }
        public string MailBody { get; set; }
        public bool IsRead { get; set; }
        public string Attachments { get; set; }
        public DateTime EmailSentOn { get; set; }
        public DateTime DateCreated { get; set; }


        public virtual CorrespondenceEmailEntity CorrespondenceEmailEntity { get; set; }
        public virtual UserEntity UserEntity { get; set; }

    }
}
