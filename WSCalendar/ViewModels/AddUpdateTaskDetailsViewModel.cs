namespace WSCalendar.ViewModels
{
    [QueryProperty(nameof(TaskDetail), "TaskDetail")]
    public partial class AddUpdateTaskDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        private TaskReminder _taskDetail = new();

        private readonly ICalendarService _calendarService;
        public AddUpdateTaskDetailsViewModel(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        [RelayCommand]
        public async void AddUpdateTask()
        {
            int response;
            if (TaskDetail.Id > 0)
            {
                response = await _calendarService.UpdateTask(TaskDetail);
            }
            else
            {
                response = await _calendarService.AddTask(new Models.TaskReminder
                {
                    Title = TaskDetail.Title,
                    Description = TaskDetail.Description,
                    TaskLocation = TaskDetail.TaskLocation,
                    Date = TaskDetail.Date,
                    Time = TaskDetail.Time
                });
            }

            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Task Added", "Record Added to Task List", "Ok");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error!", "Something went wrong while Adding to task tist", "Ok");
            }

        }
    }
}
