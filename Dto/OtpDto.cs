namespace MeroBolee.Dto
{
    public class OtpDto
    {
        public long UserId { get; set; }
        
    }

    public class OtpVerifyDto : OtpDto
    {
        public string Input { get; set; }

    }
}
