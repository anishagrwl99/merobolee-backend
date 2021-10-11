using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_favourite")]
    public class FavouriteCategoryEntity
    {
        private int id;
        private long user_id;
        private int category_id;
        private UserEntity user;
        private CategoryEntity category;
        [Column("id")]
        public int Id { get => id; set => id = value; }

        [Column("user_id")]
        [ForeignKey("User")]
        public long User_id { get => user_id; set => user_id = value; }

        [Column("category_id")]
        [ForeignKey("Category")]
        public int Category_id { get => category_id; set => category_id = value; }
        public UserEntity User { get => user; set => user = value; }
        public CategoryEntity Category { get => category; set => category = value; }
    }
}
