using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MeroBolee.Dto
{

    public class DocumentUpdateStatusDto
    {

        [Required(ErrorMessage = "User id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid user id")]
        public int UserId { get; set; }


        [Required(ErrorMessage = "Document id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid document id")]
        public long DocumentId { get; set; }


        [Required(ErrorMessage = "Status id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid status id")]
        public int StatusId { get; set; }



        [MaxLength(500, ErrorMessage = "Remarks can be {1} character long")]
        public string Remarks { get; set; }
    }



    public class DocumentDto
    {

        [Required(ErrorMessage = "User id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid user id")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Company id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid company id")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Document type id is required")]
        [Range(1, byte.MaxValue, ErrorMessage = "Invalid document type id")]
        public int DocumentTypeId { get; set; }


        [Required(ErrorMessage = "Document is required")]
        public IFormFile Document { get; set; }
    }

    public class DocumentResponseDto
    {
        public long DocumentId { get; set; }
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
