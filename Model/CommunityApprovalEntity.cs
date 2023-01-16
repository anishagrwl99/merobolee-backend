using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Newtonsoft.Json;

namespace MeroBolee.Model
{
    [Table("mb_tender_community_approval")]
    public class CommunityApprovalEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("CategoryEntity")]
        public int CategoryId { get; set; }

        [ForeignKey("TenderStatusEntity")]
        public int StatusId { get; set; }
        [ForeignKey("CompanyEntity")]
        public long CompanyId { get; set; }
        public DateTime Date_Created { get; set; }
        public DateTime Date_Modified { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("TenderEntities")]
        public long TenderId { get;  set; }

        [JsonIgnore]
        public virtual TenderEntity TenderEntities { get; set; }
        public virtual CategoryEntity CategoryEntity { get; set; }
        public virtual TenderStatusEntity TenderStatusEntity { get; set; }
        public virtual CompanyEntity CompanyEntity { get; set; }


    }
}