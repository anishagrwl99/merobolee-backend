using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_user")]
    public class UserEntity : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        
        public Guid Code { get; set; }


        [ForeignKey("Role")]
        public int? RoleId { get; set; }


        public bool IsEmailReceiver { get; set; }


        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string MiddleName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string Designation { get; set; }


        [Column(TypeName = "VARCHAR")]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string Username { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(5000)]
        public string Password { get; set; }

        
        public DateTime? ActivateDate { get; set; }

        public DateTime? ExpriedDate { get; set; }


        [ForeignKey("UserStatus")]
        public int? StatusId { get; set; }


        [Column(TypeName = "VARCHAR")]
        [MaxLength(1500)]
        public string ProfilePicture { get; set; }


        [NotMapped]
        [JsonIgnore]
        public string CompanyName { get; set; }


        public virtual UserStatusEntity UserStatus { get; set; }

        public virtual RoleEntity Role { get; set; }

    }
}
