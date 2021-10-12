using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeroBolee.Model
{
    [Table("mb_callaction_email")]
    public class CallActionEmailEntity
    {
        public long Id { get; set; }

        [ForeignKey("ParentEmail")]
        public long? ParentId { get; set; }

        [ForeignKey("FromUserEntity")]
        public long FromUserId { get; set; }

        [ForeignKey("ToUserEntity")]
        public long ToUserId { get; set; }

        public string Subject { get; set; }
        public string MailBody { get; set; }
        public bool IsRead { get; set; }
        public string Attachments { get; set; }
        public DateTime EmailSentOn { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual UserEntity FromUserEntity { get; set; }
        public virtual UserEntity ToUserEntity { get; set; }

        public virtual List<CallActionEmailEntity> Responses { get; set; }
        public virtual CallActionEmailEntity ParentEmail { get; set; }

    }
}
