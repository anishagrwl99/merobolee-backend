using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Model
{

    [Table("mb_document_status")]
    public class DocumentStatusEntity
    {

        private int _id;
        private string status;


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        

        [Required(ErrorMessage = "Document status is required")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }


    }


    [Table("mb_document_type")]
    public class DocumentTypeEntity
    {
        private int _id;
        private string typeName;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }

        [JsonIgnore]
        public virtual ICollection<CompanyDocumentEntity> CompanyDocuments { get; set; }
    }

    [Table("mb_company_document")]
    public class CompanyDocumentEntity
    {
        private long _id;
        private long _companyId;
        private long _userId;
        private int _documentStatusId;
        private int _docCategoryId;
        private long? _statusChangedBy;
        private string _documentPath;
        private string _remarks;


        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }


        [ForeignKey("Company")]
        public long CompanyID
        {
            get { return _companyId; }
            set { _companyId = value; }
        }

       
        [ForeignKey("UploadUserEntity")]
        public long UploadedBy
        {
            get { return _userId; }
            set { _userId = value; }
        }


        [ForeignKey("StatusChangedUserEntity")]
        public long? StatusChangedBy
        {
            get { return _statusChangedBy; }
            set { _statusChangedBy = value; }
        }


        [ForeignKey("DocumentType")]
        public int DocumentTypeyId
        {
            get { return _docCategoryId; }
            set { _docCategoryId = value; }
        }

        [ForeignKey("DocumentStatus")]
        public int DocumentStatusId
        {
            get { return _documentStatusId; }
            set { _documentStatusId = value; }
        }


        [Column("DocumentPath", TypeName = "VARCHAR")]
        [MaxLength(300)]
        public string DocumentPath
        {
            get { return _documentPath; }
            set { _documentPath = value; }
        }


        [Column("Remarks", TypeName = "VARCHAR")]
        [MaxLength(500)]
        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        public virtual UserEntity UploadUserEntity { get; set; }
        public virtual UserEntity StatusChangedUserEntity { get; set; }
        public virtual CompanyEntity Company { get; set; }
        public virtual DocumentTypeEntity DocumentType { get; set; }
        public virtual DocumentStatusEntity DocumentStatus { get; set; }

    }
}
