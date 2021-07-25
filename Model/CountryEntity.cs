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
        [Column("country_id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity) ]
        public int Country_Id { get => country_Id; set => country_Id = value; }

        private string country_Name;
        [Column("country_name")]
        public string Country_Name { get => country_Name; set => country_Name = value; }
        
        private string country_Code;
        [Column("country_code")]
        public string Country_Code { get => country_Code; set => country_Code = value; }

        private string abbre;
        [Column("abbre")]
        public string Abbre { get => abbre; set => abbre = value; }

    }
}
