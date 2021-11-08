using MeroBolee.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
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

     
        private long user_id;
        private long company_id;
        private long tender_Id;
        //private TenderEntity tenderEntity;
        private int admin_Status_Id;
        //private AdminStatusEntity adminStatusEntity;
        //private DateTime request_Send_Date;
        //private string remark;
        private ICollection<IFormFile> bidderRequestDocs;

        /// <summary>
        /// User Id
        /// </summary>
        public long User_id { get => user_id; set => user_id = value; }


       
        /// <summary>
        /// Company id
        /// </summary>
        public long Company_Id
        {
            get { return company_id; }
            set { company_id = value; }
        }


        /// <summary>
        /// Tender Id
        /// </summary>
        public long Tender_Id { get => tender_Id; set => tender_Id = value; }

        /// <summary>
        /// Admin status id
        /// </summary>
        public int Admin_Status_Id { get => admin_Status_Id; set => admin_Status_Id = value; }
        


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
        /// <summary>
        /// Bidding id
        /// </summary>
        public long BiddingId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long TenderId { get; set; }
        public long SupplierId { get; set; }
        public List<TenderMaterialQuotationDto> MaterialQuotation { get; set; }
        public DateTime BiddingDate { get; set; }
    }

    public class TenderMaterialQuotationDto
    {
        public long MaterialId { get; set; }
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

        
    }

}
