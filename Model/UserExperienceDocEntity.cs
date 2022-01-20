using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_experience_doc")]
    public class UserExperienceDocEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }


        [Column(TypeName = "VARCHAR")]
        [MaxLength(1500)]
        public string ExperiencedDoc { get; set; }


        [ForeignKey("User")]
        public long UserId { get; set; }


        [JsonIgnore]
        public UserEntity User { get; set; }

    }
}
