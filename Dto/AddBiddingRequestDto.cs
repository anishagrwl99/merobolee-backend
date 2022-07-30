using MeroBolee.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{

    public class TenderRegistrationDto
    {
        [Required(ErrorMessage = "User id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid user id")]
        public long UserId { get; set; }

        [Required(ErrorMessage = "company id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid company id")]
        public long CompanyId { get; set; }

        [Required(ErrorMessage = "Tender id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid tender id")]
        public long TenderId { get; set; }


    }

    public class SubmitDocumentForRegisteredTender : TenderRegistrationDto
    {
        public List<TenderSubmissionAdditionalDocDto> Documents { get; set; }
    }
    public class RegisterForTenderDto : TenderRegistrationDto
    {


        [Required(ErrorMessage = "Payment reference code is required")]
        public string PaymentReferenceCode { get; set; }

        [Required(ErrorMessage = "Payment provider is required")]
        [MaxLength(50, ErrorMessage = "Payment provider name can be {1} character long")]
        public string PaymentProvider { get; set; }

        [Required(ErrorMessage = "Payment amount is required")]
        [Range(1, (double)int.MaxValue, ErrorMessage = "Invalid payment amount")]
        public decimal PaymentAmount { get; set; }

        public DateTime RegistrationTime { get; set; }


    }


    public class UpdateRegistrationForTenderDto : TenderRegistrationDto
    {
        [Required(ErrorMessage = "Bid id is required")]
        [Range(1, (double)int.MaxValue, ErrorMessage = "Invalid Bid id")]
        public long BidId { get; set; }
        public List<TenderSubmissionAdditionalDocumentResponseDto> Documents { get; set; }
    }

    /// <summary>
    /// Bidding request dto
    /// </summary>
    public class AddBiddingRequestDto
    {
        [Required(ErrorMessage = "User id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid user id")]
        public long UserId { get; set; }



        [Required(ErrorMessage = "Company id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid company id")]
        public long CompanyId { get; set; }


        [Required(ErrorMessage = "Tender id is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid tender id")]
        public long TenderId { get; set; }


        [Required(ErrorMessage = "Bidding time is required")]
        public DateTime BiddingTime { get; set; }
    }

    /// <summary>
    /// Tender material bidding dto
    /// </summary>
    public class TenderMaterialBiddingDto
    {
        [Required(ErrorMessage = "Bidding number is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid bidding number")]
        public long BiddingId { get; set; }

        [Required(ErrorMessage = "Tender number is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid tendeer number")]
        public long TenderId { get; set; }


        [Required(ErrorMessage = "User number is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid user number")]
        public long SupplierId { get; set; }

        [Required(ErrorMessage = "Company number is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid company number")]
        public long CompanyId { get; set; }


        public List<TenderMaterialQuotationDto> MaterialQuotation { get; set; }
        public DateTime BiddingDate { get; set; }

        public decimal totalAmount { get; set;}
    }

    public class TenderAutoBidDto : TenderMaterialBiddingDto
    {
        [Required(ErrorMessage = "Percentage to deduct is required")]
        [Range(0, 100.00, ErrorMessage = "Invalid percentage for calculation")]
        public decimal Percentage { get; set; }
    }

    public class TenderMaterialQuotationDto
    {

        [Required(ErrorMessage = "Tender material number is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid tender matrial number")]
        public long MaterialId { get; set; }


        [Required(ErrorMessage = "Quotation amount is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid quotation amount")]
        public decimal Quotation { get; set; }

        public string Unit { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        /// <summary>
        /// True if material quotation is available in memory cache. No need to pass value from caller as it is maintained within application
        /// </summary>
        [JsonIgnore]
        public bool IsPrevCacheAvailable { get; set; }

        /// <summary>
        /// Will contain quotation amount when current quotation amount is invalid due to some other material quotation is invalid
        /// </summary>
        [JsonIgnore]
        public decimal PreviousQuotation { get; set; }
    }

    public class LiveBidResponse
    {
        public bool IsBidSuccess { get; set; }
        public string Position { get; set; }
        public List<TenderMaterialQuotationDto> MaterialQuotation { get; set; }
        public string Message { get; set; }
        public bool IsLowestBidReceived { get; set; }
        public DateTime LowestBidRecievedTime { get; set; }
        public decimal CurrentQuotation { get; set; }

        public AuctionLog Log { get; set; }
    }

}
