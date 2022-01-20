using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_watchlist")]
    public class WatchListEntity
    {

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }


        [ForeignKey("UserEntity")]       
        public long UserId { get; set; }



        [ForeignKey("TenderEntity")]
        public long TenderId { get; set; }


        [ForeignKey("CompanyEntity")]
        public long CompanyId { get; set; }



        [JsonIgnore]
        public TenderEntity TenderEntity { get; set; }


        [JsonIgnore]
        public CompanyEntity CompanyEntity { get; set; }



        [JsonIgnore]
        public UserEntity UserEntity { get; set; }

    }
}
