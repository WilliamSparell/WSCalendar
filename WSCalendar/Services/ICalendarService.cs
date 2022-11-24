using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSCalendar.Models;

namespace WSCalendar.Services
{
    public interface ICalendarService
    {
        Task<List<TaskReminder>> GetTaskList();
        Task<int> AddTask(TaskReminder taskReminder);
        Task<int> DeleteTask(TaskReminder taskReminder);
        Task<int> UpdateTask(TaskReminder taskReminder);
    }
}
