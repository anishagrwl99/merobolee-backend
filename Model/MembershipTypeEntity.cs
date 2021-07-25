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
        private int membership_Id;
        private string membership_Title;
        private int duration;
        private string duration_Type;
        private float membership_fee;
        private float discount;
        private int status_Id;
        private PublishStatus status;
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("membership_id")]
        public int Membership_Id { get => membership_Id; set => membership_Id = value; }
        [Column("title")]
        public string Membership_Title { get => membership_Title; set => membership_Title = value; }
        [Column("duration")]
        public int Duration { get => duration; set => duration = value; }
        [Column("duration_type")]
        public string Duration_Type { get => duration_Type; set => duration_Type = value; }
        [Column("membership_fee")]
        public float Membership_fee { get => membership_fee; set => membership_fee = value; }
        [Column("discount")]
        public float Discount { get => discount; set => discount = value; }
        [Column("status")]
        [ForeignKey("Status")]
        public int Status_Id { get => status_Id; set => status_Id = value; }
        public PublishStatus Status { get => status; set => status = value; }
    }
}
