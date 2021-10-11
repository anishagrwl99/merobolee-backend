using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{

    [Table("mb_user_company")]
    public class UserCompany
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long CompanyId { get; set; }


        public virtual CompanyEntity Company { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
