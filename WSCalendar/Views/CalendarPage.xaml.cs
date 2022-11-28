namespace WSCalendar.Views;

public partial class CalendarPage : ContentPage
{
	public CalendarPage(CalendarPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}