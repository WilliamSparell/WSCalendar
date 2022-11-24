namespace WSCalendar;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AddUpdateTaskDetails), typeof(AddUpdateTaskDetails));
	}
}
