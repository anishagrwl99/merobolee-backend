using System.ComponentModel.DataAnnotations;

namespace MeroBolee.Dto
{
    public class SuperSeedDto
    {
        [Required(ErrorMessage = "Status is required")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "Tender id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid tender id")]
        public long TenderId { get; set; }

        [Required(ErrorMessage = "User id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid user id")]
        public long UserId { get; set; }
        
        [Required(ErrorMessage = "User id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid user id")]
        public long CompanyId { get; set; }

        public string Remarks { get; set; }
    }
}
