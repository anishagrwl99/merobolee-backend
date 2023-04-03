using System.ComponentModel.DataAnnotations;

namespace MeroBolee.Dto
{
    public class AddWatchList
    {
        
        [Required(ErrorMessage = "User id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid user id")]
        public long UserId { get; set; }


        [Required(ErrorMessage = "Tender id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid tender id")]
        public long TenderId { get; set; }



        [Required(ErrorMessage = "Company id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid company id")]
        public long CompanyId { get; set; }
    }
}
