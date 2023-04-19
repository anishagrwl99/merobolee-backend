using MeroBolee.Attribute;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ganss.Xss;

namespace MeroBolee.Dto
{
    public class TenderRequestBaseDto
    {
        private string _location;
        private string _qualityRequest;
        private string _eligibilityCriteria;
        private string _performanceRequest;
        private string _additionalRequest;


        public String companyIds { get; set; }

        public int superId { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid category name")]
        public long CategoryId { get; set; }


        [Required(ErrorMessage = "Tender title is required")]
        [MaxLength(500, ErrorMessage = "Tender title can be {1} character long")]
        public string TenderTitle { get; set; }

        [Required(ErrorMessage = "Tender time interval is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid time interval value")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Time interval should be numeric only")]
        public int TimeInterval { get; set; }

        [Required(ErrorMessage = "Date till supplier registration allowed is required")]
        [DateLessThan("LiveStartDate")]
        [ShouldBeFutureDate]
        public DateTime RegistrationTill { get; set; }

        [Required(ErrorMessage = "Tender live start date is required")]
        [DateLessThan("LiveEndDate")]
        [ShouldBeFutureDate]
        public DateTime LiveStartDate { get; set; }

        [Required(ErrorMessage = "Tender live end date is required")]
        [DateGreaterThan("LiveStartDate")]
        [ShouldBeFutureDate]
        public DateTime LiveEndDate { get; set; }

        [Required(ErrorMessage = "Tender created by is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid user")]
        public long CreatedBy { get; set; }

        public bool IsDeleted { get; set; }

        [MaxLength(500, ErrorMessage = "Product can be {1} character long")]
        public string Product { get; set; }
        [Required(ErrorMessage = "Date Of Execution is required")]
        public DateTime DateOfExecution { get; set; }
        public string Location 
        {
            get => _location;
            set => _location = new HtmlSanitizer().Sanitize(value);
        }

        
        public string QualityRequest
        {
            get => _qualityRequest;
            set => _qualityRequest = new HtmlSanitizer().Sanitize(value);
        }
        public string PerformanceRequest
        {
            get => _performanceRequest;
            set => _performanceRequest = new HtmlSanitizer().Sanitize(value);
        }


        public string EligibilityCriteria
        {
            get => _eligibilityCriteria;
            set => _eligibilityCriteria = new HtmlSanitizer().Sanitize(value);
        }

        public string AdditionalRequest
        {
            get => _additionalRequest;
            set => _additionalRequest = new HtmlSanitizer().Sanitize(value);
        }

        [Range(0, double.MaxValue, ErrorMessage = "Invalid price")]
        public decimal Price { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Invalid max quotation")]
        public decimal MaxQuotation { get; set; }


        public string TenderDocTitle { get; set; }

        public IFormFile TenderDetailDoc { get; set; }
        public IFormFile TenderTermsAndConditionDoc { get; set; }

    }


    public class AddTenderRequestDto : TenderRequestBaseDto
    {
        [Required(ErrorMessage = "At least one tender material is required")]
        public ICollection<TenderMaterialRequestDto> TenderMaterials { get; set; }

        public ICollection<TenderExtraDocDto> ExtraDocuments { get; set; }

        public int Algorithm { get; set; }

        public int ProcurementId { get; set; }

    }

    public class UpdateTenderRequestDto : TenderRequestBaseDto
    {
        [Required(ErrorMessage = "Tender id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid tender id")]
        public long TenderId { get; set; }

        [Required(ErrorMessage = "At least one tender material is required")]
        public ICollection<UpdateMaterialRequestDto> TenderMaterials { get; set; }

        public List<UpdateTenderExtraDocRequestDto> ExtraDocuments { get; set; }
    }
    public class TenderMaterialRequestDto
    {
        [Required(ErrorMessage = "Tender material name is required")]
        [MaxLength(500, ErrorMessage = "Tender material name can be {1} character long")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Tender material quantity is required")]
        [Range(1,int.MaxValue, ErrorMessage = "Tender material quantity is invalid")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Tender material Units is required")]
        [MaxLength(500, ErrorMessage = "Tender material Units can be {1} character long")]
        public string Units { get; set; }
        public string MaterialGroup { get; set; }
        public bool IsDeleted { get; set; }

    }

    public class TenderExtraDocDto
    {
        [Required(ErrorMessage = "Document Title is required")]
        public string DocTitle { get; set; }
        public bool IsDeleted { get; set; }

        [Required(ErrorMessage = "Document is required")]
        [AllowExtensions(ErrorMessage = "Invalid file extension. Supported extensions .png,.jpg,.jpeg,.pdf,.doc,.docx")]
        public IFormFile Document { get; set; }
    }

    

    public class UpdateMaterialRequestDto: TenderMaterialRequestDto
    {
        public long Id { get; set; }
    }

    public class UpdateTenderExtraDocRequestDto: TenderExtraDocDto
    {
        [Required(ErrorMessage = "Document id is required")]
        [Range(0, long.MaxValue, ErrorMessage = "Invalid document id")]
        public long Id { get; set; }
    }
}
