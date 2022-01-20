using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{

    [Table("mb_user_company")]
    public class UserCompany
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required]
        public long CompanyId { get; set; }


        public  CompanyEntity Company { get; set; }
        public  UserEntity User { get; set; }
    }
}
