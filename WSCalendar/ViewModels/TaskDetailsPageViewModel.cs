using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSCalendar.Models;
using WSCalendar.Services;

namespace WSCalendar.ViewModels
{
    [QueryProperty(nameof(TaskDetail), "TaskDetail")]
    public partial class TaskDetailsPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private TaskReminder _taskDetail = new();

        private readonly ICalendarService _calendarService;
        public TaskDetailsPageViewModel(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }
    }
}
