using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_company")]
    public class CompanyEntity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CompanyId { get; set; }

 
        public string Name { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        [ForeignKey("Province")]
        public int ProvinceId { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }

        public string Zip { get; set; }

        [JsonIgnore]
        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string RegisteredAs { get; set; }

        [JsonIgnore]
        [MaxLength(25)]
        [Column(TypeName = "VARCHAR")]
        public string ReferenceCode { get; set; }


        [MaxLength(150)]
        public string ContactPerson { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        public string CompanyEmail { get; set; }

        [Url]
        [MaxLength(100)]
        public string CompanyWebsite { get; set; }

        [MaxLength(15)]
        public string Phone1 { get; set; }

        [MaxLength(15)]
        public string Phone2 { get; set; }

        [ForeignKey("MembershipType")]
        public int MembershipTypeId { get; set; }


        public virtual CountryEntity Country { get; set; }
        public virtual ProvinceEntity Province { get; set; }
        public virtual MembershipTypeEntity MembershipType { get; set; }

    }
}
