using System.ComponentModel.DataAnnotations;

namespace MeroBolee.Dto
{
    public class OtpDto
    {
        public long UserId { get; set; }
        public long companyId { get; set; }
        public string EmailId { get; set; }
    }

   
}
