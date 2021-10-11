using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    [Table("lk_company_type")]
    public class CompanyTypeLookupEntity: BaseEntity
    {
        private int company_Type_Id;
        private string company_type;
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("company_type_id")]
        public int Company_Type_Id { get => company_Type_Id; set => company_Type_Id = value; }
        [Column("company_type")]
        public string Company_type { get => company_type; set => company_type = value; }
    }


    [Table("mb_company_type")]
    public class CompanyTypeEntity: BaseEntity
    {
        public long Id { get; set; }

        [ForeignKey("Company")]
        public long CompanyId { get; set; }

        [ForeignKey("CompanyTypeLookup")]
        public int CompanyTypeId { get; set; }

        public virtual CompanyEntity Company { get; set; }
        public virtual CompanyTypeLookupEntity CompanyTypeLookup { get; set; }
    }

}
