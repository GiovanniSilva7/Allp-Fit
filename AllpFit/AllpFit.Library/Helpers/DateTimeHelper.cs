using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllpFit.Library.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime Brazil(this DateTime utcNow) =>  TimeZoneInfo.ConvertTimeFromUtc(utcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        public static DateTime DateTimeFromBrazil(DateTime? dateTime) => dateTime.HasValue ? TimeZoneInfo.ConvertTimeFromUtc(dateTime.Value, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time")) : DateTime.MinValue;
        
    }
}
