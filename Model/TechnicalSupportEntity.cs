using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_TechnicalSupport")]
    public class TechnicalSupportEntity: BaseEntity
    {
       

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public long Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(150)]
        public string Name { get; set; }


        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Column("Title")]
        [MaxLength (250)]
        public string Title { get; set; }

        [Column("Description")]
        public string Description { get; set; }

      
        [Column("UserId")]
        [ForeignKey ("UserEntity")]
        public long? UserId { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string PhoneNo { get; set; }

        [JsonIgnore]
        public UserEntity UserEntity { get; set; }

        [JsonIgnore]
        public ICollection<TechnicalSupportReceiver> Receivers { get; set; }

    }


    [Table("mb_TechnicalSupport_Receiver")]
    public class TechnicalSupportReceiver
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }


        /// <summary>
        /// Email receiver id
        /// </summary>
        [ForeignKey("User")]
        public long UserId { get; set; }


        /// <summary>
        /// Email Id
        /// </summary>
        [ForeignKey("TechnicalSupport")]
        public long TechnicalSupportId { get; set; }

        public bool IsRead { get; set; }


        [JsonIgnore]
        public virtual UserEntity User { get; set; }

        [JsonIgnore]
        public virtual TechnicalSupportEntity TechnicalSupport { get; set; }

    }
}
