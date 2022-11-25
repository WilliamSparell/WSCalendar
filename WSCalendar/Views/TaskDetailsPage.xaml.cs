namespace WSCalendar.Views;

public partial class TaskDetailsPage : ContentPage
{
    public TaskDetailsPage(TaskDetailsPageViewModel taskDetails)
	{
		InitializeComponent();

		this.BindingContext = taskDetails;
	}
}