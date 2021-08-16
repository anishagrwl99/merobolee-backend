using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Model
{
    public class BaseEntity
    {
        private DateTime? date_created;
        [Column("date_created", TypeName = "date")]
        public DateTime Date_created
        {
            get => date_created ?? DateTime.Now;
            set => date_created = value;
        }

        //private TimeSpan created_time_stamp = DateTime.Now.TimeOfDay;
        //[Column("created_timestamp")]
        //public TimeSpan Created_time_stamp
        //{
        //    get => created_time_stamp;
        //    set => created_time_stamp = value;
        //}

        private DateTime? date_modified;
        [Column("date_modified", TypeName = "date")]
        public DateTime Date_modified
        {
            get => date_modified ?? DateTime.Now;
            set => date_modified = value;
        }

        //private TimeSpan modified_time_stamp = DateTime.Now.TimeOfDay;
        //[Column("modified_timestamp")]
        //public TimeSpan Modified_time_stamp
        //{
        //    get => modified_time_stamp;
        //    set => modified_time_stamp = value;
        //}

    }
}
