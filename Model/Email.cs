using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Model
{


    /// <summary>
    /// Email sentbox for sender
    /// </summary>
    
    [Table("mb_email")]
    public class EmailEntity : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("Tender")]
        public long TenderId { get; set; }

        [ForeignKey("Company")]
        public long CompanyId { get; set; }


        [Column(TypeName = "VARCHAR(300)")]
        [Required(ErrorMessage = "Email subject is required.")]
        public string Subject { get; set; }


        [Column(TypeName = "VARCHAR(max)")]
        [Required(ErrorMessage = "Email body is required.")]
        public string Body { get; set; }


        /// <summary>
        /// Email sender Id
        /// </summary>
        [ForeignKey("User")]
        public long AuthorId { get; set; }


        public bool IsDraft { get; set; }


        [NotMapped]
        public string TenderCode { get; set; }

        [JsonIgnore]
        public virtual UserEntity User { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserEmailEntity> UserEmails { get; set; }

        [JsonIgnore]
        public virtual TenderEntity Tender { get; set; }

        [JsonIgnore]
        public virtual CompanyEntity Company { get; set; }
    }


    /// <summary>
    /// Email inbox for receiver
    /// </summary>
    
    [Table("mb_user_email")]
    public class UserEmailEntity : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }


        /// <summary>
        /// Email receiver id
        /// </summary>
        [ForeignKey("User")]
        public long UserId { get; set; }





        /// <summary>
        /// Email Id
        /// </summary>
        [ForeignKey("Email")]
        public long EmailId { get; set; }
        public bool IsRead { get; set; }

        [JsonIgnore]
        public virtual UserEntity User { get; set; }

        [JsonIgnore]
        public virtual EmailEntity Email { get; set; }


    }

}
