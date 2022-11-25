using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSCalendar.Models
{
    public class TaskReminder
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } 
        public TimeSpan Time { get; set; }
        public string TaskLocation { get; set; }

        public DateTime MinDate { get; set; } = DateTime.Now;
    }
}
