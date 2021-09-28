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
        public int UserId { get; set; }
        public int TenderId { get; set; }

        public string MailBody { get; set; }
        public string[] Attachments { get; set; }
    }
}
