namespace WSCalendar.Services
{
    public interface ICalendarService
    {
        Task<List<TaskReminder>> GetTaskList();
        Task<int> AddTask(TaskReminder taskReminder);
        Task<int> DeleteTask(TaskReminder taskReminder);
        Task<int> UpdateTask(TaskReminder taskReminder);

        Task<List<Calendar>> GetCalendarList();
        Task<int> AddTask(Calendar calendar);
        Task<int> DeleteTask(Calendar calendar);
        Task<int> UpdateTask(Calendar calendar);

    }
}
