
using System.Collections.ObjectModel;
using System.Windows.Input;
using WSCalendar.Models;

namespace WSCalendar.Views;

public partial class CalendarPage : ContentView
{
	public static readonly BindableProperty SelectedDateProperty = BindableProperty.Create(
		nameof(SelectedDate),
		typeof(DateTime),
		declaringType: typeof(CalendarPage),
		defaultBindingMode: BindingMode.TwoWay,
		defaultValue: DateTime.Now
		);

	public DateTime SelectedDate
	{
		get => (DateTime)GetValue(SelectedDateProperty);
		set => SetValue(SelectedDateProperty, value);
	}

	public ObservableCollection<CalendarModel> Dates = new();
	public CalendarPage()
	{
		InitializeComponent();
		BindDates(DateTime.Now);
	}

	private void BindDates(DateTime selectedDate)
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

	public ICommand CurrentDateCommand => new Command<CalendarModel>((currentDate) =>
	{
		SelectedDate = currentDate.Date;
	});
}