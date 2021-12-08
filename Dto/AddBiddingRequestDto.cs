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
    /// <summary>
    /// Bidding request dto
    /// </summary>
    public class AddBiddingRequestDto
    {

     
        private long userid;
        private long companyid;
        private long tenderId;
        //private TenderEntity tenderEntity;
        //private AdminStatusEntity adminStatusEntity;
        //private DateTime request_Send_Date;
        //private string remark;
        private ICollection<IFormFile> bidderRequestDocs;

        /// <summary>
        /// User Id
        /// </summary>
        public long UserId { get => userid; set => userid = value; }


       
        /// <summary>
        /// Company id
        /// </summary>
        public long CompanyId
        {
            get { return companyid; }
            set { companyid = value; }
        }


        /// <summary>
        /// Tender Id
        /// </summary>
        public long TenderId { get => tenderId; set => tenderId = value; }



        /// <summary>
        /// Bidder request docs
        /// </summary>
        public ICollection<IFormFile> BidderRequestDocs { get => bidderRequestDocs; set => bidderRequestDocs = value; }
        
        
        /// <summary>
        /// Bidding time
        /// </summary>
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
    }

    public class TenderMaterialQuotationDto
    {

        [Required(ErrorMessage = "Tender material number is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid tender matrial number")]
        public long MaterialId { get; set; }


        [Required(ErrorMessage = "Quotation amount is required")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid quotation amount")]
        public decimal Quotation { get; set; }



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

        public AuctionLog Log { get; set; }
    }

}
