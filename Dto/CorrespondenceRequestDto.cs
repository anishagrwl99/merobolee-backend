using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{

    public class CorrespondenceRequestDto
    {
        public int SenderId { get; set; }
        public int TenderId { get; set; }
        public string Subject { get; set; }
        public string EmailBody { get; set; }
        public DateTime EmailSentDateTime { get; set; }
    }

    public class CorrespondenceRequestResponseDto
    {
        public string Subject { get; set; }
        public int MailId { get; set; }
        public DateTime SentDate { get; set; }
    }

    public class CorrespondenceResponseDto
    {
        public int Id { get; set; }
        public bool IsRead { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SentOn { get; set; }
        public string SupplierName { get; set; }
        public string SupplierCompany { get; set; }
        public long TenderId { get; set; }
    }
}
