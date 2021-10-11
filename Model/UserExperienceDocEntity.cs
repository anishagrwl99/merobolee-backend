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

        private int id;
        private string experienced_doc;
        private UserEntity user;
        private long user_id;

      
        [Column("experience_doc")]
        public string Experienced_doc { get => experienced_doc; set => experienced_doc = value; }

        [JsonIgnore]
        public UserEntity User { get => user; set => user= value; }

        [Column("user_id")]
        [ForeignKey("User")]
        public long User_id { get => user_id; set => user_id = value; }

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get => id; set => id = value; }
    }
}
