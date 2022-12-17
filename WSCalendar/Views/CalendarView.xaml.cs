namespace WSCalendar.Views;

public partial class CalendarView : ContentPage
{
	public CalendarView()
	{
		InitializeComponent();
		cal.SelectedDate = DateTime.Now.AddDays(5);
	}

	private void cal_OnDateSelected(object sender, DateTime e)
	{

	}
}