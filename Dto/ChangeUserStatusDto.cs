using System.ComponentModel.DataAnnotations;

namespace MeroBolee.Dto
{
    public class ChangeUserStatusDto
    {
        [Required(ErrorMessage = "User id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid user id")]
        public long UserId { get; set; }

        [Required(ErrorMessage = "Status id is required")]
        [Range(1, byte.MaxValue, ErrorMessage = "Invalid status id")]
        public int StatusId { get; set; }

        [Required(ErrorMessage = "Request sender user id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid request sender user id")]
        public long StatusChangedBy { get; set; }
    }
}
