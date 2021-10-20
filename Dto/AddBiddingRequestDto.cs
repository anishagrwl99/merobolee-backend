using MeroBolee.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
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

        public long User_id { get => user_id; set => user_id = value; }


       

        public long Company_Id
        {
            get { return company_id; }
            set { company_id = value; }
        }


        //public UserEntity UserEntity { get => userEntity; set => userEntity = value; }
        public long Tender_Id { get => tender_Id; set => tender_Id = value; }
        //public TenderEntity TenderEntity { get => tenderEntity; set => tenderEntity = value; }
        public int Admin_Status_Id { get => admin_Status_Id; set => admin_Status_Id = value; }
        //public AdminStatusEntity AdminStatusEntity { get => adminStatusEntity; set => adminStatusEntity = value; }
        //public DateTime Request_Send_Date { get => request_Send_Date; set => request_Send_Date = value; }
        //public string Remark { get => remark; set => remark = value; }
        public ICollection<IFormFile> BidderRequestDocs { get => bidderRequestDocs; set => bidderRequestDocs = value; }
        public DateTime BiddingTime { get; set; }
    }

    public class TenderMaterialBiddingDto
    {
        public long BiddingId { get; set; }
        public long TenderId { get; set; }
        public long SupplierId { get; set; }
        public long MaterialId { get; set; }
        public decimal Quotation { get; set; }
        public DateTime BiddingDate { get; set; }
    }

    public class LiveBidResponse
    {
        public bool IsBidSuccess { get; set; }
        public string Position { get; set; }
        public long MaterialId { get; set; }
        public string Message { get; set; }
        public decimal Quotation { get; set; }
        public bool IsLowestBidReceived { get; set; }
        public DateTime LowestBidRecievedTime { get; set; }
    }

}
