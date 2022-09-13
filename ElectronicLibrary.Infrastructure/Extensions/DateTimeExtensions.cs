using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Infrastructure.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ToUTCKind(this DateTime date) =>
            new DateTime(date.Ticks, DateTimeKind.Utc);
    }
}
