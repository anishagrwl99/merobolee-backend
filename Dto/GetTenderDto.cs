using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class TenderDocuments
    {
        public string TenderDetailDocTitle { get; set; }
        public string TenderDetailDocPath { get; set; }
        public string TermsAndConditionDocPath { get; set; }
    }
    public class GetTenderDto : TenderCard
    {
        public string Location { get; set; }
        public string QualityRequest { get; set; }
        public string PerformanceRequest { get; set; }
        public string EligibilityCriteria { get; set; }
        public string AdditionalRequest { get; set; }
        public decimal Price { get; set; }
        public decimal MaxQuotation { get; set; }
       
        public int TenderLiveInterval { get; set; }
        public string CancelRemarks { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<TenderExtraDocumentResponseDto> ExtraDocuments { get; set; }
        public List<TenderMaterialResponseDto> TenderMaterials { get; set; }
    }


    public class TenderCard
    {
        public long TenderId { get; set; }
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string TenderTitle { get; set; }
        public string TenderCode { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime LiveStartDate { get; set; }
        public DateTime LiveEndDate { get; set; }
        public DateTime RegistrationTill { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }

        public string Product { get; set; }
        public DateTime DateOfExecution { get; set; }
        public DateTime DateCreated { get; set; }
        
        public decimal Price { get; set;}

        public string Location { get; set;}

        public string Size { get; set; }

        //public List<TenderCardInfo> CardInfo { get; set; }

    }

    //public class TenderCardInfo
    //{
    //    public long Id { get; set; }
    //    public string Label { get; set; }
    //    public string Value { get; set; }
    //}


    public class TenderExtraDocumentResponseDto
    {
        public long Id { get; set; }
        public string DocTitle { get; set; }
        public string DocPath { get; set; }
    }

    public class TenderMaterialResponseDto
    {
        public long Id { get; set; }
        public string MaterialName { get; set; }
        public int Quantity { get; set; }
        public string Units { get; set; }
    }

    public class TenderWatchListCard: TenderCard
    {
        public long WatchListId { get; set; }
    }

    public class BidInviterTenderListing
    {
        public List<TenderCard> PendingTenders { get; set; }
        public List<TenderCard> ActiveTenders { get; set; }
    }
}
