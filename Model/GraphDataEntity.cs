using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeroBolee.Model
{
    [Table("mb_tender_graphdata")]
    public class GraphDataEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long Procurement_of_Goods { get; set; }  
        public long Procurement_of_Works { get; set; }  
        public long Procurement_of_Consultancy_Service { get; set; }
        public DateTime Date_Created { get; set; }
        public DateTime Date_Modified { get; set; }
        public long TotalBudget { get; set; }
    }
}
