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
        [Column("province_id")]
        public int Province_Id { get => province_Id; set => province_Id = value;}

        private string province;
        [Column("province_title")]
        public string Province_Title { get => province; set => province = value; }

        private int? country_Id;
        [ForeignKey("Country")]
        [Column("country_id")]
        public int? Country_Id { get => country_Id; set => country_Id = value; }

        private CountryEntity country;
        public CountryEntity Country { get => country; set => country = value; }
    }
}
