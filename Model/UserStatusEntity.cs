using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("lk_user_status")]
    public class UserStatusEntity
    {
        private int status_Id;
        private string status;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get => status_Id; set => status_Id = value; }


        [Column("Status")]
        public string Status { get => status; set => status = value; }

    }
}
