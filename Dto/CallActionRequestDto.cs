using System;
using System.Collections.Generic;

namespace MeroBolee.Dto
{
    public class CallActionRequestDto
    {
        public long SenderId { get; set; }
        public long ToUserId { get; set; }
        public long? ParentId { get; set; }
        public string Subject { get; set; }
        public string EmailBody { get; set; }
        public DateTime EmailSentDateTime { get; set; }
    }


    public class CallActionRequestResponseDto
    {
        public string Subject { get; set; }
        public long MailId { get; set; }
        public DateTime SentDate { get; set; }
    }

    public class CallActionResponseDto
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public bool IsRead { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SentOn { get; set; }
        public string SenderName { get; set; }
        public string SupplierCompany { get; set; }

        public List<CallActionResponseDto> Responses { get; set; }
        public CallActionResponseDto Parent { get; set; }
    }
}
