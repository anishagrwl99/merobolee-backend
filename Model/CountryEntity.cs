  using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_country")]
    public class CountryEntity : BaseEntity
    {
        private int country_Id;
        [Column("Id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity) ]
        public int Id { get => country_Id; set => country_Id = value; }

        private string country_Name;
        [Column("Name")]
        public string Name { get => country_Name; set => country_Name = value; }
        
        private string country_Code;
        [Column("Code")]
        public string Code { get => country_Code; set => country_Code = value; }

        private string abbre;
        [Column("abbre")]
        public string Abbre { get => abbre; set => abbre = value; }

    }
}
