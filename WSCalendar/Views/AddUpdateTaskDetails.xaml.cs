namespace WSCalendar.Views;

public partial class AddUpdateTaskDetails : ContentPage
{
	public AddUpdateTaskDetails(AddUpdateTaskDetailsViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}