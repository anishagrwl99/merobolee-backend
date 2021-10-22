using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    /// <summary>
    /// Base model for entity
    /// </summary>
    public class BaseEntity
    {
        private DateTime? date_created;
        private DateTime? date_modified;

        /// <summary>
        /// Date time on which record is created
        /// </summary>
        [Column("date_created", TypeName = "datetime")]
        public DateTime Date_created
        {
            get => date_created ?? DateTime.Now;
            set => date_created = value;
        }

       
        /// <summary>
        /// Date time on which record is last modified
        /// </summary>
        [Column("date_modified", TypeName = "datetime")]
        public DateTime Date_modified
        {
            get => date_modified ?? DateTime.Now;
            set => date_modified = value;
        }
    }
}
