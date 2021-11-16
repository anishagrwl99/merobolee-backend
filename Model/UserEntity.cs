using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
        [Column("user_id")]
        public long User_Id { get => user_Id; set => user_Id = value; }

        [Column("user_code")]        
        public Guid User_Code { get => user_Code; set => user_Code = value; }


        [Column("role_id")]
        [ForeignKey("Role")]
        public int? Role_Id { get => role_Id; set => role_Id = value; }


        public bool IsEmailReceiver
        {
            get { return _isEmailReceiver; }
            set { _isEmailReceiver = value; }
        }


        [Column("first_name")]
        public string First_Name { get => first_Name; set => first_Name = value; }

        [Column("middle_name")]
        
        public string Middle_Name { get => middle_Name; set => middle_Name = value; }

        [Column("last_name")]
        public string Last_Name { get => last_Name; set => last_Name = value; }

        [Column("designation")]
        public string Designation { get => designation; set => designation = value; }


        [Column("email")]
        public string Person_email { get => person_email; set => person_email = value; }

        [Column("username")]
        public string Username { get => username; set => username = value; }

        [Column("password")]
        public string Password { get => password; set => password = value; }

        [Column("activate_date")]
        public DateTime? Activate_Date { get => activate_Date; set => activate_Date = value; }

        [Column("expired_date")]
        public DateTime? Expried_Date { get => expried_Date; set => expried_Date = value; }


        [Column("status_id")]
        [ForeignKey("UserStatus")]
        public int? Status_id { get => status_id; set => status_id = value; }


        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string ProfilePicture { get; set; }


        [NotMapped]
        public string Company_Name { get; set; }


        public virtual UserStatusEntity UserStatus { get => userStatus; set => userStatus = value; }

        public virtual RoleEntity Role { get => role; set => role = value; }

    }
}
