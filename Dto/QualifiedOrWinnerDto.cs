using System.ComponentModel.DataAnnotations;

namespace MeroBolee.Dto
{
    public class QualifiedOrWinnerDto
    {
        [Required(ErrorMessage = "Company id is required")]
        public string CompanyId { get; set; }

        [Required(ErrorMessage = "Tender id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid tender id")]
        public long TenderId { get; set; }
        public string  Rank { get; set; }
    }
}
