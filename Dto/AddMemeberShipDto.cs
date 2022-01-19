using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddMemeberShipDto
    {
      
        [Required(ErrorMessage = "Membership name is required")]
        [MaxLength(150, ErrorMessage = "Membership name can be {1} character long")]
        public string MembershipTitle { get; set; }

        [Required(ErrorMessage = "Membership duration is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid membership duration")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Membership duration type is required")]
        [MaxLength(6, ErrorMessage = "Membership duration type can be {1} character long")]
        public string DurationType { get; set; }

        [Required(ErrorMessage = "Membership fee is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Invalid membership fee")]
        public float Membershipfee { get; set; }

        [Required(ErrorMessage = "Membership discount is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Invalid membership discout")]
        public float Discount { get; set; }

        [Required(ErrorMessage = "Membership status type is required")]
        public int StatusId { get; set; }
    }
}
