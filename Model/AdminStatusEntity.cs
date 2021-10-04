using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_admin_status")]
    public class AdminStatusEntity
    {
        private int status_Id;
        private string status;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("status_id")]
        public int Status_Id { get => status_Id; set => status_Id = value; }

        [Column("admin_status")]
        public string Status { get => status; set => status = value; }

        public virtual ICollection<CompanyDocumentEntity> CompanyDocuments { get; set; }

    }

 
}
