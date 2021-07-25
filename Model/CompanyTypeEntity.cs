using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("mb_company_type")]
    public class CompanyTypeEntity: BaseEntity
    {
        private int company_Type_Id;
        private string company_type;
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("company_type_id")]
        public int Company_Type_Id { get => company_Type_Id; set => company_Type_Id = value; }
        [Column("company_type")]
        public string Company_type { get => company_type; set => company_type = value; }
    }
}
