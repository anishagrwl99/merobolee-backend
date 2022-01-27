using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee
{
    public enum CompanyTypeEnum
    {
        [Display(Name = "Bid Inviter")]
        BidInviter = 0,

        [Display(Name = "Bidder")]
        Bidder = 1,

        [Display(Name = "Super Admin")]
        SuperAdmin = 2
    }
}
