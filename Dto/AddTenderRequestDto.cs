using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class AddTenderRequestDto
    {
        [Required(ErrorMessage = "Company name is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid company name")]
        public long CompanyId { get; set; }


        [Required(ErrorMessage = "Category name is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid category name")]
        public int CategoryId { get; set; }


        [Required(ErrorMessage = "Tender title is required")]
        [MaxLength(500, ErrorMessage = "Tender title can be {1} character long")]
        public string TenderTitle { get; set; }

        [Required(ErrorMessage = "Date till supplier registration allowed is required")]
        public DateTime RegistrationTill { get; set; }

        [Required(ErrorMessage = "Tender live start date is required")]
        public DateTime LiveStartDate { get; set; }

        [Required(ErrorMessage = "Tender live end date is required")]
        public DateTime LiveEndDate { get; set; }
      
        [Required(ErrorMessage = "Tender created by is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid user")]
        public long CreatedBy { get; set; }


        public string Location { get; set; }
        public string QualityRequest { get; set; }
        public string PerformanceRequest { get; set; }
        public string EligibilityCriteria { get; set; }
        public string AdditionalRequest { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Invalid price")]
        public decimal Price { get; set; }

        public string TenderDocTitle { get; set; }
        public string TenderDetailDoc { get; set; }

        public string TermsAndCondition { get; set; }
        public ICollection<TenderMaterialRequestDto> TenderMaterials { get; set; }
        public ICollection<TenderCardRequestDto> TenderCards { get; set; }
    }


    public class TenderMaterialRequestDto
    {
        [Required(ErrorMessage = "Tender material name is required")]
        [MaxLength(500, ErrorMessage = "Tender material name can be {1} character long")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Tender material quantity is required")]
        [Range(1,int.MaxValue, ErrorMessage = "Tender material quantity is invalid")]
        public int Quantity { get; set; }

    }

    public class TenderCardRequestDto
    {
        [Required(ErrorMessage = "Tender card label is required")]
        [MaxLength(200, ErrorMessage = "Tender card label can be {1} character long")]
        public string Label { get; set; }

        [Required(ErrorMessage = "Tender card value is required")]
        [MaxLength(500, ErrorMessage = "Tender card value can be {1} character long")]
        public string Value { get; set; }
    }


    public class UpdateTenderRequestDto: AddTenderRequestDto
    {
        public long TenderId { get; set; }
        public new ICollection<UpdateMaterialRequestDto> TenderMaterials { get; set; }
        public new ICollection<UpdateTenderCardRequestDto> TenderCards { get; set; }

    }

    public class UpdateMaterialRequestDto: TenderMaterialRequestDto
    {
        public long Id { get; set; }
    }

    public class UpdateTenderCardRequestDto : TenderCardRequestDto
    {
        public int Id { get; set; }
    }
}
