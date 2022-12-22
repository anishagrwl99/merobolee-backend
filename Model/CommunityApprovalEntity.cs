using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MeroBolee.Model
{
    [Table("mb_tender_community_approval")]
    public class CommunityApprovalEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public int CompanyId { get; set; }
        public DateTime Date_Created { get; set; }
        public DateTime Date_Modified { get; set; }
        public bool IsDeleted { get; set; }
    }
}