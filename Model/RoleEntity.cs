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
            [Column("Id")]
            [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get => role_Id; set => role_Id = value; }

            private string role_Name;
            [Column("Name")]
            public string Name { get => role_Name; set => role_Name = value; }
    }
}
