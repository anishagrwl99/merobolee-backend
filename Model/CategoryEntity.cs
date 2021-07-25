using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static MeroBolee.Model.PublishStatus;

namespace MeroBolee.Model
{
    [Table("mb_category")]
    public class CategoryEntity : BaseEntity
    {
        private int category_Id;
        private string category;
        private int status_Id;
        private PublishStatus status;

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("category_id")]
        public int Category_Id { get => category_Id; set => category_Id = value; }
        
        [Column("category")]
        public string Category { get => category; set => category = value; }

        [ForeignKey("Status")]
        [Column("status_id")]
        public int Status_Id { get => status_Id; set => status_Id = value; }

        public PublishStatus Status { get=>status; set=>status=value; }
      
        //[Column("status")]
        //public int status_Id { get => (int) this.status; set => this.status = (PublishStatus)value; }
    }
}
