using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_bidder_requesst_doc")]
    public class BidderRequestDocEntity
    {
        private int doc_id;
        private string doc_location;

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Doc_id { get => doc_id; set => doc_id = value; }

        [Column("bidder_request_doc")]
        public string Doc_location { get => doc_location; set => doc_location = value; }
    }
}
