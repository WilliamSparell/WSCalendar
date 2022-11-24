using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WSCalendar.Models;
using WSCalendar.Services;

namespace WSCalendar.ViewModels
{
    public partial class TaskListPageViewModel : ObservableObject
    {
        public ObservableCollection<TaskReminder> Tasks { get; set; } = new ObservableCollection<TaskReminder>();

        private readonly ICalendarService _calendarService;
        public TaskListPageViewModel(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        [RelayCommand]
        public async void GetTaskList()
        {
            var taskList = await _calendarService.GetTaskList();
            if (taskList?.Count > 0)
            {
                Tasks.Clear();
                foreach (var task in taskList)
                {
                    Tasks.Add(task);
                }
            }
        }

        [RelayCommand]
        public async void AddUpdateTask()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateTaskDetails));
        }

        [RelayCommand]
        public async void DisplayAction(TaskReminder taskReminder)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");

            if (response is "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("TaskDetail", taskReminder);

                await AppShell.Current.GoToAsync(nameof(AddUpdateTaskDetails), navParam);
            }
            else if (response is "Delete")
            {
                var delResponse = await _calendarService.DeleteTask(taskReminder);
                if (delResponse > 0)
                {
                    GetTaskList();
                }
            }
        }
    }
}
