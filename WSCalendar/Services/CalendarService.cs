using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSCalendar.Models;

namespace WSCalendar.Services
{
    public class CalendarService : ICalendarService
    {
        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Calendar.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<TaskReminder>();
            }
        }

        public async Task<int> AddTask(TaskReminder taskReminder)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(taskReminder);
        }

        public async Task<int> DeleteTask(TaskReminder taskReminder)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(taskReminder);
        }

        public async Task<List<TaskReminder>> GetTaskList()
        {
            await SetUpDb();
            var studentList = await _dbConnection.Table<TaskReminder>().ToListAsync();
            return studentList;
        }

        public async Task<int> UpdateTask(TaskReminder taskReminder)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(taskReminder);
        }
    }
}
