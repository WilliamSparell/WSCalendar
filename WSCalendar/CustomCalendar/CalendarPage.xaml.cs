
using System.Collections.ObjectModel;
using System.Windows.Input;
using WSCalendar.Models;

namespace WSCalendar.CustomCalendar;

public partial class CalendarPage : StackLayout
{
	public static readonly BindableProperty SelectedDateProperty = BindableProperty.Create(
		nameof(SelectedDate),
		typeof(DateTime),
		declaringType: typeof(CalendarPage),
		defaultBindingMode: BindingMode.TwoWay,
		defaultValue: DateTime.Now,
		propertyChanged: SelectedItemChanged
		);

	private static void SelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
	{
		var controls = (CalendarPage)bindable;
		if (newValue != null)
		{
			var newDate = (DateTime)newValue;

			if (controls._tempDate.Month == newDate.Month && controls._tempDate.Year == newDate.Year)
			{
				var currentDate = controls.Dates.Where(f => f.Date == newDate.Date).FirstOrDefault();
				if (currentDate != null)
				{
					controls.Dates.ToList().ForEach(f => f.IsCurrentDate = false);
					currentDate.IsCurrentDate = true;
				}
			}
			else
			{
                controls.BindDates(newDate);
            }
		}
	}

	public DateTime SelectedDate
	{
		get => (DateTime)GetValue(SelectedDateProperty);
		set => SetValue(SelectedDateProperty, value);
	}

    public static readonly BindableProperty SelectedDateCommandProperty = BindableProperty.Create(
        nameof(SelectedDateCommand),
        typeof(ICommand),
        declaringType: typeof(CalendarPage)
        );

    public ICommand SelectedDateCommand
    {
        get => (ICommand)GetValue(SelectedDateCommandProperty);
        set => SetValue(SelectedDateCommandProperty, value);
    }

	public event EventHandler<DateTime> OnDateSelected;
    private DateTime _tempDate;

	public ObservableCollection<CalendarModel> Dates { get; set; } = new();
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
				Date = new DateTime(date.Year, date.Month, days)
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
		OnDateSelected?.Invoke(null, currentDate.Date);
		SelectedDateCommand?.Execute(currentDate.Date);

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