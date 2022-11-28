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
