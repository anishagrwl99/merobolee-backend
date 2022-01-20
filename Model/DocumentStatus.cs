using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Model
{

    [Table("lk_document_status")]
    public class DocumentStatusEntity
    {
        public int Id { get; set; }

        
        [Required(ErrorMessage = "Document status is required")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        public string Status { get; set; }


    }


    [Table("mb_document_type")]
    public class DocumentTypeEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set;}


        [Required(ErrorMessage = "Document status is required")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        public string TypeName { get; set; }

        [JsonIgnore]
        public virtual ICollection<CompanyDocumentEntity> CompanyDocuments { get; set; }
    }

    [Table("mb_company_document")]
    public class CompanyDocumentEntity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }


        [ForeignKey("Company")]
        public long CompanyID { get; set; }


        [ForeignKey("UploadUserEntity")]
        public long UploadedBy { get; set; }


        [ForeignKey("StatusChangedUserEntity")]
        public long? StatusChangedBy { get; set; }


        [ForeignKey("DocumentType")]
        public int DocumentTypeyId { get; set; }

        [ForeignKey("DocumentStatus")]
        public int DocumentStatusId { get; set; }


        [Column(TypeName = "VARCHAR")]
        [MaxLength(300)]
        public string DocumentPath { get; set; }


        [Column(TypeName = "VARCHAR")]
        [MaxLength(500)]
        public string Remarks { get; set; }

        public virtual UserEntity UploadUserEntity { get; set; }
        public virtual UserEntity StatusChangedUserEntity { get; set; }
        public virtual CompanyEntity Company { get; set; }
        public virtual DocumentTypeEntity DocumentType { get; set; }
        public virtual DocumentStatusEntity DocumentStatus { get; set; }

    }
}
