using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_favourite")]
    public class FavouriteCategoryEntity
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [JsonIgnore]
        public UserEntity User { get; set; }
        [JsonIgnore]
        public CategoryEntity Category { get; set; }
    }
}
