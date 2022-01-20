using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_membership")]
    public class MembershipTypeEntity: BaseEntity
    {
       
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MembershipId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(300)]
        public string MembershipTitle { get; set; }

        [Range(1, int.MaxValue)]
        public int Duration { get; set; }


        [Column(TypeName = "VARCHAR")]
        [MaxLength(10)]
        public string DurationType { get; set; }



        public float MembershipFee { get; set; }


        public float Discount { get; set; }

        [ForeignKey("Status")]
        public int StatusId { get; set; }

        public CommonStatus Status { get; set; }
    }
}
