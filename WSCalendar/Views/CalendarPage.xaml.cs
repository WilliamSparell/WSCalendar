
using System.Collections.ObjectModel;
using WSCalendar.Models;

namespace WSCalendar.Views;

public partial class CalendarPage : StackLayout
{
	public ObservableCollection<CalendarModel> Dates = new();
	public CalendarPage()
	{
		InitializeComponent();
		BindDates(DateTime.Now);
	}

	private void BindDates (DateTime selectedDate)
	{
		int daysCount = DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month);
		for (int days = 1; days < daysCount; days++)
		{
			Dates.Add(new CalendarModel
			{
				Date = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day)
			});
		}
	}
}