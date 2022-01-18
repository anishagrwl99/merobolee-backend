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
        private long user_Id;
        private Guid user_Code;
        private int? role_Id;
        private string first_Name;
        private string middle_Name;
        private string last_Name;
        private string designation;
        private string person_email;
        private string username;
        private string password;
        private DateTime? activate_Date;
        private DateTime? expried_Date;
        private int? status_id;
        private UserStatusEntity userStatus;
        private RoleEntity role;
        private bool _isEmailReceiver = true;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public long Id { get => user_Id; set => user_Id = value; }

        [Column("Code")]        
        public Guid Code { get => user_Code; set => user_Code = value; }


        [Column("RoleId")]
        [ForeignKey("Role")]
        public int? RoleId { get => role_Id; set => role_Id = value; }


        public bool IsEmailReceiver
        {
            get { return _isEmailReceiver; }
            set { _isEmailReceiver = value; }
        }


        [Column("FirstName", TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string FirstName { get => first_Name; set => first_Name = value; }

        [Column("MiddleName",  TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string MiddleName { get => middle_Name; set => middle_Name = value; }

        [Column("LastName", TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string LastName { get => last_Name; set => last_Name = value; }

        [Column("Designation")]
        [MaxLength(100)]
        public string Designation { get => designation; set => designation = value; }


        [Column("Email")]
        [MaxLength(100)]
        public string Email { get => person_email; set => person_email = value; }

        [Column("Username")]
        [MaxLength(100)]
        public string Username { get => username; set => username = value; }

        [Column("Password")]
        [MaxLength(250)]
        public string Password { get => password; set => password = value; }

        [Column("ActivateDate")]
        public DateTime? ActivateDate { get => activate_Date; set => activate_Date = value; }

        [Column("ExpriedDate")]
        public DateTime? ExpriedDate { get => expried_Date; set => expried_Date = value; }


        [Column("StatusId")]
        [ForeignKey("UserStatus")]
        public int? StatusId { get => status_id; set => status_id = value; }


        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string ProfilePicture { get; set; }


        [NotMapped]
        [JsonIgnore]
        public string CompanyName { get; set; }


        public virtual UserStatusEntity UserStatus { get => userStatus; set => userStatus = value; }

        public virtual RoleEntity Role { get => role; set => role = value; }

    }
}
