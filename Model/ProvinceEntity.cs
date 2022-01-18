using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_province")]
    public class ProvinceEntity : BaseEntity
    {
        private int province_Id;
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get => province_Id; set => province_Id = value;}

        private string province;
        [Column("Name")]
        public string Name { get => province; set => province = value; }

        private int? country_Id;
        [ForeignKey("Country")]
        [Column("CountryId")]
        public int? CountryId { get => country_Id; set => country_Id = value; }

        private CountryEntity country;
        public CountryEntity Country { get => country; set => country = value; }
    }
}
