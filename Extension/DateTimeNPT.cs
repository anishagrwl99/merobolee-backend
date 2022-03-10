using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee
{
    public static class DateTimeNPT
    {
        public static DateTime Now
        {
            get { return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Nepal Standard Time")); }
        } 
    }
}
