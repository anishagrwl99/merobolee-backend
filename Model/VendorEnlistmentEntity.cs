using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MeroBolee.Model
{
    [Table("mb_vendor_enlistment")]

    public class VendorEnlistmentEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Email2 { get; set; }
        public string Website { get; set; }
        public string Director_Name { get; set; }
        public string Other_Contact { get; set; }
        public string Other_Branches_Location { get; set; }
        public int Year_Of_Establishment { get; set; }
        public int Number_Of_Full_Time_Employees { get; set; }
        public string Procurement_Detatil { get; set; }
        public string Export_Countries { get; set; }
        public string Countries_With_Registered_Office { get; set; }
        public string Countries_With_Agent { get; set; }
        public string Nature_Of_Business { get; set; }
        public string Vendor_Experience { get; set; }
        public long Contracts_Currently_Underway { get; set; }
        public bool IsEnable { get; set; }
        public DateTime Date_Created { get; set; }
        public DateTime Date_Modified { get; set; }

        [ForeignKey("Company")]
        public long CompanyId { get; set; }
        public bool HasSuppliedBefore { get; set; }
        public bool HasCSRPolicies { get; set; }
        public bool HasCodeOfConduct { get; set; }
        public bool HasInternationalQualityAssurance { get; set; }
        public bool HasLocalOrNationalQualityAssurance { get; set; }
        public bool CopyOfLastFinancialStatement { get; set; }
        public bool CopyOfLatestAuditedAccount { get; set; }
        public bool CompanyRating { get; set; }
        public bool SixMonthsCurrentBankStatement { get; set; }

        public virtual List<VendorEnlistmentReferencesEntity> VendorEnlistmentReference { get; set; }
        public virtual List<VendorEnlistmentAnnualIncomeEntity> VendorEnlistmentAnnualIncomes { get; set; }
        public virtual List<VendorEnlistmentBankInfoEntity> VendorEnlistmentBankInfos { get; set; }
        public virtual List<BidderProcurementCategoryEntity> BidderProcurementCategories { get; set; }
        public virtual List<VendorEnlistmentDocumentEntity> VendorEnlistmentDocuments { get; set; }

        public virtual CompanyEntity Company { get; set; }
    }
}
