using System;

namespace MeroBolee.Dto
{
    public class ClarificationRequestDto
    {
        public int SenderId { get; set; }
        public int CorrespondenceId { get; set; }
        public string Subject { get; set; }
        public string EmailBody { get; set; }
        public DateTime EmailSentDateTime { get; set; }
    }


    public class ClarificationRequestResponseDto
    {
        public string Subject { get; set; }
        public int MailId { get; set; }
        public DateTime SentDate { get; set; }
    }

    public class ClarificationResponseDto
    {
        public int Id { get; set; }
        public bool IsRead { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SentOn { get; set; }
        public string SenderName { get; set; }
        public int CorrespondenceId { get; set; }
    }
}
