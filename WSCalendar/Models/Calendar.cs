using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCalendar.Core.Interfaces;

namespace WSCalendar.Models
{
    public class Calendar
    {
        public IList<DayOfWeek> DayName { get; set; }
        public DateTime NavigatedDate { get; set; }
        public IEnumerable<ICalendarDay> Days { get; set; }
        public DateTime TodayDate { get; set; }
    }
}
