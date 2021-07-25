using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_auction")]
    public class AuctionEntity : BaseEntity
    {
        private int auction_Id;
        private string auction_Code;
        private string auction_Title;
        private string auction_Desc;
        private int category_Id;
        private DateTime live_Auction_Date;
        private TimeSpan live_Auction_Start_Time;
        private TimeSpan live_Auction_End_Time;
        private string auction_Term;
        private int auction_Status_Id;
        private int admin_Status_Id;
        private int created_By;
        private bool is_feature;
        private AuctionStatusEntity auctionStatus;
        private AdminStatusEntity adminStatus;
        private UserEntity user;

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("auction_id")]
        public int Auction_Id { get => auction_Id; set => auction_Id = value; }

        [Column("auction_code")]
        public string Auction_Code { get => auction_Code; set => auction_Code = value; }

        [Column("auction_title")]
        public string Auction_Title { get => auction_Title; set => auction_Title = value; }
        [Column("Description")]
        public string Auction_Desc { get => auction_Desc; set => auction_Desc = value; }
        public int Category_Id { get => category_Id; set => category_Id = value; }
        public DateTime Live_Auction_Date { get => live_Auction_Date; set => live_Auction_Date = value; }
        public TimeSpan Live_Auction_Start_Time { get => live_Auction_Start_Time; set => live_Auction_Start_Time = value; }
        public TimeSpan Live_Auction_End_Time { get => live_Auction_End_Time; set => live_Auction_End_Time = value; }
        public string Auction_Term { get => auction_Term; set => auction_Term = value; }
        public int Auction_Status_Id { get => auction_Status_Id; set => auction_Status_Id = value; }
        public int Admin_Status_Id { get => admin_Status_Id; set => admin_Status_Id = value; }
        public int Created_By { get => created_By; set => created_By = value; }
        public bool Is_feature { get => is_feature; set => is_feature = value; }
        public AuctionStatusEntity AuctionStatus { get => auctionStatus; set => auctionStatus = value; }
        public AdminStatusEntity AdminStatus { get => adminStatus; set => adminStatus = value; }
        public UserEntity User { get => user; set => user = value; }
    }
}
