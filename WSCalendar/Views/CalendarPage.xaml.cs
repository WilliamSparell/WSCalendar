
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

	private DateTime _tempDate;

	public ObservableCollection<CalendarModel> Dates = new();
	public CalendarPage()
	{
		InitializeComponent();
		BindDates(DateTime.Now);
	}

	private void BindDates(DateTime date)
	{
		Dates.Clear();

		int daysCount = DateTime.DaysInMonth(date.Year, date.Month);

		for (int days = 1; days < daysCount; days++)
		{
			Dates.Add(new CalendarModel
			{
				Date = new DateTime(date.Year, date.Month, date.Day)
			});
		}

		var selectedDate = Dates.Where(f => f.Date.Date == SelectedDate.Date).FirstOrDefault();
		if (selectedDate != null)
		{
			selectedDate.IsCurrentDate = true;
			_tempDate = selectedDate.Date;
		}
	}

	public ICommand CurrentDateCommand => new Command<CalendarModel>((currentDate) =>
	{
		_tempDate = currentDate.Date;
		SelectedDate = currentDate.Date;
		Dates.ToList().ForEach(f => f.IsCurrentDate = false);
		currentDate.IsCurrentDate = true;
	});

	public ICommand NextMonthCommand => new Command(() =>
	{
		_tempDate = _tempDate.AddMonths(1);
		BindDates(_tempDate);
	});

    public ICommand PreviousMonthCommand => new Command(() =>
    {
        _tempDate = _tempDate.AddMonths(-1);
        BindDates(_tempDate);
    });
}