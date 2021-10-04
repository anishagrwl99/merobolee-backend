using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{

    public class DocumentUpdateStatusDto
    {
        public int UserId { get; set; }
        public long DocumentId { get; set; }
        public int StatusId { get; set; }
        public string Remarks { get; set; }
    }
    public class DocumentDto
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int DocumentTypeId { get; set; }
        public IFormFile Document { get; set; }
    }

    public class DocumentResponseDto
    {
        public string UploadedBy { get; set; }
        public string StatusChangedBy {get; set;}
        public string DocumentStatus { get; set; }
        public int DocumentStatusId { get; set; }
        public string DocumentPath { get; set; }
        public string DocumentType { get; set; }
        public int DocumentTypeId { get; set; }
        public string Remarks { get; set; }
    }
}
