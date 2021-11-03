using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
 
    [Table(name: "mb_tender_winner")]
    public class TenderWinnerEntity : BaseEntity
    {
        public long Id { get; set; }

        [ForeignKey("Tender")]
        public long TenderId { get; set; }


        [ForeignKey("WinCompany")]
        public long WinnerCompanyId { get; set; }


        public virtual TenderEntity Tender { get; set; }
        public virtual CompanyEntity WinCompany { get; set; }
    }
}
