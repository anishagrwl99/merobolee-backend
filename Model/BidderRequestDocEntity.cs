using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_bidder_request_doc")]
    public class BidderRequestDocEntity
    {
        private int doc_id;
        private int request_id;
        private BidderRequestEntity bidderRequest;
        private string doc_location;

        [JsonIgnore]
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Doc_id { get => doc_id; set => doc_id = value; }

        [Column("bidder_request_doc")]
        public string Document{ get => doc_location; set => doc_location = value; }

        [Column("request_id")]
        [ForeignKey("BidderRequest")]
        public int Request_id { get => request_id; set => request_id = value; }

        [JsonIgnore]
        public BidderRequestEntity BidderRequest { get => bidderRequest; set => bidderRequest = value; }
    }
}
