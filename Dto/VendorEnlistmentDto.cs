using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeroBolee.Dto
{
    public class VendorEnlistmentDto
    {
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

        public List<long> BidderProcurementCategoryIds { get; set; }

        public IEnumerable<VendorEnlistmentDocumentDto> VendorEnlistmentDocumentDtos { get; set; }

        public bool IsEnable { get; set; }
    }

    public class VendorEnlistmentReferencesDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string TypeOfContract { get; set; }
        public string Value { get; set; }
        public int Year { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public class VendorEnlistmentAnnualIncomeDto
    {
        public long Id { get; set; }
        public string FiscalYear { get; set; }
        public long IncomeSales { get; set; }
        public long ExportSales { get; set; }
    }

    public class VendorEnlistmentBankInfoDto
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Bank Name is required")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "Account Number is required")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Account Name is required")]
        public string AccountName { get; set; }

        public string SwiftCode { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        public string StreetName { get; set; }

        public int StreetNumber { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        public string PhoneNumber { get; set; }
    }

    public class VendorEnlistmentDocumentDto
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Document type id is required")]
        [Range(1, byte.MaxValue, ErrorMessage = "Invalid document type id")]
        public int DocumentTypeId { get; set; }


        [Required(ErrorMessage = "Document is required")]
        public IFormFile Document { get; set; }

        public string DocumentPath { get; set; }

        public string Name { get; set; }
    }

    public class VendorEnlistmentDetail: VendorEnlistmentDto
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PanNumber { get; set; }
    }
}
