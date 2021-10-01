using MeroBolee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Dto
{
    public class GetBiddingRequestDto
    {
        private int bid_id;
        private Guid request_code;
        private int user_id;
        private string username;
        private int tender_Id;
        private BiddingRequestTender tenderEntity;
        private int admin_Status_Id;
        private AdminStatusEntity adminStatusEntity;
        private DateTime request_Send_Date;
        private string remark;
        private ICollection<BidderRequestDocEntity> bidderRequestDocs;


        public int BidId
        {
            get { return bid_id; }
            set { bid_id = value; }
        }

        public Guid Request_code { get => request_code; set => request_code = value; }
        public int User_id { get => user_id; set => user_id = value; }
        public string Username { get => username; set => username = value; }
        public int Tender_Id { get => tender_Id; set => tender_Id = value; }
        public BiddingRequestTender Tender { get => tenderEntity; set => tenderEntity = value; }
        public int Admin_Status_Id { get => admin_Status_Id; set => admin_Status_Id = value; }
        public AdminStatusEntity AdminStatus { get => adminStatusEntity; set => adminStatusEntity = value; }
        public DateTime Request_Send_Date { get => request_Send_Date; set => request_Send_Date = value; }
        public string Remark { get => remark; set => remark = value; }
        public ICollection<BidderRequestDocEntity> BidderRequestDocs { get => bidderRequestDocs; set => bidderRequestDocs = value; }
    }
}
