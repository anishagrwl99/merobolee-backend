using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_role")]
    public class RoleEntity: BaseEntity
    {
            private int role_Id;
            [Column("role_id")]
            [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Role_Id { get => role_Id; set => role_Id = value; }

            private string role_Name;
            [Column("role")]
            public string Role_Name { get => role_Name; set => role_Name = value; }
    }
}
