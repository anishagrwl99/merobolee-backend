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
        private int user_Id;
        private UserEntity userEntity;
        private int tender_Id;
        private TenderEntity tenderEntity;

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("user_id")]
        [ForeignKey("UserEntity")]       
        public int User_Id { get => user_Id; set => user_Id = value; }
        [JsonIgnore]
        public UserEntity UserEntity { get => userEntity; set => userEntity = value; }
        [Column("tender_id")]
        [ForeignKey("TenderEntity")]
        public int Tender_Id { get => tender_Id; set => tender_Id = value; }
        [JsonIgnore]
        public TenderEntity TenderEntity { get => tenderEntity; set => tenderEntity = value; }
    }
}
