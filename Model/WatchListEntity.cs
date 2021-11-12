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
        private int id;
        private long userId;
        private UserEntity userEntity;
        private long tenderId;
        private long companyId;
        private TenderEntity tenderEntity;
        private CompanyEntity companyEntity;

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get => id; set => id = value; }


        [Column("user_id")]
        [ForeignKey("UserEntity")]       
        public long UserId { get => userId; set => userId = value; }


        [JsonIgnore]
        public UserEntity UserEntity { get => userEntity; set => userEntity = value; }


        [Column("tender_id")]
        [ForeignKey("TenderEntity")]
        public long TenderId { get => tenderId; set => tenderId = value; }


        [Column("company_id")]
        [ForeignKey("CompanyEntity")]
        public long CompanyId { get => companyId; set => companyId = value; }

        [JsonIgnore]
        public TenderEntity TenderEntity { get => tenderEntity; set => tenderEntity = value; }


        [JsonIgnore]
        public CompanyEntity CompanyEntity { get => companyEntity; set => companyEntity = value; }

    }
}
