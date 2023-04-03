using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeroBolee.Dto
{
    public class VendorEnlistmentAddDto
    {
        public long CompanyId { get; set; }
        public string Email2 { get; set; }
        public string Website { get; set; }
        [Required(ErrorMessage = "Director Name is required")]
        public string DirectorName { get; set; }
        public string OtherContact { get; set; }
        public string OtherBranchesLocation { get; set; }

        [Required(ErrorMessage = "Year of Establishment is required")]
        public int YearOfEstablishment { get; set; }
        [Required(ErrorMessage = "Number of Full time employee is required")]
        public int NumberOfFullTimeEmployees { get; set; }

        [Required(ErrorMessage = "Procurement Detatil is required")]
        public string ProcurementDetatil { get; set; }
        public string ExportCountries { get; set; }

        [Required(ErrorMessage = "Countries With Registered Office is required")]
        public string CountriesWithRegisteredOffice { get; set; }
        public string CountriesWithAgent { get; set; }

        [Required(ErrorMessage = "Nature of Business is required")]
        public List<string> NatureOfBusiness { get; set; }

        public string VendorExperience { get; set; }
        public long ContractsCurrentlyUnderway { get; set; }
        public bool HasSuppliedBefore { get; set; }
        public bool HasCSRPolicies { get; set; }
        public bool HasCodeOfConduct { get; set; }
        public bool HasInternationalQualityAssurance { get; set; }
        public bool HasLocalOrNationalQualityAssurance { get; set; }
        public bool CopyOfLastFinancialStatement { get; set; }
        public bool CopyOfLatestAuditedAccount { get; set; }
        public bool CompanyRating { get; set; }
        public bool SixMonthsCurrentBankStatement { get; set; }
        public List<VendorEnlistmentReferencesDto> VendorEnlistmentReferencesDtos { get; set; }
        public List<VendorEnlistmentAnnualIncomeDto> VendorEnlistmentAnnualIncomeDtos { get; set; }
        public List<VendorEnlistmentBankInfoDto> VendorEnlistmentBankInfoDtos { get; set; }

        public string BidderProcurementCategoryIds { get; set; }

        public IEnumerable<VendorEnlistmentDocumentDto> VendorEnlistmentDocumentDtos { get; set; }
    }
}
